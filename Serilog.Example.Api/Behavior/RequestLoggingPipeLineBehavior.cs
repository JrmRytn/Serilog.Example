using MediatR; 
using Serilog.Example.Api.Results;

namespace Serilog.Example.Api.Behavior;

public class RequestLoggingPipeLineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).FullName!.Replace("Modules.", "").Replace("+", ".");

        Log.Information("Starting request {@RequestName} {@Request} {@DateTimeNow}", requestName, request, DateTime.Now);
        var result = await next();

        if (!result.IsSuccess)
        {
            Log.Error("Request failure {@RequestName} {@Error} {@DateTimeNow}", requestName, result.Error, DateTime.Now);
        }
        else
        {
            Log.Information("Request completed {@RequestName} {@DateTimeNow} {@Result}", requestName, DateTime.Now, result);
        }
        return result;
    }
}
