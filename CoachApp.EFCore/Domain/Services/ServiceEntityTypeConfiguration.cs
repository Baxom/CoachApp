using CoachApp.Application.Domain.Users.Context;
using CoachApp.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoachApp.EFCore.Domain.Services;
internal class ServiceEntityTypeConfiguration : IEntityTypeConfiguration<Service>
{
    private readonly IUserContextFactory _userContextFactory;

    public ServiceEntityTypeConfiguration(IUserContextFactory userContextFactory)
    {
        _userContextFactory = userContextFactory;
    }

    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasQueryFilter(b => b.OwnerUserId == _userContextFactory.Get().Id);
    }
}
