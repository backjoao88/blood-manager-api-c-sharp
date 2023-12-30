using BloodManager.Application.Abstractions.BkMediator;
using Core.Primitives.Result;
using Core.ValueObjects;

namespace Application.Commands.Donors.UpdateDonor;

/// <summary>
/// Represents the command for updating the donor information
/// </summary>
public class UpdateDonorCommand : IBkRequest<Result>
{
    public UpdateDonorCommand(Guid id, string? firstName, string? lastName, string? email, Address? address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
    }
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
}