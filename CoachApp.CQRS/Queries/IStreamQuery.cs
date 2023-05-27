using MediatR;

namespace CoachApp.CQRS.Queries;
public interface IStreamQuery<out TResponse> : IStreamRequest<TResponse>
{
}
