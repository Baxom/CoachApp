using CoachApp.Application.Domain.Clients.Models;
using CoachApp.Application.Domain.Clients.Queries;
using CoachApp.Domain.Clients;
using CoachApp.EFCore.Core.Repositories;
using CoachApp.EFCore.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.EFCore.Domain.Clients;
internal class ClientRepository : EFCoreRepository<Client>, IRequestHandler<GetClientById, Client?>,
                                                                IStreamRequestHandler<GetClientIdentities, ClientIdentity>
{
    public ClientRepository(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }

    public Task<Client?> Handle(GetClientById request, CancellationToken cancellationToken) => Get(request.ClientId, cancellationToken);

    public IAsyncEnumerable<ClientIdentity> Handle(GetClientIdentities request, CancellationToken cancellationToken)
        => _coachAppContext.Set<Client>()
                            .OrderBy(b => b.Lastname)
                            .ThenBy(b => b.Firstname)
                            .Select(b => new ClientIdentity(b.Id, b.Lastname, b.Firstname))
                            .AsAsyncEnumerable();
}
