using CoachApp.Application.Domain.Clients.Models;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Clients;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Queries;
public record GetClientById(Guid ClientId) : IRequest<ExistingResult<Client>>;

public record GetClientExistsById(Guid ClientId) : IRequest<bool>;

public record GetClientIdentities : IStreamRequest<ClientIdentity>;
