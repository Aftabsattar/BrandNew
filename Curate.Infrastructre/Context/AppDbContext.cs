using Curate.Domain.Entities;
using Curate.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base (options) {}

    public DbSet<Idea> ideas { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<UserProfile> profiles { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<IdeaProducts> ideaProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdeaProducts>()
            .HasKey(ip => new { ip.IdeaId, ip.ProductId });

        modelBuilder.Entity<IdeaProducts>()
            .HasOne(ip => ip.Idea)
            .WithMany(i => i.IdeaProducts)
            .HasForeignKey(ip => ip.IdeaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<IdeaProducts>()
            .HasOne(ip => ip.Product)
            .WithMany(i => i.IdeaProducts)
            .HasForeignKey(ip => ip.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}