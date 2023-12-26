namespace Application.ViewModels;

/// <summary>
/// Represents a simplification of the donor entity
/// </summary>
public sealed class DonorViewModel
{
    public DonorViewModel(string firstName)
    {
        FirstName = firstName;
    }
    public string FirstName { get; set; }
}