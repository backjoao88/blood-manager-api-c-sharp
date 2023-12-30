using Application.ViewModels;
using BloodManager.Application.Abstractions.BkMediator;

namespace Application.Queries.Donors.ReadAllDonors;

/// <summary>
/// Represents the query for querying all donors
/// </summary>
public record ReadAllDonorsQuery : IBkRequest<IEnumerable<DonorViewModel>>;