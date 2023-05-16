using Microsoft.EntityFrameworkCore;
using VegaStarProject.Models;

namespace VegaStarProject;

public sealed class WorkContext : DbContext
{
    public WorkContext(DbContextOptions<WorkContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<WorkPlace> WorkPlaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(b =>
        {
            b.HasKey(e => e.Id);
            //b.HasOne(e => e.WorkPlace).WithOne(w => w.Employee).HasForeignKey<WorkPlace>(w => w.EmployeeId);
            b.Property(e => e.FullName).HasColumnType("varchar(50)").IsRequired();
        });

        modelBuilder.Entity<WorkPlace>(b =>
        {
            b.HasKey(w => w.Id);
            b.Property(w => w.Name).HasColumnType("varchar(50)").IsRequired();
        });
    }
}
