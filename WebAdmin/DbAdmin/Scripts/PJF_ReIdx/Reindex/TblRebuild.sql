USE [W_GnBD]
if (2501 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'USERLOGIN') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [USERLOGIN] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'ASYNCPROCESS') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [ASYNCPROCESS] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'ASYNCPROCESSARGUMENT') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [ASYNCPROCESSARGUMENT] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'NOTIFICATIONEMAILSIGNATURE') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [NOTIFICATIONEMAILSIGNATURE] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'NOTIFICATIONMESSAGE') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [NOTIFICATIONMESSAGE] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'ASYNCPROCESSATTACHMENTS') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [ASYNCPROCESSATTACHMENTS] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'USERAUTHORIZATION') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [USERAUTHORIZATION] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFAIRLN') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFAIRLN] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFAIRPT') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFAIRPT] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFAPSW') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFAPSW] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFBOOKG') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFBOOKG] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFCITY') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFCITY] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFCREW') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFCREW] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFFLIGH') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFFLIGH] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFMAINT') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFMAINT] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFMATE') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFMATE] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFPERSO') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFPERSO] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFPILOT') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFPILOT] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFPLANE') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFPLANE] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2669 > isnull((select versao from [PJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFROUTE') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [PJFROUTE] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFMEM') = 0)
	ALTER TABLE [PJFMEM] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFCFG') = 0)
	ALTER TABLE [PJFCFG] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFUSRSET') = 0)
	ALTER TABLE [PJFUSRSET] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFUSRCFG') = 0)
	ALTER TABLE [PJFUSRCFG] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFWKFACT') = 0)
	ALTER TABLE [PJFWKFACT] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFWKFCON') = 0)
	ALTER TABLE [PJFWKFCON] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFWKFLIG') = 0)
	ALTER TABLE [PJFWKFLIG] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFWKFLOW') = 0)
	ALTER TABLE [PJFWKFLOW] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFNOTIFI') = 0)
	ALTER TABLE [PJFNOTIFI] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFSCRCRD') = 0)
	ALTER TABLE [PJFSCRCRD] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFPOSTIT') = 0)
	ALTER TABLE [PJFPOSTIT] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFPRMFRM') = 0)
	ALTER TABLE [PJFPRMFRM] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFALERTA') = 0)
	ALTER TABLE [PJFALERTA] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFALTENT') = 0)
	ALTER TABLE [PJFALTENT] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFTALERT') = 0)
	ALTER TABLE [PJFTALERT] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFDELEGA') = 0)
	ALTER TABLE [PJFDELEGA] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFLSTUSR') = 0)
	ALTER TABLE [PJFLSTUSR] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFLSTCOL') = 0)
	ALTER TABLE [PJFLSTCOL] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFLSTREN') = 0)
	ALTER TABLE [PJFLSTREN] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'PJFUSRWID') = 0)
	ALTER TABLE [PJFUSRWID] REBUILD
GO
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'DOCUMS') = 0)
	ALTER TABLE [DOCUMS] REBUILD
GO
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'hashcd') = 0)
	ALTER TABLE [hashcd] REBUILD
GO
