using BloodManager.Application.Abstractions.BkMediator;

namespace Application.Abstractions.BkMediator;
public interface IBkRequestHandler<TRequest, TResponse> where TRequest : IBkRequest<TResponse>
{
    public Task<TResponse> HandleAsync(TRequest request);
}

public interface IBkRequestHandler<TRequest>
{
    public Task HandleAsync(TRequest request);
}