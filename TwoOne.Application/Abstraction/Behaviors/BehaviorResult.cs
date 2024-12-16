// Copyright (c) Ryan Capio.
// All Rights Reserved.

using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.Abstraction.Behaviors;

public static class BehaviorResult
{
    public static TResponse CreateFailureResult<TResponse>(List<string> failures) where TResponse : Result
    {
        return (TResponse)typeof(TResponse)
            .GetMethod(nameof(Result.FailureResult), [typeof(List<string>)])
            ?.Invoke(null, [failures])!;
    }
}
