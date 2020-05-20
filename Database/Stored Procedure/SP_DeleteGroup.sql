CREATE PROCEDURE [FilmApp].[SP_DeleteGroup]
	@Id int
AS
BEGIN
	DELETE FROM [UserGroup] WHERE IdGroup = @Id;
	DELETE FROM [Group] WHERE Id = @Id;
END
