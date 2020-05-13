CREATE PROCEDURE [FilmApp].[SP_DeleteGroup]
	@Id int
AS
BEGIN
	DELETE FROM [Group] WHERE Id = @Id;
END
