using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SaleWebApp.Filters
{
    public class AdminFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string jsonUser = context.HttpContext.Session.GetString("User");
            string role = context.HttpContext.Session.GetString("Role");
            if (jsonUser == null || role == null || role != "ADMIN")
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
