using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Contracts.Employees;
using ReadModel.Contracts.Employees.DataContracts;
using WriteModel.EmployeeContext.ApplicationService.Employees.Commands;
using WriteModel.EmployeeContext.Facade.Contract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCommandFacade employeeCommandFacade;
        private readonly IEmployeeQueryFacade employeeQueryFacade;

        public EmployeeController(
            IEmployeeCommandFacade employeeCommandFacade,
            IEmployeeQueryFacade employeeQueryFacade)
        {
            this.employeeCommandFacade = employeeCommandFacade;
            this.employeeQueryFacade = employeeQueryFacade;
        }

        [HttpGet]
        public async Task<IEnumerable<GetEmployeeDto>> GetAll()
        {
            return await employeeQueryFacade.GetAllAsync();
        }

        [HttpPost]
        public void Create(EmployeeCreateCommand command)
        {
            employeeCommandFacade.CreateEmployee(command);
        }
    }
}
