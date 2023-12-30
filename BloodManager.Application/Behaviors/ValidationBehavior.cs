using System.ComponentModel.DataAnnotations;
using Application.Abstractions.BkMediator;
using Application.Exceptions;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Primitives;
using FluentValidation;

namespace Application.Behaviors;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class ValidationBehavior<TRequest, TResponse> : IBkPipelineBehaviour<TRequest, TResponse> where TRequest : IBkRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public Task<TResponse> HandleAsync(TRequest request, CommandHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
        {
            return next();
        }
        var validationContext = new ValidationContext<TRequest>(request);
        var errors = _validators
            .Select(o => o.Validate(validationContext))
            .SelectMany(o => o.Errors)
            .Select(o => new Error(o.ErrorCode, o.ErrorMessage))
            .Distinct()
            .ToArray();
        if (errors.Any())
        {
            throw new CustomValidationException(errors);
        }
        return next();
    }
}