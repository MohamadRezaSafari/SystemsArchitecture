using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;

namespace Framework.ApplicationService;

public class CommandBus : ICommandBus
{
    private readonly IDiContainer diContainer;

    public CommandBus(IDiContainer diContainer)
    {
        this.diContainer = diContainer;
    }

    public void Dispatch<TCommand>(TCommand command) where TCommand : Command
    {
        try
        {
            var commandHandler = diContainer.Resolve<ICommandHandler<TCommand>>();
            var transactionCommandHandler = new TransactionCommandHandler<TCommand>(commandHandler, diContainer);
            transactionCommandHandler.Execute(command);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
