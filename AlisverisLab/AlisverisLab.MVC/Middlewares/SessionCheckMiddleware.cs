using AlisverisLab.Entity.ViewModel;
using AlisverisLab.MVC.Extensions;

namespace AlisverisLab.MVC.Middlewares
{
    public class SessionCheckMiddleware
    {
        RequestDelegate _next;

        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var session = context.Session;

            var user = session.GetSession<LoginModel>("user");


            if (user == null && !context.Request.Path.Value.Contains("/Account/LoginRegister"))
            {
                context.Response.Redirect("/Account/LoginRegister");
                return;
            }

            await _next(context);
        }
    }
}
