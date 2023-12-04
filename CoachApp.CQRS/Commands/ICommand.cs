using MediatR;

namespace CoachApp.DDD.Commands;
public interface ICommand : IBaseRequest
{
}

public interface ICommand<out TResponse> : ICommand, IRequest<TResponse>
{
}
