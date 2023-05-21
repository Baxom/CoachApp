using CoachApp.Application.Core.Repositories;
using CoachApp.CQRS.Exceptions;
using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Entities;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Commands.Handler;
internal class ClientCommandHandler : IRequestHandler<CreateClient, Client>,
                                        IRequestHandler<UpdateClient, Client>,
                                        IRequestHandler<AddPackToClient, Client>
{
    private readonly IRepository<Client> _clientRepository;

    public ClientCommandHandler(IRepository<Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Task<Client> Handle(CreateClient createClient, CancellationToken cancellationToken) => _clientRepository.Add(Client.Create(createClient.Lastname,
                                                createClient.Firstname,
                                                createClient.BirthDate,
                                                createClient.ContactDetails,
                                                createClient.Adress));

    public async Task<Client> Handle(UpdateClient updateClient, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.Get(updateClient.Id) ?? throw new AggregateNotFoundException(typeof(Client), updateClient.Id);

        client.Update(updateClient.Lastname, updateClient.Firstname, updateClient.BirthDate, updateClient.ContactDetails, updateClient.Adress);

        await _clientRepository.Update(client);

        return client!;
    }

    public async Task<Client> Handle(AddPackToClient request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.Get(request.ClientId) ?? throw new AggregateNotFoundException(typeof(Client), request.ClientId);

        client.AddPack(Pack.Create(request.serviceId, request.paymentDate, request.price, request.numberOfSessions));

        return client!;
    }
}
