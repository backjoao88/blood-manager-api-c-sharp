using Core.Entities;
using Core.Repositories;

namespace BloodManager.Infrastructure.Persistence.Ef.Repositories;

/// <summary>
/// Represents a repository for <see cref="Stock"/> entity
/// </summary>
public class StockRepository : EfCoreRepository<Stock>, IStockRepository
{
    public StockRepository(EfCoreContext efCoreContext) : base(efCoreContext)
    {
    }
}