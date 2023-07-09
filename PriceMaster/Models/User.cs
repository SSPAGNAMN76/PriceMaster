using System.Data;
using PriceMaster.ViewModels;

namespace PriceMaster.Models
{
    public class User
    {
        public User()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            BirthCity = string.Empty;
            BirthState = string.Empty;
            Email = string.Empty;
            Roles = new List<Role>();
            Credentials = new UserCredentials();
        }

        public User(RegisterViewModel registerViewModel)
        {
            LastName = registerViewModel.LastName;
            FirstName = registerViewModel.FirstName;
            BirthCity = registerViewModel.BirthCity;
            BirthState = registerViewModel.BirthState;
            Email = registerViewModel.Email;
            Roles = new List<Role>();
            Credentials = new UserCredentials();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthCity { get; set; }
        public string BirthState { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; } // Relazione N:M con la tabella Roles
        public UserCredentials Credentials { get; set; } // Relazione 1:1 con la tabella UserCredentials
    }

}
