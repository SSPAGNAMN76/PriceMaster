using PriceMaster.Models;

namespace PriceMaster.Services
{
    public interface IAuthenticationService
    {
        User Authenticate(string userName, string password);
        bool IsUserInRole(int userId, string roleName);
    }
}
