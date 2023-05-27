using CoachApp.CQRS.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Services;
using MediatR;

namespace CoachApp.Application.Domain.Services.Commands;
public record UpdateService(Guid Id, string Name, bool IsPersonalServices) : ICommand<ValidateExistingResult<Service>>;
