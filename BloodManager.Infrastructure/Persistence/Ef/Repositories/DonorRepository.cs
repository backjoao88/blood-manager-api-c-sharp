using Core.Entities;
using Core.Repositories;

namespace BloodManager.Infrastructure.Persistence.Ef.Repositories;

/// <summary>
/// Wrappers a repository for Donor entity
/// </summary>
public class DonorRepository : EfCoreRepository<Donor>, IDonorRepository
{
    public DonorRepository(EfCoreContext efCoreContext) : base(efCoreContext)
    {
    }
}