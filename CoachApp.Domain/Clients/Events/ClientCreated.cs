using CoachApp.CQRS.DomainEvents;

namespace CoachApp.Domain.Clients.Events;
public record struct ClientCreated(Guid clientId) : IDomainEvent;
