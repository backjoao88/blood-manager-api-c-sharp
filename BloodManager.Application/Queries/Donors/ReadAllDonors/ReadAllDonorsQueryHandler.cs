using Application.Abstractions.BkMediator;
using Application.ViewModels;
using BloodManager.Application.Abstractions.BkMediator;
using Core.Contracts;

namespace Application.Queries.Donors.ReadAllDonors;

/// <summary>
/// Represents the <see cref="ReadAllDonorsQuery"/> query
/// </summary>
public class ReadAllDonorsQueryHandler : IBkRequestHandler<ReadAllDonorsQuery, IEnumerable<DonorViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReadAllDonorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<DonorViewModel>> HandleAsync(ReadAllDonorsQuery request)
    {
        var donors = await _unitOfWork.DonorRepository.FindAllAsync();
        var donorsViewModel = donors.Select(o => new DonorViewModel(o.Id, o.FirstName, o.LastName, o.Email.Value, o.Address, o.Weight, o.Birth, o.BloodType, o.BloodRhFactor, o.Genre));
        return donorsViewModel;
    }
}