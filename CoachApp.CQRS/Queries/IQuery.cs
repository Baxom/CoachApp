using MediatR;

namespace CoachApp.DDD.Queries;
public interface IQuery : IBaseRequest
{
}

public interface IQuery<out TResponse> : IQuery, IRequest<TResponse>
{
}
