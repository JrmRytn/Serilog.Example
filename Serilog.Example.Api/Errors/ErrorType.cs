namespace Serilog.Example.Api.Errors;

public enum ErrorType
{
    Failure = 0,
    NotFound = 1,
    Conflict = 2,
    Validation = 3,
    Unauthorized = 4,
}