using Framework.AssemblyHelper;
using Framework.Core.AssemblyHelper;
using Framework.Core.DependencyInjection;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using ReadModel.Context;
using WriteModel.Persistence;

var builder = WebApplication.CreateBuilder(args);



var assemblyDiscovery = new AssemblyDiscovery("*.dll");
var registrars = assemblyDiscovery.DiscoveryInstances<IRegistrar>("*").ToList();
foreach (var registrar in registrars)
{
    registrar.Registrar(builder.Services, assemblyDiscovery);
}

builder.Services.AddDbContext<IDbContext, WriteModelDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("HR_Developer"));
});
builder.Services.AddDbContext<ReadModelContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("HR_Developer"));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
