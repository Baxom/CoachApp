using CoachApp.Application.Domain.Services.Models;
using CoachApp.CQRS.Queries;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Services;

namespace CoachApp.Application.Domain.Services.Queries;


public record GetServiceById(Guid ServiceId) : IQuery<ExistingResult<Service>>;
public record GetServiceExistsById(Guid ServiceId) : IQuery<bool>;
public record GetAllServices : IStreamQuery<ServiceModel>;
