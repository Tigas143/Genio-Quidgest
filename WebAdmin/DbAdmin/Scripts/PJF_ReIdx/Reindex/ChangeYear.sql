USE [W_GnBD]

GO

USE [W_GnSrcBD]

-- migração de dados da tabela PJFCITY (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFCITY] ([CODCITY], [CITY], [ZZSTATE])
SELECT [CITY].[CODCITY], [CITY].[CITY], [CITY].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFCITY] AS [CITY]
WHERE [CITY].ZZSTATE = 0
GO

-- migração de dados da tabela PJFMEM (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFMEM] ([CODMEM], [LOGIN], [ROTINA], [ALTURA], [OBS], [HOSTID], [CLIENTID], [ZZSTATE])
SELECT [MEM].[CODMEM], [MEM].[LOGIN], [MEM].[ROTINA], [MEM].[ALTURA], [MEM].[OBS], [MEM].[HOSTID], [MEM].[CLIENTID], [MEM].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFMEM] AS [MEM]
WHERE [MEM].ZZSTATE = 0
GO

-- migração de dados da tabela PJFPERSO (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFPERSO] ([CODPERSO], [NAME], [ID], [IDFK], [NATIO], [PHONE], [EMAIL], [ZZSTATE])
SELECT [PERSO].[CODPERSO], [PERSO].[NAME], [PERSO].[ID], [PERSO].[IDFK], [PERSO].[NATIO], [PERSO].[PHONE], [PERSO].[EMAIL], [PERSO].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFPERSO] AS [PERSO]
WHERE [PERSO].ZZSTATE = 0
GO

-- migração de dados da tabela UserLogin (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[UserLogin] ([CODPSW], [NOME], [PASSWORD], [CERTSN], [EMAIL], [PSWTYPE], [SALT], [DATAPSW], [USERID], [PSW2FAVL], [PSW2FATP], [DATEXP], [ATTEMPTS], [PHONE], [STATUS], [ASSOCIA], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [PSW].[CODPSW], [PSW].[NOME], [PSW].[PASSWORD], [PSW].[CERTSN], [PSW].[EMAIL], [PSW].[PSWTYPE], [PSW].[SALT], [PSW].[DATAPSW], [PSW].[USERID], [PSW].[PSW2FAVL], [PSW].[PSW2FATP], [PSW].[DATEXP], [PSW].[ATTEMPTS], [PSW].[PHONE], [PSW].[STATUS], [PSW].[ASSOCIA], [PSW].[OPERCRIA], [PSW].[DATACRIA], [PSW].[OPERMUDA], [PSW].[DATAMUDA], [PSW].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[UserLogin] AS [PSW]
WHERE [PSW].ZZSTATE = 0
GO

-- migração de dados da tabela AsyncProcess (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AsyncProcess] ([CODASCPR], [TYPE], [DATEREQU], [INITPRC], [ENDPRC], [DURATION], [STATUS], [RSLTMSG], [FINISHED], [LASTUPDT], [RESULT], [INFO], [PERCENTA], [MODOPROC], [EXTERNAL], [ID], [CODENTIT], [MOTIVO], [CODPSW], [OPERSHUT], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_APR].[CODASCPR], [S_APR].[TYPE], [S_APR].[DATEREQU], [S_APR].[INITPRC], [S_APR].[ENDPRC], [S_APR].[DURATION], [S_APR].[STATUS], [S_APR].[RSLTMSG], [S_APR].[FINISHED], [S_APR].[LASTUPDT], [S_APR].[RESULT], [S_APR].[INFO], [S_APR].[PERCENTA], [S_APR].[MODOPROC], [S_APR].[EXTERNAL], [S_APR].[ID], [S_APR].[CODENTIT], [S_APR].[MOTIVO], [S_APR].[CODPSW], [S_APR].[OPERSHUT], [S_APR].[OPERCRIA], [S_APR].[DATACRIA], [S_APR].[OPERMUDA], [S_APR].[DATAMUDA], [S_APR].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AsyncProcess] AS [S_APR]
WHERE [S_APR].ZZSTATE = 0
GO

-- migração de dados da tabela NotificationEmailSignature (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[NotificationEmailSignature] ([CODSIGNA], [NAME], [IMAGE], [TEXTASS], [USERNAME], [PASSWORD], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_NES].[CODSIGNA], [S_NES].[NAME], [S_NES].[IMAGE], [S_NES].[TEXTASS], [S_NES].[USERNAME], [S_NES].[PASSWORD], [S_NES].[OPERCRIA], [S_NES].[DATACRIA], [S_NES].[OPERMUDA], [S_NES].[DATAMUDA], [S_NES].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[NotificationEmailSignature] AS [S_NES]
WHERE [S_NES].ZZSTATE = 0
GO

-- migração de dados da tabela NotificationMessage (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[NotificationMessage] ([CODMESGS], [CODSIGNA], [CODPMAIL], [FROM], [CODTPNOT], [CODDESTN], [TO], [DESTNMAN], [TOMANUAL], [CC], [BCC], [IDNOTIF], [NOTIFICA], [EMAIL], [ASSUNTO], [AGREGADO], [ANEXO], [HTML], [ATIVO], [DESIGNAC], [MENSAGEM], [GRAVABD], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_NM].[CODMESGS], [S_NM].[CODSIGNA], [S_NM].[CODPMAIL], [S_NM].[FROM], [S_NM].[CODTPNOT], [S_NM].[CODDESTN], [S_NM].[TO], [S_NM].[DESTNMAN], [S_NM].[TOMANUAL], [S_NM].[CC], [S_NM].[BCC], [S_NM].[IDNOTIF], [S_NM].[NOTIFICA], [S_NM].[EMAIL], [S_NM].[ASSUNTO], [S_NM].[AGREGADO], [S_NM].[ANEXO], [S_NM].[HTML], [S_NM].[ATIVO], [S_NM].[DESIGNAC], [S_NM].[MENSAGEM], [S_NM].[GRAVABD], [S_NM].[OPERCRIA], [S_NM].[DATACRIA], [S_NM].[OPERMUDA], [S_NM].[DATAMUDA], [S_NM].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[NotificationMessage] AS [S_NM]
WHERE [S_NM].ZZSTATE = 0
GO

-- migração de dados da tabela PJFAIRPT (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFAIRPT] ([CODAIRPT], [NAME], [CODCITY], [ZZSTATE])
SELECT [AIRPT].[CODAIRPT], [AIRPT].[NAME], [AIRPT].[CODCITY], [AIRPT].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFAIRPT] AS [AIRPT]
WHERE [AIRPT].ZZSTATE = 0
GO

-- migração de dados da tabela AsyncProcessArgument (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AsyncProcessArgument] ([CODARGPR], [CODS_APR], [ID], [VALOR], [DOCUMENT], [DOCUMENTFK], [TIPO], [DESIGNAC], [HIDDEN], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_ARG].[CODARGPR], [S_ARG].[CODS_APR], [S_ARG].[ID], [S_ARG].[VALOR], [S_ARG].[DOCUMENT], [S_ARG].[DOCUMENTFK], [S_ARG].[TIPO], [S_ARG].[DESIGNAC], [S_ARG].[HIDDEN], [S_ARG].[OPERCRIA], [S_ARG].[DATACRIA], [S_ARG].[OPERMUDA], [S_ARG].[DATAMUDA], [S_ARG].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AsyncProcessArgument] AS [S_ARG]
WHERE [S_ARG].ZZSTATE = 0
GO

-- migração de dados da tabela AsyncProcessAttachments (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AsyncProcessAttachments] ([CODPRANX], [CODS_APR], [DOCUMENT], [DOCUMENTFK], [OPERCRIA], [DATACRIA], [ZZSTATE])
SELECT [S_PAX].[CODPRANX], [S_PAX].[CODS_APR], [S_PAX].[DOCUMENT], [S_PAX].[DOCUMENTFK], [S_PAX].[OPERCRIA], [S_PAX].[DATACRIA], [S_PAX].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AsyncProcessAttachments] AS [S_PAX]
WHERE [S_PAX].ZZSTATE = 0
GO

-- migração de dados da tabela UserAuthorization (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[UserAuthorization] ([CODUA], [CODPSW], [SISTEMA], [MODULO], [NAODUPLI], [ROLE], [NIVEL], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_UA].[CODUA], [S_UA].[CODPSW], [S_UA].[SISTEMA], [S_UA].[MODULO], [S_UA].[NAODUPLI], [S_UA].[ROLE], [S_UA].[NIVEL], [S_UA].[OPERCRIA], [S_UA].[DATACRIA], [S_UA].[OPERMUDA], [S_UA].[DATAMUDA], [S_UA].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[UserAuthorization] AS [S_UA]
WHERE [S_UA].ZZSTATE = 0
GO

-- migração de dados da tabela PJFAIRLN (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFAIRLN] ([CODAIRLN], [NAME], [CODCITY], [CODAIRHB], [ZZSTATE])
SELECT [AIRLN].[CODAIRLN], [AIRLN].[NAME], [AIRLN].[CODCITY], [AIRLN].[CODAIRHB], [AIRLN].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFAIRLN] AS [AIRLN]
WHERE [AIRLN].ZZSTATE = 0
GO

-- migração de dados da tabela PJFAPSW (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFAPSW] ([CODHPSW], [CODAIRLN], [CODPSW], [ZZSTATE])
SELECT [APSW].[CODHPSW], [APSW].[CODAIRLN], [APSW].[CODPSW], [APSW].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFAPSW] AS [APSW]
WHERE [APSW].ZZSTATE = 0
GO

-- migração de dados da tabela PJFCREW (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFCREW] ([CODCREW], [COUNT], [CREWNAME], [CODAIRLN], [ZZSTATE])
SELECT [CREW].[CODCREW], [CREW].[COUNT], [CREW].[CREWNAME], [CREW].[CODAIRLN], [CREW].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFCREW] AS [CREW]
WHERE [CREW].ZZSTATE = 0
GO

-- migração de dados da tabela PJFPILOT (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFPILOT] ([CODPILOT], [NAME], [LICENSE], [EXPERIEN], [CODAIRLN], [ZZSTATE])
SELECT [PILOT].[CODPILOT], [PILOT].[NAME], [PILOT].[LICENSE], [PILOT].[EXPERIEN], [PILOT].[CODAIRLN], [PILOT].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFPILOT] AS [PILOT]
WHERE [PILOT].ZZSTATE = 0
GO

-- migração de dados da tabela PJFPLANE (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFPLANE] ([CODPLANE], [PHOTO], [MODEL], [ENGINES], [MANUFACT], [YEAR], [CAPACITY], [STATUS], [AIRCR], [AGE], [AIRSC], [MAINT], [ISMAINT], [CODAIRLN], [ID], [ZZSTATE])
SELECT [PLANE].[CODPLANE], [PLANE].[PHOTO], [PLANE].[MODEL], [PLANE].[ENGINES], [PLANE].[MANUFACT], [PLANE].[YEAR], [PLANE].[CAPACITY], [PLANE].[STATUS], [PLANE].[AIRCR], [PLANE].[AGE], [PLANE].[AIRSC], [PLANE].[MAINT], [PLANE].[ISMAINT], [PLANE].[CODAIRLN], [PLANE].[ID], [PLANE].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFPLANE] AS [PLANE]
WHERE [PLANE].ZZSTATE = 0
GO

-- migração de dados da tabela PJFROUTE (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFROUTE] ([CODROUTE], [AIRDS], [AIRSC], [DURATION], [NAME], [CODAIRLN], [ZZSTATE])
SELECT [ROUTE].[CODROUTE], [ROUTE].[AIRDS], [ROUTE].[AIRSC], [ROUTE].[DURATION], [ROUTE].[NAME], [ROUTE].[CODAIRLN], [ROUTE].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFROUTE] AS [ROUTE]
WHERE [ROUTE].ZZSTATE = 0
GO

-- migração de dados da tabela PJFFLIGH (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFFLIGH] ([CODFLIGH], [CODPLANE], [CODROUTE], [ARRIVAL], [DEPART], [DURATION], [CODSOURC], [CODCREW], [NAMESC], [CODPILOT], [FLIGHNUM], [CODAIRLN], [ZZSTATE])
SELECT [FLIGH].[CODFLIGH], [FLIGH].[CODPLANE], [FLIGH].[CODROUTE], [FLIGH].[ARRIVAL], [FLIGH].[DEPART], [FLIGH].[DURATION], [FLIGH].[CODSOURC], [FLIGH].[CODCREW], [FLIGH].[NAMESC], [FLIGH].[CODPILOT], [FLIGH].[FLIGHNUM], [FLIGH].[CODAIRLN], [FLIGH].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFFLIGH] AS [FLIGH]
WHERE [FLIGH].ZZSTATE = 0
GO

-- migração de dados da tabela PJFMAINT (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFMAINT] ([CODMAINT], [STATUS], [CODPLANE], [DATE], [CODAIRLN], [ZZSTATE])
SELECT [MAINT].[CODMAINT], [MAINT].[STATUS], [MAINT].[CODPLANE], [MAINT].[DATE], [MAINT].[CODAIRLN], [MAINT].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFMAINT] AS [MAINT]
WHERE [MAINT].ZZSTATE = 0
GO

-- migração de dados da tabela PJFMATE (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFMATE] ([CODMATE], [NAME], [CODCREW], [CODAIRLN], [ZZSTATE])
SELECT [MATE].[CODMATE], [MATE].[NAME], [MATE].[CODCREW], [MATE].[CODAIRLN], [MATE].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFMATE] AS [MATE]
WHERE [MATE].ZZSTATE = 0
GO

-- migração de dados da tabela PJFBOOKG (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[PJFBOOKG] ([CODBOOKG], [BNUM], [FLIGHT], [PRICE], [CODPASGR], [CODAIRLN], [ZZSTATE])
SELECT [BOOKG].[CODBOOKG], [BOOKG].[BNUM], [BOOKG].[FLIGHT], [BOOKG].[PRICE], [BOOKG].[CODPASGR], [BOOKG].[CODAIRLN], [BOOKG].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[PJFBOOKG] AS [BOOKG]
WHERE [BOOKG].ZZSTATE = 0
GO

-- Tabelas Hardcoded
-- migração de dados da tabela Codigos Sequenciais
INSERT INTO [W_GnBD].[dbo].[Codigos_Sequenciais] (id_objecto, proximo)
SELECT id_objecto, proximo FROM [W_GnSrcBD].[dbo].[Codigos_Sequenciais]
GO

-- migração de dados da tabela UserAuthorization
INSERT INTO [W_GnBD].[dbo].[UserAuthorization] (CODUA, CODPSW, SISTEMA, MODULO, ROLE, NIVEL, ZZSTATE)
SELECT UA.CODUA, UA.CODPSW, UA.SISTEMA, UA.MODULO, UA.ROLE, UA.NIVEL, UA.ZZSTATE FROM [W_GnSrcBD].[dbo].[UserAuthorization] AS UA
WHERE UA.ZZSTATE = 0
GO

-- migração de dados da tabela CFG (ao criar schema, fica criada uma linha nesta tabela)
--INSERT INTO [W_GnBD].[dbo].[PJFcfg] (codcfg, checkdat, versao, versindx, manutdat, upgrindx, ZZSTATE)
--SELECT codcfg, checkdat, versao, versindx, manutdat, upgrindx, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFcfg]
--WHERE ZZSTATE = 0
--GO

-- migração de dados da tabela LSTUSR
INSERT INTO [W_GnBD].[dbo].[PJFlstusr] (CODLSTUSR, CODPSW, DESCRIC, IDLIST, MODULO, SISTEMA, ORDERCOL, ORDERTYPE, [DATA], ZZSTATE)
SELECT CODLSTUSR, CODPSW, DESCRIC, IDLIST, MODULO, SISTEMA, ORDERCOL, ORDERTYPE, [DATA], ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFlstusr]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela LSTCOL
INSERT INTO [W_GnBD].[dbo].[PJFlstcol] (CODLSTCOL, CODLSTUSR, TABELA, ALIAS, CAMPO, VISIVEL, POSICAO, OPERACAO, TIPO, ZZSTATE)
SELECT CODLSTCOL, CODLSTUSR, TABELA, ALIAS, CAMPO, VISIVEL, POSICAO, OPERACAO, TIPO, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFlstcol]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela LSTREN
INSERT INTO [W_GnBD].[dbo].[PJFlstren] (CODLSTREN, CODLSTUSR, RENDERIZACAO, VISIVEL, POSICAO, OPERACAO, TIPO, ZZSTATE)
SELECT CODLSTREN, CODLSTUSR, RENDERIZACAO, VISIVEL, POSICAO, OPERACAO, TIPO, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFlstren]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela USRWID
INSERT INTO [W_GnBD].[dbo].[PJFusrwid] (CODUSRWID, CODLSTUSR, WIDGET, ROWKEY, VISIBLE, HPOSITION, VPOSITION, ZZSTATE)
SELECT CODUSRWID, CODLSTUSR, WIDGET, ROWKEY, VISIBLE, HPOSITION, VPOSITION, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFusrwid]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela USRCFG
INSERT INTO [W_GnBD].[dbo].[PJFusrcfg] (codusrcfg, modulo, codpsw, tipo, id, ZZSTATE)
SELECT codusrcfg, modulo, codpsw, tipo, id, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFusrcfg]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela USRSET
INSERT INTO [W_GnBD].[dbo].[PJFusrset] (codusrset, modulo, codpsw, chave, valor, ZZSTATE)
SELECT codusrset, modulo, codpsw, chave, valor, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFusrset]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WKFACT
INSERT INTO [W_GnBD].[dbo].[PJFwkfact] (codwkfact, wfid, actid, tpactid, descrica, duracao, perfil, perfilu, x, y, ZZSTATE)
SELECT codwkfact, wfid, actid, tpactid, descrica, duracao, perfil, perfilu, x, y, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFwkfact]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WKFCON
INSERT INTO [W_GnBD].[dbo].[PJFwkfcon] (codwkfcon, wfid, condid, tpcondid, descrica, tiporegr, sinal, x, y, valor, ZZSTATE)
SELECT codwkfcon, wfid, condid, tpcondid, descrica, tiporegr, sinal, x, y, valor, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFwkfcon]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WKFLIG
INSERT INTO [W_GnBD].[dbo].[PJFwkflig] (codwkflig, wfid, parentid, childid, ptoy, ptox, ptor, tipo, pfromx, pfromy, pfromr, ZZSTATE)
SELECT codwkflig, wfid, parentid, childid, ptoy, ptox, ptor, tipo, pfromx, pfromy, pfromr, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFwkflig]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WKFLOW
INSERT INTO [W_GnBD].[dbo].[PJFwkflow] (codwkflow, descrica, modulo, ZZSTATE)
SELECT codwkflow, descrica, modulo, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFwkflow]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela NOTIFI
INSERT INTO [W_GnBD].[dbo].[PJFnotifi] (codnotifi, modulo, descrica, activid, menuid, usernivl, wfid, ZZSTATE)
SELECT codnotifi, modulo, descrica, activid, menuid, usernivl, wfid, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFnotifi]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela PRMFRM
INSERT INTO [W_GnBD].[dbo].[PJFprmfrm] (codprmfrm, desform, perfil, autoriza, sevalida, prfvalid, prazodia, comprova, prazohor, secompro, mensag1, mensag2, mensag3, mensag4, ZZSTATE)
SELECT codprmfrm, desform, perfil, autoriza, sevalida, prfvalid, prazodia, comprova, prazohor, secompro, mensag1, mensag2, mensag3, mensag4, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFprmfrm]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela SCRCRD
INSERT INTO [W_GnBD].[dbo].[PJFscrcrd] (codscrcrd, descrica, valor, cor, seta, usernivl, ZZSTATE)
SELECT codscrcrd, descrica, valor, cor, seta, usernivl, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFscrcrd]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela DOCUMS
INSERT INTO [W_GnBD].[dbo].[docums] (coddocums, documid, document, docpath, tabela, campo, chave, form, nome, versao, tamanho, extensao, opercria, datacria, opermuda, datamuda, ZZSTATE)
SELECT coddocums, documid, document, docpath, tabela, campo, chave, form, nome, versao, tamanho, extensao, opercria, datacria, opermuda, datamuda, ZZSTATE FROM [W_GnSrcBD].[dbo].[docums]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela POSTIT
INSERT INTO [W_GnBD].[dbo].[PJFpostit] (codpostit, tabela, codtabel, postit, tpostit, datacria, opercria, codpsw, lido, apagado, validade, nivel, codpost1, ZZSTATE)
SELECT codpostit, tabela, codtabel, postit, tpostit, datacria, opercria, codpsw, lido, apagado, validade, nivel, codpost1, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFpostit]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela HASHCD
INSERT INTO [W_GnBD].[dbo].[hashcd] (codhashcd, tabela, campos, datacria, ZZSTATE)
SELECT codhashcd, tabela, campos, datacria, ZZSTATE FROM [W_GnSrcBD].[dbo].[hashcd]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela ALERTA
INSERT INTO [W_GnBD].[dbo].[PJFalerta] (codalerta, codaltent, mensagem, tratado, activo, datacria, datareso, menu, cor, interno, backgrou, sms, email, emailenv, smsenvia, codigo, codigotp, ZZSTATE)
SELECT codalerta, codaltent, mensagem, tratado, activo, datacria, datareso, menu, cor, interno, backgrou, sms, email, emailenv, smsenvia, codigo, codigotp, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFalerta]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela ALTENT
INSERT INTO [W_GnBD].[dbo].[PJFaltent] (codaltent, codtalert, codpsw, grupo, contador, tipo, mensagem, antecede, datainic, datafina, dtmodifi, todos, backgrou, sms, email, codtpgru, codtpess, menu, incluian, activo, individu, ZZSTATE)
SELECT codaltent, codtalert, codpsw, grupo, contador, tipo, mensagem, antecede, datainic, datafina, dtmodifi, todos, backgrou, sms, email, codtpgru, codtpess, menu, incluian, activo, individu, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFaltent]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela TALERT
INSERT INTO [W_GnBD].[dbo].[PJFtalert] (codtalert, nome, metodo, priorida, cor, texto, menu, cmpnome, daltinic, daltfina, incluian, diferenc, anodifer, mesdifer, diadifer, ntabmae, ntabfilh, formid, tabela, campo, tipo, modulo, condicao, ZZSTATE)
SELECT codtalert, nome, metodo, priorida, cor, texto, menu, cmpnome, daltinic, daltfina, incluian, diferenc, anodifer, mesdifer, diadifer, ntabmae, ntabfilh, formid, tabela, campo, tipo, modulo, condicao, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFtalert]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela DELEGA
INSERT INTO [W_GnBD].[dbo].[PJFdelega] (coddelega, codpswup, codpswdw, dateini, dateend, message, revoked, auditusr, opercria, datacria, opermuda, datamuda, ZZSTATE)
SELECT coddelega, codpswup, codpswdw, dateini, dateend, message, revoked, auditusr, opercria, datacria, opermuda, datamuda, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFdelega]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela TABDINAMIC
INSERT INTO [W_GnBD].[dbo].[PJFTABDINAMIC] (codtabdinamic, NOMETABELA, NOMECAMPO, TIPODADOS, TIPOSQL, LARGURA, ZZSTATE)
SELECT codtabdinamic, NOMETABELA, NOMECAMPO, TIPODADOS, TIPOSQL, LARGURA, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFTABDINAMIC]
WHERE ZZSTATE = 0
GO


-- migração de dados da tabela ALTRAN
INSERT INTO [W_GnBD].[dbo].[PJFaltran] (codaltran, typlabel, referenc, [language], curlabel, labellng, altran, opercria, datacria, opermuda, datamuda, ZZSTATE)
SELECT codaltran, typlabel, referenc, [language], curlabel, labellng, altran, opercria, datacria, opermuda, datamuda, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFaltran]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WORKFLOWTASK
INSERT INTO [W_GnBD].[dbo].[PJFworkflowtask] (codtask, codprcess, taskdefid, taskid, performedby, runningsince, nextrun, modifieddate, modifiedby, skipped, isactive, errorExecute, ZZSTATE)
SELECT codtask, codprcess, taskdefid, taskid, performedby, runningsince, nextrun, modifieddate, modifiedby, skipped, isactive, errorExecute, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFworkflowtask]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WORKFLOWPROCESS
INSERT INTO [W_GnBD].[dbo].[PJFworkflowprocess] (codprcess, prcessid, prcessdefid, createdby, status, startdate, modifieddate, modifiedby, codinstance, dotgraph, wferror, ltask, idhk, ZZSTATE)
SELECT codprcess, prcessid, prcessdefid, createdby, status, startdate, modifieddate, modifiedby, codinstance, dotgraph, wferror, ltask, idhk, ZZSTATE FROM [W_GnSrcBD].[dbo].[PJFworkflowprocess]
WHERE ZZSTATE = 0
GO


USE [W_GnBD]
GO
-- Removing invalid FK values
UPDATE [AIRPT] SET
[AIRPT].[CODCITY] = [q0_CITY].[CODCITY]
 FROM [W_GnBD].[dbo].[PJFAIRPT] AS [AIRPT]
LEFT JOIN [PJFCITY] AS [q0_CITY] ON [AIRPT].[CODCITY] = [q0_CITY].[CODCITY]
GO

UPDATE [S_ARG] SET
[S_ARG].[CODS_APR] = [q0_S_APR].[CODASCPR]
 FROM [W_GnBD].[dbo].[AsyncProcessArgument] AS [S_ARG]
LEFT JOIN [AsyncProcess] AS [q0_S_APR] ON [S_ARG].[CODS_APR] = [q0_S_APR].[CODASCPR]
GO

UPDATE [S_PAX] SET
[S_PAX].[CODS_APR] = [q0_S_APR].[CODASCPR]
 FROM [W_GnBD].[dbo].[AsyncProcessAttachments] AS [S_PAX]
LEFT JOIN [AsyncProcess] AS [q0_S_APR] ON [S_PAX].[CODS_APR] = [q0_S_APR].[CODASCPR]
GO

UPDATE [S_UA] SET
[S_UA].[CODPSW] = [q0_PSW].[CODPSW]
 FROM [W_GnBD].[dbo].[UserAuthorization] AS [S_UA]
LEFT JOIN [UserLogin] AS [q0_PSW] ON [S_UA].[CODPSW] = [q0_PSW].[CODPSW]
GO

UPDATE [AIRLN] SET
[AIRLN].[CODAIRHB] = [q0_AIRPT].[CODAIRPT]
, [AIRLN].[CODCITY] = [q1_CITY].[CODCITY]
 FROM [W_GnBD].[dbo].[PJFAIRLN] AS [AIRLN]
LEFT JOIN [PJFAIRPT] AS [q0_AIRPT] ON [AIRLN].[CODAIRHB] = [q0_AIRPT].[CODAIRPT]
LEFT JOIN [PJFCITY] AS [q1_CITY] ON [AIRLN].[CODCITY] = [q1_CITY].[CODCITY]
GO

UPDATE [APSW] SET
[APSW].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
, [APSW].[CODPSW] = [q1_PSW].[CODPSW]
 FROM [W_GnBD].[dbo].[PJFAPSW] AS [APSW]
LEFT JOIN [PJFAIRLN] AS [q0_AIRLN] ON [APSW].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
LEFT JOIN [UserLogin] AS [q1_PSW] ON [APSW].[CODPSW] = [q1_PSW].[CODPSW]
GO

UPDATE [CREW] SET
[CREW].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
 FROM [W_GnBD].[dbo].[PJFCREW] AS [CREW]
LEFT JOIN [PJFAIRLN] AS [q0_AIRLN] ON [CREW].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
GO

UPDATE [PILOT] SET
[PILOT].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
 FROM [W_GnBD].[dbo].[PJFPILOT] AS [PILOT]
LEFT JOIN [PJFAIRLN] AS [q0_AIRLN] ON [PILOT].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
GO

UPDATE [PLANE] SET
[PLANE].[AIRCR] = [q0_AIRPT].[CODAIRPT]
, [PLANE].[CODAIRLN] = [q1_AIRLN].[CODAIRLN]
 FROM [W_GnBD].[dbo].[PJFPLANE] AS [PLANE]
LEFT JOIN [PJFAIRPT] AS [q0_AIRPT] ON [PLANE].[AIRCR] = [q0_AIRPT].[CODAIRPT]
LEFT JOIN [PJFAIRLN] AS [q1_AIRLN] ON [PLANE].[CODAIRLN] = [q1_AIRLN].[CODAIRLN]
GO

UPDATE [ROUTE] SET
[ROUTE].[AIRDS] = [q0_AIRPT].[CODAIRPT]
, [ROUTE].[CODAIRLN] = [q1_AIRLN].[CODAIRLN]
, [ROUTE].[AIRSC] = [q2_AIRPT].[CODAIRPT]
 FROM [W_GnBD].[dbo].[PJFROUTE] AS [ROUTE]
LEFT JOIN [PJFAIRPT] AS [q0_AIRPT] ON [ROUTE].[AIRDS] = [q0_AIRPT].[CODAIRPT]
LEFT JOIN [PJFAIRLN] AS [q1_AIRLN] ON [ROUTE].[CODAIRLN] = [q1_AIRLN].[CODAIRLN]
LEFT JOIN [PJFAIRPT] AS [q2_AIRPT] ON [ROUTE].[AIRSC] = [q2_AIRPT].[CODAIRPT]
GO

UPDATE [FLIGH] SET
[FLIGH].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
, [FLIGH].[CODSOURC] = [q1_AIRPT].[CODAIRPT]
, [FLIGH].[CODCREW] = [q2_CREW].[CODCREW]
, [FLIGH].[CODPILOT] = [q3_PILOT].[CODPILOT]
, [FLIGH].[CODPLANE] = [q4_PLANE].[CODPLANE]
, [FLIGH].[CODROUTE] = [q5_ROUTE].[CODROUTE]
 FROM [W_GnBD].[dbo].[PJFFLIGH] AS [FLIGH]
LEFT JOIN [PJFAIRLN] AS [q0_AIRLN] ON [FLIGH].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
LEFT JOIN [PJFAIRPT] AS [q1_AIRPT] ON [FLIGH].[CODSOURC] = [q1_AIRPT].[CODAIRPT]
LEFT JOIN [PJFCREW] AS [q2_CREW] ON [FLIGH].[CODCREW] = [q2_CREW].[CODCREW]
LEFT JOIN [PJFPILOT] AS [q3_PILOT] ON [FLIGH].[CODPILOT] = [q3_PILOT].[CODPILOT]
LEFT JOIN [PJFPLANE] AS [q4_PLANE] ON [FLIGH].[CODPLANE] = [q4_PLANE].[CODPLANE]
LEFT JOIN [PJFROUTE] AS [q5_ROUTE] ON [FLIGH].[CODROUTE] = [q5_ROUTE].[CODROUTE]
GO

UPDATE [MAINT] SET
[MAINT].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
, [MAINT].[CODPLANE] = [q1_PLANE].[CODPLANE]
 FROM [W_GnBD].[dbo].[PJFMAINT] AS [MAINT]
LEFT JOIN [PJFAIRLN] AS [q0_AIRLN] ON [MAINT].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
LEFT JOIN [PJFPLANE] AS [q1_PLANE] ON [MAINT].[CODPLANE] = [q1_PLANE].[CODPLANE]
GO

UPDATE [MATE] SET
[MATE].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
, [MATE].[CODCREW] = [q1_CREW].[CODCREW]
 FROM [W_GnBD].[dbo].[PJFMATE] AS [MATE]
LEFT JOIN [PJFAIRLN] AS [q0_AIRLN] ON [MATE].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
LEFT JOIN [PJFCREW] AS [q1_CREW] ON [MATE].[CODCREW] = [q1_CREW].[CODCREW]
GO

UPDATE [BOOKG] SET
[BOOKG].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
, [BOOKG].[FLIGHT] = [q1_FLIGH].[CODFLIGH]
, [BOOKG].[CODPASGR] = [q2_PERSO].[CODPERSO]
 FROM [W_GnBD].[dbo].[PJFBOOKG] AS [BOOKG]
LEFT JOIN [PJFAIRLN] AS [q0_AIRLN] ON [BOOKG].[CODAIRLN] = [q0_AIRLN].[CODAIRLN]
LEFT JOIN [PJFFLIGH] AS [q1_FLIGH] ON [BOOKG].[FLIGHT] = [q1_FLIGH].[CODFLIGH]
LEFT JOIN [PJFPERSO] AS [q2_PERSO] ON [BOOKG].[CODPASGR] = [q2_PERSO].[CODPERSO]
GO


USE [W_GnBD]

GO
