namespace PriceMaster.Models
{
    public class Role
    {
        public Role()
        {
            RoleName = string.Empty;
            Users = new List<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<User> Users { get; set; } // Relazione N:M con la tabella Users
    }
}
