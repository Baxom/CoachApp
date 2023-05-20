using CoachApp.Application.Domain.Services.Models;
using MediatR;

namespace CoachApp.Application.Domain.Services.Queries;
public record GetAllServices : IStreamRequest<ServiceModel>;
