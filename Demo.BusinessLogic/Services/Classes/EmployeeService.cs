using AutoMapper;
using Demo.BusinessLogic.DTOS.EmployeeDTOS;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Repository.Interfaces;
using Demo.DataAccess.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository , IMapper _mapper) : IEmployeeService
    {




        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto , Employee >(employeeDto);

            return _employeeRepository.Add(employee);

        }






        public bool DeleteEmployee(int id)
        {
            // Soft Delete ==> Update [ IsDeleted True ] 

            var employee = _employeeRepository.GetById(id); 

            if(employee is null) 
                return false;
            else
            {
                employee.IsDeleted = true; 
               return _employeeRepository.Update(employee)> 0 ? true : false;
            }


        }





        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {

            //_employeeRepository.GetAll(e => new EmployeeDto()
            //{
            //    Id = e.Id,
            //    Age = e.Age,
            //    Salary = e.Salary,
            //    Name = e.Name
            //}).Where(e=>e.Age > 27 ); 




            //------------------------////////



            //var employeeDto = _employeeRepository.GetIQueryable().Where(e => e.IsDeleted == false).Select
            //    (e => new EmployeeDto()

            //    {
            //        Id = e.Id,
            //        Age = e.Age,
            //        Salary = e.Salary
            //    }
            //    );
            //return employeeDto.ToList(); 




            //------------------------////////



            var employees = _employeeRepository.GetAll(withTracking);



            //------------------------////////

            //var employeeDto = employees.Select(e => new EmployeeDto
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Age = e.Age,
            //    Salary = e.Salary,
            //    IsActive = e.IsActive,
            //    Email = e.Email,
            //    Gender = e.Gender.ToString(),
            //    EmployeeType = e.EmployeeType.ToString()
            //}); 

            // Src ==> IEnumerable<Employee> , Dest ==> IEnumerable<EmployeeDto>

            var employeeDto = _mapper.Map<IEnumerable<Employee> , IEnumerable<EmployeeDto>>(employees);




            return employeeDto;


        }





        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
           var employee = _employeeRepository.GetById(id);

            return employee is null ? null : _mapper.Map<EmployeeDetailsDto>(employee);


            //    new EmployeeDetailsDto()

            //{
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Address = employee.Address,
            //    Salary = employee.Salary,
            //    IsActive = employee.IsActive,
            //    Email = employee.Email,
            //    PhoneNumber = employee.Phone,
            //    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
            //    CreatedOn = employee.CreatedOn,
            //    CreatedBy = 1,
            //    ModifiedBy = 1,
            //    EmployeeType = employee.EmployeeType.ToString(),
            //    Gender = employee.Gender.ToString(),



            //}; 

        }




        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto , Employee>(employeeDto));



        }







    }
}
