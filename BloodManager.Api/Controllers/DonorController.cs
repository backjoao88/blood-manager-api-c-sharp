using Application.Commands.Donor;
using Application.Queries.Donor.ReadAllDonors;
using Application.ViewModels;
using BloodManager.Api.Abstractions;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace BloodManager.Api.Controllers;

[ApiController]
[Route("/api/donors")]
public sealed class DonorController : ControllerBase
{
    private readonly IBkMediator _mediator;
    public DonorController(IBkMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateDonorCommand createDonorCommand)
    {
        await Task.Delay(2000);
        return Ok();
    }
    
    /// <summary>
    /// Returns all donors 
    /// </summary>
    /// <returns>A status 200 OK with a list of donors</returns>
    /// <returns>A status 400 Bad Request with an api error response</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<DonorViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var readAllDonors = new ReadAllDonorsQuery();
        var donors = await _mediator.SendAsync<ReadAllDonorsQuery, IEnumerable<DonorViewModel>>(readAllDonors);
        return Ok(donors);
    }
}