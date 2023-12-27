using BloodManager.Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Primitives;
using Core.Primitives.Result;

namespace Application.Commands.DeleteDonor;

/// <summary>
/// Represents the <see cref="DeleteDonorCommand"/> handler
/// </summary>
public class DeleteDonorCommandHandler : IBkRequestHandler<DeleteDonorCommand, Result>
{
    public DeleteDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    private readonly IUnitOfWork _unitOfWork;

    public async Task<Result> HandleAsync(DeleteDonorCommand request)
    {
        var donor = await _unitOfWork.DonorRepository.FindByIdAsync(request.Id);
        if (donor is null)
        {
            return Result.Fail(GenericErrors.NotFound);
        }
        _unitOfWork.DonorRepository.Remove(donor);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}