using MediatR;

namespace CoachApp.CQRS.Queries;
public interface IQuery : IBaseRequest
{
}

public interface IQuery<out TResponse> : IQuery, IRequest<TResponse>
{
}
