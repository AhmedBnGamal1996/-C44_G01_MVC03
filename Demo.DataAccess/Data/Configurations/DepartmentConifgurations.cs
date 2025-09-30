using Demo.DataAccess.Models.DepartmentModule;

namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConifgurations : BaseEntityConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {


            builder.Property(D => D.Id).UseIdentityColumn(10, 10); 

            builder.Property(D => D.Name).HasColumnType("varchar(20)");

            builder.Property(D => D.Code).HasColumnType("varchar(20)");

            builder.Property(D=>D.CreatedOn).HasDefaultValueSql("getdate()");

            builder.Property(D => D.ModifiedOn).HasDefaultValueSql("getdate()");

            builder.HasMany(D=>D.Employees)
                .WithOne(E=>E.Department)
                .HasForeignKey(E=>E.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            base.Configure(builder);





        }





    }


}
