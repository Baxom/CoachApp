using CoachApp.Application.Domain.Services.Models;
using CoachApp.Application.Domain.Services.Queries;
using CoachApp.Domain.Services;
using CoachApp.EFCore.Core.Readers;
using CoachApp.EFCore.Core.Repositories;
using CoachApp.EFCore.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CoachApp.EFCore.Domain.Services;
internal class ServiceRepository : EFCoreRepository<Service>, IRequestHandler<GetServiceById, Service?>
{
    public ServiceRepository(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }

    public Task<Service?> Handle(GetServiceById request, CancellationToken cancellationToken) => Get(request.ServiceId, cancellationToken);
}

internal class ServiceReader : EFCoreReader<Service>, IRequestHandler<GetServiceExistsById, bool>,
                                                                IStreamRequestHandler<GetAllServices, ServiceModel>
{
    public ServiceReader(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }

    public IAsyncEnumerable<ServiceModel> Handle(GetAllServices request, CancellationToken cancellationToken)
        => _set.OrderBy(b => b.Name)
               .Select(b => new ServiceModel(b.Id, b.Name, b.IsPersonalServices))
                .AsAsyncEnumerable();

    public Task<bool> Handle(GetServiceExistsById request, CancellationToken cancellationToken) => _set.AnyAsync(b => b.Id == request.ServiceId);
}
