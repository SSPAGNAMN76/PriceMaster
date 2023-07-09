using PriceMaster.Models;
using PriceMaster.ViewModels;

namespace PriceMaster.Repositories
{
    public interface IUserRepository
    {
        (bool, User) Authenticate(string username, string password);
        User GetUserByEmail(string email);
        User GetUserByUserName(string userName);
        void RegisterUser(RegisterViewModel viewModel);
        IEnumerable<string> GetUserRoles(string username);
        void ResetUserPassword(string username, string newPassword);
        bool IsUserInRole(int userId, string roleName);
        void AssignUserRoles(string userName, IEnumerable<string> roleNames);
    }
}
