using CoachApp.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoachApp.EFCore.Domain.Users;
internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);
        builder.OwnsOne(x => x.ContactDetails);
        builder.OwnsOne(x => x.CompanyInformation);
    }
}
