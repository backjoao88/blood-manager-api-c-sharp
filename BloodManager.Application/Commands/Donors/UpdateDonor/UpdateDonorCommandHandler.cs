using System.Diagnostics.CodeAnalysis;
using Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Primitives;
using Core.Primitives.Result;
using Core.ValueObjects;

namespace Application.Commands.Donors.UpdateDonor;

/// <summary>
/// Represents the <see cref="UpdateDonorCommand"/> handler
/// </summary>
public class UpdateDonorCommandHandler : IBkRequestHandler<UpdateDonorCommand, Result>
{
    public UpdateDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    private readonly IUnitOfWork _unitOfWork;
    public async Task<Result> HandleAsync(UpdateDonorCommand request)
    {
        var donor = await _unitOfWork.DonorRepository.FindByIdAsync(request.Id);
        if (donor is null)
        {
            return Result.Fail(DomainErrors.Donor.NotFoundDonorError);
        }
        var newFirstName = request.FirstName is not null && request.FirstName.Any() ? request.FirstName : donor.FirstName;
        var newLastName = request.LastName is not null && request.LastName.Any() ? request.LastName : donor.LastName;
        var newEmail = request.Email is not null && request.Email.Any() ? new Email(request.Email) : donor.Email;
        var newAddressStreet =
            request.Address is not null && request.Address.Street.Any()
                ? request.Address.Street
                : donor.Address.Street;
        var newAddressPostalCode = request.Address is not null && request.Address.PostalCode.Any()
            ? request.Address.PostalCode
            : donor.Address.PostalCode;
        var newAddressState = request.Address is not null && request.Address.State.Any()
            ? request.Address.State
            : donor.Address.PostalCode;
        var newAddressCity = request.Address is not null && request.Address.City.Any()
            ? request.Address.City
            : donor.Address.City;
        var newAddress = new Address(newAddressStreet, newAddressPostalCode, newAddressState, newAddressCity);
        donor.Update(
            newFirstName, 
            newLastName, 
            newEmail,
            newAddress
        );
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}