using MediatR;

namespace TwoOne.Domain.Common.Shared.Results;

public class Result : Result<Unit>
{
    // Constructor to initialize Result with Unit type (no value)
    private Result(bool success, List<string>? errors)
        : base(success, Unit.Value, errors)
    {
    }

    // Factory method for success result
    public static Result SuccessResult()
    {
        return new Result(true, null);
    }

    // Factory method for failure result with a list of errors
    public static new Result FailureResult(List<string> errors)
    {
        return new Result(false, errors);
    }

    // Factory method for failure result with a single error message
    public static new Result FailureResult(string error)
    {
        return FailureResult([error]);
    }
}