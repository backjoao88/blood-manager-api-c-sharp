using Core.Primitives;

namespace BloodManager.Api.Abstractions;

/// <summary>
/// Wrapper a general api error response
/// </summary>
public class ApiErrorResponse
{
    public ApiErrorResponse(List<Error> errors)
    {
        _errors = errors;
    }
    private readonly List<Error> _errors;
}