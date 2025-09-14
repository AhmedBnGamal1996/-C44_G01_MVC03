using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Demo.DataAccess.Data.Context;


namespace Demo.DataAccess.Data.Repository
{
    public class DepartmentRepository(ApplicationDbContext _dbContext)
    {
      


        // 5 Crud Operations

        // GetALL
        // GetById




        public Department GetById (int id )
        {


            var department = _dbContext.Departments.Find(id); 

            return department; 





        }









    }
}
