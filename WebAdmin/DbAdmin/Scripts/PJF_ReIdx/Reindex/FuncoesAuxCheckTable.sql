use [W_GnBD]
if exists(select * from sysobjects where type = 'P' and name = 'CriarTabelaTmp')
	DROP PROCEDURE CriarTabelaTmp
EXEC('CREATE PROCEDURE CriarTabelaTmp 
	@NomeTabela NVARCHAR(300),
	@PK NVARCHAR(300),
	@PKtype nvarchar(1)
	,@PKsize int = 0
	,@NewTable bit OUTPUT
	AS
	set nocount on
	SET @NewTable = 0;
	if object_id(@NomeTabela, ''U'') is null 
	begin
		if @PKtype = ''G''
			EXEC (''CREATE TABLE ['' + @NomeTabela + ''] ('' + @PK + '' uniqueidentifier ROWGUIDCOL NOT NULL);'')
		else if @PKtype = ''I''
			begin
				if (@PKsize<3)
					EXEC (''CREATE TABLE ['' + @NomeTabela + ''] ('' + @PK + '' TINYINT NOT NULL );'')
				else if (@PKsize>=3 and @PKsize<5)
					EXEC (''CREATE TABLE ['' + @NomeTabela + ''] ('' + @PK + '' SMALLINT NOT NULL );'')
				else if(@PKsize>=5 and @PKsize<10)
					EXEC (''CREATE TABLE ['' + @NomeTabela + ''] ('' + @PK + '' INT NOT NULL );'')
				else
					EXEC (''CREATE TABLE ['' + @NomeTabela + ''] ('' + @PK + '' BIGINT NOT NULL );'')
			end
		else
			EXEC (''CREATE TABLE ['' + @NomeTabela + ''] ('' + @PK + '' NVARCHAR(1));'')
		SET @NewTable = 1;
	end')
	
if exists(select * from sysobjects where type = 'P' and name = 'ApagarTodosIndicesTmp')
	DROP PROCEDURE ApagarTodosIndicesTmp
EXEC ('CREATE PROCEDURE ApagarTodosIndicesTmp
	@NomeTabela NVARCHAR(300), @sistema NVARCHAR(10), @pkName NVARCHAR(150) = ''''
	AS
	set nocount on
	DECLARE @sql NVARCHAR(MAX);
	DECLARE @Hasfilestream bit;
	SET @Hasfilestream = 0;
	SET @NomeTabela = UPPER(@NomeTabela);
	SET @sistema = UPPER(@sistema);
	
	-- ir buscar o nome actual da chave primária
	declare @pkNameNow nvarchar(150)
	set @pkNameNow = ''''
	if (@pkName != '''')
		SELECT @pkNameNow = COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + ''.'' + CONSTRAINT_NAME), ''IsPrimaryKey'') = 1 AND TABLE_NAME = @NomeTabela AND TABLE_SCHEMA = ''dbo''
	
	if (@Hasfilestream = 0)
	begin
		if (@pkName = '''' OR (@pkName != '''' AND UPPER(@pkNameNow) != UPPER(@pkName))) -- só apagar a chave primária se mudar de nome ou caso seja obrigado
		begin
	-- Drop primary keys
				SET @sql = N'''';
				SELECT @sql = @sql + N''ALTER TABLE ''
				  + QUOTENAME(OBJECT_SCHEMA_NAME([parent_object_id]))
				  + ''.'' + QUOTENAME(OBJECT_NAME([parent_object_id])) 
				  + '' DROP CONSTRAINT '' + QUOTENAME(name) + ''; ''
				FROM sys.key_constraints 
				WHERE [type] = ''PK''
					AND OBJECTPROPERTY([parent_object_id], ''IsMsShipped'') = 0 
					AND UPPER(OBJECT_NAME([parent_object_id])) = @NomeTabela;

				EXEC sp_executesql @sql;
		end
	end
	
	-- Non-clustered indexes
	SET @sql = N'''';
	SELECT @sql = @sql + N''DROP INDEX ''
	  + QUOTENAME(name) + '' ON ''
	  + QUOTENAME(OBJECT_SCHEMA_NAME([object_id]))
	  + ''.'' + QUOTENAME(OBJECT_NAME([object_id])) + ''; ''
	FROM sys.indexes 
	WHERE index_id > 0
		AND OBJECTPROPERTY([object_id], ''IsMsShipped'') = 0 
		AND UPPER(OBJECT_NAME([object_id])) = @NomeTabela -- só objectos da tabela do parametro
		AND [type] != 1 --só objectos que não sejam chave primária
		AND (name LIKE (@NomeTabela + ''%'') OR name LIKE (@sistema + ''%'')); --só objectos que tenham como prefixo o nome da tabela ou o nome do sistema

	EXEC sp_executesql @sql;')
	
if exists(select * from sysobjects where type = 'P' and name = 'AlinharCmpDireitaTmp')
	DROP PROCEDURE AlinharCmpDireitaTmp
EXEC ('CREATE PROCEDURE AlinharCmpDireitaTmp
	@NomeTabela NVARCHAR(300),
	@name VARCHAR(300),
	@length VARCHAR(25),
	@location VARCHAR(25),
	@type VARCHAR(25)
	AS
	set nocount on
	if (@location = ''FF_DIREITA'' and @type in (''dbText'', ''dbMemo''))
	begin
		EXEC (''UPDATE ['' + @NomeTabela + ''] SET '' + @name + ''= space('' + @length + '' - len(LTRIM('' + @name + '')))+LTRIM('' + @name + '') WHERE LEN('' + @name + '')< replace('' + @length + '','''' '''', '''''''') AND LEN('' + @name + '')>0'')
		EXEC (''UPDATE ['' + @NomeTabela + ''] SET '' + @name + ''='''''''' where '' + @name + '' is null'')
	end')

if exists(select * from sysobjects where type = 'P' and name = 'AlterarCamposTmp')
	DROP PROCEDURE AlterarCamposTmp
EXEC ('CREATE PROCEDURE AlterarCamposTmp
	@NomeTabela NVARCHAR(300),
	@nameCampo VARCHAR(300),
	@tipoDados VARCHAR(25),
	@typeSQL VARCHAR(300),
	@length VARCHAR(25)
	AS
	set nocount on
	--verificar se o tipo de dados são diferentes dos inseridos
	BEGIN TRY
		DECLARE @tipo varchar(50);
		DECLARE @len varchar(25);
		DECLARE @exist bit = 0;
		DECLARE @computed bit = 0;
		DECLARE @checksize bit = 0;
		DECLARE @defvalue nvarchar(max) = '''';

		-- check if the field exists and get its schema
		select TOP 1 @tipo = t.name, @exist = 1, @computed = c.iscomputed, 
			@len = CASE 
				WHEN t.name IN (''nvarchar'', ''nchar'') THEN convert(varchar, CASE WHEN  c.length = -1 THEN 8000 ELSE c.length/2 END)
				WHEN t.name IN (''varchar'', ''char'') THEN convert(varchar, CASE WHEN c.length = -1 THEN 8000 ELSE c.length END)
				WHEN t.name IN (''decimal'') THEN (CAST(c.prec AS VARCHAR) +  '','' + CAST(c.scale AS VARCHAR))
				ELSE convert(varchar, c.length) END
			from sys.syscolumns c 
			inner join sys.sysobjects o on o.id = c.id
			inner join sys.systypes t on t.xusertype = c.xusertype
			where o.name = @NomeTabela and c.name = @nameCampo;
			
		-- only some types need to check their size qualifier (most its the data type itself that changes)
		if(@tipo in (''nvarchar'', ''nchar'', ''varchar'', ''char'', ''decimal'', ''datetime2'')) SET @checksize = 1;

		--if the columns is a computed column, then we should delete it first
		if(@computed = 1)
			EXEC (''ALTER TABLE ['' + @NomeTabela + ''] DROP COLUMN "'' + @nameCampo + ''" '')

		--add the column if it doesn''t exist in the table
		if (@exist = 0 OR @computed = 1)
		begin
			if (@tipoDados in (''float'',''real'',''decimal'',''tinyint'',''smallint'',''int'',''bigint''))
				set @defvalue = '' DEFAULT 0 WITH VALUES'';
			EXEC(''ALTER TABLE ['' + @NomeTabela + ''] ADD "'' + @nameCampo + ''" '' + @typeSQL + @defvalue);
		end
		--modify the column if it already exists in the table
		else
		begin
			DECLARE @sql nvarchar(max);
			
			--check if the data type or its properties are different from the requested ones
			if (@tipo != lower(replace(@tipoDados,'' '','''')) OR (@checksize = 1 AND @len != replace(@length,'' '', '''')))
			begin
				--there can be default contraints that need to be dropped before we can alter the column type
				EXEC dbo.DropConstraintsTmp @NomeTabela, @nameCampo;

				--alter the column type in the table
				set @sql = ''ALTER TABLE ['' + @NomeTabela + ''] ALTER COLUMN "'' + @nameCampo + ''" '' + @typeSQL;
				EXEC sp_executesql @sql;

				--after we alter the field type we need to recreate the contraints
				if (@tipoDados in (''float'',''real'',''decimal'',''tinyint'',''smallint'',''int'',''bigint''))
				begin
					set @sql = ''ALTER TABLE ['' + @NomeTabela + ''] ADD DEFAULT 0 FOR "''+ @nameCampo +''"''
					EXEC sp_executesql @sql;
				end
			end
		end
	END TRY
	BEGIN CATCH
		declare @erro as nvarchar (4000)
		set @erro = ''Error while changing the column '' + @nameCampo + '' on table '' + @NomeTabela + '': '' + CHAR(13) + ERROR_MESSAGE()
		RAISERROR (@erro, 16, -1)
	END CATCH')

if exists(select * from sysobjects where type = 'FN' and name = 'ConcatenarGroupByTmp')
	DROP Function ConcatenarGroupByTmp;
if exists(select * from sysobjects where type = 'P' and name = 'CheckIdxTmp')
	DROP PROCEDURE CheckIdxTmp;
IF TYPE_ID(N'IndexCheckType') IS NOT NULL
	DROP TYPE IndexCheckType;
EXEC ('CREATE TYPE IndexCheckType AS TABLE 
(idxName varchar(1000), columnName varchar(1000), uniqueIdx int, ordem int, include int, pk int);')

EXEC ('create function dbo.ConcatenarGroupByTmp(@tabela IndexCheckType READONLY, @indexName varchar(1000), @include int)
returns varchar(5000)
as
begin
	--juntar todas as opções de um determinado grupo na mesma row separados por '',''
	declare @out varchar(5000)
	select	@out = coalesce(@out + '',['' + convert(varchar(1000),columnName) + '']'', ''['' + convert(varchar(1000),columnName) + '']'')
	from	@tabela
	where	idxName = @indexName and include = @include
	return @out
end')

EXEC ('CREATE PROCEDURE CheckIdxTmp
@tabela IndexCheckType READONLY,
@tableName nvarchar(128),
@idxPKName nvarchar(250),
@sistema nvarchar(10)
AS
set nocount on
DECLARE @sql as nvarchar(max);
--SELECIONAR TODOS OS INDICES QUE ESTÃO CRIADOS
DECLARE @tblOriginal TABLE (idxName varchar(1000), columnName varchar(1000), uniqueIdx int, ordem int, include int, pk int)
insert @tblOriginal
	SELECT i.name, c.name, indexproperty(o.[object_id], i.name, ''IsUnique''), ik.key_ordinal, ik.is_included_column, i.is_primary_key 
	FROM sys.objects o
	JOIN sys.indexes i ON i.[object_id] = o.[object_id]
	JOIN sys.index_columns ik ON ik.[object_id] = i.[object_id] AND ik.index_id = i.index_id
	JOIN sys.columns c ON c.[object_id] = ik.[object_id] AND c.column_id = ik.column_id
	WHERE indexproperty(o.[object_id], i.name, ''IsStatistics'') = 0 AND indexproperty(o.[object_id], i.name, ''IsHypothetical'') = 0 
	AND o.name = @tableName AND (i.name like @sistema + ''%'')

--QUERY QUE INDICA TODOS OS INDICES QUE ESTÃO DIFERENTES E TÊM DE SER APAGADOS
DECLARE @apagarIdx TABLE (idxName varchar(1000), columnName varchar(1000), uniqueIdx int, ordem int, include int, pk int)
insert @apagarIdx
SELECT t.*
       FROM @tabela as t 
	   INNER JOIN @tblOriginal as ix ON (t.idxName = ix.idxName)
	   LEFT JOIN @tblOriginal as o
             ON (t.idxName = o.idxName 
          AND t.columnName = o.columnName
					AND t.uniqueIdx = o.uniqueIdx
					AND t.ordem = o.ordem
					AND t.include = o.include)
       WHERE o.idxName IS NULL
insert @apagarIdx
SELECT o.*
       FROM @tblOriginal as o LEFT JOIN @tabela as t
             ON (o.idxName = t.idxName
          AND o.columnName = t.columnName
					AND o.uniqueIdx = t.uniqueIdx
					AND o.ordem = t.ordem
					AND o.include = t.include)
       WHERE t.idxName IS NULL
      
if(exists (select idxName from @apagarIdx))
begin
  SET @sql = N'''';
 SELECT @sql = @sql + CAST(
             CASE 
                  WHEN pk = 1 THEN ''ALTER TABLE '' + @tableName + '' DROP CONSTRAINT '' + idxName + ''; ''
				  ELSE ''DROP INDEX '' + idxName + '' ON '' + @tableName + ''; ''
             END AS nvarchar(max))
 FROM (select distinct idxName, pk from @apagarIdx) as tbl

 EXEC sp_executesql @sql;
end

  --QUERY QUE INDICA TODOS OS INDICES QUE ESTÃO DIFERENTES E TÊM DE SER CRIADOS
  DECLARE @dummyRdxTmp as IndexCheckType;
  insert into @dummyRdxTmp (idxName, columnName, uniqueIdx, ordem, include)
  select idxName, columnName, uniqueIdx, ordem, include from @tabela where idxName not in (
  select isnull(i.name COLLATE SQL_Latin1_General_CP1_CI_AI,'''') FROM sys.objects o JOIN sys.indexes i ON i.[object_id] = o.[object_id] where  
  indexproperty(o.[object_id], i.name, ''IsStatistics'') = 0
  AND indexproperty(o.[object_id], i.name, ''IsHypothetical'') = 0
  and o.name = @tableName)

SET @sql = N'''';
SELECT @sql = @sql +  CAST(
             CASE 
                  WHEN idxName = @idxPKName THEN ''ALTER TABLE '' + @tableName + '' ADD CONSTRAINT '' + idxName + '' PRIMARY KEY ('' + columnName + ''); ''
				  WHEN (includeName is null or len(rtrim(includeName)) = 0) THEN (''CREATE '' + CASE WHEN uniqueIdx = 1 THEN ''UNIQUE '' ELSE '''' END + ''INDEX '' + idxName + '' ON '' + @tableName + '' ('' + columnName + ''); '')
				  ELSE ''CREATE '' + CASE WHEN uniqueIdx = 1 THEN ''UNIQUE '' ELSE '''' END + ''INDEX '' + idxName + '' ON '' + @tableName + '' ('' + columnName + '') INCLUDE ('' + includeName + ''); ''
             END AS nvarchar(max))
FROM (select distinct idxName, dbo.ConcatenarGroupByTmp(@dummyRdxTmp, idxName, 0) as columnName, uniqueIdx, dbo.ConcatenarGroupByTmp(@dummyRdxTmp, idxName, 1) as includeName from @dummyRdxTmp) AS tbl

EXEC sp_executesql @sql;')
GO
if exists(select * from sysobjects where type = 'P' and name = 'DropColumnsTmp')
	DROP PROCEDURE DropColumnsTmp
IF TYPE_ID(N'DropColumnType') IS NOT NULL
	DROP TYPE DropColumnType;
EXEC ('CREATE TYPE DropColumnType AS TABLE (name VARCHAR(300));')
EXEC ('CREATE PROCEDURE DropColumnsTmp
@tabela DropColumnType READONLY,
@tableName nvarchar(128)
AS
set nocount on
declare @result nvarchar(MAX)
select @result = COALESCE(@result + '','', '''') + ''['' + TblToRemove.name + '']'' 
from (
	select Col.name
	from sysobjects as Tbl inner join syscolumns as Col on Tbl.id = Col.id 
	where Tbl.name = @tableName and Col.name COLLATE SQL_Latin1_General_CP1_CI_AI not in (select name from @tabela)) as TblToRemove

if (@result != '''')
BEGIN
	declare @constraints nvarchar(MAX)

	SELECT @constraints = COALESCE(@constraints + '','', '''') + ''['' + obj_Constraint.NAME + '']''
        FROM   sys.objects obj_table 
        JOIN sys.objects obj_Constraint ON obj_table.object_id = obj_Constraint.parent_object_id 
        JOIN sys.default_constraints constraints ON constraints.object_id = obj_Constraint.object_id -- changed from sysconstraints because when number of columns is bigger than smallint, the view produces an error
        JOIN sys.columns columns ON columns.object_id = obj_table.object_id AND columns.column_id = constraints.parent_column_id
    WHERE obj_table.NAME=@tableName AND columns.NAME COLLATE SQL_Latin1_General_CP1_CI_AI not in (select name from @tabela)

	if (@constraints != '''')
		EXEC(''ALTER TABLE ['' + @tableName + ''] DROP CONSTRAINT '' + @constraints);

	/* If it detects indexes associated with the columns to be removed, it removes them */
	declare @indexes nvarchar(MAX)
	select @indexes = COALESCE(@indexes + char(10), '''') + ''Drop INDEX ['' +  sysindex.name + ''] On '' +@tableName
	From sys.indexes As SysIndex
		Inner Join sys.index_columns As SysIndexCol On SysIndex.object_id = SysIndexCol.object_id And SysIndex.index_id = SysIndexCol.index_id 
		Inner Join sys.columns As SysCols On SysIndexCol.column_id = SysCols.column_id And SysIndexCol.object_id = SysCols.object_id 
	Where 
		type <> 0 
		And SysIndex.object_id in (Select systbl.object_id from sys.tables as systbl Where SysTbl.name = @tableName)
		and  SysCols.name COLLATE SQL_Latin1_General_CP1_CI_AI not in (select name from @tabela)
	
	if (@indexes != '''')
		EXEC(@indexes);

	EXEC (''ALTER TABLE ['' + @tableName + ''] DROP COLUMN '' + @result);
END');
GO
if exists(select * from sysobjects where type = 'P' and name = 'DropConstraintsTmp')
	DROP PROCEDURE DropConstraintsTmp
EXEC ('CREATE PROCEDURE DropConstraintsTmp
@tableName nvarchar(128),
@columnName nvarchar(128)
AS
BEGIN
	set nocount on
	declare @constraints nvarchar(MAX)
	SELECT @constraints = COALESCE(@constraints + '','', '''') + ''['' + obj_Constraint.NAME + '']''
    FROM   sys.objects obj_table 
        JOIN sys.objects obj_Constraint ON obj_table.object_id = obj_Constraint.parent_object_id 
        JOIN sys.default_constraints constraints ON constraints.object_id = obj_Constraint.object_id -- changed from sysconstraints because when number of columns is bigger than smallint, the view produces an error
        JOIN sys.columns columns ON columns.object_id = obj_table.object_id AND columns.column_id = constraints.parent_column_id
    WHERE obj_table.NAME=@tableName AND columns.NAME COLLATE SQL_Latin1_General_CP1_CI_AI = @columnName
	if (@constraints != '''')
		EXEC(''ALTER TABLE ['' + @tableName + ''] DROP CONSTRAINT '' + @constraints);
END');
GO
if exists(select * from sysobjects where type = 'P' and name = 'estrutura_dinamica')
	DROP PROCEDURE estrutura_dinamica
EXEC ('create PROCEDURE estrutura_dinamica
as
begin
	DECLARE @nometabela VARCHAR(25)
	DECLARE @nomecampo VARCHAR(25)
	DECLARE @tipodados VARCHAR(15)
	DECLARE @tiposql VARCHAR(15)
	DECLARE @largura int
	DECLARE tableFields CURSOR STATIC FOR
	SELECT nometabela, nomecampo, tipodados, tiposql, largura from [PJFTABDINAMIC] where zzstate = 0
	OPEN tableFields
	FETCH NEXT FROM tableFields INTO @nometabela, @nomecampo, @tipodados, @tiposql, @largura
	WHILE @@fetch_status = 0
	BEGIN
		exec AlterarCamposTmp @nometabela, @nomecampo, @tipodados, @tiposql, @largura;
	FETCH NEXT FROM tableFields INTO @nometabela, @nomecampo, @tipodados, @tiposql, @largura
	END
	CLOSE tableFields
	DEALLOCATE tableFields
end');
GO
if exists(select * from sysobjects where type = 'P' and name = 'DoRestoreDatabase')
	DROP PROCEDURE DoRestoreDatabase
EXEC ('create PROCEDURE DoRestoreDatabase
@path VARCHAR(255),
@database VARCHAR(150)
as
BEGIN	
	SET NOCOUNT ON;
	
	DECLARE @dataFileName NVARCHAR(256)
	DECLARE @logFileName NVARCHAR(256)

	DECLARE @defaultDataPath NVARCHAR(512)
	DECLARE @defaultLogPath NVARCHAR(512)

	DECLARE @filelist TABLE
	(
		LogicalName NVARCHAR(256),
		PhysicalName NVARCHAR(512),
		[Type] varchar, 
		[FileGroupName] varchar(128), 
		[Size] varchar(128),
		[MaxSize] varchar(128), 
		[FileId]varchar(128), 
		[CreateLSN]varchar(128), 
		[DropLSN]varchar(128), 
		[UniqueId]varchar(128), 
		[ReadOnlyLSN]varchar(128), 
		[ReadWriteLSN]varchar(128),
		[BackupSizeInBytes]varchar(128), 
		[SourceBlockSize]varchar(128), 
		[FileGroupId]varchar(128), 
		[LogGroupGUID]varchar(128), 
		[DifferentialBaseLSN]varchar(128), 
		[DifferentialBaseGUID]varchar(128), 
		[IsReadOnly]varchar(128), 
		[IsPresent]varchar(128), 
		[TDEThumbprint]varchar(128),
		[SnapshotUrl]varchar(128)
	);

	INSERT INTO @filelist
	EXEC(''RESTORE FILELISTONLY FROM DISK = '''''' + @path + '''''''')

	--Get file paths from backupfile
	SELECT @dataFileName = LogicalName FROM @filelist WHERE Type = ''D''
	SELECT @logFileName = LogicalName FROM @filelist WHERE Type = ''L''  

	--Get database data folder
	SELECT @defaultDataPath = CAST(SERVERPROPERTY(''InstanceDefaultDataPath'') AS NVARCHAR(512))
	SELECT @defaultLogPath = CAST(SERVERPROPERTY(''InstanceDefaultLogPath'') AS NVARCHAR(512))
	
	DECLARE @restoreQuery NVARCHAR(1000)
	SET @restoreQuery = 
		''RESTORE DATABASE '' + @database + '' FROM DISK = '''''' + @path + '''''''' +
		'' WITH REPLACE, MOVE '''''' + @dataFileName + '''''' TO ''''''+ @defaultDataPath + ''\'' + @database + ''.mdf'''', MOVE '''''' +
		 @logFileName + '''''' TO ''''''+ @defaultLogPath +''\'' + @database + ''.ldf''''''
	
	EXEC sp_executesql @restoreQuery
END');
GO
