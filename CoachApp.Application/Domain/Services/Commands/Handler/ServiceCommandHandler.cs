using CoachApp.Application.Core.Repositories;
using CoachApp.CQRS.Exceptions;
using CoachApp.Domain.Services;
using MediatR;

namespace CoachApp.Application.Domain.Services.Commands.Handler;
internal class ServiceCommandHandler : IRequestHandler<CreateService, Service>,
                                        IRequestHandler<UpdateService, Service>
{
    private readonly IRepository<Service> _serviceRepository;

    public ServiceCommandHandler(IRepository<Service> clientRepository)
    {
        _serviceRepository = clientRepository;
    }

    public Task<Service> Handle(CreateService createService, CancellationToken cancellationToken)
    {
        return _serviceRepository.Add(Service.Create(createService.Name,
                                                createService.IsPersonalServices));
    }

    public async Task<Service> Handle(UpdateService updateService, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.Get(updateService.Id) ?? throw new AggregateNotFoundException(typeof(Service), updateService.Id);

        service.Update(updateService.Name, updateService.IsPersonalServices);

        await _serviceRepository.Update(service);

        return service;
    }
}
