using CoachApp.Domain._Common;
using CoachApp.Domain.Clients;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Commands;
public record AddPackToClient(Guid ClientId, Guid serviceId, DateTime? paymentDate, Price price, int numberOfSessions) : IRequest<Client>;
