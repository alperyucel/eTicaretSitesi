using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlisverisLab.MVC.CustomAttributes
{
    public class ActiveUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectToActionResult("Index", "Home", null);

            base.OnActionExecuting(context);
        }
    }
}
