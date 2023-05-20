using CoachApp.Domain.Packs;

namespace CoachApp.Application.Domain.Packs.Models.Mappers;
public static class PackModelMapper
{
    public static PackModel MapToPackModel(this Pack pack) => new PackModel(pack.Id, 
                                                                            pack.ClientId, 
                                                                            pack.ServiceId, 
                                                                            pack.PaymentDate, 
                                                                            pack.Amount, 
                                                                            pack.NumberOfSessions, 
                                                                            pack.RemainingSessions);
}
