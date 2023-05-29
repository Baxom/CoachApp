using CoachApp.CQRS.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Services;

namespace CoachApp.Application.Domain.Services.Commands;
public record struct CreateService(string Name, bool IsPersonalServices) : ICommand<ValidateResult<Service>>;
