using Core.Contracts;
using Core.Entities;

namespace Core.Repositories;

/// <summary>
/// Contract to define a donation repository
/// </summary>
public interface IDonationRepository : IRepository<Donation>
{
    public new Task<Donation?> FindByIdAsync(Guid id);
    public new Task<List<Donation>> FindAllAsync();
}