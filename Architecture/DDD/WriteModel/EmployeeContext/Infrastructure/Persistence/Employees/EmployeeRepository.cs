using Framework.Core.Persistence;
using Framework.Persistence;
using System.Linq.Expressions;
using WriteModel.EmployeeContext.Domain.Employees;
using WriteModel.EmployeeContext.Domain.Employees.Services;

namespace WriteModel.EmployeeContext.Infrastructure.Persistence.Employees;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(IDbContext dbContext)
        : base(dbContext)
    {
    }

    public void Create(Employee employee)
    {
        base.Create(employee);
    }

    protected override IEnumerable<Expression<Func<Employee, object>>> GetAggregateExpression()
    {
        throw new NotImplementedException();
    }
}
