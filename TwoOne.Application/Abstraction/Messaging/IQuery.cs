using MediatR;
using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
