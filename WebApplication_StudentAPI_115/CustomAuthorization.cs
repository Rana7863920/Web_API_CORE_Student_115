using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApplication_StudentAPI_115
{
    public class CustomAuthorization : AuthorizeAttribute
    {

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Forbidden,
                Content = new StringContent("You are unauthorized to access this resource")
            };
        }
    }
}
