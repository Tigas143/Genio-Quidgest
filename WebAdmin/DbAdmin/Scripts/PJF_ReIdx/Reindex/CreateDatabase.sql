 if db_id('W_GnBD') is null
begin
	CREATE DATABASE [W_GnBD] COLLATE SQL_Latin1_General_CP1_CI_AI
	ALTER DATABASE [W_GnBD] SET RECOVERY SIMPLE
	ALTER DATABASE [W_GnBD] SET AUTO_CLOSE  OFF
end
else
begin
	if ((select convert(sysname,DatabasePropertyEx('W_GnBD','Collation'))) != 'SQL_Latin1_General_CP1_CI_AI')
	begin
		ALTER DATABASE [W_GnBD] SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
		ALTER DATABASE [W_GnBD] COLLATE SQL_Latin1_General_CP1_CI_AI
		ALTER DATABASE [W_GnBD] SET MULTI_USER
	end
end
GO
use [W_GnBD]
GO
