
using ImplementationBase;
using System.Reflection;


try
{
    var loadLocations = new string[] {
                @"D:\Develop\SystemsArchitecture\Architecture\Plugin\ImplementationBase\obj\Debug\net8.0\ImplementationBase.dll",
                //@"C:\Temp\Plugins\2\ImplementationTwo.dll"
            };
    IEnumerable<ITask> tasks = loadLocations.SelectMany(pluginPath =>
    {
        Assembly pluginAssembly = LoadPlugin(pluginPath);
        return CreateCommands(pluginAssembly);
    }).ToList();
    foreach (ITask task in tasks)
    {
        Console.WriteLine($"{task.Id}\t - {task.Description}");
        Console.WriteLine($" The running task returns - {task.Run()}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}


static Assembly LoadPlugin(string relativePath)
{
    var pluginLocation = relativePath;
    var loadContext = new PluginLoadContext(pluginLocation);
    return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
}

static IEnumerable<ITask> CreateCommands(Assembly assembly)
{
    int count = 0;
    foreach (Type type in assembly.GetTypes())
    {
        if (typeof(ITask).IsAssignableFrom(type))
        {
            ITask? result = Activator.CreateInstance(type) as ITask;
            if (result != null)
            {
                count++;
                yield
                return result;
            }
        }
    }
}
