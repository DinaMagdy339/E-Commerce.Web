using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace E_Commerce.Web.CustomMiddleWares
{
    public class CustomExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleWare> _logger;

        public CustomExceptionHandlerMiddleWare(RequestDelegate Next, ILogger<CustomExceptionHandlerMiddleWare> logger)
        {
            _next = Next;
            _logger = logger;
        }

        public ILogger<CustomExceptionHandlerMiddleWare> Logger { get; }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something Went Wrong");
                // Set Status Code for the response
                //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                // set the response content type
                httpContext.Response.ContentType = "application/json";
                // response object
                var Response = new ErrorToReturn
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = ex.Message
                };
                // return object as json
                //var ResponseToReturn = JsonSerializer.Serialize(Response);
                //await httpContext.Response.WriteAsync(ResponseToReturn);
                await httpContext.Response.WriteAsJsonAsync(Response);
            }
        }

    }
}
