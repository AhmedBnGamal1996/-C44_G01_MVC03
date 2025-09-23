using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Data.Repository.Interfaces;
using Demo.DataAccess.Models.DepartmentModule;


namespace Demo.DataAccess.Data.Repository.Classes
{
     public class DepartmentRepository(ApplicationDbContext _dbContext) : GenericRepository<Department>(_dbContext), IDepartmentRepository
    {















    }

}
