using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.Data;

public class TempDbContext : DbContext
{
    public DbSet<Api> Apis => Set<Api>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Api>(b => {
            b.HasKey(x => x.Id);
            b.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        });
    }

    public TempDbContext(DbContextOptions<TempDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<ApiCatalog> ApiCatalogs => Set<ApiCatalog>();
}