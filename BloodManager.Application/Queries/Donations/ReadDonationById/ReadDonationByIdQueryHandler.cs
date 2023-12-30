using Application.Abstractions.BkMediator;
using Application.ViewModels;
using Core.Contracts;
using Core.Primitives;
using Core.Primitives.Result;

namespace Application.Queries.Donations.ReadDonationById;


/// <summary>
/// Represents the <see cref="ReadDonationById"/> handler
/// </summary>
public class ReadDonationByIdQueryHandler : IBkRequestHandler<ReadDonationByIdQuery, Result<DonationViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    public ReadDonationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DonationViewModel>> HandleAsync(ReadDonationByIdQuery request)
    {
        var donation = await _unitOfWork.DonationRepository.FindByIdAsync(request.Id);
        if (donation is null)
        {
            return Result.Fail<DonationViewModel>(GenericErrors.NotFound);
        }
        
        var donationViewModel = new DonationViewModel(donation.Id, donation.DonationDate,  donation.QuantityMl, 
                donation.Donor is not null ? 
                    new DonorViewModel(
                        donation.Donor.Id, 
                        donation.Donor.FirstName, 
                        donation.Donor.LastName, 
                        donation.Donor.Email.Value, 
                        donation.Donor.Address, 
                        donation.Donor.Weight, 
                        donation.Donor.Birth
                    ) : null
        );
        return Result.Ok(donationViewModel);
    }
}