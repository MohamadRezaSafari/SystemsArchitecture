using Framework.AssemblyHelper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WriteModel.Persistence;

public class WriteModelDbContext : DbContextBase
{
    public WriteModelDbContext(DbContextOptions<WriteModelDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityMapping = DetectEntityMapping();

        entityMapping.ForEach(a =>
        {
            modelBuilder.ApplyConfiguration(a);

        });
    }

    protected List<dynamic> DetectEntityMapping()
    {
        var assemblyHelper = new AssemblyDiscovery("*.dll");
        var getType = assemblyHelper.DiscoveryTypes<IEntityMapping>("HR")
            .Select(Activator.CreateInstance)
            .Cast<dynamic>()
            .ToList();

        return getType;
    }
}
