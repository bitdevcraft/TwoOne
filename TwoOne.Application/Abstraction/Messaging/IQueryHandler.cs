using MediatR;

using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.Abstraction.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}