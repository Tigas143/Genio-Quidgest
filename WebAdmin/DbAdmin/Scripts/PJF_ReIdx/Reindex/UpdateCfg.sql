IF((SELECT COUNT(1) FROM PJFcfg) = 0)
	INSERT INTO PJFcfg (codcfg, checkdat, versao, versindx, manutdat, upgrindx, zzstate) VALUES ('     1', GETDATE(), 2669, 0, NULL, 0, 0)
ELSE
  UPDATE PJFcfg set versao = 2669, upgrindx = 0;
GO
