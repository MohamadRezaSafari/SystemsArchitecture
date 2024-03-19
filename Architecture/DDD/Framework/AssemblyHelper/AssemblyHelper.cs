using Framework.Core.AssemblyHelper;
using System.Reflection;

namespace Framework.AssemblyHelper;

public class AssemblyHelper : IAssemblyDiscovery
{
    private static List<Assembly> loadedAssemblies = null;
    private readonly string assemblySearchPattern;

    public AssemblyHelper(string assemblySearchPattern)
    {
        this.assemblySearchPattern = assemblySearchPattern;
        LoadAssemblies(assemblySearchPattern);
    }

    public IEnumerable<T> DiscoveryInstances<T>(string searchNamespace)
    {
        throw new NotImplementedException();
    }

    private void LoadAssemblies(string assemblySearchPattern)
    {
        if (loadedAssemblies == null)
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            loadedAssemblies = Directory.GetFiles(directory, assemblySearchPattern)
                .Select(Assembly.LoadFrom)
                .ToList();
        }
    }
}
