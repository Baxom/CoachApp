using CoachApp.DDD.Aggregates;
using CoachApp.DDD.Commands;
using MediatR;
using OneOf;

namespace CoachApp.DDD.Mediatr;
public class EventPublisherBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand //where TResponse : IAggregateRoot
{
    private readonly IPublisher _publisher;

    public EventPublisherBehavior(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = (await next());

        if (response is IOneOf { Value: IAggregateRoot aggregateRoot })
        {
            foreach (var domainEvent in aggregateRoot.DomainEvents)
                await _publisher.Publish(domainEvent);

            aggregateRoot.ClearDomainEvents(); 
        }

        return response;
    }

}

