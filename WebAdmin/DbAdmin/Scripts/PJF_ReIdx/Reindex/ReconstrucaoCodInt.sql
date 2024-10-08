USE [W_GnBD]
DECLARE @nextcod bigint

if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFAIRLN')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFAIRLN', coalesce(cast((select max(codairln) from PJFAIRLN) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codairln) from PJFAIRLN) as bigint) + 1, 1) where id_objecto = 'PJFAIRLN'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFAIRPT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFAIRPT', coalesce(cast((select max(codairpt) from PJFAIRPT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codairpt) from PJFAIRPT) as bigint) + 1, 1) where id_objecto = 'PJFAIRPT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFAPSW')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFAPSW', coalesce(cast((select max(codhpsw) from PJFAPSW) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codhpsw) from PJFAPSW) as bigint) + 1, 1) where id_objecto = 'PJFAPSW'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFBOOKG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFBOOKG', coalesce(cast((select max(codbookg) from PJFBOOKG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codbookg) from PJFBOOKG) as bigint) + 1, 1) where id_objecto = 'PJFBOOKG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFCITY')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFCITY', coalesce(cast((select max(codcity) from PJFCITY) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codcity) from PJFCITY) as bigint) + 1, 1) where id_objecto = 'PJFCITY'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFCREW')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFCREW', coalesce(cast((select max(codcrew) from PJFCREW) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codcrew) from PJFCREW) as bigint) + 1, 1) where id_objecto = 'PJFCREW'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFFLIGH')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFFLIGH', coalesce(cast((select max(codfligh) from PJFFLIGH) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codfligh) from PJFFLIGH) as bigint) + 1, 1) where id_objecto = 'PJFFLIGH'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFMAINT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFMAINT', coalesce(cast((select max(codmaint) from PJFMAINT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codmaint) from PJFMAINT) as bigint) + 1, 1) where id_objecto = 'PJFMAINT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFMATE')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFMATE', coalesce(cast((select max(codmate) from PJFMATE) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codmate) from PJFMATE) as bigint) + 1, 1) where id_objecto = 'PJFMATE'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFPERSO')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFPERSO', coalesce(cast((select max(codperso) from PJFPERSO) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codperso) from PJFPERSO) as bigint) + 1, 1) where id_objecto = 'PJFPERSO'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFPILOT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFPILOT', coalesce(cast((select max(codpilot) from PJFPILOT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codpilot) from PJFPILOT) as bigint) + 1, 1) where id_objecto = 'PJFPILOT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFPLANE')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFPLANE', coalesce(cast((select max(codplane) from PJFPLANE) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codplane) from PJFPLANE) as bigint) + 1, 1) where id_objecto = 'PJFPLANE'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'UserLogin')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('UserLogin', coalesce(cast((select max(codpsw) from UserLogin) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codpsw) from UserLogin) as bigint) + 1, 1) where id_objecto = 'UserLogin'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFROUTE')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFROUTE', coalesce(cast((select max(codroute) from PJFROUTE) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codroute) from PJFROUTE) as bigint) + 1, 1) where id_objecto = 'PJFROUTE'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'NotificationEmailSignature')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('NotificationEmailSignature', coalesce(cast((select max(codsigna) from NotificationEmailSignature) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codsigna) from NotificationEmailSignature) as bigint) + 1, 1) where id_objecto = 'NotificationEmailSignature'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'NotificationMessage')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('NotificationMessage', coalesce(cast((select max(codmesgs) from NotificationMessage) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codmesgs) from NotificationMessage) as bigint) + 1, 1) where id_objecto = 'NotificationMessage'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AsyncProcessAttachments')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AsyncProcessAttachments', coalesce(cast((select max(codpranx) from AsyncProcessAttachments) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codpranx) from AsyncProcessAttachments) as bigint) + 1, 1) where id_objecto = 'AsyncProcessAttachments'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'UserAuthorization')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('UserAuthorization', coalesce(cast((select max(codua) from UserAuthorization) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codua) from UserAuthorization) as bigint) + 1, 1) where id_objecto = 'UserAuthorization'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFMEM')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFMEM', coalesce(cast((select max(CODMEM) from PJFMEM) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODMEM) from PJFMEM) as bigint) + 1, 1) where id_objecto = 'PJFMEM'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFCFG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFCFG', coalesce(cast((select max(CODCFG) from PJFCFG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODCFG) from PJFCFG) as bigint) + 1, 1) where id_objecto = 'PJFCFG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFUSRSET')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFUSRSET', coalesce(cast((select max(CODUSRSET) from PJFUSRSET) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODUSRSET) from PJFUSRSET) as bigint) + 1, 1) where id_objecto = 'PJFUSRSET'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFUSRCFG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFUSRCFG', coalesce(cast((select max(CODUSRCFG) from PJFUSRCFG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODUSRCFG) from PJFUSRCFG) as bigint) + 1, 1) where id_objecto = 'PJFUSRCFG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFWKFACT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFWKFACT', coalesce(cast((select max(CODWKFACT) from PJFWKFACT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODWKFACT) from PJFWKFACT) as bigint) + 1, 1) where id_objecto = 'PJFWKFACT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFWKFCON')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFWKFCON', coalesce(cast((select max(CODWKFCON) from PJFWKFCON) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODWKFCON) from PJFWKFCON) as bigint) + 1, 1) where id_objecto = 'PJFWKFCON'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFWKFLIG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFWKFLIG', coalesce(cast((select max(CODWKFLIG) from PJFWKFLIG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODWKFLIG) from PJFWKFLIG) as bigint) + 1, 1) where id_objecto = 'PJFWKFLIG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFWKFLOW')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFWKFLOW', coalesce(cast((select max(CODWKFLOW) from PJFWKFLOW) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODWKFLOW) from PJFWKFLOW) as bigint) + 1, 1) where id_objecto = 'PJFWKFLOW'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFNOTIFI')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFNOTIFI', coalesce(cast((select max(CODNOTIFI) from PJFNOTIFI) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODNOTIFI) from PJFNOTIFI) as bigint) + 1, 1) where id_objecto = 'PJFNOTIFI'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFSCRCRD')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFSCRCRD', coalesce(cast((select max(CODSCRCRD) from PJFSCRCRD) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODSCRCRD) from PJFSCRCRD) as bigint) + 1, 1) where id_objecto = 'PJFSCRCRD'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFPOSTIT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFPOSTIT', coalesce(cast((select max(CODPOSTIT) from PJFPOSTIT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODPOSTIT) from PJFPOSTIT) as bigint) + 1, 1) where id_objecto = 'PJFPOSTIT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFPRMFRM')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFPRMFRM', coalesce(cast((select max(CODPRMFRM) from PJFPRMFRM) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODPRMFRM) from PJFPRMFRM) as bigint) + 1, 1) where id_objecto = 'PJFPRMFRM'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFALERTA')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFALERTA', coalesce(cast((select max(CODALERTA) from PJFALERTA) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODALERTA) from PJFALERTA) as bigint) + 1, 1) where id_objecto = 'PJFALERTA'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFALTENT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFALTENT', coalesce(cast((select max(CODALTENT) from PJFALTENT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODALTENT) from PJFALTENT) as bigint) + 1, 1) where id_objecto = 'PJFALTENT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFTALERT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFTALERT', coalesce(cast((select max(CODTALERT) from PJFTALERT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODTALERT) from PJFTALERT) as bigint) + 1, 1) where id_objecto = 'PJFTALERT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFDELEGA')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFDELEGA', coalesce(cast((select max(CODDELEGA) from PJFDELEGA) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODDELEGA) from PJFDELEGA) as bigint) + 1, 1) where id_objecto = 'PJFDELEGA'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFLSTUSR')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFLSTUSR', coalesce(cast((select max(CODLSTUSR) from PJFLSTUSR) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODLSTUSR) from PJFLSTUSR) as bigint) + 1, 1) where id_objecto = 'PJFLSTUSR'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFLSTCOL')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFLSTCOL', coalesce(cast((select max(CODLSTCOL) from PJFLSTCOL) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODLSTCOL) from PJFLSTCOL) as bigint) + 1, 1) where id_objecto = 'PJFLSTCOL'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFLSTREN')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFLSTREN', coalesce(cast((select max(CODLSTREN) from PJFLSTREN) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODLSTREN) from PJFLSTREN) as bigint) + 1, 1) where id_objecto = 'PJFLSTREN'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFUSRWID')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFUSRWID', coalesce(cast((select max(CODUSRWID) from PJFUSRWID) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODUSRWID) from PJFUSRWID) as bigint) + 1, 1) where id_objecto = 'PJFUSRWID'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFTBLCFG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFTBLCFG', coalesce(cast((select max(CODTBLCFG) from PJFTBLCFG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODTBLCFG) from PJFTBLCFG) as bigint) + 1, 1) where id_objecto = 'PJFTBLCFG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFTBLCFGSEL')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFTBLCFGSEL', coalesce(cast((select max(CODTBLCFGSEL) from PJFTBLCFGSEL) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODTBLCFGSEL) from PJFTBLCFGSEL) as bigint) + 1, 1) where id_objecto = 'PJFTBLCFGSEL'

if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'HASHCD')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('HASHCD', coalesce(cast((select max(codHASHCD) from HASHCD) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codHASHCD) from HASHCD) as bigint) + 1, 1) where id_objecto = 'HASHCD'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'DOCUMS')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('DOCUMS', coalesce(cast((select max(codDOCUMS) from DOCUMS) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codDOCUMS) from DOCUMS) as bigint) + 1, 1) where id_objecto = 'DOCUMS'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'UserAuthorization')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('UserAuthorization', coalesce(cast((select max(CODUA) from UserAuthorization) as int) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODUA) from UserAuthorization) as int) + 1, 1) where id_objecto = 'UserAuthorization'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFWORKFLOWPROCESS')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFWORKFLOWPROCESS', coalesce(cast((select max(CODPRCESS) from PJFWORKFLOWPROCESS) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODPRCESS) from PJFWORKFLOWPROCESS) as bigint) + 1, 1) where id_objecto = 'PJFWORKFLOWPROCESS'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'PJFWORKFLOWTASK')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('PJFWORKFLOWTASK', coalesce(cast((select max(CODTASK) from PJFWORKFLOWTASK) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODTASK) from PJFWORKFLOWTASK) as bigint) + 1, 1) where id_objecto = 'PJFWORKFLOWTASK'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'NotificationEmailSignature')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('NotificationEmailSignature', coalesce(cast((select max(codsigna) from NotificationEmailSignature) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codsigna) from NotificationEmailSignature) as bigint) + 1, 1) where id_objecto = 'NotificationEmailSignature'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'NotificationMessage')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('NotificationMessage', coalesce(cast((select max(codmesgs) from NotificationMessage) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codmesgs) from NotificationMessage) as bigint) + 1, 1) where id_objecto = 'NotificationMessage'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'ReportList')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('ReportList', coalesce(cast((select max(CODREPORT) from ReportList) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODREPORT) from ReportList) as bigint) + 1, 1) where id_objecto = 'ReportList'
GO
 