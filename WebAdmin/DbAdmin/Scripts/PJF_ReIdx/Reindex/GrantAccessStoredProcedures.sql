USE [W_GnBD]
declare @ownerDB varchar(40)
set @ownerDB = (select top 1 users.name from sysusers users inner join master.dbo.syslogins logins on users.sid = logins.sid where logins.name = 'QUIDGEST')

if exists(select * from sysobjects where name = 'DropFunctionsOnPublications')
	exec ('GRANT TAKE OWNERSHIP ON [DropFunctionsOnPublications] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'AddFunctionsOnPublications')
	exec ('GRANT TAKE OWNERSHIP ON [AddFunctionsOnPublications] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'emptyL')
	exec ('GRANT TAKE OWNERSHIP ON [emptyL] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'emptyD')
	exec ('GRANT TAKE OWNERSHIP ON [emptyD] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'emptyN')
	exec ('GRANT TAKE OWNERSHIP ON [emptyN] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'emptyC')
	exec ('GRANT TAKE OWNERSHIP ON [emptyC] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'emptyG')
	exec ('GRANT TAKE OWNERSHIP ON [emptyG] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'emptyT')
	exec ('GRANT TAKE OWNERSHIP ON [emptyT] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'theAppAno')
	exec ('GRANT TAKE OWNERSHIP ON [theAppAno] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'theAppSigla')
	exec ('GRANT TAKE OWNERSHIP ON [theAppSigla] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'minD')
	exec ('GRANT TAKE OWNERSHIP ON [minD] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'minN')
	exec ('GRANT TAKE OWNERSHIP ON [minN] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'maxD')
	exec ('GRANT TAKE OWNERSHIP ON [maxD] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'maxN')
	exec ('GRANT TAKE OWNERSHIP ON [maxN] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'atoi')
	exec ('GRANT TAKE OWNERSHIP ON [atoi] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'IntToString')
	exec ('GRANT TAKE OWNERSHIP ON [IntToString] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'SomaDias')
	exec ('GRANT TAKE OWNERSHIP ON [SomaDias] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'RoundQG')
	exec ('GRANT TAKE OWNERSHIP ON [RoundQG] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'ansi_C')
	exec ('GRANT TAKE OWNERSHIP ON [ansi_C] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'ansi_N')
	exec ('GRANT TAKE OWNERSHIP ON [ansi_N] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'ansi_L')
	exec ('GRANT TAKE OWNERSHIP ON [ansi_L] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'ansi_D')
	exec ('GRANT TAKE OWNERSHIP ON [ansi_D] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'KeyToString')
	exec ('GRANT TAKE OWNERSHIP ON [KeyToString] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'StringToKey')
	exec ('GRANT TAKE OWNERSHIP ON [StringToKey] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'ComparaDatas')
	exec ('GRANT TAKE OWNERSHIP ON [ComparaDatas] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'LengthString')
	exec ('GRANT TAKE OWNERSHIP ON [LengthString] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'Impar')
	exec ('GRANT TAKE OWNERSHIP ON [Impar] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'FormatDate')
	exec ('GRANT TAKE OWNERSHIP ON [FormatDate] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'HorasToDouble')
	exec ('GRANT TAKE OWNERSHIP ON [HorasToDouble] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'DoubleToHoras')
	exec ('GRANT TAKE OWNERSHIP ON [DoubleToHoras] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'HorasAdd')
	exec ('GRANT TAKE OWNERSHIP ON [HorasAdd] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'CriaDataHora')
	exec ('GRANT TAKE OWNERSHIP ON [CriaDataHora] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'Diferenca_entre_Datas')
	exec ('GRANT TAKE OWNERSHIP ON [Diferenca_entre_Datas] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'CriarTabelaTmp')
	exec ('GRANT TAKE OWNERSHIP ON [CriarTabelaTmp] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'ApagarTodosIndicesTmp')
	exec ('GRANT TAKE OWNERSHIP ON [ApagarTodosIndicesTmp] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'AlinharCmpDireitaTmp')
	exec ('GRANT TAKE OWNERSHIP ON [AlinharCmpDireitaTmp] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'AlterarCamposTmp')
	exec ('GRANT TAKE OWNERSHIP ON [AlterarCamposTmp] TO ' + @ownerDB)
if exists(select * from sysobjects where name = 'ConcatenarGroupByTmp')
	exec ('GRANT TAKE OWNERSHIP ON [ConcatenarGroupByTmp] TO ' + @ownerDB)
GO
