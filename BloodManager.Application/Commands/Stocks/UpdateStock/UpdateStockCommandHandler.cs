using Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Primitives;
using Core.Primitives.Result;

namespace Application.Commands.Stocks.UpdateStock;

/// <summary>
/// Represents the <see cref="UpdateStockCommand"/> handler
/// </summary>
public class UpdateStockCommandHandler : IBkRequestHandler<UpdateStockCommand, Result>
{
    public UpdateStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    private readonly IUnitOfWork _unitOfWork;
    public async Task<Result> HandleAsync(UpdateStockCommand request)
    {
        var stock = await _unitOfWork.StockRepository.FindByIdAsync(request.Id);
        if (stock is null)
        {
            return Result.Fail(DomainErrors.Stock.NotFoundStockError);
        }
        var stockUpdateResult = stock.Update(request.QuantityMl);
        if (stockUpdateResult.IsFailure)
        {
            // stock update error
            return Result.Fail(stockUpdateResult.Error);
        }
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}