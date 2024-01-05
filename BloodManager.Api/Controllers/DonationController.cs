using Application.Abstractions.BkMediator;
using Application.Commands.Donations.CreateDonation;
using Application.Queries.Donations.ReadDonationByDonorId;
using Application.Queries.Donations.ReadDonationById;
using Application.Queries.Donations.ReadDonationWithinDays;
using Application.Queries.Stocks.ReadStockById;
using Application.ViewModels;
using BloodManager.Api.Abstractions;
using Core.Primitives.Result;
using Microsoft.AspNetCore.Mvc;

namespace BloodManager.Api.Controllers;

/// <summary>
/// Represents the donation endpoint controller
/// </summary>
[ApiController]
[Route("/api/donations")]
public class DonationController : ApiController
{
    private readonly IBkMediator _mediator;

    public DonationController(IBkMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Creates a new donation in the database
    /// </summary>
    /// <param name="createDonationCommand"></param>
    /// <returns>A status 200 OK</returns>
    /// <returns>A status 400 Bad Request with an api error response</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateDonationCommand createDonationCommand)
    {
        var result = await _mediator.SendAsync<CreateDonationCommand, Result>(createDonationCommand);
        return result.IsSuccess 
            ? Ok() 
            : BadRequest(result.Error);
    }

    /// <summary>
    /// Returns a donation that matches with the informed Guid ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="readDonationByIdQuery"></param>
    /// <returns>A status 200 OK with the required stock</returns>
    /// <returns>A status 400 Bad Request with an api error response</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DonationViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(Guid id, [FromBody] ReadDonationByIdQuery readDonationByIdQuery)
    {
        readDonationByIdQuery.Id = id;
        var donationViewModelResult =
            await _mediator.SendAsync<ReadDonationByIdQuery, Result<DonationViewModel>>(readDonationByIdQuery);
        return donationViewModelResult.IsSuccess
            ? Ok(donationViewModelResult.Value)
            : BadRequest(donationViewModelResult.Error);
    }

    /// <summary>
    /// Return a list of the last donations based on a specified number of days
    /// </summary>
    /// <param name="days"></param>
    /// <returns>A status 200 OK with a list of donations</returns>
    [HttpGet("last")]
    public async Task<IActionResult> GetDonationsWithinDays([FromQuery] int days)
    {
        var readDonationWithinDays = new ReadDonationWithinDays(days);
        var donationsViewModel =
            await _mediator.SendAsync<ReadDonationWithinDays, List<DonationViewModelSimple>>(readDonationWithinDays);
        return Ok(donationsViewModel);
    }

    /// <summary>
    /// Returns a list of donations based on a specified donor id
    /// </summary>
    /// <param name="idDonor"></param>
    /// <param name="readDonationByDonorId"></param>
    /// <returns>A status 200 OK with a list of donations</returns>
    [HttpGet("{idDonor}/donors")]
    [ProducesResponseType(typeof(List<DonationViewModelSimple>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDonationsByDonorId(Guid idDonor, [FromBody] ReadDonationByDonorId readDonationByDonorId)
    {
        readDonationByDonorId.IdDonor = idDonor;
        var donationViewModelResult = await _mediator.SendAsync<ReadDonationByDonorId, List<DonationViewModelSimple>>(readDonationByDonorId);
        return Ok(donationViewModelResult);
    }
}