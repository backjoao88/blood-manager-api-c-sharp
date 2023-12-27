namespace Core.Primitives.Result;

public static class ResultExtensions
{
    public static Result Bind(this Result result, Func<Result> next)
    {
        if (result.IsSuccess)
        {
            return next();
        }
        return Result.Fail(result.Error);
    }
}