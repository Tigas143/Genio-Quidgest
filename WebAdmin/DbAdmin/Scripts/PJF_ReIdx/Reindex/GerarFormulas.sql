
-- recalculo de fórmulas para a tabela PJFBOOKG
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFMATE
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFMAINT
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFFLIGH
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
-- Layer 0
update [fligh]
SET [fligh].[duration] =dbo.DateDiffPart([fligh].[depart],[fligh].[arrival],'H')
,[fligh].[namesc] =ISNULL([plane].[airsc], '')
FROM [pjffligh] AS [fligh]
LEFT JOIN [pjfplane] as [plane] ON [fligh].[codplane]=[plane].[codplane]


GO
GO
-- recalculo de fórmulas para a tabela PJFROUTE
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFPLANE
USE [W_GnBD]
GO
USE [W_GnBD]
GO
USE [W_GnBD]
update [pjfplane] set
     [maint] = + (select isnull(sum(source.[STATUS]),0) from [pjfmaint] as source where [pjfplane].[codplane] = source.[codplane] and source.zzstate = 0)
GO
USE [W_GnBD]
GO
-- Layer 0
update [plane]
SET [plane].[age] =year(cast(floor(cast(CURRENT_TIMESTAMP as float)) as datetime))-year([plane].[year])
FROM [pjfplane] AS [plane]


-- Layer 1
update [plane]
SET [plane].[ismaint] =(case when ([plane].[maint]>0) then 1 else 0 end)
FROM [pjfplane] AS [plane]


GO
GO
-- recalculo de fórmulas para a tabela PJFPILOT
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFCREW
USE [W_GnBD]
GO
USE [W_GnBD]
GO
USE [W_GnBD]
update [pjfcrew] set
     [count] = + (select isnull(count(*),0) from [pjfmate] as source where [pjfcrew].[codcrew] = source.[codcrew] and source.zzstate = 0)
GO
USE [W_GnBD]
GO
-- Layer 0
GO
GO
-- recalculo de fórmulas para a tabela PJFAPSW
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFAIRLN
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela UserAuthorization
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
-- Layer 0
update [s_ua]
SET [s_ua].[naodupli] =dbo.KeyToString([s_ua].[codpsw])+[s_ua].[modulo]
,[s_ua].[nivel] =dbo.GetLevelFromRole([s_ua].[nivel],[s_ua].[role])
FROM [userauthorization] AS [s_ua]


GO
GO
-- recalculo de fórmulas para a tabela AsyncProcessAttachments
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela AsyncProcessArgument
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFAIRPT
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela NotificationMessage
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela NotificationEmailSignature
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela AsyncProcess
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
-- Layer 0
update [s_apr]
SET [s_apr].[finished] =(case when ([s_apr].[status]='T' or [s_apr].[status]='AB' or [s_apr].[status]='C') then 1 else 0 end)
FROM [asyncprocess] AS [s_apr]


GO
GO
-- recalculo de fórmulas para a tabela UserLogin
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFPERSO
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFMEM
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela PJFCITY
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO


GO