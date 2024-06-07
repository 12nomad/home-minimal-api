using System.Diagnostics;

namespace HomeMinimalApi.Common.Middlewares;

public class RequestTimerMiddleware : IMiddleware {
    private readonly ILogger<RequestTimerMiddleware> _logger;

    public RequestTimerMiddleware(ILogger<RequestTimerMiddleware> logger) {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        var stopWatch = new Stopwatch();

        try {
            stopWatch.Start();
            await next(context);
        } finally {
            stopWatch.Stop();
            _logger.LogInformation("{Method} {Path} took {ElapsedMilliseconds} to finish.", context.Request.Method
                                                                                            , context.Request.Path
                                                                                            , stopWatch.ElapsedMilliseconds);
        }
    }
}