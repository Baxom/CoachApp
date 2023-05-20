using CoachApp.Application.Domain.Packs.Queries;
using CoachApp.Domain.Packs;
using CoachApp.EFCore.Core.Repositories;
using CoachApp.EFCore.Database;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;

namespace CoachApp.EFCore.Domain.Packs;
internal class PackRepository : EFCoreRepository<Pack>, IRequestHandler<GetPackById, Pack?>
{
    public PackRepository(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }

    public Task<Pack?> Handle(GetPackById request, CancellationToken cancellationToken) => Get(request.PackId, cancellationToken);
}
