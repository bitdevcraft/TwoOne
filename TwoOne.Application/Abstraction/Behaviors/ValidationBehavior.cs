// Copyright (c) Ryan Capio.
// All Rights Reserved.

using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.Abstraction.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        ValidationResult[] validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(context, cancellationToken))
        );

        var failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .Select(error => error.ErrorMessage)
            .ToList();

        if (failures.Count <= 0)
        {
            return await next();
        }

        // Return a failure result if there are validation errors
        return BehaviorResult
            .CreateFailureResult<TResponse>(failures);
    }
}
