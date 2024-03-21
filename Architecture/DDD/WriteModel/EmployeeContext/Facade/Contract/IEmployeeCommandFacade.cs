using WriteModel.EmployeeContext.ApplicationService.Employees.Commands;

namespace WriteModel.EmployeeContext.Facade.Contract;

public interface IEmployeeCommandFacade
{
    void CreateEmployee(EmployeeCreateCommand command);
}
