using CoachApp.Application.Core.Repositories;
using CoachApp.CQRS.Exceptions;
using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Entities;
using FluentValidation;
using MediatR;
using OneOf.Types;
using OneOf;
using FluentValidation.Results;
using CoachApp.CQRS.Results;
using System.Reflection.Metadata.Ecma335;

namespace CoachApp.Application.Domain.Clients.Commands.Handler;
internal class ClientCommandHandler : IRequestHandler<CreateClient, ValidateResult<Client>>,
                                        IRequestHandler<UpdateClient, ValidateExistingResult<Client>>,
                                        IRequestHandler<AddPackToClient, ValidateExistingResult<Client>>
{
    private readonly IRepository<Client> _clientRepository;

    public ClientCommandHandler(IRepository<Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ValidateResult<Client>> Handle(CreateClient createClient, CancellationToken cancellationToken) => await _clientRepository.Add(Client.Create(createClient.Lastname,
                                                createClient.Firstname,
                                                createClient.BirthDate,
                                                createClient.ContactDetails,
                                                createClient.Adress));

    public async Task<ValidateExistingResult<Client>> Handle(UpdateClient updateClient, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.Get(updateClient.Id);

        if (client is null) return new NotFound();

        client.Update(updateClient.Lastname, updateClient.Firstname, updateClient.BirthDate, updateClient.ContactDetails, updateClient.Adress);

        await _clientRepository.Update(client);

        return client!;
    }

    public async Task<ValidateExistingResult<Client>> Handle(AddPackToClient request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.Get(request.ClientId);

        if (client is null) return new NotFound();

        client.AddPack(Pack.Create(request.serviceId, request.paymentDate, request.price, request.numberOfSessions));

        return client!;
    }
}
