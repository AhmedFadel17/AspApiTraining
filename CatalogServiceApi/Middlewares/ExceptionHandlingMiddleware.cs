using CatalogServiceApi.Application.DTOs.Errors;

namespace CatalogServiceApi.WebUi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                KeyNotFoundException => StatusCodes.Status404NotFound,
                ArgumentException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError,
            };

            var response = new ErrorResponseDto
            {
                Error = exception.Message,
                StatusCode = context.Response.StatusCode,
                Details = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                  ? exception.StackTrace
                  : null
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
