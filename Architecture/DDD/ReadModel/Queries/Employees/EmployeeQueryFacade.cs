using Framework.Facade;
using Mapster;
using Microsoft.EntityFrameworkCore;
using ReadModel.Context;
using ReadModel.Contracts.Employees;
using ReadModel.Contracts.Employees.DataContracts;

namespace ReadModel.Queries.Employees;

public class EmployeeQueryFacade : FacadeQueryBase, IEmployeeQueryFacade
{
    private readonly DeveloperContext dbContext;

    public EmployeeQueryFacade(DeveloperContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<GetEmployeeDto>> GetAllAsync()
    {
        var employees = await dbContext.Employees.ToListAsync();

        return employees.Adapt<List<GetEmployeeDto>>();
    }
}
