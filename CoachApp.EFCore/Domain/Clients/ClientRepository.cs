using CoachApp.Application.Domain.Clients.Queries;
using CoachApp.Domain.Clients;
using CoachApp.EFCore.Core.Repositories;
using CoachApp.EFCore.Database;
using MediatR;

namespace CoachApp.EFCore.Domain.Clients;
internal class ClientRepository : EFCoreRepository<Client>, IRequestHandler<GetClientById, Client?>
{
    public ClientRepository(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }

    public Task<Client?> Handle(GetClientById request, CancellationToken cancellationToken) => Get(request.ClientId, cancellationToken);
}
