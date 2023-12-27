﻿using BloodManager.Application.Abstractions.BkMediator;
using Core.Contracts;
using Core.Entities;
using Core.Primitives;
using Core.Primitives.Result;
using Core.ValueObjects;

namespace Application.Commands.CreateDonor;

/// <summary>
/// Represents the <see cref="CreateDonorCommand"/> handler
/// </summary>
public class CreateDonorCommandHandler : IBkRequestHandler<CreateDonorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(CreateDonorCommand request)
    {
        var email = new Email(request.Email);
        var donor = new Donor(request.FirstName, request.LastName, email, request.Address, request.Weight, request.Birth);
        if (!await _unitOfWork.DonorRepository.IsEmailUnique(email))
        {
            return Result.Fail(DomainErrors.Donor.EmailNotUniqueError);
        }
        await _unitOfWork.DonorRepository.SaveAsync(donor);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}