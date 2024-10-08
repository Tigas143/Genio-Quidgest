USE [W_GnBD]
if ('W_GnZeroTrue'='1')
begin
    IF((SELECT COUNT(1) FROM [PJFcfg]) > 0)
        UPDATE [PJFcfg] SET versindx = 0
end
GO
IF ('W_GnZeroTrue'='1' AND EXISTS (SELECT * FROM [W_GnBD].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ASYNCPROCESS'))
BEGIN
if (not exists(SELECT CODASCPR FROM ASYNCPROCESS ))
begin	
	DROP TABLE ASYNCPROCESS	
end
END
GO
IF ('W_GnZeroTrue'='1' AND EXISTS (SELECT * FROM [W_GnBD].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ASYNCPROCESSARGUMENT'))
BEGIN
if (not exists(SELECT CODARGPR FROM ASYNCPROCESSARGUMENT ))
begin
	DROP TABLE ASYNCPROCESSARGUMENT	
end
END
GO
IF ('W_GnZeroTrue'='1' AND EXISTS (SELECT * FROM [W_GnBD].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ASYNCPROCESSATTACHMENTS'))
BEGIN
if (not exists(SELECT CODPRANX FROM ASYNCPROCESSATTACHMENTS ))
begin
	DROP TABLE ASYNCPROCESSATTACHMENTS	
end
END
GO



if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'USERLOGIN','CODPSW','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'USERLOGIN','PJF','CODPSW'
	exec AlterarCamposTmp 'USERLOGIN', 'CODPSW', 'int', 'INT NOT NULL', '4'
   	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'USERLOGIN' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [USERLOGIN] ADD CONSTRAINT [USERLOGIN_CODPSW__] PRIMARY KEY(CODPSW)
	exec AlterarCamposTmp 'USERLOGIN', 'NOME', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'USERLOGIN', 'PASSWORD', 'varchar', 'VARCHAR(150)', '150'
	exec AlterarCamposTmp 'USERLOGIN', 'CERTSN', 'varchar', 'VARCHAR(32)', '32'
	exec AlterarCamposTmp 'USERLOGIN', 'EMAIL', 'varchar', 'VARCHAR(254)', '254'
	exec AlterarCamposTmp 'USERLOGIN', 'PSWTYPE', 'varchar', 'VARCHAR(3)', '3'
	exec AlterarCamposTmp 'USERLOGIN', 'SALT', 'varchar', 'VARCHAR(32)', '32'
	exec AlterarCamposTmp 'USERLOGIN', 'DATAPSW', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERLOGIN', 'USERID', 'varchar', 'VARCHAR(250)', '250'
	exec AlterarCamposTmp 'USERLOGIN', 'PSW2FAVL', 'varchar', 'VARCHAR(1000)', '1000'
	exec AlterarCamposTmp 'USERLOGIN', 'PSW2FATP', 'varchar', 'VARCHAR(16)', '16'
	exec AlterarCamposTmp 'USERLOGIN', 'DATEXP', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERLOGIN', 'ATTEMPTS', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'USERLOGIN', 'PHONE', 'varchar', 'VARCHAR(16)', '16'
	exec AlterarCamposTmp 'USERLOGIN', 'STATUS', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'USERLOGIN', 'ASSOCIA', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'USERLOGIN', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'USERLOGIN', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERLOGIN', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'USERLOGIN', 'DATAMUDA', 'datetime', 'DATETIME', '8'
  exec AlterarCamposTmp 'USERLOGIN', 'PSWTYPE', 'varchar', 'VARCHAR(3)', '3'
  exec AlterarCamposTmp 'USERLOGIN', 'SALT', 'varchar', 'VARCHAR(32)', '32'
  exec AlterarCamposTmp 'USERLOGIN', 'DATAPSW', 'datetime', 'DATETIME', '8'
  exec AlterarCamposTmp 'USERLOGIN', 'USERID', 'varchar', 'VARCHAR(250)', '250'
  exec AlterarCamposTmp 'USERLOGIN', 'PSW2FAVL', 'varchar', 'VARCHAR(1000)', '1000'
  exec AlterarCamposTmp 'USERLOGIN', 'PSW2FATP', 'varchar', 'VARCHAR(16)', '16'
  exec AlterarCamposTmp 'USERLOGIN', 'EMAIL', 'varchar', 'VARCHAR(254)', '254'
  exec AlterarCamposTmp 'USERLOGIN', 'DATEXP', 'datetime', 'DATETIME', '8'
  exec AlterarCamposTmp 'USERLOGIN', 'ATTEMPTS', 'int', 'INT', '2'
  exec AlterarCamposTmp 'USERLOGIN', 'PHONE', 'varchar', 'VARCHAR(16)', '16'
  exec AlterarCamposTmp 'USERLOGIN', 'STATUS', 'int', 'INT', '2'
	exec AlterarCamposTmp 'USERLOGIN', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'ASYNCPROCESS','CODASCPR','G', 16 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'ASYNCPROCESS','PJF','CODASCPR'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'CODASCPR', 'uniqueidentifier', 'uniqueidentifier NOT NULL', '16'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'ASYNCPROCESS' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [ASYNCPROCESS] ADD CONSTRAINT [ASYNCPROCESS_CODASCPR] PRIMARY KEY(CODASCPR)
	exec AlterarCamposTmp 'ASYNCPROCESS', 'TYPE', 'varchar', 'VARCHAR(12)', '12'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'DATEREQU', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'INITPRC', 'datetime', 'DATETIME', '16'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'ENDPRC', 'datetime', 'DATETIME', '16'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'DURATION', 'varchar', 'VARCHAR(5)', '5'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'STATUS', 'varchar', 'VARCHAR(2)', '2'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'RSLTMSG', 'varchar', 'VARCHAR(250)', '250'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'FINISHED', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'LASTUPDT', 'datetime', 'DATETIME', '19'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'RESULT', 'varchar', 'VARCHAR(2)', '2'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'INFO', 'varchar', 'VARCHAR(500)', '500'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'PERCENTA', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'MODOPROC', 'varchar', 'VARCHAR(9)', '9'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'EXTERNAL', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'ID', 'int', 'INT', '4'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'CODENTIT', 'int', 'INT', '4'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'MOTIVO', 'varchar', 'VARCHAR(200)', '200'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'CODPSW', 'int', 'INT', '4'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'OPERSHUT', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'ASYNCPROCESSARGUMENT','CODARGPR','G', 16 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'ASYNCPROCESSARGUMENT','PJF','CODARGPR'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'CODARGPR', 'uniqueidentifier', 'uniqueidentifier NOT NULL', '16'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'ASYNCPROCESSARGUMENT' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [ASYNCPROCESSARGUMENT] ADD CONSTRAINT [ASYNCPROCESSARGUMENT_CODARGPR] PRIMARY KEY(CODARGPR)
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'CODS_APR', 'uniqueidentifier', 'uniqueidentifier', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'ID', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'VALOR', 'varchar', 'VARCHAR(250)', '250'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DOCUMENTFK', 'int', 'int', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DOCUMENT', 'varchar', 'VARCHAR(200)', '200'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'TIPO', 'varchar', 'VARCHAR(250)', '250'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DESIGNAC', 'varchar', 'VARCHAR(200)', '200'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'HIDDEN', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'NOTIFICATIONEMAILSIGNATURE','CODSIGNA','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'NOTIFICATIONEMAILSIGNATURE','PJF','CODSIGNA'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'CODSIGNA', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'NOTIFICATIONEMAILSIGNATURE' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [NOTIFICATIONEMAILSIGNATURE] ADD CONSTRAINT [NOTIFICATIONEMAILSIGNATURE_CODSIGNA] PRIMARY KEY(CODSIGNA)
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'NAME', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'IMAGE', 'varbinary', 'VARBINARY(MAX)', '3'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'TEXTASS', 'varchar', 'VARCHAR(300)', '300'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'USERNAME', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'PASSWORD', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'NOTIFICATIONMESSAGE','CODMESGS','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'NOTIFICATIONMESSAGE','PJF','CODMESGS'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODMESGS', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'NOTIFICATIONMESSAGE' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [NOTIFICATIONMESSAGE] ADD CONSTRAINT [NOTIFICATIONMESSAGE_CODMESGS] PRIMARY KEY(CODMESGS)
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODSIGNA', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODPMAIL', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'FROM', 'varchar', 'VARCHAR(254)', '254'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODTPNOT', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODDESTN', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'TO', 'varchar', 'VARCHAR(254)', '254'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'DESTNMAN', 'tinyint', 'TINYINT', '1'
 	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'TOMANUAL', 'varchar', 'VARCHAR(MAX)', '8000'
 	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CC', 'varchar', 'VARCHAR(MAX)', '8000'
 	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'BCC', 'varchar', 'VARCHAR(MAX)', '8000'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'IDNOTIF', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'NOTIFICA', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'EMAIL', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'ASSUNTO', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'AGREGADO', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'ANEXO', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'HTML', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'ATIVO', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'DESIGNAC', 'varchar', 'VARCHAR(100)', '100'
 	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'MENSAGEM', 'varchar', 'VARCHAR(MAX)', '8000'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'GRAVABD', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'ASYNCPROCESSATTACHMENTS','CODPRANX','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'ASYNCPROCESSATTACHMENTS','PJF','CODPRANX'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'CODPRANX', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'ASYNCPROCESSATTACHMENTS' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [ASYNCPROCESSATTACHMENTS] ADD CONSTRAINT [ASYNCPROCESSATTACHMENTS_CODPRANX] PRIMARY KEY(CODPRANX)
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'CODS_APR', 'uniqueidentifier', 'uniqueidentifier', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'DOCUMENTFK', 'int', 'int', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'DOCUMENT', 'varchar', 'VARCHAR(200)', '200'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'USERAUTHORIZATION','CODUA','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'USERAUTHORIZATION','PJF','CODUA'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'CODUA', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'USERAUTHORIZATION' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [USERAUTHORIZATION] ADD CONSTRAINT [USERAUTHORIZATION_CODUA___] PRIMARY KEY(CODUA)
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'CODPSW', 'int', 'INT', '4'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'SISTEMA', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'MODULO', 'varchar', 'VARCHAR(3)', '3'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'NAODUPLI', 'varchar', 'VARCHAR(39)', '39'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'ROLE', 'varchar', 'VARCHAR(16)', '16'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'NIVEL', 'bigint', 'BIGINT', '8'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFAIRLN','CODAIRLN','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFAIRLN','PJF','CODAIRLN'
	exec AlterarCamposTmp 'PJFAIRLN', 'CODAIRLN', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFAIRLN' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFAIRLN] ADD CONSTRAINT [PJFAIRLN_CODAIRLN] PRIMARY KEY(CODAIRLN)
	exec AlterarCamposTmp 'PJFAIRLN', 'NAME', 'varchar', 'VARCHAR(9)', '9'
	exec AlterarCamposTmp 'PJFAIRLN', 'CODCITY', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFAIRLN', 'CODAIRHB', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFAIRLN', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFAIRPT','CODAIRPT','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFAIRPT','PJF','CODAIRPT'
	exec AlterarCamposTmp 'PJFAIRPT', 'CODAIRPT', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFAIRPT' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFAIRPT] ADD CONSTRAINT [PJFAIRPT_CODAIRPT] PRIMARY KEY(CODAIRPT)
	exec AlterarCamposTmp 'PJFAIRPT', 'NAME', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'PJFAIRPT', 'CODCITY', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFAIRPT', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFAPSW','CODHPSW','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFAPSW','PJF','CODHPSW'
	exec AlterarCamposTmp 'PJFAPSW', 'CODHPSW', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFAPSW' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFAPSW] ADD CONSTRAINT [PJFAPSW_CODHPSW_] PRIMARY KEY(CODHPSW)
	exec AlterarCamposTmp 'PJFAPSW', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFAPSW', 'CODPSW', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFAPSW', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFBOOKG','CODBOOKG','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFBOOKG','PJF','CODBOOKG'
	exec AlterarCamposTmp 'PJFBOOKG', 'CODBOOKG', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFBOOKG' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFBOOKG] ADD CONSTRAINT [PJFBOOKG_CODBOOKG] PRIMARY KEY(CODBOOKG)
	exec AlterarCamposTmp 'PJFBOOKG', 'BNUM', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'PJFBOOKG', 'FLIGHT', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFBOOKG', 'PRICE', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFBOOKG', 'CODPASGR', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFBOOKG', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFBOOKG', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFCITY','CODCITY','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFCITY','PJF','CODCITY'
	exec AlterarCamposTmp 'PJFCITY', 'CODCITY', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFCITY' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFCITY] ADD CONSTRAINT [PJFCITY_CODCITY_] PRIMARY KEY(CODCITY)
	exec AlterarCamposTmp 'PJFCITY', 'CITY', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFCITY', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFCREW','CODCREW','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFCREW','PJF','CODCREW'
	exec AlterarCamposTmp 'PJFCREW', 'CODCREW', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFCREW' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFCREW] ADD CONSTRAINT [PJFCREW_CODCREW_] PRIMARY KEY(CODCREW)
	exec AlterarCamposTmp 'PJFCREW', 'COUNT', 'bigint', 'BIGINT', '8'
	exec AlterarCamposTmp 'PJFCREW', 'CREWNAME', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'PJFCREW', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFCREW', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFFLIGH','CODFLIGH','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFFLIGH','PJF','CODFLIGH'
	exec AlterarCamposTmp 'PJFFLIGH', 'CODFLIGH', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFFLIGH' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFFLIGH] ADD CONSTRAINT [PJFFLIGH_CODFLIGH] PRIMARY KEY(CODFLIGH)
	exec AlterarCamposTmp 'PJFFLIGH', 'CODPLANE', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFFLIGH', 'CODROUTE', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFFLIGH', 'ARRIVAL', 'datetime', 'DATETIME', '16'
	exec AlterarCamposTmp 'PJFFLIGH', 'DEPART', 'datetime', 'DATETIME', '16'
	exec AlterarCamposTmp 'PJFFLIGH', 'DURATION', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFFLIGH', 'CODSOURC', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFFLIGH', 'CODCREW', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFFLIGH', 'NAMESC', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'PJFFLIGH', 'CODPILOT', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFFLIGH', 'FLIGHNUM', 'varchar', 'VARCHAR(15)', '15'
	exec AlterarCamposTmp 'PJFFLIGH', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFFLIGH', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFMAINT','CODMAINT','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFMAINT','PJF','CODMAINT'
	exec AlterarCamposTmp 'PJFMAINT', 'CODMAINT', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFMAINT' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFMAINT] ADD CONSTRAINT [PJFMAINT_CODMAINT] PRIMARY KEY(CODMAINT)
	exec AlterarCamposTmp 'PJFMAINT', 'STATUS', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFMAINT', 'CODPLANE', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFMAINT', 'DATE', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'PJFMAINT', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFMAINT', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFMATE','CODMATE','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFMATE','PJF','CODMATE'
	exec AlterarCamposTmp 'PJFMATE', 'CODMATE', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFMATE' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFMATE] ADD CONSTRAINT [PJFMATE_CODMATE_] PRIMARY KEY(CODMATE)
	exec AlterarCamposTmp 'PJFMATE', 'NAME', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'PJFMATE', 'CODCREW', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFMATE', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFMATE', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFPERSO','CODPERSO','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFPERSO','PJF','CODPERSO'
	exec AlterarCamposTmp 'PJFPERSO', 'CODPERSO', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFPERSO' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFPERSO] ADD CONSTRAINT [PJFPERSO_CODPERSO] PRIMARY KEY(CODPERSO)
	exec AlterarCamposTmp 'PJFPERSO', 'NAME', 'varchar', 'VARCHAR(25)', '25'
	exec AlterarCamposTmp 'PJFPERSO', 'IDFK', 'int', 'int', '16'
	exec AlterarCamposTmp 'PJFPERSO', 'ID', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'PJFPERSO', 'NATIO', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFPERSO', 'PHONE', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'PJFPERSO', 'EMAIL', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFPERSO', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFPILOT','CODPILOT','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFPILOT','PJF','CODPILOT'
	exec AlterarCamposTmp 'PJFPILOT', 'CODPILOT', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFPILOT' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFPILOT] ADD CONSTRAINT [PJFPILOT_CODPILOT] PRIMARY KEY(CODPILOT)
	exec AlterarCamposTmp 'PJFPILOT', 'NAME', 'varchar', 'VARCHAR(10)', '10'
	exec AlterarCamposTmp 'PJFPILOT', 'LICENSE', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFPILOT', 'EXPERIEN', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'PJFPILOT', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFPILOT', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFPLANE','CODPLANE','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFPLANE','PJF','CODPLANE'
	exec AlterarCamposTmp 'PJFPLANE', 'CODPLANE', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFPLANE' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFPLANE] ADD CONSTRAINT [PJFPLANE_CODPLANE] PRIMARY KEY(CODPLANE)
	exec AlterarCamposTmp 'PJFPLANE', 'PHOTO', 'varbinary', 'VARBINARY(MAX)', '3'
	exec AlterarCamposTmp 'PJFPLANE', 'MODEL', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFPLANE', 'ENGINES', 'bigint', 'BIGINT', '8'
	exec AlterarCamposTmp 'PJFPLANE', 'MANUFACT', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFPLANE', 'YEAR', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'PJFPLANE', 'CAPACITY', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFPLANE', 'STATUS', 'varchar', 'VARCHAR(9)', '9'
	exec AlterarCamposTmp 'PJFPLANE', 'AIRCR', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFPLANE', 'AGE', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'PJFPLANE', 'AIRSC', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'PJFPLANE', 'MAINT', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'PJFPLANE', 'ISMAINT', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'PJFPLANE', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFPLANE', 'ID', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'PJFPLANE', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2669 > isnull((select versao from [PJFcfg]),0))
begin
	declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFROUTE','CODROUTE','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFROUTE','PJF','CODROUTE'
	exec AlterarCamposTmp 'PJFROUTE', 'CODROUTE', 'int', 'INT NOT NULL', '4'
  	if (not exists(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = 'PJFROUTE' AND TABLE_SCHEMA = 'dbo'))
		ALTER TABLE [PJFROUTE] ADD CONSTRAINT [PJFROUTE_CODROUTE] PRIMARY KEY(CODROUTE)
	exec AlterarCamposTmp 'PJFROUTE', 'AIRDS', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFROUTE', 'AIRSC', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFROUTE', 'DURATION', 'varchar', 'VARCHAR(5)', '5'
	exec AlterarCamposTmp 'PJFROUTE', 'NAME', 'varchar', 'VARCHAR(10)', '10'
	exec AlterarCamposTmp 'PJFROUTE', 'CODAIRLN', 'int', 'INT', '4'
	exec AlterarCamposTmp 'PJFROUTE', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

-- Create Placeholder Computed columns
--PJFCITY
--PJFMEM
--PJFPERSO
--USERLOGIN
--ASYNCPROCESS
if exists (select Col.name from systypes as tp, sysobjects as Tbl  inner join syscolumns as Col on Tbl.id = Col.id  where Col.xtype = tp.xtype and Tbl.name = 'ASYNCPROCESS' and Col.name = 'RTSTATUS')
BEGIN
  EXEC dbo.DropConstraintsTmp 'ASYNCPROCESS', 'RTSTATUS'
  EXEC('ALTER TABLE [ASYNCPROCESS] DROP COLUMN [RTSTATUS]')
END
EXEC('ALTER TABLE [ASYNCPROCESS] ADD [RTSTATUS] AS cast(null as varchar(2))')
--NOTIFICATIONEMAILSIGNATURE
--NOTIFICATIONMESSAGE
--PJFAIRPT
--ASYNCPROCESSARGUMENT
--ASYNCPROCESSATTACHMENTS
--USERAUTHORIZATION
--PJFAIRLN
--PJFAPSW
--PJFCREW
--PJFPILOT
--PJFPLANE
--PJFROUTE
--PJFFLIGH
--PJFMAINT
--PJFMATE
--PJFBOOKG
GO

-- Update Computed Column functions
--PJFCITY
--PJFMEM
--PJFPERSO
--USERLOGIN
--ASYNCPROCESS
IF NOT EXISTS (SELECT id FROM sysobjects WHERE xtype='FN' AND NAME='FORMULA_ASYNCPROCESS_RTSTATUS') EXEC('CREATE FUNCTION dbo.FORMULA_ASYNCPROCESS_RTSTATUS(@CODASCPR VARCHAR(MAX)) RETURNS varchar(2) AS BEGIN RETURN NULL END;')
EXEC('ALTER FUNCTION dbo.FORMULA_ASYNCPROCESS_RTSTATUS(@CODASCPR VARCHAR(MAX))
RETURNS varchar(2) AS
BEGIN
    RETURN (SELECT (case when ([s_apr].[status]=''EE'' or [s_apr].[status]=''D'' or [s_apr].[status]=''AC'' or [s_apr].[status]=''AG'') then (case when ((dbo.Diferenca_entre_Datas([s_apr].[lastupdt],CONVERT(datetime,CURRENT_TIMESTAMP),''S'')>10 and [s_apr].[status]<>''AG'') or (dbo.Diferenca_entre_Datas([s_apr].[lastupdt],CONVERT(datetime,CURRENT_TIMESTAMP),''S'')>45 and [s_apr].[status]=''AG'')) then ''NR'' else [s_apr].[status] end) else [s_apr].[status] end) from [asyncprocess] as [s_apr] WHERE [S_APR].[CODASCPR] = @CODASCPR);
END')
EXEC dbo.DropConstraintsTmp 'ASYNCPROCESS', 'RTSTATUS'
EXEC('ALTER TABLE [ASYNCPROCESS] DROP COLUMN [RTSTATUS]')
EXEC('ALTER TABLE [ASYNCPROCESS] ADD [RTSTATUS] AS dbo.FORMULA_ASYNCPROCESS_RTSTATUS(CODASCPR)')
--NOTIFICATIONEMAILSIGNATURE
--NOTIFICATIONMESSAGE
--PJFAIRPT
--ASYNCPROCESSARGUMENT
--ASYNCPROCESSATTACHMENTS
--USERAUTHORIZATION
--PJFAIRLN
--PJFAPSW
--PJFCREW
--PJFPILOT
--PJFPLANE
--PJFROUTE
--PJFFLIGH
--PJFMAINT
--PJFMATE
--PJFBOOKG
GO

	exec estrutura_dinamica
GO
