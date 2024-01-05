using Application.Abstractions.BkMediator;
using Application.ViewModels;
using Core.Contracts;
using Core.Primitives;
using Core.Primitives.Result;

namespace Application.Queries.Donors.ReadDonorById;

/// <summary>
/// Represents the <see cref="ReadDonorByIdQuery"/> handler
/// </summary>
public class ReadDonorByIdQueryHandler : IBkRequestHandler<ReadDonorByIdQuery, Result<DonorViewModel>>
{
    public ReadDonorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    private readonly IUnitOfWork _unitOfWork;

    public async Task<Result<DonorViewModel>> HandleAsync(ReadDonorByIdQuery request)
    {
        var donor = await _unitOfWork.DonorRepository.FindByIdAsync(request.Id);
        if (donor is null)
        {
            return Result.Fail<DonorViewModel>(GenericErrors.NotFound);
        }
        return Result.Ok(new DonorViewModel(donor.Id, donor.FirstName, donor.LastName, donor.Email.Value, donor.Address, donor.Weight, donor.Birth, donor.BloodType, donor.BloodRhFactor, donor.Genre));
    }
}