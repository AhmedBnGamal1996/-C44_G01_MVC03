using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;



namespace Demo.DataAccess.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {



        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

            //    optionsBuilder.UseSqlServer("ConnectionString");



            //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // modelBuilder.ApplyConfiguration<Department>(new Configurations.DepartmentConifgurations());



           //  modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
            base.OnModelCreating(modelBuilder);


            // modelBuilder.Entity<IdentityRole>().ToTable("Users");


        }



        public DbSet<Department> Departments { get; set; } 
         public DbSet<Employee> Employees { get; set; }





    }
}