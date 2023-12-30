using Core.Primitives;

namespace BloodManager.Api.Abstractions;

/// <summary>
/// Wrapper a general api error response
/// </summary>
public class ApiErrorResponse
{
    public ApiErrorResponse(IReadOnlyCollection<Error> errors)
    {
        Errors = errors;
    }

    public ApiErrorResponse(Error error)
    {
        Errors = new[] { error };
    }
    public IReadOnlyCollection<Error> Errors { get; set; }
}