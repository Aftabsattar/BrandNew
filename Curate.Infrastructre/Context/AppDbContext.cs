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
}