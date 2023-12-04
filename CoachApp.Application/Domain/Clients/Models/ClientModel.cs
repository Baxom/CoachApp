using CoachApp.Domain.Clients.Models;

namespace CoachApp.Application.Domain.Clients.Models;
public record ClientModel(Guid Id, string Lastname, string Firstname, DateTime birthDate, ContactDetails contactDetails, Address Address);
