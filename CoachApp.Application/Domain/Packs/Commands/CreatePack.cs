using CoachApp.Domain.Packs;
using MediatR;

namespace CoachApp.Application.Domain.Packs.Commands;
public record CreatePack(Guid ClientId, Guid ServiceId, DateTime? PaymentDate, decimal Amount, int NumberOfSessions) : IRequest<Pack>;
