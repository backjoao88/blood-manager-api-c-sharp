namespace BloodManager.Application.Abstractions.BkMediator;

public interface IBkPipelineBehaviour<TRequest> where TRequest : IBkRequest
{
    public Task HandleAsync(TRequest request, CommandHandlerDelegate next);
}

public interface IBkPipelineBehaviour<TRequest, TResponse> where TRequest : IBkRequest<TResponse>
{
    public Task<TResponse> HandleAsync(TRequest request, CommandHandlerDelegate<TResponse> next);
}

public delegate Task CommandHandlerDelegate();
public delegate Task<TResponse> CommandHandlerDelegate<TResponse>();