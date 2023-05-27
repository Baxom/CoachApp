using System.Collections.ObjectModel;
using CoachApp.CQRS.DomainEvents;

namespace CoachApp.CQRS.Aggregates;
public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly IList<IDomainEvent> _domainEvents;

    IReadOnlyCollection<IDomainEvent> IAggregateRoot.DomainEvents => new ReadOnlyCollection<IDomainEvent>(_domainEvents);
    void IAggregateRoot.ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    protected AggregateRoot(bool initId = false) : base(initId)
    {
        _domainEvents= new List<IDomainEvent>();
    }
}
