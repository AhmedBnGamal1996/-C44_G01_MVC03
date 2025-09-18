

using System.ComponentModel.DataAnnotations;

namespace Demo.BusinessLogic.DTOS
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Name is required !! ")] 
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage ="Code is required !! ")]
        public string Code { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateOnly DateOfCreation { get; set; }




















    }
}
