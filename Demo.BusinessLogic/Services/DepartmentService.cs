using Demo.DataAccess.Data.Repository;
using Demo.DataAccess.Data.Context; 

namespace Demo.BusinessLogic.Services
{
    internal class DepartmentService
    {

        private readonly IDepartmentRepository _departmentRepository; 

        // High level modules should not depend on level modules 
        // both should depend  on abstraction 


        public DepartmentService (IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // Medthods ==> Repository















    }
}
