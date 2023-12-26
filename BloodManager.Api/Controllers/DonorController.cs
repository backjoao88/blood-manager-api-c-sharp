using Microsoft.AspNetCore.Mvc;

namespace BloodManager.Api.Controllers;

[ApiController]
[Route("/api/donors")]
public sealed class DonorController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}