using Demo.DataAccess.Models;

namespace Demo.BusinessLogic.DTOS.DepartmentDTOS
{
    public class DepartmentDetailsDto
    {

        public int Id { get; set; }

        public int CreatedBy { get; set; }      // User ID 

        public DateOnly? CreatedOn { get; set; }        // The date Time of creating the record 

        public int ModifiedBy { get; set; }    // User Id 

        public DateOnly? ModifiedOn { get; set; }   // The date Time of creating the record 

        public bool IsDeleted { get; set; }  // Soft Delete


        public string Name { get; set; } = string.Empty;


        public string? Description { get; set; }

        public string Code { get; set; } = string.Empty;

      







    }
}
