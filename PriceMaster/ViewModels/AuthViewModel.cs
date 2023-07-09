using System.ComponentModel.DataAnnotations;
using PriceMaster.Helper;

namespace PriceMaster.ViewModels
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
            LastName = string.Empty;
            FirstName = string.Empty;
            BirthCity = string.Empty;
            BirthState = string.Empty;
            Email = string.Empty;
        }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string HashedPassword => PasswordManager.HashPassword(Password);

        [Compare("Password", ErrorMessage = "Le password non corrispondono.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string BirthCity { get; set; }

        [Required]
        public string BirthState { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
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
