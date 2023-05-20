﻿using CoachApp.Domain.Services;
using MediatR;

namespace CoachApp.Application.Domain.Services.Commands;
public record UpdateService(Guid Id, string Name, bool IsPersonalServices) : IRequest<Service>;