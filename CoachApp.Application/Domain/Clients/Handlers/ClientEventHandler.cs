using CoachApp.Application.Domain.Services.Commands;
using CoachApp.Domain.Clients.Events;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Handlers;
internal class ClientEventHandler : INotificationHandler<ClientCreated>
{
    private readonly ISender _sender;

    public ClientEventHandler(ISender sender)
    {
        _sender = sender;
    }

    public Task Handle(ClientCreated notification, CancellationToken cancellationToken)
    {
        return _sender.Send(new CreateService($"Default service for client {notification.clientId}", false));
    }
}
