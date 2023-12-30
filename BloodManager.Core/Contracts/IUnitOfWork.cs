using Core.Repositories;

namespace Core.Contracts;

public interface IUnitOfWork
{
    public IDonorRepository DonorRepository { get; }
    public IStockRepository StockRepository { get; }
    public IDonationRepository DonationRepository { get; }
    public int Complete();
    public Task<int> CompleteAsync();
}