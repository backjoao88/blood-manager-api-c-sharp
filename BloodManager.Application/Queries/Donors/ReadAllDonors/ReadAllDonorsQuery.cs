using Application.Abstractions.BkMediator;
using Application.ViewModels;

namespace Application.Queries.Donors.ReadAllDonors;

/// <summary>
/// Represents the query for querying all donors
/// </summary>
public record ReadAllDonorsQuery : IBkRequest<IEnumerable<DonorViewModel>>;