USE [W_GnBD]

GO
UPDATE dest SET dest.[airsc] = source.[name] FROM pjfplane AS dest INNER JOIN pjfairpt AS source ON source.codairpt = dest.aircr WHERE dest.[airsc] is null OR dest.[airsc] != source.[name]
UPDATE dest SET dest.[airsc] = '' FROM pjfplane AS dest WHERE (aircr IS NULL OR aircr = '') AND dest.[airsc]  != '' 
GO
UPDATE dest SET dest.[codsourc] = source.[aircr] FROM pjffligh AS dest INNER JOIN pjfplane AS source ON source.codplane = dest.codplane WHERE dest.[codsourc] is null OR dest.[codsourc] != source.[aircr]
UPDATE dest SET dest.[codsourc] = NULL FROM pjffligh AS dest WHERE (codplane IS NULL OR codplane = '') AND dest.[codsourc]  IS NOT NULL 
GO

