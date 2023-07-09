IF EXISTS ( 
        SELECT 1 
        FROM INFORMATION_SCHEMA.COLUMNS 
        WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'Email' )
BEGIN
    UPDATE dbo.Users
    SET Email = 'simone.spagna@gmail.com'
    WHERE   FirstName = 'Simone' 
            AND LastName = 'Spagna' 
            AND BirthCity = 'Mantova' 
            AND BirthState = 'Italy' 
            AND BirthDate = '1976-05-01';
END
