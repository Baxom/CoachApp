using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Models;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Commands;
public record UpdateClient(Guid Id, string Lastname, string Firstname, DateTime BirthDate, ContactDetails ContactDetails, Adress Adress) : IRequest<Client>;
