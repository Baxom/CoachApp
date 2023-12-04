using CoachApp.DDD.DomainEvents;

namespace CoachApp.DDD.Aggregates;
public interface IAggregateRoot : IEntity
{
    internal IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    internal void ClearDomainEvents();

}
