declare @bCorrect nvarchar(800)

set @bCorrect = 'ok'


--Verificar o schema da tabela de codigos sequenciais
if object_id('dbo.Codigos_Sequenciais', 'U') is null
	set @bCorrect = 'There is no Codigos_Sequenciais table. The database schema was not created correctly.'
else if ((SELECT COUNT(name) FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Codigos_Sequenciais') and name in ('id_objecto', 'proximo')) != 2)
begin
	set @bCorrect = 'The schema in Codigos_Sequenciais is incorrect. The database schema was not created correctly.'
end

IF @bCorrect <> 'ok' RAISERROR (@bCorrect, 16, -1)
GO
