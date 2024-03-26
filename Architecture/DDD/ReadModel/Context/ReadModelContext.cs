using Microsoft.EntityFrameworkCore;
using ReadModel.Context.Models;

namespace ReadModel.Context;

public class ReadModelContext : DbContext
{
    public ReadModelContext()
    {

    }

    public ReadModelContext(DbContextOptions<ReadModelContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Employee> Employees { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer("Server=192.168.2.252;Database=HR_Developer;Trusted_Connection=True;User Id = saleadmin; Password = 123")
                .AddInterceptors(new SlowQueryInterceptor());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee", "EmployeeContext");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);
        });

    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
