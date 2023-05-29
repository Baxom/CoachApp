using CoachApp.Application.Core.Repositories;
using CoachApp.Application.Domain.Services.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Services;
using MediatR;
using OneOf.Types;

namespace CoachApp.Application.Domain.Services.Handlers;
internal class ServiceCommandHandler : IRequestHandler<CreateService, ValidateResult<Service>>,
                                        IRequestHandler<UpdateService, ValidateExistingResult<Service>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ValidateResult<Service>> Handle(CreateService createService, CancellationToken cancellationToken)
    {
        Service service = await _unitOfWork.Services.Add(Service.Create(createService.Name,
                                                        createService.IsPersonalServices));
       
        await _unitOfWork.SaveChangesAsync();

        return service;
    }

    public async Task<ValidateExistingResult<Service>> Handle(UpdateService updateService, CancellationToken cancellationToken)
    {
        var service = await _unitOfWork.Services.Get(updateService.Id);

        if (service is null) return new NotFound();

        service.Update(updateService.Name, updateService.IsPersonalServices);

        await _unitOfWork.Services.Update(service);

        await _unitOfWork.SaveChangesAsync();

        return service;
    }
}
