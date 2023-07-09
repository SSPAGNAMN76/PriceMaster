using Dapper;
using PriceMaster.Helper;
using PriceMaster.Models;
using PriceMaster.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace PriceMaster.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration)
            : base(configuration)
        {
        }

        public (bool, User) Authenticate(string userName, string password)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT u.*, c.PasswordHash
                            FROM Users u
                            INNER JOIN UserCredentials c ON u.UserId = c.UserId
                            WHERE c.UserName = @UserName";

                var user = connection.QueryFirstOrDefault<User>(sql, new { UserName = userName });

                if (user != null && VerifyPassword(password, user.Credentials.PasswordHash))
                {
                    return (true, user);
                }

                return (false, null)!;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT u.*, c.PasswordHash
                            FROM Users u
                            INNER JOIN UserCredentials c ON u.UserId = c.UserId
                            WHERE u.Email = @Email";

                return connection.QueryFirstOrDefault<User>(sql, new { Email = email });
            }
        }

        public User GetUserByUserName(string userName)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT u.*, c.PasswordHash
                            FROM Users u
                            INNER JOIN UserCredentials c ON u.UserId = c.UserId
                            WHERE c.UserName = @UserName";

                return connection.QueryFirstOrDefault<User>(sql, new { UserName = userName });
            }
        }

        public void RegisterUser(RegisterViewModel userViewModel)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                // Begin transaction
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert User record
                        var userData = new User(userViewModel);
                        
                        string insertUserSql = @"
                    INSERT INTO Users (FirstName, LastName, BirthCity, BirthState, BirthDate, Email)
                    VALUES (@FirstName, @LastName, @BirthCity, @BirthState, @BirthDate, @Email);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                        int userId = connection.ExecuteScalar<int>(insertUserSql, userData, transaction);

                        // Associate UserCredentials with User
                        userData.Credentials.UserId = userId;
                        string insertUserCredentialsSql = @"
                    INSERT INTO UserCredentials (UserId, UserName, PasswordHash)
                    VALUES (@UserId, @UserName, @PasswordHash)";
                        connection.Execute(insertUserCredentialsSql, userData.Credentials, transaction);

                        // Commit transaction
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // Rollback transaction in case of any error
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    

        public IEnumerable<string> GetUserRoles(string userName)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT r.RoleName
                            FROM Users u
                            INNER JOIN UserRoles ur ON u.UserId = ur.UserId
                            INNER JOIN Roles r ON ur.RoleId = r.RoleId
                            WHERE u.UserName = @UserName";

                return connection.Query<string>(sql, new { UserName = userName });
            }
        }

        public void ResetUserPassword(string userName, string newPasswordHash)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE UserCredentials
                            SET PasswordHash = @PasswordHash
                            WHERE UserName = @UserName";

                connection.Execute(sql, new { UserName = userName, PasswordHash = newPasswordHash });
            }
        }

        public void AssignUserRoles(string userName, IEnumerable<string> roleNames)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                // Get the User Id
                string getUserIdSql = @"SELECT UserId FROM Users WHERE UserName = @UserName";
                int userId = connection.ExecuteScalar<int>(getUserIdSql, new { UserName = userName });

                // Get the Role Ids
                string getRoleIdsSql = @"SELECT RoleId FROM Roles WHERE RoleName IN @RoleNames";
                IEnumerable<int> roleIds = connection.Query<int>(getRoleIdsSql, new { RoleNames = roleNames });

                // Create the UserRoles records
                string createUserRolesSql = @"INSERT INTO UserRoles (UserId, RoleId) VALUES (@UserId, @RoleId)";
                foreach (int roleId in roleIds)
                {
                    connection.Execute(createUserRolesSql, new { UserId = userId, RoleId = roleId });
                }
            }
        }

        public bool IsUserInRole(int userId, string roleName)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT COUNT(*) 
                            FROM Users u
                            INNER JOIN UserRoles ur ON u.UserId = ur.UserId
                            INNER JOIN Roles r ON ur.RoleId = r.RoleId
                            WHERE u.UserId = @UserId AND r.RoleName = @RoleName";

                int count = connection.ExecuteScalar<int>(sql, new { UserId = userId, RoleName = roleName });
                return count > 0;
            }
        }

        private bool VerifyPassword(string password, string passwordHash) => PasswordManager.HashPassword(password) == passwordHash;
    }
}

