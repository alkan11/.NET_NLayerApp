using Microsoft.AspNetCore.Diagnostics;
using NLayer.Service.Excaption;
using NlayerCoreApp.DTOs;
using System.Text.Json;

namespace NLayer.API.Middleware
{
    public static  class UseCustomExceptionHandler
    {
        public static void UserCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var excaption = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = excaption.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDTO<NoContentDTO>.Fail(statusCode, excaption.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
