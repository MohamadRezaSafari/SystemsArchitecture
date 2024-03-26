using Framework.Core.ApplicationService;
using WriteModel.EmployeeContext.ApplicationService.Employees.Commands;
using WriteModel.EmployeeContext.Domain.Employees;
using WriteModel.EmployeeContext.Domain.Employees.Services;

namespace WriteModel.EmployeeContext.ApplicationService.Employees.CommandHandlers;

public class EmployeeCreateCommandHandler : ICommandHandler<EmployeeCreateCommand>
{
    private readonly IEmployeeRepository employeeRepository;

    public EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public void Execute(EmployeeCreateCommand command)
    {
        Employee employee = new Employee(command.FirstName, command.LastName);

        employeeRepository.Create(employee);
    }
}
