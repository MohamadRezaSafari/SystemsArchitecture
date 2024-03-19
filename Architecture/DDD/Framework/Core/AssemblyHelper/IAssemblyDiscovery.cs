namespace Framework.Core.AssemblyHelper;

public interface IAssemblyDiscovery
{
    IEnumerable<T> DiscoveryInstances<T>(string searchNamespace);
}
