using CoachApp.Application.Domain.Services.Models;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Services;
using MediatR;

namespace CoachApp.Application.Domain.Services.Queries;


public record GetServiceById(Guid ServiceId) : IRequest<ExistingResult<Service>>;
public record GetServiceExistsById(Guid ServiceId) : IRequest<bool>;
public record GetAllServices : IStreamRequest<ServiceModel>;
