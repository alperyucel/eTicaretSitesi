using AlisverisLab.Core.Utility;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.Entity.ViewModel;
using AlisverisLab.MVC.CustomAttributes;
using AlisverisLab.MVC.Extensions;
using AlisverisLab.MVC.Models;
using AlisverisLab.MVC.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AlisverisLab.MVC.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signIn;
        IMapper mapper;
        IConfiguration configuration;
		IHttpClientFactory httpClientFactory;
        IMemoryCache memoryCache;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signIn, IMapper mapper, IConfiguration configuration, IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            this.userManager = userManager;
            this.signIn = signIn;
            this.mapper = mapper;
            this.configuration = configuration;
            this.httpClientFactory = httpClientFactory;
            this.memoryCache = memoryCache;
             
        }
        public IActionResult LoginRegister()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

            //HttpClient client = httpClientFactory.CreateClient();

            //JwtHelper jwtHelper = new JwtHelper(HttpContext, client);

            //jwtHelper.GetToken(model);


            AppUser user = userManager.FindByNameAsync(model.UserName).Result;

            if (!user.EmailConfirmed)
                return View("RegistirationConfirmation");

            var result = signIn.PasswordSignInAsync(model.UserName, model.Password, model.IsRemember, true).Result;

            if (result.Succeeded)
            {
                userManager.ResetAccessFailedCountAsync(user).Wait();
                HttpContext.Session.SetSession("user", model);
                return RedirectToAction("Index", "Home");
            }

            #region İlk Yöntem
            //int failedCount = userManager.GetAccessFailedCountAsync(user).Result;

            //if (failedCount >= 3)
            //{
            //    string token = userManager.GeneratePasswordResetTokenAsync(user).Result;

            //    var callBackUrl = Url.Action("ResetPassword", "Account", new { token = token, email = user.Email }, protocol: HttpContext.Request.Scheme);

            //    bool emailResult = new EmailService(configuration).SendEmail($"Parola Sıfırlamak için <a href='{callBackUrl}'>buraya tıklayın!</a>", "Reset Password", true, user.Email);

            //    return View("ErrorVw", "Birden fazla hatalı deneme sonucunda hesabınız kilitlenmiştir! Lütfen E-Posta adresinize gönderilen parola sıfırlama işlemini tamamlayın");
            //}
            //else
            //{
            //    var sonuc = userManager.AccessFailedAsync(user).Result;
            //} 
            #endregion

            if (result.IsLockedOut)
            {
                return View("ErrorVw", "Hesabınız hatalı giriş denemeleri sonucu kısıtlanmıştır!");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = userManager.CreateAsync(new AppUser { UserName = model.UserName, Email = model.Email }, model.Password).Result;

			if (result.Succeeded)
			{
				AppUser user = userManager.FindByNameAsync(model.UserName).Result;

                var token = userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                var callBackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token },
                    protocol: HttpContext.Request.Scheme);


                bool a = new EmailService(configuration).SendEmail($"Lütfen E-Posta Adresinizi Doğrulamak için <a href='{callBackUrl}'>buraya tıklayın!</a>", "Confirm Email", true, user.Email);

                userManager.AddToRoleAsync(user, "UserApp").Wait();
				//var signResult = signIn.PasswordSignInAsync(model.UserName, model.Password, false, false).Result;
				//if (signResult.Succeeded)
                if(a)
                    return View("RegistirationConfirmation");
                else
					return View("LoginRegister");
			}
			else
				return View(model);
		}
        public IActionResult ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = userManager.FindByIdAsync(userId).Result;
            if (user == null)
            {
                return RedirectToAction("Index", "Home");

            }


            var result = userManager.ConfirmEmailAsync(user, token).Result;

            if (result.Succeeded)
            {
                return View("ConfirmEmailSuccess");

            }

            return View("ConfirmEmailFailed");


        }

        [HttpPost]
        public IActionResult LogOut()
		{
			signIn.SignOutAsync().Wait();
			return RedirectToAction("Index", "Home");
		}

        [HttpGet]
        [ActiveUser]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                ProfileModel profile = mapper.Map<ProfileModel>(userManager.FindByNameAsync(User.Identity.Name).Result);

                ProfileModel veri = memoryCache.GetCache<ProfileModel>("Account:Profile");

                if (veri == null)
                {
                    ProfileModel data = mapper.Map<ProfileModel>(userManager.FindByNameAsync(User.Identity.Name).Result);

                    memoryCache.SetCache("Account:Profile", data, TimeSpan.FromMinutes(2));

                    return View(data);
                }
                else
                    return View(veri);
            }
            return View();           
        }

        [HttpPost]
        public IActionResult ProfileUpdate(ProfileModel model)
        {
            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            user.Email = model.Email;

            user.PhoneNumber = model.PhoneNumber;

            user.UserName = model.UserName;

            if (!(string.IsNullOrEmpty(model.CurrentPassword) && string.IsNullOrEmpty(model.Password) && string.IsNullOrEmpty(model.ConfirmPassword)))
            {
                var passwordResult = userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password).Result;
            }

            var userResult = userManager.UpdateAsync(user).Result;

            userManager.UpdateAsync(user);

            signIn.RefreshSignInAsync(user).Wait();

            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUser user = userManager.FindByEmailAsync(model.Email).Result;
            if (user == null || !userManager.IsEmailConfirmedAsync(user).Result)
            {
                return View("ForgotPasswordFailed");
            }

            string token = userManager.GeneratePasswordResetTokenAsync(user).Result;

            var callBackUrl = Url.Action("ResetPassword", "Account", new { token = token, email = user.Email }, protocol: HttpContext.Request.Scheme);

            bool result = new EmailService(configuration).SendEmail($"Parola Sıfırlamak için <a href='{callBackUrl}'>buraya tıklayın!</a>", "Reset Password", true, user.Email);

            if (result)
            {
                return View("ForgotPasswordSendEmail");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {

            return View(new ResetPasswordModel { Mail = email, Token = token });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUser user = userManager.FindByEmailAsync(model.Mail).Result;

            if (user == null)
            {
                return View("ForgotPasswordFailed");
            }

            var result = userManager.ResetPasswordAsync(user, model.Token, model.NewPassword).Result;

            if (result.Succeeded)
            {
                userManager.ResetAccessFailedCountAsync(user).Wait();
                return View("Success", "Parola Değiştirme İşlemi Başarılı");
            }

            return View(model);
        }
    }
}
