using Framework.Core.ApplicationService;

namespace WriteModel.EmployeeContext.ApplicationService.Employees.Commands;

public class EmployeeCreateCommand : Command
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
