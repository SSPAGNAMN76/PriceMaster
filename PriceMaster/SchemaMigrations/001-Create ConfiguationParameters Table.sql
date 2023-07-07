IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'dbo.ConfigurationParameters')
BEGIN
    CREATE TABLE dbo.ConfigurationParameters
    (
        Id INT IDENTITY(1,1) PRIMARY KEY NONCLUSTERED,
        IVA DECIMAL(18,2) NOT NULL,
        ScortaMinima INT NOT NULL,
        RicaricoMinimo DECIMAL(18,2) NOT NULL,
        SpeseSpedizioneListino DECIMAL(18,2) NOT NULL,
        MargineSSMinimo DECIMAL(18,2) NOT NULL,
        DifferenzaMinima DECIMAL(18,2) NOT NULL,
        SpeseSpedizioneRivenditore DECIMAL(18,2) NOT NULL
    )

    CREATE CLUSTERED INDEX IX_ConfigurationParameters_Id ON ConfigurationParameters (Id)
    CREATE INDEX IX_ConfigurationParameters_IVA ON ConfigurationParameters (IVA)
    CREATE INDEX IX_ConfigurationParameters_SpeseSpedizioneListino ON ConfigurationParameters (SpeseSpedizioneListino)
    CREATE INDEX IX_ConfigurationParameters_SpeseSpedizioneRivenditore ON ConfigurationParameters (SpeseSpedizioneRivenditore)
END
