namespace Core.Primitives.Result;

public static class ResultExtensions
{
    public static Result Bind<TIn, TOut>(this Result result, Func<TIn, TOut> next)
    {
        return Result.Fail(GenericErrors.NullValue);
    }
}