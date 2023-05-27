using CoachApp.CQRS.Aggregates;
using CoachApp.CQRS.Commands;
using MediatR;
using OneOf;

namespace CoachApp.CQRS.Mediatr;
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

        if (response is IOneOf oneOf && oneOf.Value is IAggregateRoot aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.DomainEvents)
                await _publisher.Publish(domainEvent);

            aggregateRoot.ClearDomainEvents(); 
        }

        return response;
    }

}

