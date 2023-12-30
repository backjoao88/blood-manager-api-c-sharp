using Core.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace BloodManager.Api.Abstractions;

/// <summary>
/// General use API controller
/// Inherits ControllerBase from AspNet Core
/// </summary>
public abstract class ApiController : ControllerBase
{
    [NonAction]
    public IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new[] { error }));
    [NonAction]
    public IActionResult BadRequest(Error[] errors) => BadRequest(new ApiErrorResponse(errors));
}