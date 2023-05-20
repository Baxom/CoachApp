using CoachApp.Application.Domain.Users.Context;
using CoachApp.Domain.Packs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoachApp.EFCore.Domain.Packs;
internal class PackEntityTypeConfiguration : IEntityTypeConfiguration<Pack>
{
    private readonly IUserContextFactory _userContextFactory;

    public PackEntityTypeConfiguration(IUserContextFactory userContextFactory)
    {
        _userContextFactory = userContextFactory;
    }

    public void Configure(EntityTypeBuilder<Pack> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasQueryFilter(b => b.OwnerUserId == _userContextFactory.Get().Id);
    }
}
