namespace TaskWise.Application.Common.OperationHandler;

public sealed class OperationResult<T>
{
    public T? Payload { get; init; }
    public OperationStatus Status { get; init; }
    public IReadOnlyCollection<string> ErrorMessages { get; init; } = [];

    public bool IsSuccess => Status == OperationStatus.Success;

    public static OperationResult<T> Success(T? payload) => new()
    {
        Status = OperationStatus.Success,
        Payload = payload
    };

    public static OperationResult<T> NotFound(string message) => new()
    {
        Status = OperationStatus.NotFound,
        ErrorMessages = [message]
    };

    public static OperationResult<T> UserNotActive(string message) => new()
    {
        Status = OperationStatus.UserNotActive,
        ErrorMessages = [message]
    };

    public static OperationResult<T> Unauthorized(string message) => new()
    {
        Status = OperationStatus.Unauthorized,
        ErrorMessages = [message]
    };
}
