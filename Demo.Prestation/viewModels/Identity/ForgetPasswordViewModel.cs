using System.ComponentModel.DataAnnotations;

namespace Demo.Prestation.viewModels.Identity
{
    public class ForgetPasswordViewModel
    {


        [Required]
        [EmailAddress]
        public string Email { get; set; }



    }
}
