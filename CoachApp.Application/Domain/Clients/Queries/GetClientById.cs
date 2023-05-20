using CoachApp.Domain.Clients;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Queries;
public record GetClientById(Guid ClientId) : IRequest<Client>;
