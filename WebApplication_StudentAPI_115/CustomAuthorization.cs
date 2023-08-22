using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Build.Tasks;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApplication_StudentAPI_115
{
    public class CustomAuthorization : AuthorizeAttribute
    {
        protected virtual void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new Exception("Error");
            }

            actionContext.Response =
            actionContext.ControllerContext.Request.CreateErrorResponse(
                                  HttpStatusCode.Unauthorized,
                                  "My Un-Authorized Message");
        }
    }
}
