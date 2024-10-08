USE [W_GnBD]
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFCITY_CODCITY_', 'codcity', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Tabela NotDup CITY
SELECT 'PJFCITY_CD0C9EE422BD487E', 'city', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfcity', 'PJFCITY_CODCITY_', 'pjf';
end
GO
if (1 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFMEM_CODMEM__', 'codmem', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'pjfmem', 'PJFMEM_CODMEM__', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFPERSO_CODPERSO', 'codperso', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Menu PJF_71
SELECT 'PJFPERSO_5771B2F9165B467C', 'email', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfperso', 'PJFPERSO_CODPERSO', 'pjf';
end
GO
if (1 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'USERLOGIN_CODPSW__', 'codpsw', 1, 1, 0, 1
UNION ALL
SELECT 'USERLOGIN_nome', 'nome', 0, 1, 0, 0
 
exec CheckIdxTmp @tabela, 'userlogin', 'USERLOGIN_CODPSW__', 'pjf';
end
GO
if (1 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'ASYNCPROCESS_CODASCPR', 'codascpr', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'asyncprocess', 'ASYNCPROCESS_CODASCPR', 'pjf';
end
GO
if (1 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'NOTIFICATIONEMAILSIGNATURE_CODSIGNA', 'codsigna', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'notificationemailsignature', 'NOTIFICATIONEMAILSIGNATURE_CODSIGNA', 'pjf';
end
GO
if (1 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'NOTIFICATIONMESSAGE_CODMESGS', 'codmesgs', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'notificationmessage', 'NOTIFICATIONMESSAGE_CODMESGS', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFAIRPT_CODAIRPT', 'codairpt', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Menu PJF_221
SELECT 'PJFAIRPT_B8030807788A4D4F', 'name', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfairpt', 'PJFAIRPT_CODAIRPT', 'pjf';
end
GO
if (1 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'ASYNCPROCESSARGUMENT_CODARGPR', 'codargpr', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'asyncprocessargument', 'ASYNCPROCESSARGUMENT_CODARGPR', 'pjf';
end
GO
if (1 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'ASYNCPROCESSATTACHMENTS_CODPRANX', 'codpranx', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'asyncprocessattachments', 'ASYNCPROCESSATTACHMENTS_CODPRANX', 'pjf';
end
GO
if (1 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'USERAUTHORIZATION_CODUA___', 'codua', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Tabela NotDup S_UA
SELECT 'PJFS_UA_B5399E129F0E448D', 'naodupli', 0, 1, 0, 0
UNION ALL
-- Index with origin: Tabela NotDup S_UA
SELECT 'PJFS_UA_B5399E129F0E448D', 'role', 0, 2, 0, 0

exec CheckIdxTmp @tabela, 'userauthorization', 'USERAUTHORIZATION_CODUA___', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFAIRLN_CODAIRLN', 'codairln', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Menu PJF_211
SELECT 'PJFAIRLN_7CCD72AAA8E0440E', 'name', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfairln', 'PJFAIRLN_CODAIRLN', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFAPSW_CODHPSW_', 'codhpsw', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFAPSW_0A9FFE04DDEC4DBC', 'codairln', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfapsw', 'PJFAPSW_CODHPSW_', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFCREW_CODCREW_', 'codcrew', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFCREW_5F220BC5E7194BE0', 'codairln', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu PJF_621
SELECT 'PJFCREW_5E0148A042F64CD5', 'crewname', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfcrew', 'PJFCREW_CODCREW_', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFPILOT_CODPILOT', 'codpilot', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Tabela NotDup PILOT
SELECT 'PJFPILOT_278794554C2E42E2', 'license', 0, 1, 0, 0
UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFPILOT_BBBFB52B95904A81', 'codairln', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu PJF_611
SELECT 'PJFPILOT_99465CA43AE44343', 'name', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfpilot', 'PJFPILOT_CODPILOT', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFPLANE_CODPLANE', 'codplane', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Tabela NotDup PLANE
SELECT 'PJFPLANE_BABE35CD1DE8460D', 'model', 0, 1, 0, 0
UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFPLANE_1D98F1E0184A4328', 'codairln', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu PJF_31
SELECT 'PJFPLANE_D153B52DE4AA4D97', 'year', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfplane', 'PJFPLANE_CODPLANE', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFROUTE_CODROUTE', 'codroute', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFROUTE_70EDB58D8E274AF7', 'codairln', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu PJF_241
SELECT 'PJFROUTE_CA616C5D38BF46E3', 'duration', 0, 1, 0, 0
UNION ALL
-- Index with origin: DB index FLIGHTROUTENAME
SELECT 'PJFROUTE_640CADDB66324555', 'name', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfroute', 'PJFROUTE_CODROUTE', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFFLIGH_CODFLIGH', 'codfligh', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Tabela NotDup FLIGH
SELECT 'PJFFLIGH_77BD98ECA18B452C', 'codplane', 0, 1, 0, 0
UNION ALL
-- Index with origin: Tabela NotDup FLIGH
SELECT 'PJFFLIGH_3EABE1837DA94182', 'flighnum', 0, 1, 0, 0
UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFFLIGH_8E0E5DA9F8AD4098', 'codairln', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu PJF_251
SELECT 'PJFFLIGH_F12EBD27248D4759', 'depart', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjffligh', 'PJFFLIGH_CODFLIGH', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFMAINT_CODMAINT', 'codmaint', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Formula SR PLANE
SELECT 'PJFMAINT_D1C5D3D728C64227', 'codplane', 0, 1, 0, 0
UNION ALL
SELECT 'PJFMAINT_D1C5D3D728C64227','zzState', 0, 0, 1, 0
UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFMAINT_4CCABAB8346845A4', 'codairln', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfmaint', 'PJFMAINT_CODMAINT', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFMATE_CODMATE_', 'codmate', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Formula SR CREW
SELECT 'PJFMATE_F208398396F64745', 'codcrew', 0, 1, 0, 0
UNION ALL
SELECT 'PJFMATE_F208398396F64745','zzState', 0, 0, 1, 0
UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFMATE_FFD5FAEE36864312', 'codairln', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu PJF_631
SELECT 'PJFMATE_B4F99337049D47F8', 'name', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfmate', 'PJFMATE_CODMATE_', 'pjf';
end
GO
if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'PJFBOOKG_CODBOOKG', 'codbookg', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Tabela NotDup BOOKG
SELECT 'PJFBOOKG_CB8ACC2AD4834BD7', 'bnum', 1, 1, 0, 0
UNION ALL
-- Index with origin: Eph AIRLINE
SELECT 'PJFBOOKG_AEA0E546BCA64895', 'codairln', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'pjfbookg', 'PJFBOOKG_CODBOOKG', 'pjf';
end
GO

if (169 > isnull((select versindx from PJFcfg),0) or 'W_GnZeroTrue'='1')
begin
-- Indíces de tabelas hardcoded (continuam da forma antiga [apagar e criar])
if (exists(select top 1 name from sys.indexes where name = 'pjfalerta_alerta01'))
	DROP INDEX pjfalerta_alerta01 ON pjfalerta
CREATE INDEX pjfalerta_alerta01 ON pjfalerta (codaltent)

if (exists(select top 1 name from sys.indexes where name = 'pjfpostit_postit01'))
	DROP INDEX pjfpostit_postit01 ON pjfpostit
CREATE INDEX pjfpostit_postit01 ON pjfpostit (tabela,codtabel)

if (exists(select top 1 name from sys.indexes where name = 'pjfpostit_postit02'))
	DROP INDEX pjfpostit_postit02 ON pjfpostit
CREATE INDEX pjfpostit_postit02 ON pjfpostit (codtabel)

if (exists(select top 1 name from sys.indexes where name = 'pjfpostit_postit03'))
	DROP INDEX pjfpostit_postit03 ON pjfpostit
CREATE INDEX pjfpostit_postit03 ON pjfpostit (postit)

if (exists(select top 1 name from sys.indexes where name = 'pjfpostit_postit04'))
	DROP INDEX pjfpostit_postit04 ON pjfpostit
CREATE INDEX pjfpostit_postit04 ON pjfpostit (tpostit)

if (exists(select top 1 name from sys.indexes where name = 'pjfpostit_postit05'))
	DROP INDEX pjfpostit_postit05 ON pjfpostit
CREATE INDEX pjfpostit_postit05 ON pjfpostit (codpsw)


if (exists(select top 1 name from sys.indexes where name = 'pjfpostit_postit06'))
	DROP INDEX pjfpostit_postit06 ON pjfpostit
CREATE INDEX pjfpostit_postit06 ON pjfpostit (nivel)

if (exists(select top 1 name from sys.indexes where name = 'pjfpostit_postit07'))
	DROP INDEX pjfpostit_postit07 ON pjfpostit
CREATE INDEX pjfpostit_postit07 ON pjfpostit (codpost1)

if (exists(select top 1 name from sys.indexes where name = 'pjfaltent_altent01'))
	DROP INDEX pjfaltent_altent01 ON pjfaltent
CREATE INDEX pjfaltent_altent01 ON pjfaltent (codtalert,tipo)

if (exists(select top 1 name from sys.indexes where name = 'pjfdelega_delega01'))
	DROP INDEX pjfdelega_delega01 ON pjfdelega
CREATE INDEX pjfdelega_delega01 ON pjfdelega (coddelega,codpswup)

if (exists(select top 1 name from sys.indexes where name = 'pjfdelega_delega02'))
	DROP INDEX pjfdelega_delega02 ON pjfdelega
CREATE INDEX pjfdelega_delega02 ON pjfdelega (coddelega,codpswdw)

if (exists(select top 1 name from sys.indexes where name = 'docums_docums01'))
	DROP INDEX docums_docums01 ON docums
CREATE INDEX docums_docums01 ON docums (documid,versao)

if (exists(select top 1 name from sys.indexes where name = 'docums_docums02'))
	DROP INDEX docums_docums02 ON docums
CREATE INDEX docums_docums02 ON docums (nome)


if (exists(select top 1 name from sys.indexes where name = 'docums_docums03'))
	DROP INDEX docums_docums03 ON docums
CREATE INDEX docums_docums03 ON docums (tabela,ZZSTATE)

if (exists(select top 1 name from sys.indexes where name = 'pjflstusr_codpsw'))
	DROP INDEX pjflstusr_codpsw ON pjflstusr
CREATE INDEX pjflstusr_codpsw ON pjflstusr (codpsw, descric)

if (exists(select top 1 name from sys.indexes where name = 'pjflstcol_codlstusr'))
	DROP INDEX pjflstcol_codlstusr ON pjflstcol
CREATE INDEX pjflstcol_codlstusr ON pjflstcol (codlstusr)

if (exists(select top 1 name from sys.indexes where name = 'pjflstren_codlstusr'))
	DROP INDEX pjflstren_codlstusr ON pjflstren
CREATE INDEX pjflstren_codlstusr ON pjflstren (codlstusr)

if (exists(select top 1 name from sys.indexes where name = 'pjfusrwid_codlstusr'))
	DROP INDEX pjfusrwid_codlstusr ON pjfusrwid
CREATE INDEX pjfusrwid_codlstusr ON pjfusrwid (codlstusr)

if (exists(select top 1 name from sys.indexes where name = 'pjftblcfg_codpsw_uuid_name'))
	DROP INDEX pjftblcfg_codpsw_uuid_name ON pjftblcfg
CREATE INDEX pjftblcfg_codpsw_uuid_name ON pjftblcfg (codpsw, uuid, name)

if (exists(select top 1 name from sys.indexes where name = 'pjftblcfgsel_codpsw_uuid'))
	DROP INDEX pjftblcfgsel_codpsw_uuid ON pjftblcfgsel
CREATE INDEX pjftblcfgsel_codpsw_uuid ON pjftblcfgsel (codpsw, uuid)



if (exists(select top 1 name from sys.indexes where name = 'logpjfall_logpjfall01'))
	DROP INDEX logpjfall_logpjfall01 ON logpjfall
CREATE CLUSTERED INDEX [logpjfall_logpjfall01] ON [dbo].[logPJFall]([LOGTABLE] ASC, [LOGFIELD] ASC, [OP] ASC,[DATE] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


UPDATE PJFcfg set versindx = 169
end
GO