using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Data.Repository.Interfaces;
using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Models.EmployeeModule;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess.Data.Repository.Classes
{
    public class EmployeeRepository(ApplicationDbContext _dbContext) : GenericRepository<Employee>(_dbContext),  IEmployeeRepository
    {




      
        // Method ==> Database ==> Department 

        // Get Departments Description < 20 char 







    }








}
