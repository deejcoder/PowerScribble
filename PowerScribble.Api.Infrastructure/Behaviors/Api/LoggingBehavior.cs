using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Logging;
using PowerScribble.Api.Domain.Models;

namespace PowerScribble.Api.Infrastructure.Behaviors.Api
{
    public class LoggingBehavior
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingBehavior(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next;
            _logger = loggerFactory.CreateLogger<LoggingBehavior>();
        }

        /// <summary>
        /// Logs API responses
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            // only use this middleware when the client has sent a post request to the API
            if (!httpContext.Request.Method.Equals(System.Net.Http.HttpMethod.Post.Method))
            {
                await _next.Invoke(httpContext);
                return;
            }

            if (httpContext.Request.ContentType is null) return;

            // only when the content is JSON
            if (!httpContext.Request.ContentType.Equals(System.Net.Mime.MediaTypeNames.Application.Json))
            {
                await _next.Invoke(httpContext);
                return;
            }
            var jsonOptions = httpContext.RequestServices.GetService<IOptions<JsonOptions>>();

            // attempt to deserialize the json request
            try
            {
                // allow us to read multiple times from the body
                httpContext.Request.EnableBuffering();
                using (var reader = new StreamReader(httpContext.Request.Body, leaveOpen: true))
                {

                    var json = await reader.ReadToEndAsync();
                    ApiRequest? apiResponse = JsonConvert.DeserializeObject<ApiRequest>(json);
                    if (apiResponse != null)
                    {
                        // log the header information
                        string status = (apiResponse.Ok ? "Success" : "Failed");
                        _logger.LogInformation("POST {Status}: {Message}", status, apiResponse.Message);
                    }
                }

                httpContext.Request.Body.Position = 0;
            }
            catch
            { }

            await _next.Invoke(httpContext);
        }
    }
}
