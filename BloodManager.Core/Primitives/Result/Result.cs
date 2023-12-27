namespace Core.Primitives.Result;

/// <summary>
/// Wrappers a expressive failure or success result
/// </summary>
public class Result
{
    public Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    public bool IsSuccess { get; set; }
    public Error Error { get; set; }
    public bool IsFailure => !IsSuccess;
    public static Result Ok() => new(true, GenericErrors.None);
    public static Result<TValue> Ok<TValue>(TValue value) => new(value, true, GenericErrors.None);
    public static Result Fail(Error error) => new(false, error);
    public static Result<TValue> Fail<TValue>(Error error) => new(default!, false, error);
}

/// <summary>
/// Wrappers a expressive generic failure or success result
/// </summary>
public class Result<TValue> : Result
{
    public Result(TValue value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        Value = value;
    }
    public TValue Value { get; set; }
}