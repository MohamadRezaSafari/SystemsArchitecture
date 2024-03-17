namespace ImplementationBase;

public class TaskOne : ITask
{
    public string Id
    {
        get;
    } = "One";

    public string Description
    {
        get;
    } = "First Implementation plugin";

    public int Run()
    {
        return 1;
    }
}

public class TaskTwo : ITask
{
    public string Id
    {
        get;
    } = "Two";

    public string Description
    {
        get;
    } = "Second Implementation plugin";

    public int Run()
    {
        return 2;
    }
}
