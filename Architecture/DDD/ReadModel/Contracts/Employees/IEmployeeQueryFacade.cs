using ReadModel.Contracts.Employees.DataContracts;

namespace ReadModel.Contracts.Employees;

public interface IEmployeeQueryFacade
{
    Task<List<GetEmployeeDto>> GetAllAsync();
}
