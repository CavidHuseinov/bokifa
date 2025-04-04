using System.Net;
using System.Text.Json;

namespace Oxu.WebAPI.Middlewares
{
    public class GlobalHandleException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalHandleException> _logger;

        public GlobalHandleException(RequestDelegate next, ILogger<GlobalHandleException> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                StatusCode = response.StatusCode,
                Message = "An unexpected error occurred. Please try again later.",
                Details = exception.Message 
            };

            var jsonResponse = JsonSerializer.Serialize(errorResponse);
            await response.WriteAsync(jsonResponse);
        }
    }
}
