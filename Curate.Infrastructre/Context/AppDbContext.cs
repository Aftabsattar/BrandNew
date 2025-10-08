using Curate.Domain.Entities;
using Curate.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base (options) {}

    public DbSet<Idea> ideas { get; set; }
    public DbSet<Register> user { get; set; }
}