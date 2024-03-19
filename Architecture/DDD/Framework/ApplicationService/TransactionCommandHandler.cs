using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;

namespace Framework.ApplicationService;

public class TransactionCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
{
    private readonly ICommandHandler<TCommand> commandHandler;
    private readonly IDiContainer diContainer;

    public TransactionCommandHandler(
        ICommandHandler<TCommand> commandHandler,
        IDiContainer diContainer)
    {
        this.commandHandler = commandHandler;
        this.diContainer = diContainer;
    }

    public void Execute(TCommand command)
    {
        var unitOfWork = diContainer.Resolve<IUnitOfWork>();

        try
        {
            commandHandler.Execute(command);
            unitOfWork.Commit();
        }
        catch (Exception e)
        {
            unitOfWork.Rollback();
            throw;
        }
    }
}
