using Application.Abstractions.BkMediator;
using Application.ViewModels;

namespace Application.Queries.Stocks.ReadAllStocks;

/// <summary>
/// Command for read all stocks available
/// </summary>
public class ReadAllStocksQuery : IBkRequest<List<StockViewModel>>;