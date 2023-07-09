IF NOT EXISTS ( SELECT 1 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'BirthCity')
BEGIN
    ALTER TABLE dbo.Users
        ADD BirthCity NVARCHAR(50) NULL,
        BirthState NVARCHAR(50) NOT NULL,
        BirthDate DATE;

    ALTER TABLE dbo.UserCredentials
        ADD UserName NVARCHAR(20) NOT NULL;
END