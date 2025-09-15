using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Repository
{
    public class TestMockDepartmentRepository : IDepartmentRepository
    {
        public int Add(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            throw new NotImplementedException();
        }

        public Department? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Remove(Department department)
        {
            throw new NotImplementedException();
        }

        public int Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
