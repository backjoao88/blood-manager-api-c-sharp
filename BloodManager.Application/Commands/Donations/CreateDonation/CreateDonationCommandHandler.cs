using System.Runtime.InteropServices.JavaScript;
using Application.Abstractions.BkMediator;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Entities;
using Core.Primitives;
using Core.Primitives.Result;

namespace Application.Commands.Donations.CreateDonation;

/// <summary>
/// Represents the <see cref="CreateDonationCommand"/> handler
/// </summary>
public class CreateDonationCommandHandler : IBkRequestHandler<CreateDonationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateDonationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> HandleAsync(CreateDonationCommand request)
    {
        var donor = await _unitOfWork.DonorRepository.FindByIdAsync(request.IdDonor);
        if (donor is null)
        {
            return Result.Fail(DomainErrors.Donor.NotFoundDonorError);
        }
        var donorCanDonateResult = donor.CanDonate();
        if (donorCanDonateResult.IsFailure)
        {
            return Result.Fail(donorCanDonateResult.Error);
        }
        var lastDonation = await _unitOfWork.DonationRepository.GetLastDonationFromAsync(request.IdDonor);
        if (lastDonation is not null)
        {
            var checkDonationIntervalResult = donor.CheckDonationInterval(lastDonation.DonationDate);
            if (checkDonationIntervalResult.IsFailure)
            {
                return Result.Fail(checkDonationIntervalResult.Error);
            }
        }
        var donation = new Donation(DateTime.Now, request.QuantityMl, request.IdDonor);
        var donationQuantityCheckResult = donation.IsValidQuantity();
        if (donationQuantityCheckResult.IsFailure)
        {
            return Result.Fail(donationQuantityCheckResult.Error);
        }
        await _unitOfWork.DonationRepository.SaveAsync(donation);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}