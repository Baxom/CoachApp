using CoachApp.Domain.Services;
using MediatR;

namespace CoachApp.Application.Domain.Services.Queries;
public record GetServiceById(Guid ServiceId) : IRequest<Service>;
