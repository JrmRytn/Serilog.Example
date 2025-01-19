using Serilog.Example.Api.Results;

namespace Serilog.Example.Api.Errors;

public sealed record Error(string Code, string? Description = null, ErrorType ErrorType = ErrorType.Failure)
{
    public static readonly Error None = new(string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);
    public static readonly Error DatabaseError = new("Error.DatabaseError", "Database error occured", ErrorType.Failure);

    public static implicit operator Result(Error error) => Result.Failure(error);
    public Result ToResult() => Result.Failure(this);
}
