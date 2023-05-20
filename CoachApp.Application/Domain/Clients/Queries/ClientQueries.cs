using CoachApp.Application.Domain.Clients.Models;
using CoachApp.Domain.Clients;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Queries;
public record GetClientById(Guid ClientId) : IRequest<Client>;

public record GetClientExistsById(Guid ClientId) : IRequest<bool>;

public record GetClientIdentities : IStreamRequest<ClientIdentity>;
