using Core.Contracts;
using Core.Repositories;

namespace BloodManager.Infrastructure.Persistence.Ef;

/// <summary>
/// Class that represents an EFCore unit of work.
/// </summary>
public class EfCoreUnitOfWork : IUnitOfWork
{
    public EfCoreUnitOfWork(EfCoreContext efCoreContext, IDonorRepository donorRepository, IStockRepository stockRepository, IDonationRepository donationRepository)
    {
        _efCoreContext = efCoreContext;
        DonorRepository = donorRepository;
        StockRepository = stockRepository;
        DonationRepository = donationRepository;
    }
    public IDonorRepository DonorRepository { get; set; }
    public IStockRepository StockRepository { get; set; }
    public IDonationRepository DonationRepository { get; }
    private readonly EfCoreContext _efCoreContext;
    public int Complete()
    {
        return _efCoreContext.SaveChanges();
    }
    public async Task<int> CompleteAsync()
    {
        return await _efCoreContext.SaveChangesAsync();
    }
}