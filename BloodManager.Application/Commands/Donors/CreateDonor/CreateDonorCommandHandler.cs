using Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Entities;
using Core.Primitives;
using Core.Primitives.Result;
using Core.Services;
using Core.ValueObjects;

namespace Application.Commands.Donors.CreateDonor;

/// <summary>
///     Represents the <see cref="CreateDonorCommand" /> handler
/// </summary>
public class CreateDonorCommandHandler : IBkRequestHandler<CreateDonorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostalCodeService _postalCodeService;

    public CreateDonorCommandHandler(IUnitOfWork unitOfWork, IPostalCodeService postalCodeService)
    {
        _unitOfWork = unitOfWork;
        _postalCodeService = postalCodeService;
    }

    public async Task<Result> HandleAsync(CreateDonorCommand request)
    {
        var email = new Email(request.Email);
        var isEmailUnique = await _unitOfWork.DonorRepository.IsEmailUnique(email);
        if (!isEmailUnique) return Result.Fail(DomainErrors.Donor.EmailNotUniqueError);
        // performing postal code check
        var address = new Address(request.Address.Street, request.Address.PostalCode, request.Address.City, request.Address.State); 
        if (request.Address.PostalCode.Any())
        {
            var postalCodeDto = await _postalCodeService.CheckPostalCodeAsync(request.Address.PostalCode);
            if (postalCodeDto is not null)
            {
                address.State = postalCodeDto.State.Any() ? postalCodeDto.State : address.State;
                address.Street = postalCodeDto.Street.Any() ? postalCodeDto.Street : address.Street;
                address.City = postalCodeDto.City.Any() ? postalCodeDto.City : address.City;
            }
        }
        var donor = new Donor(
            request.FirstName,
            request.LastName,
            email,
            address,
            request.Weight,
            request.Birth,
            request.BloodType,
            request.BloodRhFactor,
            request.Genre
        );
        await _unitOfWork.DonorRepository.SaveAsync(donor);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}