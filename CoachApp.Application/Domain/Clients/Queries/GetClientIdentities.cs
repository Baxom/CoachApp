using CoachApp.Application.Domain.Clients.Models;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Queries;
public record GetClientIdentities : IStreamRequest<ClientIdentity>;
