﻿using Microsoft.Extensions.DependencyInjection;

namespace BloodManager.Application.Abstractions.BkMediator;

public class BkMediator : IBkMediator
{
    public BkMediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private readonly IServiceProvider _serviceProvider;

    public async Task SendAsync<TRequest>(TRequest request) where TRequest : IBkRequest
    {
        var handler =
            (IBkRequestHandler<TRequest>)_serviceProvider.GetRequiredService(typeof(IBkRequestHandler<TRequest>));
        var behaviours = _serviceProvider.GetServices<IBkPipelineBehaviour<TRequest>>().ToList();
        if (!behaviours.Any())
        {
            await handler.HandleAsync(request);
            return;
        }

        CommandHandlerDelegate next = () => handler.HandleAsync(request);
        behaviours.Reverse();
        foreach (var behaviour in behaviours)
        {
            var currentNext = next;
            next = () => behaviour.HandleAsync(request, currentNext);
        }

        await next();
    }

    public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request) where TRequest : IBkRequest<TResponse>
    {
        var handler =
            (IBkRequestHandler<TRequest, TResponse>)_serviceProvider.GetRequiredService(
                typeof(IBkRequestHandler<TRequest, TResponse>));
        var behaviours =
            _serviceProvider
                .GetServices<IBkPipelineBehaviour<TRequest, TResponse>>().ToList();
        if (!behaviours.Any())
        {
            return await handler.HandleAsync(request);
        }
        CommandHandlerDelegate<TResponse> next = () => handler.HandleAsync(request);
        behaviours.Reverse();
        foreach (var behaviour in behaviours)
        {
            var currentNext = next;
            next = () => behaviour.HandleAsync(request, currentNext);
        }
        return await next();
    }
}