using CoachApp.Application.Core.Repositories;
using CoachApp.Application.Domain.Clients.Commands;
using CoachApp.CQRS.Results;
using CoachApp.DDD.Results;
using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Entities;
using MediatR;
using OneOf.Types;

namespace CoachApp.Application.Domain.Clients.Handlers;
internal class ClientCommandHandler : IRequestHandler<CreateClient, ValidateResult<Client>>,
                                        IRequestHandler<UpdateClient, ValidateExistingResult<Client>>,
                                        IRequestHandler<AddPackToClient, ValidateExistingResult<Client>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ValidateResult<Client>> Handle(CreateClient createClient, CancellationToken cancellationToken) => await _unitOfWork.Clients.Add(Client.Create(createClient.Lastname,
                                                createClient.Firstname,
                                                createClient.BirthDate,
                                                createClient.ContactDetails,
                                                createClient.Address));

    public async Task<ValidateExistingResult<Client>> Handle(UpdateClient updateClient, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.Get(updateClient.Id);

        if (client is null) return new NotFound();

        client.Update(updateClient.Lastname, updateClient.Firstname, updateClient.BirthDate, updateClient.ContactDetails, updateClient.Address);

        await _unitOfWork.Clients.Update(client);

        await _unitOfWork.SaveChangesAsync();

        return client!;
    }

    public async Task<ValidateExistingResult<Client>> Handle(AddPackToClient request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.Get(request.ClientId);

        if (client is null) return new NotFound();

        client.AddPack(Pack.Create(request.ServiceId, request.PaymentDate, request.Price, request.NumberOfSessions));

        await _unitOfWork.SaveChangesAsync();

        return client!;
    }
}
