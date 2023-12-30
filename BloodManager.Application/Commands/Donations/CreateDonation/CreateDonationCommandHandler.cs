using Application.Abstractions.BkMediator;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Entities;
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
        var donation = new Donation(DateTime.Now, request.QuantityMl, request.IdDonor);
        
        await _unitOfWork.DonationRepository.SaveAsync(donation);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}