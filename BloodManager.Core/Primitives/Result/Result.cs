namespace Core.Primitives.Result;

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
    public static Result Fail(Error error) => new(false, error);
}

public class Result<TValue> : Result
{
    public Result(TValue value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        Value = value;
    }
    public TValue Value { get; set; }
}