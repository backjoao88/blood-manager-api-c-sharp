namespace Application.Abstractions.BkMediator;

/// <summary>
/// Contract for a handler with a response
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface IBkRequestHandler<TRequest, TResponse> where TRequest : IBkRequest<TResponse>
{
    public Task<TResponse> HandleAsync(TRequest request);
}
/// <summary>
/// Contract for a handler with no response
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public interface IBkRequestHandler<TRequest>
{
    public Task HandleAsync(TRequest request);
}