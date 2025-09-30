namespace Demo.DataAccess.Models.Shared
{
    public class BaseEntity   // Include the commen propertoies [ Parent ] 
    {

        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; } 

        public int ModifiedBy { get; set; }    // User Id \

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }  // Soft Delete






    }
}
