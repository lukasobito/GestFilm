CREATE PROCEDURE [FilmApp].[SP_GetGroup]
	@Id int
AS
BEGIN
	SELECT Id, [Name] 
	FROM [Group]
	WHERE id = @Id;
END
