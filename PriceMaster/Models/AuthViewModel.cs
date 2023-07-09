using System.ComponentModel.DataAnnotations;

namespace PriceMaster.Models
{
    public class LoginViewModel
    {
        public LoginViewModel()
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

    public class RegisterViewModel
    {
        public RegisterViewModel()
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

    public class ForgotPasswordViewModel
    {
        public ForgotPasswordViewModel()
        {
            Email = string.Empty;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
