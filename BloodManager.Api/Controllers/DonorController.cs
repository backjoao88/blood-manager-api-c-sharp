using Application.Commands.Donors.CreateDonor;
using Application.Commands.Donors.DeleteDonor;
using Application.Commands.Donors.UpdateDonor;
using Application.Queries.Donors.ReadAllDonors;
using Application.Queries.Donors.ReadDonorById;
using Application.ViewModels;
using BloodManager.Api.Abstractions;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Primitives;
using Core.Primitives.Result;
using Microsoft.AspNetCore.Mvc;

namespace BloodManager.Api.Controllers;

/// <summary>
/// Represents the donor endpoint controller
/// </summary>
[ApiController]
[Route("/api/donors")]
public class DonorController : ApiController
{
    private readonly IBkMediator _mediator;
    public DonorController(IBkMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Creates a new donor in the database
    /// </summary>
    /// <param name="createDonorCommand"></param>
    /// <returns>A status 200 OK</returns>
    /// <returns>A status 400 Bad Request with an api error response</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateDonorCommand createDonorCommand)
    {
        var result = await _mediator.SendAsync<CreateDonorCommand, Result>(createDonorCommand);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
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
        var readAllDonorsQuery = new ReadAllDonorsQuery();
        var donors = await _mediator.SendAsync<ReadAllDonorsQuery, IEnumerable<DonorViewModel>>(readAllDonorsQuery);
        return Ok(donors);
    }
    
    /// <summary>
    /// Returns a donor that matches with the informed Guid ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A status 200 OK with the required donor</returns>
    /// <returns>A status 400 Bad Request with an api error response</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DonorViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var readDonorByIdQuery = new ReadDonorByIdQuery(id);
        var donorViewModelResult = await _mediator.SendAsync<ReadDonorByIdQuery, Result<DonorViewModel>>(readDonorByIdQuery);
        return donorViewModelResult.IsSuccess ? Ok(donorViewModelResult.Value) : NotFound(donorViewModelResult.Error);
    }

    /// <summary>
    /// Deletes a donor from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A status 200 OK</returns>
    /// <returns>A status 404 Not Found with an api error response</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteDonorCommand = new DeleteDonorCommand(id);
        var result = await _mediator.SendAsync<DeleteDonorCommand, Result>(deleteDonorCommand);
        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    /// <summary>
    /// Updates a donor in the database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateDonorCommand"></param>
    /// <returns>A status 200 OK</returns>
    /// <returns>A status 404 Not Found with an api error response</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDonorCommand updateDonorCommand)
    {
        updateDonorCommand.Id = id;
        var result = await _mediator.SendAsync<UpdateDonorCommand, Result>(updateDonorCommand);
        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }
}