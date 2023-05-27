﻿using CoachApp.Application.Core.Repositories;
using CoachApp.Application.Domain.Services.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Services;
using MediatR;
using OneOf.Types;

namespace CoachApp.Application.Domain.Services.Handlers;
internal class ServiceCommandHandler : IRequestHandler<CreateService, ValidateResult<Service>>,
                                        IRequestHandler<UpdateService, ValidateExistingResult<Service>>
{
    private readonly IRepository<Service> _serviceRepository;

    public ServiceCommandHandler(IRepository<Service> clientRepository)
    {
        _serviceRepository = clientRepository;
    }

    public async Task<ValidateResult<Service>> Handle(CreateService createService, CancellationToken cancellationToken)
    {
        Service service = await _serviceRepository.Add(Service.Create(createService.Name,
                                                        createService.IsPersonalServices));
        throw new NotImplementedException();

        return service;
    }

    public async Task<ValidateExistingResult<Service>> Handle(UpdateService updateService, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.Get(updateService.Id);

        if (service is null) return new NotFound();

        service.Update(updateService.Name, updateService.IsPersonalServices);

        await _serviceRepository.Update(service);

        return service;
    }
}