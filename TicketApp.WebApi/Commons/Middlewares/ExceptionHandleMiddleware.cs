using TicketApp.WebApi.Commons.Exceptions;
using Newtonsoft.Json;

namespace TicketApp.WebApi.Commons.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (StatusCodeException statusCodeException)
            {
                await HandleAsync(statusCodeException, httpContext);
            }
            catch (Exception exception)
            {
                await OtherHandleAsync(exception, httpContext);
            }
        }

        public async Task HandleAsync(StatusCodeException statusCodeException, HttpContext httpContext)
        {
            httpContext.Response.StatusCode = (int)statusCodeException.HttpStatusCode;
            httpContext.Response.ContentType = "application/json";
            string json = JsonConvert.SerializeObject(new {Message = statusCodeException.Message});
            await httpContext.Response.WriteAsync(json);
        }

        public async Task OtherHandleAsync(Exception exception, HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 504;
            httpContext.Response.ContentType = "application/json";
            string json = JsonConvert.SerializeObject(new {Message = exception.Message});
            await httpContext.Response.WriteAsync(json);
        }
    }
}
