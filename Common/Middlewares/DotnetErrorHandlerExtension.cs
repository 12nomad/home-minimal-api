using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HomeMinimalApi.Common.Middlewares;

public static class DotnetErrorHandlerExtension {
    public static void ConfigureExceptionHandler(this IApplicationBuilder application) {
        application.Run(async context => {
            var logger = context.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("DotNet Custom Exception Handler Middleware");
            var env = context.RequestServices.GetRequiredService<IHostEnvironment>();
            var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            logger.LogError(4, "Something went wrong. Machine: {Machine}, TraceId: {TraceId}, Error: {Error}"
                                                                                                                , Environment.MachineName
                                                                                                                , Activity.Current?.TraceId
                                                                                                                , error?.Message);

            var problemDetails = new ProblemDetails {
                Title = "Oops! Something went wrong.",
                Status = StatusCodes.Status500InternalServerError,
                Extensions = {
                    {"TraceId", Activity.Current?.TraceId.ToString()}
                }
            };

            if (env.IsDevelopment()) problemDetails.Detail = error?.ToString();

            await Results.Problem(problemDetails).ExecuteAsync(context);
        });
    }
}