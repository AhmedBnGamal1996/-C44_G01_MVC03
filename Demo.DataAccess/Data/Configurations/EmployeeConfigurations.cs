using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Models.Shared;


namespace Demo.DataAccess.Data.Configurations
{
    public class EmployeeConfigurations :  BaseEntityConfiguration<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {


            builder.Property(E=>E.Address).HasColumnType("VARCHAR(50)");
            
            builder.Property(E => E.Name).HasColumnType("VARCHAR(50)");
            
            builder.Property(E => E.Salary).HasColumnType("DECIMAL(10,2)");



            builder.Property(E=>E.Gender).HasConversion((empGender) => empGender.ToString()
            ,(gender) => (Gender) Enum.Parse(typeof(Gender),gender));





            builder.Property(E => E.EmployeeType).HasConversion((empType) => empType.ToString()
           , (employeeType) => (EmployeeType)Enum.Parse(typeof(EmployeeType), employeeType));




            base.Configure(builder);




        }












    }
}
