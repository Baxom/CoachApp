using CoachApp.Application.Domain.Packs.Models;
using CoachApp.Domain.Packs;
using MediatR;

namespace CoachApp.Application.Domain.Packs.Queries;

public record GetPackById(Guid PackId) : IRequest<Pack>;

public record GetAllPacks : IStreamRequest<PackModel>;