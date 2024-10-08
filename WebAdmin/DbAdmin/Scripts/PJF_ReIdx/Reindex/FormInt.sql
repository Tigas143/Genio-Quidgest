*{pjfcity}*
GO
*{pjfmem}*
GO
*{pjfperso}*
GO
*{userlogin}*
GO
*{asyncprocess}*
USE [W_GnBD]
update [s_apr] set [finished] = (case when ([s_apr].[status]='T' or [s_apr].[status]='AB' or [s_apr].[status]='C') then 1 else 0 end) from [asyncprocess] as [s_apr]
GO
*{notificationemailsignature}*
GO
*{notificationmessage}*
GO
*{pjfairpt}*
GO
*{asyncprocessargument}*
GO
*{asyncprocessattachments}*
GO
*{userauthorization}*
USE [W_GnBD]
update [s_ua] set [naodupli] = dbo.KeyToString([s_ua].[codpsw])+[s_ua].[modulo] from [userauthorization] as [s_ua]
update [s_ua] set [nivel] = dbo.GetLevelFromRole([s_ua].[nivel],[s_ua].[role]) from [userauthorization] as [s_ua]
GO
*{pjfairln}*
GO
*{pjfapsw}*
GO
*{pjfcrew}*
GO
*{pjfpilot}*
GO
*{pjfplane}*
USE [W_GnBD]
update [plane] set [age] = year(cast(floor(cast(CURRENT_TIMESTAMP as float)) as datetime))-year([plane].[year]) from [pjfplane] as [plane]
update [plane] set [ismaint] = (case when ([plane].[maint]>0) then 1 else 0 end) from [pjfplane] as [plane]
GO
*{pjfroute}*
GO
*{pjffligh}*
USE [W_GnBD]
update [fligh] set [duration] = dbo.DateDiffPart([fligh].[depart],[fligh].[arrival],'H') from [pjffligh] as [fligh]
update [fligh] set [namesc] = dbo.ansi_C([plane].[airsc]) from [pjffligh] as [fligh] LEFT JOIN [pjfplane] as [plane] ON [fligh].[codplane] = [plane].[codplane]
GO
*{pjfmaint}*
GO
*{pjfmate}*
GO
*{pjfbookg}*
GO
