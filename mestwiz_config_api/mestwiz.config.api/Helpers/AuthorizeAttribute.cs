using mestwiz.config.data.access.Services;
using mestwiz.config.data.entities.Functions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web;

namespace mestwiz.config.api.Helpers
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute() : base(typeof(CustomAuthorizeFilter))
        {
        }
    }

    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        private DataContext DataContext;

        public CustomAuthorizeFilter(DataContext dataContext)
        {
            this.DataContext = dataContext;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string SessionId = context.HttpContext.Request?.Headers["SessionId"].ToString();
            string Host = context.HttpContext.Request?.Headers["UserHost"].ToString();
            string AppPathAction = context.HttpContext.Request?.Path;
            string AppMethodAction = context.HttpContext.Request?.Method;

            if(SessionId.IsNullString().Result && Host.IsNullString().Result)
                context.Result = new UnauthorizedResult();
        }
    }
}
