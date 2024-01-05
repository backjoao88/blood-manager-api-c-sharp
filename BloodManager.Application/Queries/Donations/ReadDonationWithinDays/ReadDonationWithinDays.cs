using Application.Abstractions.BkMediator;
using Application.ViewModels;

namespace Application.Queries.Donations.ReadDonationWithinDays;

/// <summary>
/// Represents the query to retrieve last donations based on a number of days
/// </summary>
public class ReadDonationWithinDays : IBkRequest<List<DonationViewModelSimple>>
{
    public ReadDonationWithinDays(int days)
    {
        Days = days;
    }
    public int Days { get; set; }
}