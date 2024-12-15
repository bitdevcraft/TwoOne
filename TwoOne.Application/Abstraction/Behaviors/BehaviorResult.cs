using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.Abstraction.Behaviors;

public static class BehaviorResult<TResponse> where TResponse : Result
{
    public static TResponse CreateFailureResult(List<string> failures)
        => (TResponse)typeof(TResponse)
            .GetMethod(nameof(Result.FailureResult), [typeof(List<string>)])
            ?.Invoke(null, [failures])!;
}