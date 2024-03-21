using Framework.Core.ApplicationService;
using Framework.Facade;
using WriteModel.EmployeeContext.ApplicationService.Employees.Commands;
using WriteModel.EmployeeContext.Facade.Contract;

namespace WriteModel.EmployeeContext.Facade;

public class EmployeeCommandFacade : FacadeCommandBase, IEmployeeCommandFacade
{
    public EmployeeCommandFacade(ICommandBus commandBus)
        : base(commandBus)
    {
    }

    public void CreateEmployee(EmployeeCreateCommand command)
    {
        CommandBus.Dispatch(command);
    }
}
