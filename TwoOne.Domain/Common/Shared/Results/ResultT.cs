namespace TwoOne.Domain.Common.Shared.Results;

public class Result<T>
{
    public bool Success { get; private set; }

    public T? Value { get; private set; }

    public List<string> Errors { get; private set; }

    protected Result(bool success, T? value, List<string>? errors)
    {
        Success = success;
        Value = value;
        Errors = errors ?? [];
    }

    public static Result<T> SuccessResult(T value)
    {
        return new Result<T>(true, value, null);
    }

    public static Result<T> FailureResult(List<string> errors)
    {
        return new Result<T>(false, default, errors);
    }

    public static Result<T> FailureResult(string error)
    {
        return FailureResult([error]);
    }
}