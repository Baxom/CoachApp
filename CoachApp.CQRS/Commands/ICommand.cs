using MediatR;

namespace CoachApp.CQRS.Commands;
public interface ICommand : IBaseRequest
{
}

public interface ICommand<out TResponse> : ICommand, IRequest<TResponse>
{
}
