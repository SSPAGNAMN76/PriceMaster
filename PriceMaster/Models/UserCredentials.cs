namespace PriceMaster.Models
{
    public class UserCredentials
    {
        public UserCredentials()
        {
            PasswordHash = string.Empty;
            UserName = string.Empty;
            User = new User();
        }

        public int CredentialId { get; set; }
        public int UserId { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public User User { get; set; } // Relazione 1:1 con la tabella Users
    }
}
