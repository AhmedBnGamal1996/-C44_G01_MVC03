using System.Reflection;



namespace Demo.DataAccess.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {



        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

            //    optionsBuilder.UseSqlServer("ConnectionString");



            //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // modelBuilder.ApplyConfiguration<Department>(new Configurations.DepartmentConifgurations());



            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        
        }


         public DbSet<Department> Departments { get; set; } 





    }
}