using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Presentation.Extensions;

public static class ApplicationBuilderExtensions
{
    //public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    //{
    //    app.UseExceptionHandler(errorApp =>
    //    {
    //        errorApp.Run(async context =>
    //        {
    //            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    //            var exception = exceptionHandlerPathFeature.Error;
    //            var problemDetails = new ProblemDetails
    //            {
    //                Instance = context.Request.Path,
    //                Status = StatusCodes.Status500InternalServerError,
    //                Title = "An error occurred",
    //                Detail = exception.Message
    //            };
    //            context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
    //            context.Response.ContentType = "application / problem + json";
    //            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    //        });
    //    }
    //}
}

