-----------------------------------------------------------
-- CITY
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_CITY', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_CITY AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_CITY 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CITY
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- CITY
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_CITY', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_CITY AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_CITY 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CITY
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_CITY', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_CITY AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_CITY @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for CITY
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- MEM
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_MEM', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_MEM AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_MEM 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de MEM
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- MEM
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_MEM', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_MEM AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_MEM 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de MEM
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_MEM', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_MEM AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_MEM @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for MEM
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- PERSO
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_PERSO', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_PERSO AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_PERSO 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PERSO
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- PERSO
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_PERSO', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_PERSO AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_PERSO 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PERSO
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_PERSO', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_PERSO AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_PERSO @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for PERSO
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- PSW
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_PSW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_PSW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_PSW 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PSW
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- PSW
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_PSW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_PSW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_PSW 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PSW
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_PSW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_PSW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_PSW @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for PSW
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [psw] set 
	[ATTEMPTS] = COALESCE([psw].[ATTEMPTS], 0)
 ,	[STATUS] = COALESCE([psw].[STATUS], 0)
	FROM [userlogin] AS [psw]

	WHERE ([psw].[codpsw] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- S_APR
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_S_APR', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_S_APR AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_S_APR 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_APR
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [s_apr]
SET [s_apr].[finished] =(case when ([s_apr].[status]=''T'' or [s_apr].[status]=''AB'' or [s_apr].[status]=''C'') then 1 else 0 end)
FROM [asyncprocess] AS [s_apr]

 where ([s_apr].[codascpr] = @x OR @x IS NULL)
END')
GO
-----------------------------------------------------------
-- S_APR
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_S_APR', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_S_APR AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_S_APR 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_APR
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [s_apr]
SET [s_apr].[finished] =(case when ([s_apr].[status]=''T'' or [s_apr].[status]=''AB'' or [s_apr].[status]=''C'') then 1 else 0 end)
FROM [asyncprocess] AS [s_apr]

 where ([s_apr].[codascpr] in (select item from @x))
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_S_APR', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_S_APR AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_S_APR @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_APR
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [s_apr] set 
	[PERCENTA] = COALESCE([s_apr].[PERCENTA], 0)
	FROM [asyncprocess] AS [s_apr]

	WHERE ([s_apr].[codascpr] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- S_NES
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_S_NES', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_S_NES AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_S_NES 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_NES
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- S_NES
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_S_NES', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_S_NES AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_S_NES 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_NES
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_S_NES', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_S_NES AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_S_NES @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_NES
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- S_NM
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_S_NM', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_S_NM AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_S_NM 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_NM
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- S_NM
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_S_NM', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_S_NM AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_S_NM 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_NM
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_S_NM', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_S_NM AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_S_NM @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_NM
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- AIRPT
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_AIRPT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_AIRPT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_AIRPT 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de AIRPT
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- AIRPT
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_AIRPT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_AIRPT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_AIRPT 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de AIRPT
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_AIRPT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_AIRPT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_AIRPT @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for AIRPT
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- S_ARG
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_S_ARG', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_S_ARG AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_S_ARG 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_ARG
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- S_ARG
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_S_ARG', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_S_ARG AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_S_ARG 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_ARG
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_S_ARG', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_S_ARG AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_S_ARG @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_ARG
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- S_PAX
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_S_PAX', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_S_PAX AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_S_PAX 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_PAX
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- S_PAX
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_S_PAX', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_S_PAX AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_S_PAX 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_PAX
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_S_PAX', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_S_PAX AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_S_PAX @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_PAX
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- S_UA
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_S_UA', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_S_UA AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_S_UA 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_UA
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [s_ua]
SET [s_ua].[naodupli] =dbo.KeyToString([s_ua].[codpsw])+[s_ua].[modulo]
,[s_ua].[nivel] =dbo.GetLevelFromRole([s_ua].[nivel],[s_ua].[role])
FROM [userauthorization] AS [s_ua]

 where ([s_ua].[codua] = @x OR @x IS NULL)
END')
GO
-----------------------------------------------------------
-- S_UA
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_S_UA', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_S_UA AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_S_UA 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_UA
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [s_ua]
SET [s_ua].[naodupli] =dbo.KeyToString([s_ua].[codpsw])+[s_ua].[modulo]
,[s_ua].[nivel] =dbo.GetLevelFromRole([s_ua].[nivel],[s_ua].[role])
FROM [userauthorization] AS [s_ua]

 where ([s_ua].[codua] in (select item from @x))
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_S_UA', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_S_UA AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_S_UA @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_UA
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [s_ua] set 
	[NIVEL] = COALESCE([s_ua].[NIVEL], 0)
	FROM [userauthorization] AS [s_ua]

	WHERE ([s_ua].[codua] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- AIRLN
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_AIRLN', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_AIRLN AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_AIRLN 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de AIRLN
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- AIRLN
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_AIRLN', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_AIRLN AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_AIRLN 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de AIRLN
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_AIRLN', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_AIRLN AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_AIRLN @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for AIRLN
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- APSW
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_APSW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_APSW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_APSW 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de APSW
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- APSW
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_APSW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_APSW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_APSW 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de APSW
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_APSW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_APSW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_APSW @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for APSW
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- CREW
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_CREW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_CREW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_CREW 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CREW
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR
update [pjfcrew] set
     [count] = + (select isnull(count(*),0) from [pjfmate] as source where [pjfcrew].[codcrew] = source.[codcrew] and source.zzstate = 0)
where ([pjfcrew].[codcrew] = @x OR @x IS NULL)

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
END')
GO
-----------------------------------------------------------
-- CREW
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_CREW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_CREW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_CREW 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CREW
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR
update [pjfcrew] set
     [count] = + (select isnull(count(*),0) from [pjfmate] as source where [pjfcrew].[codcrew] = source.[codcrew] and source.zzstate = 0)
where ([pjfcrew].[codcrew] in (select item from @x))

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_CREW', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_CREW AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_CREW @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for CREW
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [crew] set 
	[COUNT] = COALESCE([crew].[COUNT], 0)
	FROM [pjfcrew] AS [crew]

	WHERE ([crew].[codcrew] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- PILOT
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_PILOT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_PILOT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_PILOT 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PILOT
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- PILOT
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_PILOT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_PILOT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_PILOT 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PILOT
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_PILOT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_PILOT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_PILOT @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for PILOT
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [pilot] set 
	[EXPERIEN] = COALESCE([pilot].[EXPERIEN], 0)
	FROM [pjfpilot] AS [pilot]

	WHERE ([pilot].[codpilot] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- PLANE
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_PLANE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_PLANE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_PLANE 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PLANE
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR
update [pjfplane] set
     [maint] = + (select isnull(sum(source.[STATUS]),0) from [pjfmaint] as source where [pjfplane].[codplane] = source.[codplane] and source.zzstate = 0)
where ([pjfplane].[codplane] = @x OR @x IS NULL)

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [plane]
SET [plane].[age] =year(cast(floor(cast(CURRENT_TIMESTAMP as float)) as datetime))-year([plane].[year])
,[plane].[airsc] =ISNULL([aircr].[name], '''')
FROM [pjfplane] AS [plane]
LEFT JOIN [pjfairpt] as [aircr] ON [plane].[aircr]=[aircr].[codairpt]

 where ([plane].[codplane] = @x OR @x IS NULL)
-- Layer 1
update [plane]
SET [plane].[ismaint] =(case when ([plane].[maint]>0) then 1 else 0 end)
FROM [pjfplane] AS [plane]

 where ([plane].[codplane] = @x OR @x IS NULL)
END')
GO
-----------------------------------------------------------
-- PLANE
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_PLANE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_PLANE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_PLANE 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PLANE
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR
update [pjfplane] set
     [maint] = + (select isnull(sum(source.[STATUS]),0) from [pjfmaint] as source where [pjfplane].[codplane] = source.[codplane] and source.zzstate = 0)
where ([pjfplane].[codplane] in (select item from @x))

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [plane]
SET [plane].[age] =year(cast(floor(cast(CURRENT_TIMESTAMP as float)) as datetime))-year([plane].[year])
,[plane].[airsc] =ISNULL([aircr].[name], '''')
FROM [pjfplane] AS [plane]
LEFT JOIN [pjfairpt] as [aircr] ON [plane].[aircr]=[aircr].[codairpt]

 where ([plane].[codplane] in (select item from @x))
-- Layer 1
update [plane]
SET [plane].[ismaint] =(case when ([plane].[maint]>0) then 1 else 0 end)
FROM [pjfplane] AS [plane]

 where ([plane].[codplane] in (select item from @x))
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_PLANE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_PLANE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_PLANE @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for PLANE
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [plane] set 
	[ENGINES] = COALESCE([plane].[ENGINES], 0)
 ,	[CAPACITY] = COALESCE([plane].[CAPACITY], 0)
 ,	[AGE] = COALESCE([plane].[AGE], 0)
 ,	[MAINT] = COALESCE([plane].[MAINT], 0)
	FROM [pjfplane] AS [plane]

	WHERE ([plane].[codplane] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- ROUTE
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_ROUTE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_ROUTE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_ROUTE 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de ROUTE
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- ROUTE
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_ROUTE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_ROUTE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_ROUTE 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de ROUTE
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_ROUTE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_ROUTE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_ROUTE @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for ROUTE
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- FLIGH
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_FLIGH', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_FLIGH AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_FLIGH 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de FLIGH
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- FLIGH
-- Assumimos que as formulas dos seguintes campos estão bem calculadas:
-----------------------------------------------------------
-- [PLANE -> AIRSC]
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [fligh]
SET [fligh].[duration] =dbo.DateDiffPart([fligh].[depart],[fligh].[arrival],''H'')
,[fligh].[codsourc] =[plane].[aircr]
,[fligh].[namesc] =ISNULL([plane].[airsc], '''')
FROM [pjffligh] AS [fligh]
LEFT JOIN [pjfplane] as [plane] ON [fligh].[codplane]=[plane].[codplane]

 where ([fligh].[codfligh] = @x OR @x IS NULL)
END')
GO
-----------------------------------------------------------
-- FLIGH
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_FLIGH', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_FLIGH AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_FLIGH 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de FLIGH
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- FLIGH
-- Assumimos que as formulas dos seguintes campos estão bem calculadas:
-----------------------------------------------------------
-- [PLANE -> AIRSC]
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [fligh]
SET [fligh].[duration] =dbo.DateDiffPart([fligh].[depart],[fligh].[arrival],''H'')
,[fligh].[codsourc] =[plane].[aircr]
,[fligh].[namesc] =ISNULL([plane].[airsc], '''')
FROM [pjffligh] AS [fligh]
LEFT JOIN [pjfplane] as [plane] ON [fligh].[codplane]=[plane].[codplane]

 where ([fligh].[codfligh] in (select item from @x))
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_FLIGH', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_FLIGH AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_FLIGH @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for FLIGH
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [fligh] set 
	[DURATION] = COALESCE([fligh].[DURATION], 0)
	FROM [pjffligh] AS [fligh]

	WHERE ([fligh].[codfligh] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- MAINT
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_MAINT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_MAINT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_MAINT 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de MAINT
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- MAINT
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_MAINT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_MAINT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_MAINT 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de MAINT
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_MAINT', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_MAINT AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_MAINT @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for MAINT
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- MATE
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_MATE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_MATE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_MATE 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de MATE
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- MATE
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_MATE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_MATE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_MATE 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de MATE
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_MATE', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_MATE AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_MATE @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for MATE
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- BOOKG
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_Calc_BOOKG', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Calc_BOOKG AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Calc_BOOKG 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de BOOKG
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- BOOKG
-----------------------------------------------------------
USE [W_GnBD]
IF OBJECT_ID(N'dbo.Genio_CalcBlock_BOOKG', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_CalcBlock_BOOKG AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_CalcBlock_BOOKG 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de BOOKG
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
IF OBJECT_ID(N'dbo.Genio_Default_BOOKG', 'P') IS NULL
    EXEC('CREATE PROCEDURE dbo.Genio_Default_BOOKG AS SET NOCOUNT ON;')

EXEC('
ALTER PROCEDURE dbo.Genio_Default_BOOKG @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for BOOKG
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
