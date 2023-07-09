IF NOT EXISTS ( SELECT 1 
                FROM dbo.Roles 
                WHERE RoleName = 'Administrator')
BEGIN
    BEGIN TRANSACTION;

    INSERT INTO dbo.Roles (RoleName)
    VALUES ('Users'), ('Administrators'), ('Accountants'), ('Storekeepers');

    DECLARE @UserId INT;
    INSERT INTO dbo.Users (FirstName, LastName, BirthCity, BirthState, BirthDate)
    VALUES ('Simone', 'Spagna','Mantova', 'Italy', '1976-05-01');
    SET @UserId = SCOPE_IDENTITY();

    DECLARE @CredentialId INT;
    DECLARE @PasswordHash NVARCHAR(MAX);
    DECLARE @UserName NVARCHAR(20); -- Assumi che la colonna UserName sia di tipo NVARCHAR(50)
    SET @UserName = 'Admin';
    SET @PasswordHash = HASHBYTES('SHA2_256', 'Qwerty03!');
    INSERT INTO [dbo].[UserCredentials] ([UserId], [PasswordHash], [UserName])
    VALUES (@UserId, @PasswordHash, @UserName);
    SET @CredentialId = SCOPE_IDENTITY();

    INSERT INTO UserRoles (RoleId, UserId)
    SELECT RoleId, @UserId
    FROM Roles;

    COMMIT TRAN;
END