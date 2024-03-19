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
        var assemblyInstances = loadedAssemblies
            .Where(i => i.FullName.StartsWith(searchNamespace))
            .SelectMany(i => i.GetTypes())
            .Where(i => i.IsClass && !i.IsAbstract)
            .Where(i => i.GetInterface(typeof(T).Name) != null)
            .Select(Activator.CreateInstance)
            .OfType<T>();

        return assemblyInstances;
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
