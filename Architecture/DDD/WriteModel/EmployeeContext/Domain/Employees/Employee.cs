using Framework.Core.Domain;
using Framework.Domain;
using WriteModel.EmployeeContext.Domain.Employees.Services;

namespace WriteModel.EmployeeContext.Domain.Employees;

public class Employee : EntityBase, IAggregateRoot
{
    protected Employee() { }

    public Employee(
        IEmployeeRepository employeeRepository, 
        string firstName, 
        string lastName)
    {

        SetFirstName(firstName);
        SetLastName(lastName);
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }


    private void SetFirstName(string firstName)
    {
        //if (string.IsNullOrWhiteSpace(firstName))
            //throw new FirstNameRequiredException();

        FirstName = firstName;
    }

    private void SetLastName(string lastName)
    {
        //if (string.IsNullOrWhiteSpace(lastName))
        //    throw new LastNameRequiredException();

        LastName = lastName;
    }
}
