using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WriteModel.Persistence;

public class HRDesignTimeDbContext : IDesignTimeDbContextFactory<WriteModelDbContext>
{
    public WriteModelDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WriteModelDbContext>();

        //optionsBuilder
        //    .UseSqlServer("Data Source = 172.16.26.9; Initial Catalog = HR_Developer; User Id = saleadmin; Password = 123");

        return new WriteModelDbContext(optionsBuilder.Options);
    }
}
