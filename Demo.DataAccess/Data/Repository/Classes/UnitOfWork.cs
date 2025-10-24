using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Data.Repository.Interfaces;


namespace Demo.DataAccess.Data.Repository.Classes
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {

            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));


            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(dbContext));
            _dbContext = dbContext;


        }


        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;







        public int SaveChanges()
        {
           
            return _dbContext.SaveChanges();
        }


    }





}
