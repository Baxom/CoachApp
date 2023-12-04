using MediatR;

namespace CoachApp.DDD.Queries;
public interface IStreamQuery<out TResponse> : IStreamRequest<TResponse>
{
}
