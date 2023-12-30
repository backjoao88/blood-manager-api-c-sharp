using Application.Commands.Donors.CreateDonor;
using Application.Commands.Stocks.CreateStock;
using Application.Queries.Stocks.ReadStockById;
using Application.ViewModels;
using BloodManager.Api.Abstractions;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Primitives.Result;
using Microsoft.AspNetCore.Mvc;

namespace BloodManager.Api.Controllers;

/// <summary>
/// Represents the stock endpoint controller
/// </summary>
[ApiController]
[Route("/api/stocks")]
public class StockController : ApiController
{
    private readonly IBkMediator _mediator;
    public StockController(IBkMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new stock in the database
    /// </summary>
    /// <param name="createStockCommand"></param>
    /// <returns></returns>
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateStockCommand createStockCommand)
    {
        var result = await _mediator.SendAsync<CreateStockCommand, Result>(createStockCommand);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    /// <summary>
    /// Returns a stock that matches with the informed Guid ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="readStockByIdQuery"></param>
    /// <returns>A status 200 OK with the required stock</returns>
    /// <returns>A status 400 Bad Request with an api error response</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(StockViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, ReadStockByIdQuery readStockByIdQuery)
    {
        readStockByIdQuery.Id = id;
        var stockViewModelResult = await _mediator.SendAsync<ReadStockByIdQuery, Result<StockViewModel>>(readStockByIdQuery);
        return stockViewModelResult.IsSuccess ? Ok(stockViewModelResult.Value) : BadRequest(stockViewModelResult.Error);
    }
    
}