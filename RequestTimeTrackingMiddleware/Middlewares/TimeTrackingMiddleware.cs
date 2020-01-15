using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RequestTimeTrackingMiddleware.Middlewares
{
    public class TimeTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;

        public TimeTrackingMiddleware(RequestDelegate next, ILogger<TimeTrackingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var start=DateTime.Now;
            await _next(context);
            var end = DateTime.Now;

            var dt = end - start;
            _logger.LogInformation($"Request time = {dt.Milliseconds} ms");
        }
    }

    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimeTracking(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeTrackingMiddleware>();
        }
    }
}
