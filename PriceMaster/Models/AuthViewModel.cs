using System.ComponentModel.DataAnnotations;

namespace PriceMaster.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        public RegisterModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Le password non corrispondono.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordModel
    {
        public ForgotPasswordModel()
        {
            Email = string.Empty;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
