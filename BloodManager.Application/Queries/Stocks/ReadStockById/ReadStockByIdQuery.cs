﻿using Application.Abstractions.BkMediator;
using Application.ViewModels;
using Core.Primitives.Result;

namespace Application.Queries.Stocks.ReadStockById;

/// <summary>
/// Represents the query for querying a specified stock
/// </summary>
public record ReadStockByIdQuery : IBkRequest<Result<StockViewModel>>
{
    public ReadStockByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}