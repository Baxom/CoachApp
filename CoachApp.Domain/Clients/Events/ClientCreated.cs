using CoachApp.DDD.DomainEvents;

namespace CoachApp.Domain.Clients.Events;
public record struct ClientCreated(Guid clientId) : IDomainEvent;
