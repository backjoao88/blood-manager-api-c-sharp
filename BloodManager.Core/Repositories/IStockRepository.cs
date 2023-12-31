using Core.Contracts;
using Core.Entities;
using Core.Enums;

namespace Core.Repositories;

/// <summary>
/// Contract to define a stock repository
/// </summary>
public interface IStockRepository : IRepository<Stock>
{
    public Task<bool> IsStockUniqueAsync(Stock stock);
    public Task<Stock?> FindByBloodTypeAndRhFactor(EBlood eBloodType, EBloodRhFactor eBloodRhFactor);
}