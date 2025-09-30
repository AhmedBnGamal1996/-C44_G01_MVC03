using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Data.Repository.Interfaces;
using Demo.DataAccess.Models.DepartmentModule;


namespace Demo.DataAccess.Data.Repository.Classes
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Department entity)
        {
            Add(entity);
        }

        public void Update(Department entity)
        {
            Update(entity);
        }

        public void Remove(Department entity)
        {
            Remove(entity);
        }
    }

}
