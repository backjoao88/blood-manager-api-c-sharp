using Application.Abstractions.BkMediator;
using Application.ViewModels;
using Core.Contracts;

namespace Application.Queries.Donations.ReadDonationWithinDays;

/// <summary>
/// Represents the <see cref="ReadDonationWithinDays"/> handler
/// </summary>
public class ReadDonationWithinDaysHandler : IBkRequestHandler<ReadDonationWithinDays, List<DonationViewModelSimple>>
{
    private readonly IUnitOfWork _unitOfWork;
    public ReadDonationWithinDaysHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DonationViewModelSimple>> HandleAsync(ReadDonationWithinDays request)
    {
        var donations = await _unitOfWork.DonationRepository.GetDonationsWithinDaysAsync(request.Days);
        var donationsViewModel = donations
            .Select(o => new DonationViewModelSimple(o.Id, o.DonationDate, o.QuantityMl))
            .ToList();
        return donationsViewModel;
    }
}