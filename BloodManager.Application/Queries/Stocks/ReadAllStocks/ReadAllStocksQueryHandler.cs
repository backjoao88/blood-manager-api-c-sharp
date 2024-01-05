using Application.Abstractions.BkMediator;
using Application.ViewModels;
using Core.Contracts;

namespace Application.Queries.Stocks.ReadAllStocks;

/// <summary>
/// Represents the <see cref="ReadAllStocksQuery"/> handler
/// </summary>
public class ReadAllStocksQueryHandler : IBkRequestHandler<ReadAllStocksQuery, List<StockViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    public ReadAllStocksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<StockViewModel>> HandleAsync(ReadAllStocksQuery request)
    {
        var stocks = await _unitOfWork.StockRepository.FindAllAsync();
        var stocksViewModel = stocks.Select(o =>
                new StockViewModel(o.Id, o.Description, o.BloodType, o.BloodRhFactor, o.QuantityMl,
                    o.MinimumQuantityMl)).ToList();
        return stocksViewModel;
    }
}