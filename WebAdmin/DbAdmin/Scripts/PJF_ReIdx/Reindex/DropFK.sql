USE [W_GnBD]
SET NOCOUNT ON
DECLARE @SchemaName VARCHAR(100)
SET @SchemaName = NULL -- for a specific schema name set it here
DECLARE @ObjectID INT
, @ObjectName VARCHAR(500)
, @SQL NVARCHAR(2000)
, @Count INT
, @ObjectType VARCHAR(1000)
CREATE TABLE #ObjectTemp (ObjectID INT IDENTITY(1,1) NOT NULL, ObjectName VARCHAR(250), ObjectType VARCHAR(100))
SET @Count = 0
INSERT INTO #ObjectTemp (ObjectName, ObjectType)
SELECT Table_Schema + '.[' + Table_Name + ']', Constraint_Name
FROM INFORMATION_SCHEMA.Table_CONSTRAINTS
WHERE (@SchemaName IS NULL OR UPPER(Table_Schema) = UPPER(@SchemaName))
AND Constraint_Type = 'FOREIGN KEY'
ORDER BY constraint_type , Table_Name
SELECT @ObjectID = MIN(ObjectID) FROM #ObjectTemp
WHILE @ObjectID IS NOT NULL
BEGIN
SELECT @ObjectName = ObjectName, @ObjectType = ObjectType
FROM #ObjectTemp WHERE ObjectID = @ObjectID
SET @SQL = 'ALTER TABLE ' + @ObjectName + ' DROP CONSTRAINT [' + @ObjectType + ']'
EXECUTE SP_EXECUTESQL @SQL
SELECT @ObjectID = MIN(ObjectID) FROM #ObjectTemp WHERE ObjectID > @ObjectID
SET @ObjectName = NULL
SET @SQL = NULL
SET @COUNT = @Count + 1
END
DROP TABLE #ObjectTemp
GO
