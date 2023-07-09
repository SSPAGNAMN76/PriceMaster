using PriceMaster.Helper;
using PriceMaster.Models;
using PriceMaster.Repositories;

namespace PriceMaster.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string userName, string password)
        {
            var user = _userRepository.GetUserByUserName(userName);

            if (VerifyPassword(password, user.Credentials.PasswordHash))
            {
                return user;
            }

            return null!;
        }

        public bool IsUserInRole(int userId, string roleName) => _userRepository.IsUserInRole(userId, roleName);

        private bool VerifyPassword(string password, string passwordHash) => PasswordManager.HashPassword(password) == passwordHash;
    }
}