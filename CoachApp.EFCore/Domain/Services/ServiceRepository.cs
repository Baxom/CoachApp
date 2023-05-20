using CoachApp.Application.Domain.Services.Models;
using CoachApp.Application.Domain.Services.Queries;
using CoachApp.Domain.Services;
using CoachApp.EFCore.Core.Repositories;
using CoachApp.EFCore.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.EFCore.Domain.Services;
internal class ServiceRepository : EFCoreRepository<Service>, IRequestHandler<GetServiceById, Service?>,
                                                                IStreamRequestHandler<GetAllServices, ServiceModel>
{
    public ServiceRepository(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }

    public Task<Service?> Handle(GetServiceById request, CancellationToken cancellationToken) => Get(request.ServiceId, cancellationToken);

    public IAsyncEnumerable<ServiceModel> Handle(GetAllServices request, CancellationToken cancellationToken)
        => _coachAppContext.Services
                            .OrderBy(b => b.Name)
                            .Select(b => new ServiceModel(b.Id, b.Name, b.IsPersonalServices))
                            .AsAsyncEnumerable();
}
