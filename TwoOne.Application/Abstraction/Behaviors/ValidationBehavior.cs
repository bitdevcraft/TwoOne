using FluentValidation;
using FluentValidation.Results;

using MediatR;

using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.Abstraction.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        ValidationResult[] validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken))
        );

        List<string> failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .Select(error => error.ErrorMessage)
            .ToList();

        if (failures.Count <= 0)
        {
            return await next();
        }

        // Return a failure result if there are validation errors
        return BehaviorResult<TResponse>
            .CreateFailureResult(failures);
    }
}