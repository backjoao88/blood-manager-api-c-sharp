using Core.Contracts;
using Core.Entities;
using Core.ValueObjects;

namespace Core.Repositories;

/// <summary>
/// Contract to define a donor repository
/// </summary>
public interface IDonorRepository : IRepository<Donor>
{
    public Task<bool> IsEmailUnique(Email email);
}