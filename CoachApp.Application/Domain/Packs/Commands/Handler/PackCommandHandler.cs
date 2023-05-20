using CoachApp.Application.Core.Repositories;
using CoachApp.Application.Domain.Clients.Queries;
using CoachApp.Application.Domain.Services.Queries;
using CoachApp.CQRS.Exceptions;
using CoachApp.Domain.Packs;
using MediatR;

namespace CoachApp.Application.Domain.Packs.Commands.Handler;
internal class PackCommandHandler : IRequestHandler<CreatePack, Pack>
{
    private readonly IRepository<Pack> _packRepository;
    private readonly ISender _sender;

    public PackCommandHandler(IRepository<Pack> packRepository, ISender sender)
    {
        _packRepository = packRepository;
        _sender = sender;
    }

    public async Task<Pack> Handle(CreatePack createPack, CancellationToken cancellationToken)
    {

        var checks = await Task.WhenAll(_sender.Send(new GetClientExistsById(createPack.ClientId)),
                                        _sender.Send(new GetServiceExistsById(createPack.ServiceId)));

        if (!checks.First()) throw new DomainException($"Client with id {createPack.ClientId} does not exists");
        if (!checks.Last()) throw new DomainException($"Service with id {createPack.ServiceId} does not exists");

        return await _packRepository.Add(Pack.Create(createPack.ClientId,
                                                createPack.ServiceId,
                                                createPack.PaymentDate,
                                                createPack.Amount,
                                                createPack.NumberOfSessions));
    }
}
