using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using ETicaretAPI.Application.Exceptions;

namespace ETicaret.WEBAPI.Extensions
{
   static public class ConfigureGlobalExceptionHandlerExtension
    {
        public static void ConfigureGlobalExceptionHandler<T>(this WebApplication application, ILogger<T> logger)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundUserException => (int)HttpStatusCode.BadRequest,
                            AuthenticationErrorException => (int)HttpStatusCode.Unauthorized,
                            _ => (int)HttpStatusCode.InternalServerError
                        };

                        logger.LogError(contextFeature.Error, contextFeature.Error.Message);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Title = "Hata alındı!"
                        }));
                    }
                });
            });
        }
    }
}
