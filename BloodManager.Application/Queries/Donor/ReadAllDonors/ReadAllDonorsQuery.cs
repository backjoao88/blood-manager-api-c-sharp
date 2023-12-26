using Application.ViewModels;
using BloodManager.Application.Abstractions.BkMediator;

namespace Application.Queries.Donor.ReadAllDonors;

public record ReadAllDonorsQuery : IBkRequest<IEnumerable<DonorViewModel>>;