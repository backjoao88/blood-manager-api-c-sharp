using Core.Entities;
using Core.Repositories;
using Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BloodManager.Infrastructure.Persistence.Ef.Repositories;

/// <summary>
/// Wrappers a repository for Donor entity
/// </summary>
public class DonorRepository : EfCoreRepository<Donor>, IDonorRepository
{
    public DonorRepository(EfCoreContext efCoreContext) : base(efCoreContext)
    {
    }
    
    /// <summary>
    /// Checks if the result of <see cref="Email"/> is unique in the database
    /// </summary>
    /// <param name="email"></param>
    /// <returns>A boolean value</returns>
    public async Task<bool> IsEmailUnique(Email email)
    {
        return !await EfCoreContext.Donors.AnyAsync(o => o.Email.Value == email.Value);
    }
}