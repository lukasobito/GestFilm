CREATE PROCEDURE [FilmApp].[SP_CreateGroup]
	@Name nvarchar(50)
AS
BEGIN
	INSERT INTO [Group] (Name) OUTPUT inserted.Id VALUES (@name);
END
