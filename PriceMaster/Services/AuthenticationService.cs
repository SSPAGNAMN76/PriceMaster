using System.Data;
using System.Data.SqlClient;
using Dapper;
using PriceMaster.Helper;
using PriceMaster.Models;

namespace PriceMaster.Services;

public class AuthenticationService : IAuthenticationService
{
    
    private readonly SqlConnection _dbConnection;

    public AuthenticationService(SqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public User Authenticate(string userName, string password)
    {
        var sql = @"SELECT u.*, c.PasswordHash
                    FROM Users u
                    INNER JOIN UserCredentials c ON u.UserId = c.UserId
                    WHERE c.UserName = @UserName";

        var user = _dbConnection.QueryFirstOrDefault<User>(sql, new { UserName = userName });

        if (user != null && VerifyPassword(password, user.Credentials.PasswordHash))
        {
            return user;
        }

        return null!;
    }

    public bool IsUserInRole(int userId, string roleName)
    {
        var sql = @"SELECT COUNT(*)
                    FROM UserRoles ur
                    INNER JOIN Roles r ON ur.RoleId = r.RoleId
                    WHERE ur.UserId = @UserId AND r.RoleName = @RoleName";

        var count = _dbConnection.ExecuteScalar<int>(sql, new { UserId = userId, RoleName = roleName });

        return count > 0;
    }

    private bool VerifyPassword(string password, string passwordHash) => PasswordManager.HashPassword(password) == passwordHash;
}