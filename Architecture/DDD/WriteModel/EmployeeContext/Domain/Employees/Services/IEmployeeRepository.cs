using Framework.Core.Persistence;

namespace WriteModel.EmployeeContext.Domain.Employees.Services;

public interface IEmployeeRepository : IRepository
{
    void Create(Employee employee);
}
