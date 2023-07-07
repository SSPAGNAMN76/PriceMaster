IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ConfigurationParameters') AND name = 'ValidFrom')
BEGIN
    ALTER TABLE dbo.ConfigurationParameters
    ADD ValidFrom DATETIME NOT NULL DEFAULT GETDATE(),
        ValidTo DATETIME NULL
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ConfigurationParameters') AND name = 'IsCurrent')
BEGIN
    ALTER TABLE dbo.ConfigurationParameters
    ADD IsCurrent BIT NOT NULL DEFAULT 1
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ConfigurationParameters') AND name = 'CreatedAt')
BEGIN
    ALTER TABLE dbo.ConfigurationParameters
    ADD CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME NULL
END
