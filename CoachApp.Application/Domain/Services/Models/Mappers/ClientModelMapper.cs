using CoachApp.Domain.Services;

namespace CoachApp.Application.Domain.Services.Models.Mappers;
public static class ServiceModelMapper
{
    public static ServiceModel MapToServiceModel(this Service client) => new ServiceModel(client.Id, client.Name, client.IsPersonalServices);
}
