



		
 
USE [W_GnBD]

if exists(SELECT top 1 name FROM sysobjects where name = 'Codigos_Int_Modulos')
	DROP TABLE Codigos_Int_Modulos
if exists(SELECT top 1 name FROM sysobjects where name = 'Codigos_Internos')
	DROP TABLE Codigos_Internos
	declare @NewTable as bit;
	exec CriarTabelaTmp 'Codigos_Sequenciais','id_objecto','0', 50, @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'Codigos_Sequenciais','PJF','id_objecto'
	exec AlterarCamposTmp 'Codigos_Sequenciais', 'id_objecto', 'varchar', 'VARCHAR(50) NOT NULL', 50
	if not exists (select * from sysobjects where xtype = 'PK' and parent_obj = (select id from sysobjects where name = 'Codigos_Sequenciais'))
		ALTER TABLE Codigos_Sequenciais ADD CONSTRAINT CODIGOS_SEQUENCIAIS_PK PRIMARY KEY(id_objecto)
	exec AlterarCamposTmp 'Codigos_Sequenciais', 'proximo', 'bigint', 'BIGINT', '10'
GO

 
declare @NewTable as bit;
exec CriarTabelaTmp 'PJFmem','codmem','I', 8, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFmem','PJF','codmem'
exec AlterarCamposTmp 'PJFmem', 'codmem', 'int', 'INT NOT NULL', '8'
if (@NewTable = 1)
	ALTER TABLE [PJFmem] ADD CONSTRAINT [PJFMEM_CODMEM__] PRIMARY KEY(codmem)
exec AlterarCamposTmp 'PJFmem', 'login', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFmem', 'altura', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFmem', 'rotina', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFmem', 'obs', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFmem', 'hostid', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'PJFmem', 'clientid', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFmem', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO
declare @NewTable as bit;
exec CriarTabelaTmp 'PJFcfg','codcfg','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFcfg','PJF','codcfg'
exec AlterarCamposTmp 'PJFcfg', 'codcfg', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFcfg] ADD CONSTRAINT [PJFCFG_CODCFG__] PRIMARY KEY(codcfg)
exec AlterarCamposTmp 'PJFcfg', 'checkdat', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFcfg', 'versao', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFcfg', 'versindx', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFcfg', 'manutdat', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFcfg', 'upgrindx', 'int', 'INT', '5'
exec AlterarCamposTmp 'PJFcfg', 'usrsetv', 'int', 'INT', '5'
exec AlterarCamposTmp 'PJFcfg', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFtblcfg','CODTBLCFG','I', 8 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFtblcfg','PJF','CODTBLCFG'
exec AlterarCamposTmp 'PJFtblcfg', 'CODTBLCFG', 'int', 'INT NOT NULL', '8'
if (@NewTable = 1)
	ALTER TABLE [PJFtblcfg] ADD CONSTRAINT [PJFTBLCFG_CODTBLCFG] PRIMARY KEY(CODTBLCFG)

exec AlterarCamposTmp 'PJFtblcfg', 'CODPSW', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFtblcfg', 'UUID', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtblcfg', 'NAME', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtblcfg', 'CONFIGID', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFtblcfg', 'CONFIG', 'varchar', 'VARCHAR(MAX)', 'MAX'
exec AlterarCamposTmp 'PJFtblcfg', 'DATE', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFtblcfg', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFtblcfgsel','CODTBLCFGSEL','I', 8 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFtblcfgsel','PJF','CODTBLCFGSEL'
exec AlterarCamposTmp 'PJFtblcfgsel', 'CODTBLCFGSEL', 'int', 'INT NOT NULL', '8'
if (@NewTable = 1)
	ALTER TABLE [PJFtblcfgsel] ADD CONSTRAINT [PJFTBLCFGSEL_CODTBLCFGSEL] PRIMARY KEY(CODTBLCFGSEL)

exec AlterarCamposTmp 'PJFtblcfgsel', 'CODPSW', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFtblcfgsel', 'UUID', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtblcfgsel', 'CODTBLCFG', 'int', 'INT', '6'
exec AlterarCamposTmp 'PJFtblcfgsel', 'DATE', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFtblcfgsel', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFlstusr','CODLSTUSR','I', 8 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFlstusr','PJF','CODLSTUSR'
exec AlterarCamposTmp 'PJFlstusr', 'CODLSTUSR', 'int', 'INT NOT NULL', '8'
if (@NewTable = 1)
	ALTER TABLE [PJFlstusr] ADD CONSTRAINT [PJFLSTUSR_CODLSTUSR] PRIMARY KEY(CODLSTUSR)

exec AlterarCamposTmp 'PJFlstusr', 'CODPSW', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFlstusr', 'DESCRIC', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFlstusr', 'IDLIST', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFlstusr', 'MODULO', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'PJFlstusr', 'SISTEMA', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'PJFlstusr', 'ORDERCOL', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFlstusr', 'ORDERTYPE', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFlstusr', 'DATA', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFlstusr', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFlstcol','CODLSTCOL','I', 8 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFlstcol','PJF','CODLSTCOL'
exec AlterarCamposTmp 'PJFlstcol', 'CODLSTCOL', 'int', 'INT NOT NULL', '8'
if (@NewTable = 1)
	ALTER TABLE [PJFlstcol] ADD CONSTRAINT [PJFLSTCOL_CODLSTCOL] PRIMARY KEY(CODLSTCOL)
exec AlterarCamposTmp 'PJFlstcol', 'CODLSTUSR', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFlstcol', 'TABELA', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFlstcol', 'ALIAS', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFlstcol', 'CAMPO', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFlstcol', 'VISIVEL', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFlstcol', 'POSICAO', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFlstcol', 'OPERACAO', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFlstcol', 'TIPO', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFlstcol', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFlstren','CODLSTREN','I', 8 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFlstren','PJF','CODLSTREN'
exec AlterarCamposTmp 'PJFlstren', 'CODLSTREN', 'int', 'INT NOT NULL', '8'
if (@NewTable = 1)
	ALTER TABLE [PJFlstren] ADD CONSTRAINT [PJFLSTCOL_CODLSTREN] PRIMARY KEY(CODLSTREN)
exec AlterarCamposTmp 'PJFlstren', 'CODLSTUSR', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFlstren', 'RENDERIZACAO', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFlstren', 'VISIVEL', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFlstren', 'POSICAO', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFlstren', 'OPERACAO', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFlstren', 'TIPO', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFlstren', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFusrwid','CODUSRWID','I', 8 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFusrwid','PJF','CODUSRWID'
exec AlterarCamposTmp 'PJFusrwid', 'CODUSRWID', 'int', 'INT NOT NULL', '8'
if (@NewTable = 1)
	ALTER TABLE [PJFusrwid] ADD CONSTRAINT [PJFLSTCOL_CODUSRWID] PRIMARY KEY(CODUSRWID)
exec AlterarCamposTmp 'PJFusrwid', 'CODLSTUSR', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFusrwid', 'WIDGET', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFusrwid', 'ROWKEY', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFusrwid', 'VISIBLE', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFusrwid', 'HPOSITION', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFusrwid', 'VPOSITION', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFusrwid', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFusrcfg','codusrcfg','I', 6 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFusrcfg','PJF','codusrcfg'

exec AlterarCamposTmp 'PJFusrcfg', 'codusrcfg', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFusrcfg] ADD CONSTRAINT [PJFUSRCFG_CODUSRCFG] PRIMARY KEY(codusrcfg)
exec AlterarCamposTmp 'PJFusrcfg', 'modulo', 'varchar', 'VARCHAR(3)', '3'

exec AlterarCamposTmp 'PJFusrcfg', 'codpsw', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFusrcfg', 'tipo', 'varchar', 'VARCHAR(2)', '2'
exec AlterarCamposTmp 'PJFusrcfg', 'id', 'varchar', 'VARCHAR(15)', '15'
exec AlterarCamposTmp 'PJFusrcfg', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFusrset','codusrset','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFusrset','PJF','codusrset'

exec AlterarCamposTmp 'PJFusrset', 'codusrset', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFusrset] ADD CONSTRAINT [PJFUSRSET_CODUSRSET] PRIMARY KEY(codusrset)
exec AlterarCamposTmp 'PJFusrset', 'modulo', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'PJFusrset', 'codpsw', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFusrset', 'chave', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'PJFusrset', 'valor', 'varchar', 'VARCHAR(4000)', '4000'
exec AlterarCamposTmp 'PJFusrset', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFwkfact','codwkfact','I',  6 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFwkfact','PJF','codwkfact'
exec AlterarCamposTmp 'PJFwkfact', 'codwkfact', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFwkfact] ADD CONSTRAINT [PJFWKFACT_CODWKFACT] PRIMARY KEY(codwkfact)
exec AlterarCamposTmp 'PJFwkfact', 'wfid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'PJFwkfact', 'actid', 'int', 'INT', ''
exec AlterarCamposTmp 'PJFwkfact', 'tpactid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'PJFwkfact', 'descrica', 'varchar', 'VARCHAR(40)', '40'
exec AlterarCamposTmp 'PJFwkfact', 'duracao', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkfact', 'perfil', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkfact', 'perfilu', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkfact', 'x', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkfact', 'y', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkfact', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFwkfcon','codwkfcon','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFwkfcon','PJF','codwkfcon'
exec AlterarCamposTmp 'PJFwkfcon', 'codwkfcon', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFwkfcon] ADD CONSTRAINT [PJFWKFCON_CODWKFCON] PRIMARY KEY(codwkfcon)
exec AlterarCamposTmp 'PJFwkfcon', 'wfid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'PJFwkfcon', 'condid', 'int', 'INT', ''
exec AlterarCamposTmp 'PJFwkfcon', 'tpcondid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'PJFwkfcon', 'descrica', 'varchar', 'VARCHAR(40)', '40'
exec AlterarCamposTmp 'PJFwkfcon', 'tiporegr', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkfcon', 'sinal', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'PJFwkfcon', 'x', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkfcon', 'y', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkfcon', 'valor', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'PJFwkfcon', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFwkflig','codwkflig','I',6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFwkflig','PJF','codwkflig'
exec AlterarCamposTmp 'PJFwkflig', 'codwkflig', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFwkflig] ADD CONSTRAINT [PJFWKFLIG_CODWKFLIG] PRIMARY KEY(codwkflig)
exec AlterarCamposTmp 'PJFwkflig', 'wfid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'PJFwkflig', 'parentid', 'int', 'INT', '6'
exec AlterarCamposTmp 'PJFwkflig', 'childid', 'int', 'INT', '6'
exec AlterarCamposTmp 'PJFwkflig', 'ptoy', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkflig', 'ptox', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkflig', 'ptor', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkflig', 'tipo', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkflig', 'pfromx', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkflig', 'pfromy', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkflig', 'pfromr', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFwkflig', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFwkflow','codwkflow','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFwkflow','PJF','codwkflow'
exec AlterarCamposTmp 'PJFwkflow', 'codwkflow', 'int', 'INT NOT NULL', ''
if (@NewTable = 1)
	ALTER TABLE [PJFwkflow] ADD CONSTRAINT [PJFWKFLOW_CODWKFLOW] PRIMARY KEY(codwkflow)
exec AlterarCamposTmp 'PJFwkflow', 'descrica', 'varchar', 'VARCHAR(40)', '40'
exec AlterarCamposTmp 'PJFwkflow', 'modulo', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'PJFwkflow', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFnotifi','codnotifi','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFnotifi','PJF','codnotifi'
exec AlterarCamposTmp 'PJFnotifi', 'codnotifi', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFnotifi] ADD CONSTRAINT [PJFNOTIFI_CODNOTIFI] PRIMARY KEY(codnotifi)
exec AlterarCamposTmp 'PJFnotifi', 'modulo', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'PJFnotifi', 'descrica', 'varchar', 'VARCHAR(120)', '120'
exec AlterarCamposTmp 'PJFnotifi', 'activid', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFnotifi', 'menuid', 'varchar', 'VARCHAR(15)', '15'
exec AlterarCamposTmp 'PJFnotifi', 'usernivl', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFnotifi', 'wfid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'PJFnotifi', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFprmfrm','codprmfrm','I',6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFprmfrm','PJF','codprmfrm'
exec AlterarCamposTmp 'PJFprmfrm', 'codprmfrm', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFprmfrm] ADD CONSTRAINT [PJFPRMFRM_CODPRMFRM] PRIMARY KEY(codprmfrm)
exec AlterarCamposTmp 'PJFprmfrm', 'desform', 'varchar', 'VARCHAR(8)', '8'
exec AlterarCamposTmp 'PJFprmfrm', 'perfil', 'varchar', 'VARCHAR(2)', '2'
exec AlterarCamposTmp 'PJFprmfrm', 'autoriza', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFprmfrm', 'sevalida', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFprmfrm', 'prfvalid', 'varchar', 'VARCHAR(2)', '2'
exec AlterarCamposTmp 'PJFprmfrm', 'prazodia', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFprmfrm', 'comprova', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'PJFprmfrm', 'prazohor', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFprmfrm', 'secompro', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFprmfrm', 'mensag1', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFprmfrm', 'mensag2', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFprmfrm', 'mensag3', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFprmfrm', 'mensag4', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFprmfrm', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFscrcrd','codscrcrd','I', 6 ,  @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFscrcrd','PJF','codscrcrd'
exec AlterarCamposTmp 'PJFscrcrd', 'codscrcrd', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFscrcrd] ADD CONSTRAINT [PJFSCRCRD_CODSCRCRD] PRIMARY KEY(codscrcrd)
exec AlterarCamposTmp 'PJFscrcrd', 'descrica', 'varchar', 'VARCHAR(60)', '60'
exec AlterarCamposTmp 'PJFscrcrd', 'valor', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFscrcrd', 'cor', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFscrcrd', 'seta', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFscrcrd', 'usernivl', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'PJFscrcrd', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

if exists(select name from sysobjects where xtype = 'u' and name = 'PJFdocums')
BEGIN
declare @NewTable as bit;
	exec CriarTabelaTmp 'PJFdocums','coddocums','I', 6 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'PJFdocums','PJF','coddocums'

	exec AlterarCamposTmp 'PJFdocums', 'coddocums', 'int', 'INT NOT NULL', '8'
	exec AlinharCmpDireitaTmp 'PJFdocums', 'coddocums', '8', 'FF_DIREITA', 'dbText'
	if (not exists(select * from sysobjects where xtype = 'PK' and parent_obj = (select id from sysobjects where name = 'PJFdocums') and name = 'PJFDOCUMS_CODDOCUMS'))
		ALTER TABLE [PJFdocums] ADD CONSTRAINT [PJFDOCUMS_CODDOCUMS] PRIMARY KEY(coddocums)
	
	exec AlterarCamposTmp 'PJFdocums', 'documid', 'int', 'INT', '8'

--Caso a versão anterior tenha sido gerada para sql2005, a coluna document será do tipo IMAGE.
--Ao passar de uma versão para a outra, forçar a filestream numa coluna já existente dá erro por limitação do próprio sql.
--Tem de ser criada uma nova coluna e os dados passados para ela
--Dropar a image e rename a nova coluna para document
IF (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'PJFdocums' AND [COLUMN_NAME] = 'document') = 'image'
BEGIN
	SET ANSI_WARNINGS OFF;
	exec sp_RENAME 'PJFdocums.document', 'document_temp' , 'COLUMN';
	exec AlterarCamposTmp 'PJFdocums', 'document', 'varbinary', 'VARBINARY(MAX)', '';
	EXECUTE sp_executesql N'UPDATE [PJFdocums] set document = document_temp; ALTER TABLE [PJFdocums] DROP COLUMN document_temp;';
	SET ANSI_WARNINGS ON;
END
ELSE
BEGIN 
	IF (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'PJFdocums' AND [COLUMN_NAME] = 'document') = 'varchar'
	BEGIN
		SET ANSI_WARNINGS OFF	;
		exec sp_RENAME 'PJFdocums.document', 'document_temp' , 'COLUMN';
		exec AlterarCamposTmp 'PJFdocums', 'document', 'varbinary', 'VARBINARY(MAX)', '';
		exec AlterarCamposTmp 'PJFdocums', 'docpath', 'varchar', 'VARCHAR(260)', '260';
		EXECUTE sp_executesql N'UPDATE [PJFdocums] set docpath = document_temp; ALTER TABLE [PJFdocums] DROP COLUMN document_temp;';
	END
	ELSE
	BEGIN
		exec AlterarCamposTmp 'PJFdocums', 'document', 'varbinary', 'VARBINARY(MAX)', ''
	END
END

exec AlterarCamposTmp 'PJFdocums', 'docpath', 'varchar', 'VARCHAR(260)', '260'

	exec AlterarCamposTmp 'PJFdocums', 'tabela', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFdocums', 'campo', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'PJFdocums', 'chave', 'varchar', 'VARCHAR(36)', '36'
	exec AlterarCamposTmp 'PJFdocums', 'form', 'varchar', 'VARCHAR(8)', '8'
	exec AlterarCamposTmp 'PJFdocums', 'nome', 'varchar', 'VARCHAR(255)', '255'
	exec AlterarCamposTmp 'PJFdocums', 'versao', 'varchar', 'VARCHAR(10)', '10'
	exec AlterarCamposTmp 'PJFdocums', 'tamanho', 'float', 'FLOAT(53)', '10'
	exec AlterarCamposTmp 'PJFdocums', 'extensao', 'varchar', 'VARCHAR(5)', '5'
	exec AlterarCamposTmp 'PJFdocums', 'opercria', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'PJFdocums', 'datacria', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'PJFdocums', 'opermuda', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'PJFdocums', 'datamuda', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'PJFdocums', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
END
GO

--A tabela docums deixou de ter o prefixo do sistema, e passa a chamar-se apenas "docums" de forma a poder ser reutilizada por sistemas partilhados.
--Caso esta bd tenha mais do que um sistema, é necessário migrar os documentos de todos os sistemas, excepto do primeiro que reindexar a bd. Ou seja,
--o primeiro faz o rename da tabela (visto não mudar nada a nivel da estrutura da tabela) e os restantes fazem inserts.
--EDIT:Adaptei e retirei o código do ficheiro ActStoredProcFIM e coloquei aqui de forma a conseguir evitar migração / duplicação de dados para BD's com um único sistema.
--Como este script corre primeiro que o ActStoredProcFIM, a docums já vai estar criada nessa altura, com os respectivos indices e filestream, pelo que apagar a docums e renomear a PJFDocums 
--iria originar uma segunda reindexação para corrigir os indices.
IF EXISTS(SELECT top 1 name FROM sysobjects WHERE name = 'PJFdocums')
BEGIN
    IF EXISTS(SELECT top 1 name FROM sysobjects WHERE name = 'docums')
    BEGIN
        INSERT INTO DOCUMS ([coddocums],[documid],[document],[docpath],[tabela],[campo],[chave],[form],[nome],[versao],[tamanho],[extensao],[opercria],[datacria],[opermuda],[datamuda],[ZZSTATE])
        SELECT [coddocums],[documid],[document],[docpath],[tabela],[campo],[chave],[form],[nome],[versao],[tamanho],[extensao],[opercria],[datacria],[opermuda],[datamuda],[ZZSTATE] FROM [PJFDOCUMS]
        EXEC sp_rename 'PJFdocums', 'backupPJFdocums'
    END
    ELSE
    BEGIN
        EXEC sp_rename 'PJFdocums', 'docums'
        EXEC sp_rename 'PJFdocums_CODDOCUMS', 'DOCUMS_CODDOCUMS'
    END
END
GO

	declare @NewTable as bit;
	exec CriarTabelaTmp 'docums','coddocums','I', 8 , @NewTable OUTPUT
	if (@NewTable = 0)
		exec ApagarTodosIndicesTmp 'docums','PJF','coddocums'

	exec AlterarCamposTmp 'docums', 'coddocums', 'int', 'INT NOT NULL', '8'
	if (not exists(select * from sysobjects where xtype = 'PK' and parent_obj = (select id from sysobjects where name = 'docums') and name = 'DOCUMS_CODDOCUMS'))
		ALTER TABLE docums ADD CONSTRAINT [DOCUMS_CODDOCUMS] PRIMARY KEY(coddocums)
	
	exec AlterarCamposTmp 'docums', 'documid', 'int', 'INT', '8'

--Caso a versão anterior tenha sido gerada para sql2005, a coluna document será do tipo IMAGE.
--Ao passar de uma versão para a outra, forçar a filestream numa coluna já existente dá erro por limitação do próprio sql.
--Tem de ser criada uma nova coluna e os dados passados para ela
--Dropar a image e rename a nova coluna para document
IF (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'docums' AND [COLUMN_NAME] = 'document') = 'image'
BEGIN
	SET ANSI_WARNINGS OFF	;
	exec sp_RENAME 'docums.document', 'document_temp' , 'COLUMN';
	exec AlterarCamposTmp 'docums', 'document', 'varbinary', 'VARBINARY(MAX)', '';
	EXECUTE sp_executesql N'UPDATE docums set document = document_temp; ALTER TABLE docums DROP COLUMN document_temp;';
	SET ANSI_WARNINGS ON;
END
ELSE
BEGIN 
	IF (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'docums' AND [COLUMN_NAME] = 'document') = 'varchar' or (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'docums' AND [COLUMN_NAME] = 'document') = 'nvarchar'
	BEGIN
		SET ANSI_WARNINGS OFF	;
		exec sp_RENAME 'docums.document', 'document_temp' , 'COLUMN';
		exec AlterarCamposTmp 'docums', 'document', 'varbinary', 'VARBINARY(MAX)', '';
		exec AlterarCamposTmp 'docums', 'docpath', 'varchar', 'VARCHAR(260)', '260';
		EXECUTE sp_executesql N'UPDATE docums set docpath = document_temp; ALTER TABLE docums DROP COLUMN document_temp;';
	END
	ELSE
	BEGIN
		exec AlterarCamposTmp 'docums', 'document', 'varbinary', 'VARBINARY(MAX)', ''
	END
END

	exec AlterarCamposTmp 'docums', 'docpath', 'varchar', 'VARCHAR(260)', '260'

	exec AlterarCamposTmp 'docums', 'tabela', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'docums', 'campo', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'docums', 'chave', 'varchar', 'VARCHAR(36)', '36'
	exec AlterarCamposTmp 'docums', 'form', 'varchar', 'VARCHAR(8)', '8'
	exec AlterarCamposTmp 'docums', 'nome', 'varchar', 'VARCHAR(255)', '255'
	exec AlterarCamposTmp 'docums', 'versao', 'varchar', 'VARCHAR(10)', '10'
	exec AlterarCamposTmp 'docums', 'tamanho', 'float', 'FLOAT(53)', '10'
	exec AlterarCamposTmp 'docums', 'extensao', 'varchar', 'VARCHAR(5)', '5'
	exec AlterarCamposTmp 'docums', 'opercria', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'docums', 'datacria', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'docums', 'opermuda', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'docums', 'datamuda', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'docums', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFpostit','codpostit','I', 6,  @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFpostit','PJF','codpostit'
exec AlterarCamposTmp 'PJFpostit', 'codpostit', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFpostit] ADD CONSTRAINT [PJFPOSTIT_CODPOSTIT] PRIMARY KEY(codpostit)
exec AlterarCamposTmp 'PJFpostit', 'tabela', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'PJFpostit', 'codtabel', 'varchar', 'VARCHAR(32)', '32'
exec AlterarCamposTmp 'PJFpostit', 'postit', 'varchar', 'VARCHAR(255)', '255'
exec AlterarCamposTmp 'PJFpostit', 'tpostit', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFpostit', 'datacria', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFpostit', 'opercria', 'varchar', 'VARCHAR(100)', '100'

exec AlterarCamposTmp 'PJFpostit', 'codpsw', 'int', 'int', '8'
exec AlterarCamposTmp 'PJFpostit', 'lido', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFpostit', 'apagado', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFpostit', 'validade', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFpostit', 'nivel', 'float', 'FLOAT(53)', '53'

exec AlterarCamposTmp 'PJFpostit', 'codpost1', 'int', 'INT', '6'
exec AlterarCamposTmp 'PJFpostit', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'hashcd','codhashcd','I', 6 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'hashcd','PJF','codhashcd'
exec AlterarCamposTmp 'hashcd', 'codhashcd', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE hashcd ADD CONSTRAINT [HASHCD_CODHASHCD] PRIMARY KEY(codhashcd)
exec AlterarCamposTmp 'hashcd', 'tabela', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'hashcd', 'campos', 'varchar', 'VARCHAR(900)', '900'
exec AlterarCamposTmp 'hashcd', 'datacria', 'datetime', 'DATETIME', '6'
exec AlterarCamposTmp 'hashcd', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFalerta','codalerta','I', 6 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFalerta','PJF','codalerta'
exec AlterarCamposTmp 'PJFalerta', 'codalerta', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFalerta] ADD CONSTRAINT [PJFALERTA_CODALERTA] PRIMARY KEY(codalerta)
exec AlterarCamposTmp 'PJFalerta', 'codaltent', 'int', 'INT', '6'
exec AlterarCamposTmp 'PJFalerta', 'mensagem', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFalerta', 'tratado', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFalerta', 'activo', 'float', 'FLOAT(53)', '1'
exec AlterarCamposTmp 'PJFalerta', 'datacria', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFalerta', 'datareso', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFalerta', 'menu', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'PJFalerta', 'cor', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFalerta', 'interno', 'float', 'FLOAT(53)', '1'
exec AlterarCamposTmp 'PJFalerta', 'backgrou', 'int', 'INT', '1'
exec AlterarCamposTmp 'PJFalerta', 'sms', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFalerta', 'email', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFalerta', 'emailenv', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFalerta', 'smsenvia', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFalerta', 'codigo', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFalerta', 'codigotp', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFalerta', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFaltent','codaltent','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFaltent','PJF','codaltent'
exec AlterarCamposTmp 'PJFaltent', 'codaltent', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFaltent] ADD CONSTRAINT [PJFALTENT_CODALTENT] PRIMARY KEY(codaltent)
exec AlterarCamposTmp 'PJFaltent', 'codtalert', 'int', 'INT', '6'

exec AlterarCamposTmp 'PJFaltent', 'codpsw', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFaltent', 'grupo', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'PJFaltent', 'contador', 'float', 'FLOAT(53)', '5'
exec AlterarCamposTmp 'PJFaltent', 'tipo', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFaltent', 'mensagem', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFaltent', 'antecede', 'float', 'FLOAT(53)', '3'
exec AlterarCamposTmp 'PJFaltent', 'datainic', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFaltent', 'datafina', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFaltent', 'dtmodifi', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFaltent', 'todos', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFaltent', 'backgrou', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFaltent', 'sms', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFaltent', 'email', 'tinyint', 'TINYINT', '1'

exec AlterarCamposTmp 'PJFaltent', 'codtpgru', 'int', 'INT  NOT NULL ', '8'
exec AlterarCamposTmp 'PJFaltent', 'codtpess', 'int', 'INT  NOT NULL ', '8'

exec AlterarCamposTmp 'PJFaltent', 'menu', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'PJFaltent', 'incluian', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFaltent', 'activo', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFaltent', 'individu', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFaltent', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFtalert','codtalert','I',  6 , @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFtalert','PJF','codtalert'
exec AlterarCamposTmp 'PJFtalert', 'codtalert', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFtalert] ADD CONSTRAINT [PJFTALERT_CODTALERT] PRIMARY KEY(codtalert)
exec AlterarCamposTmp 'PJFtalert', 'nome', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'metodo', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'priorida', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFtalert', 'cor', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFtalert', 'texto', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'menu', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'PJFtalert', 'cmpnome', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'daltinic', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'PJFtalert', 'daltfina', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'PJFtalert', 'incluian', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFtalert', 'diferenc', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFtalert', 'anodifer', 'float', 'FLOAT(53)', '2'
exec AlterarCamposTmp 'PJFtalert', 'mesdifer', 'float', 'FLOAT(53)', '2'
exec AlterarCamposTmp 'PJFtalert', 'diadifer', 'float', 'FLOAT(53)', '2'
exec AlterarCamposTmp 'PJFtalert', 'ntabmae', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'ntabfilh', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'formid', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'tabela', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'campo', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFtalert', 'tipo', 'float', 'FLOAT(53)', '4'
exec AlterarCamposTmp 'PJFtalert', 'modulo', 'varchar', 'VARCHAR(5)', '5'
exec AlterarCamposTmp 'PJFtalert', 'condicao', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'PJFtalert', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFdelega','coddelega','I',  6,  @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFdelega','PJF','coddelega'
exec AlterarCamposTmp 'PJFdelega', 'coddelega', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFdelega] ADD CONSTRAINT [PJFDELEGA_CODDELEGA] PRIMARY KEY(coddelega)
exec AlterarCamposTmp 'PJFdelega', 'codpswup', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFdelega', 'codpswdw', 'int', 'INT', '8'
exec AlterarCamposTmp 'PJFdelega', 'dateini', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFdelega', 'dateend', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFdelega', 'message', 'varchar', 'VARCHAR(4000)', '4000'
exec AlterarCamposTmp 'PJFdelega', 'revoked', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFdelega', 'auditusr', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFdelega', 'opercria', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFdelega', 'datacria', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFdelega', 'opermuda', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFdelega', 'datamuda', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFdelega', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO



declare @NewTable as bit;
exec CriarTabelaTmp 'PJFTABDINAMIC','codtabdinamic','I', 6,  @NewTable OUTPUT
exec AlterarCamposTmp 'PJFTABDINAMIC', 'NOMETABELA', 'varchar', 'VARCHAR(25)', '25'
exec AlterarCamposTmp 'PJFTABDINAMIC', 'NOMECAMPO', 'varchar', 'VARCHAR(25)', '25'
exec AlterarCamposTmp 'PJFTABDINAMIC', 'TIPODADOS', 'varchar', 'VARCHAR(15)', '15'
exec AlterarCamposTmp 'PJFTABDINAMIC', 'TIPOSQL', 'varchar', 'VARCHAR(15)', '15'
exec AlterarCamposTmp 'PJFTABDINAMIC', 'LARGURA', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFTABDINAMIC', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

USE [W_GnBD]
if not exists(SELECT top 1 name FROM sysobjects where name = 'logPJFpro')
begin
	EXEC ('CREATE TABLE logPJFpro ( [Login] [varchar](100) NULL ) ')
end
exec ApagarTodosIndicesTmp 'logPJFpro','PJF'
exec AlterarCamposTmp 'logPJFpro', 'Login', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'logPJFpro', 'Data', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'logPJFpro', 'Accao', 'varchar', 'VARCHAR(200)', '200'
GO



declare @NewTable as bit;
exec CriarTabelaTmp 'PJFaltran','codaltran','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFaltran','PJF','codaltran'

exec AlterarCamposTmp 'PJFaltran', 'codaltran', 'int', 'INT NOT NULL', '16'
if (@NewTable = 1)
	ALTER TABLE [PJFaltran] ADD CONSTRAINT [PJFALTRAN_CODALTRAN] PRIMARY KEY(codaltran)
exec AlterarCamposTmp 'PJFaltran', 'typlabel', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'PJFaltran', 'referenc', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'PJFaltran', 'language', 'varchar', 'VARCHAR(2)', '2'
exec AlterarCamposTmp 'PJFaltran', 'curlabel', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'PJFaltran', 'labellng', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'PJFaltran', 'altran', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'PJFaltran', 'opercria', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFaltran', 'datacria', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFaltran', 'opermuda', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFaltran', 'datamuda', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFaltran', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO



declare @NewTable as bit;
exec CriarTabelaTmp 'PJFworkflowtask','codtask','I',  6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFworkflowtask','PJF','codtask'
exec AlterarCamposTmp 'PJFworkflowtask', 'codtask', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFworkflowtask] ADD CONSTRAINT [PJFWORKFLOWTASK_CODTASK_] PRIMARY KEY(codtask)
exec AlterarCamposTmp 'PJFworkflowtask', 'codprcess', 'int', 'INT', '6'

exec AlterarCamposTmp 'PJFworkflowtask', 'taskdefid', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFworkflowtask', 'taskid', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'PJFworkflowtask', 'performedby', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFworkflowtask', 'runningsince', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFworkflowtask', 'nextrun', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFworkflowtask', 'modifieddate', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFworkflowtask', 'modifiedby', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFworkflowtask', 'skipped', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'PJFworkflowtask', 'isactive', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'PJFworkflowtask', 'errorExecute', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFworkflowtask', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO



declare @NewTable as bit;
exec CriarTabelaTmp 'PJFworkflowprocess','codprcess','I',  6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFworkflowprocess','PJF','codprcess'
exec AlterarCamposTmp 'PJFworkflowprocess', 'codprcess', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFworkflowprocess] ADD CONSTRAINT [PJFWORKFLOWPROCESS_CODPRCESS] PRIMARY KEY(codprcess)
exec AlterarCamposTmp 'PJFworkflowprocess', 'prcessid', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFworkflowprocess', 'prcessdefid', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'PJFworkflowprocess', 'createdby', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'PJFworkflowprocess', 'status', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'PJFworkflowprocess', 'startdate', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFworkflowprocess', 'modifieddate', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'PJFworkflowprocess', 'modifiedby', 'varchar', 'VARCHAR(100)', '100'

exec AlterarCamposTmp 'PJFworkflowprocess', 'codinstance', 'int', 'INT', '6'

exec AlterarCamposTmp 'PJFworkflowprocess', 'dotgraph', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'PJFworkflowprocess', 'wferror', 'int', 'INT', '2'
exec AlterarCamposTmp 'PJFworkflowprocess', 'ltask', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFworkflowprocess', 'idhk', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFworkflowprocess', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

--Se por alguma razão ainda não existe a tabela de logs, cria-a
IF OBJECT_ID('dbo.logPJFall', 'U') IS NULL
BEGIN
  USE [W_GnBD]
	CREATE TABLE [dbo].[logPJFall](
	  [COD] [varchar](38) NOT NULL,
	  [LOGTABLE] [varchar](50) NULL,
		[LOGFIELD] [varchar](50) NULL,
		[OP] [char](1) NOT NULL,
		[VAL] [varchar](MAX) NULL,
		[DATE] [datetime] NOT NULL,
		[WHO] [varchar](50) NULL
	)
END
GO

IF OBJECT_ID('dbo.PswBlacklist', 'U') IS NULL
BEGIN
	USE [W_GnBD]
	CREATE TABLE PswBlacklist (
		pass VARCHAR(64) PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = on)
	)
END
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'PJFalerts','codalerts','I',6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'PJFalerts','PJF','codalerts'
exec AlterarCamposTmp 'PJFalerts', 'Codalerts', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [PJFalerts] ADD CONSTRAINT [PJFALERTS_CODALERTS]  PRIMARY KEY(codalerts)
exec AlterarCamposTmp 'PJFalerts', 'Codpsw', 'int', 'INT', '6'
exec AlterarCamposTmp 'PJFalerts', 'Content', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'PJFalerts', 'Datacria', 'datetime', 'DATETIME', '8' 
exec AlterarCamposTmp 'PJFalerts', 'Datamuda', 'datetime', 'DATETIME', '8' 
exec AlterarCamposTmp 'PJFalerts', 'Delay', 'int', 'INT', '5' 
exec AlterarCamposTmp 'PJFalerts', 'Dismissable', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFalerts', 'Idalert', 'varchar','VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFalerts', 'Inactive', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'PJFalerts', 'Modulo', 'varchar', 'VARCHAR(10)', '10'
exec AlterarCamposTmp 'PJFalerts', 'Nivel', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'PJFalerts', 'Title', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'PJFalerts', 'Type', 'int', 'INT', '1' --enum: success, info, warning, danger
exec AlterarCamposTmp 'PJFalerts', 'URL', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'PJFalerts', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'ReportList','codreport','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'ReportList','PJF','codreport'
exec AlterarCamposTmp 'ReportList', 'codreport', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [ReportList] ADD CONSTRAINT [REPORTLIST_CODREPORT] PRIMARY KEY(codreport)
exec AlterarCamposTmp 'ReportList', 'REPORT', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'ReportList', 'SLOTID', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'ReportList', 'TITULO', 'varchar', 'VARCHAR(120)', '120'
exec AlterarCamposTmp 'ReportList', 'OPERCRIA', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'ReportList', 'DATACRIA', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'ReportList', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

declare @NewTable as bit;
exec CriarTabelaTmp 'Cavreport','codreport','I', 6, @NewTable OUTPUT
if (@NewTable = 0)
	exec ApagarTodosIndicesTmp 'Cavreport','PJF','codreport'
exec AlterarCamposTmp 'Cavreport', 'codreport', 'int', 'INT NOT NULL', '6'
if (@NewTable = 1)
	ALTER TABLE [Cavreport] ADD CONSTRAINT [CAVREPORT_CODREPORT] PRIMARY KEY(codreport)
exec AlterarCamposTmp 'Cavreport', 'TITLE', 'varchar', 'VARCHAR(200)', '200'
exec AlterarCamposTmp 'Cavreport', 'ACESSO', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'Cavreport', 'DATAXML', 'varchar', 'VARCHAR(MAX)', '8000'
exec AlterarCamposTmp 'Cavreport', 'OPERCRIA', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'Cavreport', 'DATACRIA', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'Cavreport', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO


