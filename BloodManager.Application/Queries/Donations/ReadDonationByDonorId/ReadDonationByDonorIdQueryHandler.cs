using Application.Abstractions.BkMediator;
using Application.ViewModels;
using Core.Contracts;
using Core.Entities;

namespace Application.Queries.Donations.ReadDonationByDonorId;

/// <summary>
/// Represents the <see cref="ReadDonationByDonorId"/> handler
/// </summary>
public class ReadDonationByDonorIdQueryHandler : IBkRequestHandler<ReadDonationByDonorId, List<DonationViewModelSimple>>
{
    public ReadDonationByDonorIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    private readonly IUnitOfWork _unitOfWork;
    public async Task<List<DonationViewModelSimple>> HandleAsync(ReadDonationByDonorId request)
    {
        var donations = await _unitOfWork.DonationRepository.GetDonationsByDonorIdAsync(request.IdDonor);
        var donationsViewModel = donations.Select(o => new DonationViewModelSimple(o.Id, o.DonationDate, o.QuantityMl))
            .ToList();
        return donationsViewModel;
    }
}