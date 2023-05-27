using CoachApp.CQRS.DomainEvents;

namespace CoachApp.CQRS.Aggregates;
public interface IAggregateRoot : IEntity
{
    internal IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    internal void ClearDomainEvents();

}
