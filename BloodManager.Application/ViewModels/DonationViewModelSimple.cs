namespace Application.ViewModels;

/// <summary>
/// Represents a simple donation view model
/// </summary>
public class DonationViewModelSimple
{
    public DonationViewModelSimple(Guid id, DateTime donationDate, double quantityMl)
    {
        Id = id;
        DonationDate = donationDate;
        QuantityMl = quantityMl;
    }
    public Guid Id { get; set; }
    public DateTime DonationDate { get; set; }
    public double QuantityMl { get; set; }
}