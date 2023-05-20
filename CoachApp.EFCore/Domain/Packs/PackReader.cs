using CoachApp.Application.Domain.Packs.Models;
using CoachApp.Application.Domain.Packs.Queries;
using CoachApp.Domain.Packs;
using CoachApp.EFCore.Core.Readers;
using CoachApp.EFCore.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.EFCore.Domain.Packs;

internal class PackReader : EFCoreReader<Pack>, IStreamRequestHandler<GetAllPacks, PackModel>
{
    public PackReader(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }


    public IAsyncEnumerable<PackModel> Handle(GetAllPacks request, CancellationToken cancellationToken)
        => _set.Select(b => new PackModel(b.Id, b.ClientId, b.ServiceId, b.PaymentDate, b.Amount, b.NumberOfSessions, b.RemainingSessions)).AsAsyncEnumerable();
}