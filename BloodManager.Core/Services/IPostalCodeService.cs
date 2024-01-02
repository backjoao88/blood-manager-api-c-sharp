using Core.Dtos;

namespace Core.Services;

/// <summary>
/// Represents a contract to implement a check on postal code services
/// </summary>
public interface IPostalCodeService
{
    public Task<PostalCodeDto?> CheckPostalCodeAsync(string postalCode);
}