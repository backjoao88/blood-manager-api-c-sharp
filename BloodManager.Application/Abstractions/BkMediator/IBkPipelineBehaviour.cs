namespace Application.Abstractions.BkMediator;

/// <summary>
/// Represents a contract for a middleware with no response
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public interface IBkPipelineBehaviour<TRequest> where TRequest : IBkRequest
{
    public Task HandleAsync(TRequest request, CommandHandlerDelegate next);
}

/// <summary>
/// Represents a contract for a middleware with a response
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface IBkPipelineBehaviour<TRequest, TResponse> where TRequest : IBkRequest<TResponse>
{
    public Task<TResponse> HandleAsync(TRequest request, CommandHandlerDelegate<TResponse> next);
}

/// <summary>
/// Representation of a delegate with no response
/// </summary>
public delegate Task CommandHandlerDelegate();
/// <summary>
/// Representation of a delegate with a response
/// </summary>
public delegate Task<TResponse> CommandHandlerDelegate<TResponse>();