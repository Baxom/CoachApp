using CoachApp.CQRS.Results;
using CoachApp.Domain.Services;
using MediatR;

namespace CoachApp.Application.Domain.Services.Commands;
public record CreateService(string Name, bool IsPersonalServices) : IRequest<ValidateResult<Service>>;
