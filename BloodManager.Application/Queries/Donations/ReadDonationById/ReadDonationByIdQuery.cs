using Application.Abstractions.BkMediator;
using Application.ViewModels;
using Core.Primitives.Result;

namespace Application.Queries.Donations.ReadDonationById;

/// <summary>
/// Represents the query for querying a specified donation
/// </summary>
public class ReadDonationByIdQuery : IBkRequest<Result<DonationViewModel>>
{
    public ReadDonationByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}