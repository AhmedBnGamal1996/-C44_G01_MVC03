using Demo.BusinessLogic.DTOS.DepartmentDTOS;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Repository.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {

        // Get All ==> Id , Code .Name , Description , DataOfCreation 

        public IEnumerable<DepartmentDto> GetAllDepartments(bool withTracking = false)
        { 
            // GEt ALl Repo 

            var departments = _unitOfWork.DepartmentRepository.GetAll(withTracking);
            return departments.Select(d => d.ToDepartmentDto());


        }
            


        // GEt By ID 

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);


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

            _unitOfWork.DepartmentRepository.Add(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();

        }


        public int UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
           _unitOfWork.DepartmentRepository.Update(updateDepartmentDto.ToEntity());


            return _unitOfWork.SaveChanges();





        }


        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null) return false;

            _unitOfWork.DepartmentRepository.Remove(department);
            return _unitOfWork.SaveChanges() > 0 ? true : false;



        }















    }

}
