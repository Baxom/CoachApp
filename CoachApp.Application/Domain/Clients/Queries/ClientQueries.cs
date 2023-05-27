using CoachApp.Application.Domain.Clients.Models;
using CoachApp.CQRS.Queries;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Clients;

namespace CoachApp.Application.Domain.Clients.Queries;
public record GetClientById(Guid ClientId) : IQuery<ExistingResult<Client>>;

public record GetClientExistsById(Guid ClientId) : IQuery<bool>;

public record GetClientIdentities : IStreamQuery<ClientIdentity>;
