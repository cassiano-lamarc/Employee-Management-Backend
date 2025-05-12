using Microsoft.EntityFrameworkCore;

namespace Infrasctructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<Domain.Entities.Employee> Employees { get; set; }
    public DbSet<Domain.Entities.Department> Departments { get; set; }
    public DbSet<Domain.Entities.User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
