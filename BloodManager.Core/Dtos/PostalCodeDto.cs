using Core.Services;

namespace Core.Dtos;

/// <summary>
/// Represents the return response from <see cref="IPostalCodeService"/> interface
/// </summary>
public class PostalCodeDto
{
    public PostalCodeDto(string street, string city, string state)
    {
        Street = street;
        City = city;
        State = state;
    }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}