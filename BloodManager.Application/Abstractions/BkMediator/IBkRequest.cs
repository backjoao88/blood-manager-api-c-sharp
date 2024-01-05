namespace Application.Abstractions.BkMediator;

/// <summary>
/// Contract for a request with a response 
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IBkRequest<TResponse>;
/// <summary>
/// Contract for a request with no response
/// </summary>
public interface IBkRequest;