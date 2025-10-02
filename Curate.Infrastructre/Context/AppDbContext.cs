using Curate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base (options) {}

    public DbSet<Idea> ideas { get; set; }
}