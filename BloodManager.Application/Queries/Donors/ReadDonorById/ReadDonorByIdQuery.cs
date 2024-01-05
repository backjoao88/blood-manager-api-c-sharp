using Application.Abstractions.BkMediator;
using Application.ViewModels;
using Core.Primitives.Result;

namespace Application.Queries.Donors.ReadDonorById;

/// <summary>
/// Represents the query for querying a specific donor
/// </summary>
public class ReadDonorByIdQuery : IBkRequest<Result<DonorViewModel>>
{
    public ReadDonorByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}