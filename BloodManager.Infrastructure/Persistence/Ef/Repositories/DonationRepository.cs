using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodManager.Infrastructure.Persistence.Ef.Repositories;

/// <summary>
/// Represents a repository for Donation entity
/// </summary>
public class DonationRepository : EfCoreRepository<Donation>, IDonationRepository
{
    public DonationRepository(EfCoreContext efCoreContext) : base(efCoreContext)
    {
    }
    
    /// <summary>
    /// Return a donation filled with the corresponding donor
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A donor</returns>
    public new async Task<Donation?> FindByIdAsync(Guid id)
    {
        return await EfCoreContext.Donations.Include(o => o.Donor).SingleOrDefaultAsync(o => o.Id == id);
    }
    
    /// <summary>
    /// Return all donations filled with the corresponding donors
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A list of donations</returns>
    public new async Task<List<Donation>> FindAllAsync()
    {
        return await EfCoreContext.Donations.Include(o => o.Donor).ToListAsync();
    }
}