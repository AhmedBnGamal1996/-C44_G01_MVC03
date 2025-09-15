

using Demo.BusinessLogic.DTOS;
using Demo.DataAccess.Models;

namespace Demo.BusinessLogic.Factories
{
    public static class DepartmentsFactory
    {

        public static DepartmentDto ToDepartmentDto (this Department d)
        {
            return new DepartmentDto()
            {
                DeptId = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = d.CreatedOn.HasValue ? DateOnly.FromDateTime(d.CreatedOn.Value) : default
            };
        }


        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {

                Id = department.Id,
                Code = department.Code,
                Description = department.Description,
                Name = department.Name,
                CreatedBy = department.CreatedBy,
                IsDeleted = department.IsDeleted,
                ModifiedBy = department.ModifiedBy,
                CreatedOn = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default,
                ModifiedOn = department.ModifiedOn.HasValue ? DateOnly.FromDateTime(department.ModifiedOn.Value) : default,
            }; 

        }

        public static Department ToEntity(this CreateDepartmentDto departmentDto)
        {
            return new Department()
            {
                Description = departmentDto.Description,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                // DateOnly ==> DateTime

                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly() )



            };




        }


        public static Department ToEntity(this UpdateDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Description = departmentDto.Description,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                // DateOnly ==> DateTime

                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())



            };




        }


    }
}
