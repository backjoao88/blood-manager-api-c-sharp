using Application.Abstractions.BkMediator;
using Application.ViewModels;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Primitives;
using Core.Primitives.Result;

namespace Application.Queries.Stocks.ReadStockById;

/// <summary>
/// Represents the <see cref="ReadStockByIdQuery"/> handler
/// </summary>
public class ReadStockByIdQueryHandler : IBkRequestHandler<ReadStockByIdQuery, Result<StockViewModel>>
{
    public ReadStockByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    private readonly IUnitOfWork _unitOfWork;
    public async Task<Result<StockViewModel>> HandleAsync(ReadStockByIdQuery request)
    {
        var stock = await _unitOfWork.StockRepository.FindByIdAsync(request.Id);
        if (stock is null)
        {
            return Result.Fail<StockViewModel>(GenericErrors.NotFound);
        }
        var stockViewModel = new StockViewModel(stock.Id, stock.Description, stock.BloodType, stock.BloodRhFactor,
            stock.QuantityMl, stock.MinimumQuantityMl);
        return Result.Ok(stockViewModel);
    }
}