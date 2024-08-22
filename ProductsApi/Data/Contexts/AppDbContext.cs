using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Configurations;
using ProductsApi.Data.Entities;

namespace ProductsApi.Data.Contexts;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options,IServiceProvider services) : base(options)
    {
        this.Services = services;
    }
    public IServiceProvider Services { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FileMetadata> FileMetadatas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<Product>().HasOne(f => f.FileMetadata)
            .WithMany()
            .HasForeignKey(f => f.FileMetadataId);

        modelBuilder.ApplyConfiguration(new RoleConfiguration(Services));
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}

