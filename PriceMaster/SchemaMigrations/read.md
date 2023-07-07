# Prerequisites

- Docker installed
- Sql Server Management Studio installed

# Setup docker container

In Windoes PowerSher run the following command :
- docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Qwerty03' -p 10000:1433 --name SqlPriceMaster -d mcr.microsoft.com/mssql/server:latest

# Create Sql Server DB

- Open Sql Server Management Studio
- Connect to localhost,10000 with user sa and password Qwerty03
- Create a new database usng PriceMaster from the GUI
	- In the GUI ( or bash ) you can also open a New query Windows and run the following script :
		- 
		```sql
		USE [master]						
        GO

		IF DB_ID('PriceMaster') IS NULL
		BEGIN
			CREATE DATABASE [PriceMaster]
			ON PRIMARY 
			(NAME = N'PriceMaster', FILENAME = N'/var/opt/mssql/data/PriceMaster.mdf', SIZE = 8192KB, MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB)
			LOG ON 
			(NAME = N'PriceMaster_log', FILENAME = N'/var/opt/mssql/data/PriceMaster_log.ldf', SIZE = 8192KB, MAXSIZE = 2048GB, FILEGROWTH = 65536KB)
			WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
		END
		GO

		USE [PriceMaster]
		GO

		IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
		BEGIN
			EXEC [dbo].[sp_fulltext_database] @action = 'enable'
		END
		GO

		ALTER DATABASE [PriceMaster] SET RECOVERY FULL
		GO

		ALTER DATABASE [PriceMaster] SET READ_COMMITTED_SNAPSHOT ON
		GO

		ALTER DATABASE [PriceMaster] SET AUTO_UPDATE_STATISTICS ON
		GO

		ALTER DATABASE [PriceMaster] SET PAGE_VERIFY CHECKSUM
		GO

		ALTER DATABASE [PriceMaster] SET ALLOW_SNAPSHOT_ISOLATION ON
		GO

		ALTER DATABASE [PriceMaster] SET QUERY_STORE = ON
		GO

		ALTER DATABASE [PriceMaster] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
		GO
		```

#Apply Migrations

To apply the migrations, use the following command:

```powershell
dotnet-badgie-migrator "Server=localhost,10000;Database=PriceMaster;User Id=sa;Password=Qwerty03;" .\SchemaMigrations\*.sql -i -d:SqlServer
```
