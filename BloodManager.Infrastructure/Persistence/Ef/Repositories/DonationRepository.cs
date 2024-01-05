using System.Runtime.InteropServices.JavaScript;
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
    /// <returns>A list of donations</returns>
    public new async Task<List<Donation>> FindAllAsync()
    {
        return await EfCoreContext.Donations.Include(o => o.Donor).ToListAsync();
    }
    
    /// <summary>
    /// Returns the last donation date from the requested donor 
    /// </summary>
    /// <param name="idDonor"></param>
    /// <returns>A datetime value</returns>
    public async Task<Donation?> GetLastDonationFromAsync(Guid idDonor)
    {
        return await EfCoreContext.Donations.Where(o => o.IdDonor == idDonor).OrderByDescending(o => o.DonationDate)
            .FirstOrDefaultAsync();
    }
    
    /// <summary>
    /// Return a set of donations made by a specific donor
    /// </summary>
    /// <param name="idDonor"></param>
    /// <returns>A list of donations</returns>
    public async Task<List<Donation>> GetDonationsByDonorIdAsync(Guid idDonor)
    {
        return await EfCoreContext.Donations.Where(o => o.IdDonor == idDonor).ToListAsync();
    }

    /// <summary>
    /// Return a set of donations in a last specified interval of days
    /// </summary>
    /// <param name="days"></param>
    /// <returns>A list of donations</returns>
    public async Task<List<Donation>> GetDonationsWithinDaysAsync(int days)
    {
        var intervalDate = DateTime.Now.AddDays(-days);
        return await EfCoreContext.Donations.Where(o => o.DonationDate > intervalDate).ToListAsync();
    }
}