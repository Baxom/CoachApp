namespace CoachApp.Application.Domain.Packs.Models;
public record PackModel(Guid Id, Guid ClientId, Guid ServiceId, DateTime? PaymentDate, decimal Amount, int NumberOfSession, int RemainingSession);
