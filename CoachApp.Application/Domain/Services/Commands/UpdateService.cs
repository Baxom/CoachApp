﻿using CoachApp.CQRS.Results;
using CoachApp.DDD.Commands;
using CoachApp.DDD.Results;
using CoachApp.Domain.Services;

namespace CoachApp.Application.Domain.Services.Commands;
public record struct UpdateService(Guid Id, string Name, bool IsPersonalServices) : ICommand<ValidateExistingResult<Service>>;
