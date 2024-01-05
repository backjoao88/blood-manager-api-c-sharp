using Application.Abstractions.BkMediator;
using Application.ViewModels;

namespace Application.Queries.Donations.ReadDonationByDonorId;

/// <summary>
/// Represents the query for querying a specified donation by donor id
/// </summary>
public class ReadDonationByDonorId : IBkRequest<List<DonationViewModelSimple>>
{
    public ReadDonationByDonorId(Guid idDonor)
    {
        IdDonor = idDonor;
    }
    public Guid IdDonor { get; set; }
}