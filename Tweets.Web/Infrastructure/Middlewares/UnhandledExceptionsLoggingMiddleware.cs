using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Tweets.Web.Infrastructure.Middlewares
{
    public class UnhandledExceptionsLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public UnhandledExceptionsLoggingMiddleware(RequestDelegate next, IHostingEnvironment hostingEnvironment,
            ILogger<UnhandledExceptionsLoggingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private Tuple<HttpStatusCode, string> GetErrorInfo(Exception ex)
        {
            return ex is DbUpdateConcurrencyException
                ? new Tuple<HttpStatusCode, string>(HttpStatusCode.Conflict, "Unhandled conflict has occurred")
                : new Tuple<HttpStatusCode, string>(HttpStatusCode.InternalServerError, "Unhandled exception has occurred");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                context.Response.Clear();

                var errorInfo = GetErrorInfo(exception);
                _logger.LogError(0, exception, errorInfo.Item2);
                context.Response.StatusCode = (int)errorInfo.Item1;

                if (_hostingEnvironment.IsDevelopment() || _hostingEnvironment.IsStaging())
                {
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync(
                        JsonConvert.SerializeObject(new { Message = errorInfo.Item2, Exception = exception }));
                }
            }
        }
    }
}
