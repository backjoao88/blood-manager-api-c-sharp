using Core.Repositories;

namespace Core.Contracts;

public interface IUnitOfWork
{
    public IDonorRepository DonorRepository { get; } 
    public int Complete();
}