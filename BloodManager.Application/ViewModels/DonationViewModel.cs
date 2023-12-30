using Core.Entities;

namespace Application.ViewModels;

/// <summary>
/// Represents a simplification of the donation entity
/// </summary>
public class DonationViewModel
{
    public DonationViewModel(Guid id, DateTime donationDate, double quantityMl, DonorViewModel? donor)
    {
        Id = id;
        DonationDate = donationDate;
        QuantityMl = quantityMl;
        Donor = donor;
    }
    public Guid Id { get; set; }
    public DateTime DonationDate { get; set; }
    public double QuantityMl { get; set; }
    
    public DonorViewModel? Donor { get; set; }
}