using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlisverisLab.MVC.CustomAttributes
{
	public class IsAdmin : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!(context.HttpContext.User.Identity.IsAuthenticated && context.HttpContext.User.IsInRole("Admin")))
				context.Result = new RedirectToActionResult("Index", "Home", new { area = "" });

			base.OnActionExecuting(context);
		}
	}
}
