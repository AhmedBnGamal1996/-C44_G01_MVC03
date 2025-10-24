using System.ComponentModel.DataAnnotations;

namespace Demo.Prestation.viewModels.Identity
{
    public class ForgetPasswordViewModel
    {


        [Required(ErrorMessage = "Email Can not be Empty! ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



    }
}
