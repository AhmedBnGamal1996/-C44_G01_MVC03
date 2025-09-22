using Demo.BusinessLogic.DTOS.EmployeeDTOS;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
           
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {

            var employees = _employeeRepository.GetAll(withTracking);
            var employeeDtos = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                IsActive = e.IsActive,
                Email = e.Email,
                Gender = e.Gender.ToString(),
                EmployeeType = e.EmployeeType.ToString()
            }); 
            
            return employeeDtos;


        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
           var employee = _employeeRepository.GetById(id);

            return employee is null ? null : new EmployeeDetailsDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.Phone,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                CreatedOn = employee.CreatedOn,
                CreatedBy = 1,
                ModifiedBy = 1,
                EmployeeType = employee.EmployeeType.ToString(),
                Gender = employee.Gender.ToString(),



            }; 
            
        }




        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
