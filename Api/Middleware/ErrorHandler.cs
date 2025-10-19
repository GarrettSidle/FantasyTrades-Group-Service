using System.Net;
using FantasyTradesGroupService.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FantasyTradesGroupService.Api.Middleware
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandler> _logger;

        public ErrorHandler(RequestDelegate next, ILogger<ErrorHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException dex)
            {
                // Log full stack trace
                _logger.LogError(dex, "Domain error: {Message}", dex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new { error = dex.Message });
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                // Log full stack trace
                _logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // Return only a generic message to the client
                var result = JsonSerializer.Serialize(new { error = "An unexpected error occurred." });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
