namespace Serilog.Example.Api.Errors;

public abstract class BaseError<T>
{
    public static Error NotFound(Guid id) => new($"{typeof(T).Name}.NotFound", $"The {typeof(T).Name} with the Id='{id}' was not found.", ErrorType.NotFound);
    public static Error FailureToCreate => new($"{typeof(T).Name}.FailureToCreate", $"Failure to create {typeof(T).Name}", ErrorType.Failure);
    public static Error FailureToUpdate => new($"{typeof(T).Name}.FailureToUpdate", $"Failure to update {typeof(T).Name}", ErrorType.Failure);
    public static Error FailureToSoftDelete => new($"{typeof(T).Name}.FailureToSoftDelete", $"Failure to soft delete {typeof(T).Name}", ErrorType.Failure);
    public static Error Conflict => new($"{typeof(T).Name}.Conflict", $"{typeof(T).Name} already exists.", ErrorType.Conflict); 
    public static Error SoftDeletedMessage(Guid id) => new($"{typeof(T).Name}.SofDeleted", $"{typeof(T).Name} with the Id='{id}' was already soft deleted. Recover before updating this record.", ErrorType.NotFound); 
}
