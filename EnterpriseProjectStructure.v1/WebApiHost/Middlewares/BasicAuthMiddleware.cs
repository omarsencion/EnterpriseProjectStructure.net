namespace WebApiHost.Middlewares
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Org.Domain.Abstractions.Business;
    using Org.Domain.Abstractions.Common;
    using Org.Domain.WebApi;
    using System.Threading.Tasks;

    public static class BasicAuthMiddlewareExtension
    {
        public static void UseBasicAuth(this IApplicationBuilder app)
        {
            app.UseMiddleware<BasicAuthMiddleware>();
        }
    }

    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IBusinessService<IAuth> _auth;

        public BasicAuthMiddleware(IBusinessService<IAuth> auth, RequestDelegate next)
        {
            _next = next;
            _auth = auth;  
        }

        public Task Invoke(HttpContext httpContext)
        {
            _auth.Get().Validate();

            return _next(httpContext);
        }
    }
}
