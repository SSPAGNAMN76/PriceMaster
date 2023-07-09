IF  EXISTS ( SELECT 1 
            FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE   TABLE_NAME = 'Users' 
                    AND COLUMN_NAME = 'Email' 
                    AND IS_NULLABLE = 'YES' )
 
BEGIN
    ALTER TABLE dbo.Users
    ALTER COLUMN Email NVARCHAR(70) NOT NULL;
    
    IF NOT EXISTS ( SELECT 1 
                    FROM sys.indexes 
                    WHERE   name = 'UQ_Users_Email' 
                            AND object_id = OBJECT_ID('dbo.Users'))
    BEGIN
        CREATE UNIQUE INDEX UQ_Users_Email ON dbo.Users (Email);
    END
END