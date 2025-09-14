
using Demo.DataAccess.Models;

namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConifgurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {


            builder.Property(D => D.Id).UseIdentityColumn(10, 10); 

            builder.Property(D => D.Name).HasColumnType("varchar(20)");

            builder.Property(D => D.Code).HasColumnType("varchar(20)");

            builder.Property(D=>D.CreatedOn).HasDefaultValueSql("getdate()");

            builder.Property(D => D.ModifiedOn).HasDefaultValueSql("getdate()");







        }





    }


}
