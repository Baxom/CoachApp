using CoachApp.Application.Domain.Clients.Models;
using CoachApp.Application.Domain.Clients.Queries;
using CoachApp.CQRS.Results;
using CoachApp.DDD.Results;
using CoachApp.Domain.Clients;
using CoachApp.EFCore.Core.Readers;
using CoachApp.EFCore.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf.Types;

namespace CoachApp.EFCore.Domain.Clients;
internal class ClientReader : EFCoreReader<Client>, IRequestHandler<GetClientExistsById, bool>,
                                                                IRequestHandler<GetClientById, ExistingResult<Client>>,
                                                                IStreamRequestHandler<GetClientIdentities, ClientIdentity>
{
    public ClientReader(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }


    public IAsyncEnumerable<ClientIdentity> Handle(GetClientIdentities request, CancellationToken cancellationToken)
        => _set.OrderBy(b => b.Lastname)
                            .ThenBy(b => b.Firstname)
                            .Select(b => new ClientIdentity(b.Id, b.Lastname, b.Firstname))
                            .AsAsyncEnumerable();

    public Task<bool> Handle(GetClientExistsById request, CancellationToken cancellationToken) => _set.AnyAsync(b => b.Id == request.ClientId);

    public async Task<ExistingResult<Client>> Handle(GetClientById request, CancellationToken cancellationToken)
    {
        var client = await _set.FirstOrDefaultAsync(b => b.Id == request.ClientId);

        if (client is null) return new NotFound();

        return client;
    }
}
