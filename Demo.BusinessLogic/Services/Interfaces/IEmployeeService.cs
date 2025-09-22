

using Demo.BusinessLogic.DTOS.EmployeeDTOS;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        // Get All Employees
        IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false);


        // Get Employee By Id
        EmployeeDetailsDto? GetEmployeeById(int id);



        // Create Employee
        int CreateEmployee(CreatedEmployeeDto  employeeDto);



        // Update Employee
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);


        bool DeleteEmployee(int id);

    }
}
