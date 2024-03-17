namespace ImplementationBase;

public interface ITask
{
    string Id
    {
        get;
    }
    string Description
    {
        get;
    }

    int Run();
}
