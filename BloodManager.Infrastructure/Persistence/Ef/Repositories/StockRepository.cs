using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodManager.Infrastructure.Persistence.Ef.Repositories;

/// <summary>
/// Represents a repository for <see cref="Stock"/> entity
/// </summary>
public class StockRepository : EfCoreRepository<Stock>, IStockRepository
{
    public StockRepository(EfCoreContext efCoreContext) : base(efCoreContext)
    {
    }

    public async Task<bool> IsStockUniqueAsync(Stock stock)
    {
        return !await EfCoreContext.Stocks.AnyAsync(s => s.BloodRhFactor == stock.BloodRhFactor && s.BloodType == stock.BloodType);
    }

    public async Task<Stock?> FindByBloodTypeAndRhFactor(EBlood eBloodType, EBloodRhFactor eBloodRhFactor)
    {
        return await EfCoreContext.Stocks.SingleOrDefaultAsync(s => s != null && s.BloodType == eBloodType && s.BloodRhFactor == eBloodRhFactor);
    }
}