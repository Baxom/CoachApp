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

        builder.OwnsOne(x => x.Address);
        builder.OwnsOne(x => x.ContactDetails);

        builder.OwnsMany(x => x.Packs, owned =>
        {
            owned.OwnsOne(x => x.Price, price => price.Property(b => b.Amount).HasPrecision(5, 2));
        });

        builder.OwnsMany(x => x.Services, owned =>
        {
            owned.OwnsOne(x => x.Price, price => price.Property(b => b.Amount).HasPrecision(5,2));
        });
        
        builder.HasQueryFilter(b => b.OwnerUserId == _userContextFactory.Get().Id);
    }
}
