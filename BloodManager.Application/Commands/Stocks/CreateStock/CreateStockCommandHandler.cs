using Application.Abstractions.BkMediator;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Entities;
using Core.Primitives;
using Core.Primitives.Result;

namespace Application.Commands.Stocks.CreateStock;

/// <summary>
/// Represents the <see cref="CreateStockCommand"/> handler
/// </summary>
public class CreateStockCommandHandler : IBkRequestHandler<CreateStockCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> HandleAsync(CreateStockCommand request)
    {
        var stock = new Stock(request.Description, request.BloodType, request.BloodRhFactor, request.QuantityMl, request.MinimumQuantityMl);
        if (!await _unitOfWork.StockRepository.IsStockUniqueAsync(stock))
        {
            return Result.Fail(DomainErrors.Stock.DuplicatedStockError);
        }
        await _unitOfWork.StockRepository.SaveAsync(stock);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}