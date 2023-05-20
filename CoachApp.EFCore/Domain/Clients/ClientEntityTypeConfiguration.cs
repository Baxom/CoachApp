using CoachApp.Application.Domain.Users.Context;
using CoachApp.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoachApp.EFCore.Domain.Clients;
internal class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
{
    private readonly IUserContextFactory _userContextFactory;

    public ClientEntityTypeConfiguration(IUserContextFactory userContextFactory)
    {
        _userContextFactory = userContextFactory;
    }

    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(x => x.Adress);
        builder.OwnsOne(x => x.ContactDetails);

        builder.HasQueryFilter(b => b.OwnerUserId == _userContextFactory.Get().Id);
    }
}
