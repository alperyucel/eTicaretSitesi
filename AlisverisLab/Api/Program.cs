using AlisverisLab.BusinessLogic.DependencyResolver;
using AlisverisLab.DataAccess.DbContext;
using AlisverisLab.Entity.POCO;
using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				//options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["JWT:Issuer"],
					ValidAudience = builder.Configuration["JWT:Audince"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))

				};
			});

			// Add services to the container.

			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
			{
				options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
				{
					Description = "JWT Token",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					 {
						 new OpenApiSecurityScheme
						 {
							Reference = new OpenApiReference
							{
							   Type=ReferenceType.SecurityScheme,
							   Id="Bearer"
							}
						 },
						 new string[]{}
					 }
				});
			});

			builder.Services.AddBussinessService();

			builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

			JwtHelper.Init(builder.Configuration);

			builder.Services.AddIdentity<AppUser, AppRole>(x =>
			{
				x.User.RequireUniqueEmail = true;
				x.Password.RequiredLength = 3;
				x.Password.RequireNonAlphanumeric = false;
				x.Password.RequireUppercase = false;
				x.Password.RequireLowercase = false;
				x.Password.RequireDigit = false;

				//E-Posta onayýný zorunlu kýlmak için ekledik
				x.SignIn.RequireConfirmedEmail = true;

			}).AddEntityFrameworkStores<AlisverisLabDbContext>().AddDefaultTokenProviders();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

			app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
