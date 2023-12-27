﻿using BloodManager.Application.Abstractions.BkMediator;
using Core.Primitives.Result;

namespace Application.Commands.DeleteDonor;

/// <summary>
/// Represents the command for soft-removing a donor from the database.
/// </summary>
public class DeleteDonorCommand : IBkRequest<Result>
{
    public DeleteDonorCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}