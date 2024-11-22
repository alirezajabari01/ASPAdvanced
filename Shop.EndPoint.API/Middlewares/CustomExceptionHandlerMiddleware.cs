using Shop.EndPoint.API.Exceptions;
using Shop.EndPoint.API.Filters;
using System.Net;
using ApplicationException = Shop.EndPoint.API.Exceptions.ApplicationException;

namespace Shop.EndPoint.API.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly ILogger<CustomExceptionHandlerMiddleware> logger;
        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            this.logger = logger;
            Next = next;
        }

        public RequestDelegate Next { get; set; }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (ApplicationException ex)
            {
                if (ex.IsConfidentiality == false)
                {
                    var res = new MyResponse(ex.Message);
                    context.Response.StatusCode = (int)ex.StatusCode;
                    await context.Response.WriteAsJsonAsync(res);
                }
                else
                {
                    await UnHandleError(context, ex);
                }

            }
            catch (Exception ex)
            {
                await UnHandleError(context, ex);
            }
        }

        private async Task UnHandleError(HttpContext context, Exception ex)
        {
            logger.LogError(ex.Message + ex.StackTrace);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync("InternalServerError");
        }
    }
}
