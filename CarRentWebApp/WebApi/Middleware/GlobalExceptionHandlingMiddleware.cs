using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace WebApi.Middleware
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Internal server error",
                    Title = e.GetType().Name,
                    Detail = e.Message
                };
            }
        }
    }
}
