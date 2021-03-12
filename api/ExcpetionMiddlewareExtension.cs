using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using Services.Common;

namespace api
{
    public static class ExcpetionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (contextFeature != null)
                    {
                        if (contextFeature.Error is TheoException)
                        {
                            Log.Error($"Something went wrong: {contextFeature.Error}");
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = 406,
                                Message = "You're stupid"
                            }.ToString());
                        }
                        else
                        {
                            Log.Error($"Something went wrong: {contextFeature.Error}");
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal Server Error"
                            }.ToString());
                        }

                    }
                });
            });
        }
    }
}