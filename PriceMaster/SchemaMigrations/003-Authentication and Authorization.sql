IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'dbo.AspNetUsers')
BEGIN

   -- Creazione della tabella Roles
    CREATE TABLE Roles (
        RoleId INT IDENTITY(1, 1) NOT NULL,
        RoleName NVARCHAR(50) NOT NULL,
        CONSTRAINT PK_Roles PRIMARY KEY NONCLUSTERED (RoleId)
    );

    -- Creazione della tabella Users
    CREATE TABLE Users (
        UserId INT IDENTITY(1, 1) NOT NULL,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        CONSTRAINT PK_Users PRIMARY KEY NONCLUSTERED (UserId)
    );

    -- Creazione della tabella UserCredentials
    CREATE TABLE UserCredentials (
        CredentialId INT IDENTITY(1, 1) NOT NULL,
        UserId INT NOT NULL,
        PasswordHash NVARCHAR(MAX) NOT NULL,
        CONSTRAINT PK_UserCredentials PRIMARY KEY NONCLUSTERED (CredentialId),
        CONSTRAINT FK_UserCredentials_Users FOREIGN KEY (UserId) REFERENCES Users (UserId) ON DELETE CASCADE
    );

    -- Creazione della tabella UserRoles
    CREATE TABLE UserRoles (
        RoleId INT NOT NULL,
        UserId INT NOT NULL,
        CONSTRAINT PK_UserRoles PRIMARY KEY NONCLUSTERED (RoleId, UserId),
        CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleId) REFERENCES Roles (RoleId) ON DELETE CASCADE,
        CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserId) REFERENCES Users (UserId) ON DELETE CASCADE
    );

    -- Creazione degli indici
    CREATE NONCLUSTERED INDEX IDX_UserCredentials_UserId ON UserCredentials (UserId);
    CREATE NONCLUSTERED INDEX IDX_UserRoles_RoleId ON UserRoles (RoleId);
    CREATE NONCLUSTERED INDEX IDX_UserRoles_UserId ON UserRoles (UserId);


END
