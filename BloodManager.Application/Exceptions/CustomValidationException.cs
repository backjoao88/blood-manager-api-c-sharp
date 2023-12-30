using Core.Primitives;

namespace Application.Exceptions;

/// <summary>
/// Represents a validation exception
/// </summary>
public class CustomValidationException : Exception
{
    public CustomValidationException(IReadOnlyCollection<Error> errors)
    {
        Errors = errors;
    }
    public IReadOnlyCollection<Error> Errors { get; set; }
}