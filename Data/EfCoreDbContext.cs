using System.Reflection;
using HomeMinimalApi.ListingsModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeMinimalApi.Data;

public class EfCoreDbContext : DbContext {
    public EfCoreDbContext(DbContextOptions options) : base(options) {
    }

    public DbSet<Listing> Listings => Set<Listing>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}