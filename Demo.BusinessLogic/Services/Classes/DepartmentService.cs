using Demo.BusinessLogic.DTOS.DepartmentDTOS;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Data.Repository.Interfaces;
using Demo.DataAccess.Models;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {

        // Get All ==> Id , Code .Name , Description , DataOfCreation 

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            // GEt ALl Repo 

            var departments = _departmentRepository.GetAll();
            return departments.Select(d => d.ToDepartmentDto());


        }



        // GEt By ID 

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);


            //if (department == null)
            //{
            //    return null;
            //}
            // Mapping Types :- 
            // Auto Mapping ==> PAckage [ AutoMapper ] 
            // Extention MEthod MApping 
            // Constractour Mapping 
            // Manual Mapping 




            return department is null ? null : department.ToDepartmentDetailsDto();

            // Mapping ==> Department To DepartmentDetailsDto



            //ADD
        }



        public int AddDepartment(CreateDepartmentDto departmentDto)
        {

            return _departmentRepository.Add(departmentDto.ToEntity());

        }


        public int UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {

            return _departmentRepository.Update(updateDepartmentDto.ToEntity());

        }


        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) return false;

            int numsOfRows = _departmentRepository.Remove(department);
            return numsOfRows > 0 ? true : false;



        }















    }

}
