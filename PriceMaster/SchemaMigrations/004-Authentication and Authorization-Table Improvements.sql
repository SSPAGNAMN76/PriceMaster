-- Aggiunta delle colonne nella tabella "Users" 
ALTER TABLE dbo.Users
ADD BirthCity NVARCHAR(50) NULL,
    BirthState NVARCHAR(50) NOT NULL,
    BirthDate DATE;

-- Aggiunta della colonna Username nella tabella "UserCredentials" 
ALTER TABLE dbo.UserCredentials
ADD UserName NVARCHAR(20) NOT NULL;