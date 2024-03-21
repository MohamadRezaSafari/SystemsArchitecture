using Framework.Core.AssemblyHelper;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Core.DependencyInjection;

public interface IRegistrar
{
    void Registrar(IServiceCollection services, IAssemblyDiscovery assemblyDiscovery);
}
