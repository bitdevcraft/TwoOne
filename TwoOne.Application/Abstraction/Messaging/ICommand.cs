using MediatR;
using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
