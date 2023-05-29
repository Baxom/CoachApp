using CoachApp.Application.Domain.Services.Models;
using CoachApp.Application.Domain.Services.Queries;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Services;
using CoachApp.EFCore.Core.Readers;
using CoachApp.EFCore.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf.Types;

namespace CoachApp.EFCore.Domain.Services;

internal class ServiceReader : EFCoreReader<Service>, IRequestHandler<GetServiceExistsById, bool>,
                                                    IRequestHandler<GetServiceById, ExistingResult<Service>>,
                                                    IStreamRequestHandler<GetAllServices, ServiceModel>
{
    public ServiceReader(CoachAppContext coachAppContext) : base(coachAppContext)
    {
    }

    public async Task<ExistingResult<Service>> Handle(GetServiceById request, CancellationToken cancellationToken)
    {
        var service = await _set.FirstOrDefaultAsync(b => b.Id == request.ServiceId);

        if (service is null) return new NotFound();

        return service;
    }

    public IAsyncEnumerable<ServiceModel> Handle(GetAllServices request, CancellationToken cancellationToken)
        => _set.OrderBy(b => b.Name)
               .Select(b => new ServiceModel(b.Id, b.Name, b.IsPersonalServices))
                .AsAsyncEnumerable();

    public Task<bool> Handle(GetServiceExistsById request, CancellationToken cancellationToken) => _set.AnyAsync(b => b.Id == request.ServiceId);
}

