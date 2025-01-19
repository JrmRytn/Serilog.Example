namespace Serilog.Example.Api.Errors;

public static class ErrorFactory<T, TKey>
{
    public static Error FailureToCreate => new($"{typeof(T).Name}.FailureToCreate", $"Failure to create {typeof(T).Name}", ErrorType.Failure);
    public static Error FailureToUpdate => new($"{typeof(T).Name}.FailureToUpdate", $"Failure to update {typeof(T).Name}", ErrorType.Failure);
    public static Error DuplicateEntity => new($"{typeof(T).Name}.Conflict", $"{typeof(T).Name} already exists.", ErrorType.Conflict);
    public static Error NotFound(TKey id) => new($"{typeof(T).Name}.NotFound", $"The {typeof(T).Name} with the Id='{id}' was not found.", ErrorType.NotFound);

}
