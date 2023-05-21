using System.Reflection;
using CoachApp.Application.Domain.Users.Context;
using CoachApp.Domain._Common;
using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Entities;
using CoachApp.Domain.Services;
using CoachApp.Domain.Users;
using CoachApp.EFCore.Domain.Clients;
using CoachApp.EFCore.Domain.Services;
using CoachApp.EFCore.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.EFCore.Database;
internal class CoachAppContext : DbContext
{
    private static PropertyInfo _ownerIdPropertyInfo = typeof(AggregateRootPerTenant).GetProperty(nameof(AggregateRootPerTenant.OwnerUserId))!;
    private readonly IDbContextFactory<CoachAppContext> _factory;
    private readonly IUserContextFactory _userContextFactory;

    public CoachAppContext(IDbContextFactory<CoachAppContext> factory, DbContextOptions<CoachAppContext> options, IUserContextFactory userContextFactory) : base(options)
    {
        _factory = factory;
        _userContextFactory = userContextFactory;
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Pack> Packs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration(_userContextFactory));
        modelBuilder.ApplyConfiguration(new ServiceEntityTypeConfiguration(_userContextFactory));
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

        // modelBuilder.RemoveUnderScoreFromPropertyName();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var createdEntries = ChangeTracker.Entries()
            .Where(b => b.State == EntityState.Added && b.Entity is AggregateRootPerTenant);

        if (createdEntries.Any())
        {
            var currentUserId = _userContextFactory.Get().Id;

            foreach (var entry in createdEntries)
            {
                _ownerIdPropertyInfo.SetValue(entry.Entity, currentUserId);
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public CoachAppContext CreateContextForQuery() => _factory.CreateDbContext();
}
