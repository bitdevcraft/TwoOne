// Copyright (c) Ryan Capio.
// All Rights Reserved.

namespace TwoOne.Domain.Common.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
