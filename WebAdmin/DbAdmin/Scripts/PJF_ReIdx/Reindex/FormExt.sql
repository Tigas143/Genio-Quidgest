*{pjfbookg}*
GO
USE [W_GnBD]
GO
*{pjfmate}*
GO
USE [W_GnBD]
GO
*{pjfmaint}*
GO
USE [W_GnBD]
GO
*{pjffligh}*
GO
USE [W_GnBD]
GO
*{pjfroute}*
GO
USE [W_GnBD]
GO
*{pjfplane}*
USE [W_GnBD]
update [pjfplane] set
     [maint] = + (select isnull(sum(source.[STATUS]),0) from [pjfmaint] as source where [pjfplane].[codplane] = source.[codplane] and source.zzstate = 0)
GO
USE [W_GnBD]
GO
*{pjfpilot}*
GO
USE [W_GnBD]
GO
*{pjfcrew}*
USE [W_GnBD]
update [pjfcrew] set
     [count] = + (select isnull(count(*),0) from [pjfmate] as source where [pjfcrew].[codcrew] = source.[codcrew] and source.zzstate = 0)
GO
USE [W_GnBD]
GO
*{pjfapsw}*
GO
USE [W_GnBD]
GO
*{pjfairln}*
GO
USE [W_GnBD]
GO
*{userauthorization}*
GO
USE [W_GnBD]
GO
*{asyncprocessattachments}*
GO
USE [W_GnBD]
GO
*{asyncprocessargument}*
GO
USE [W_GnBD]
GO
*{pjfairpt}*
GO
USE [W_GnBD]
GO
*{notificationmessage}*
GO
USE [W_GnBD]
GO
*{notificationemailsignature}*
GO
USE [W_GnBD]
GO
*{asyncprocess}*
GO
USE [W_GnBD]
GO
*{userlogin}*
GO
USE [W_GnBD]
GO
*{pjfperso}*
GO
USE [W_GnBD]
GO
*{pjfmem}*
GO
USE [W_GnBD]
GO
*{pjfcity}*
GO
USE [W_GnBD]
GO
