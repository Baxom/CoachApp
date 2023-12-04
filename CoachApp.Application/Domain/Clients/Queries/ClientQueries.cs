using CoachApp.Application.Domain.Clients.Models;
using CoachApp.CQRS.Results;
using CoachApp.DDD.Queries;
using CoachApp.DDD.Results;
using CoachApp.Domain.Clients;

namespace CoachApp.Application.Domain.Clients.Queries;
public record GetClientById(Guid ClientId) : IQuery<ExistingResult<Client>>;

public record GetClientExistsById(Guid ClientId) : IQuery<bool>;

public record GetClientIdentities : IStreamQuery<ClientIdentity>;
