using Foody_backend.Exceptions;

namespace Foody_backend.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next , ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;


        }


        public async Task InvokeAsync(HttpContext context) {

            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning("Validation error: {Message}", ex.Message);
                await WriteResponse(context, 400, ex.Message);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning("Not found: {Message}", ex.Message);

                await WriteResponse(context, 404, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogWarning("Unauthorized: {Message}", ex.Message);

                await WriteResponse(context, 403, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred");

                await WriteResponse(context, 500, "An unexpected error occurred");
            }






        }
        private static async Task WriteResponse(HttpContext context, int statuscode, string message) {

            context.Response.StatusCode = statuscode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = message });

        }

    }

}