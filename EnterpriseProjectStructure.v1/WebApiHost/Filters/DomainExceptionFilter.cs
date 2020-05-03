namespace WebApiHost.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // TODO
            // Log Errors

            context.Result = new ContentResult()
            {
                Content = "Something went wrong."
            };
            context.ExceptionHandled = true;
        }
    }
}
