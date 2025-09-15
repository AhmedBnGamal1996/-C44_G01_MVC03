using Demo.DataAccess.Data.Context;


namespace Demo.DataAccess.Data.Repository
{
    public class DepartmentRepository(ApplicationDbContext _dbContext) : IDepartmentRepository
    {
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Departments.ToList();
            }

            else return _dbContext.Departments.AsNoTracking().ToList();






        }



        // 5 Crud Operations

        // GetALL
        // GetById




        public Department? GetById(int id) => _dbContext.Departments.Find(id);

        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }


        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }



        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }
















    }
}
