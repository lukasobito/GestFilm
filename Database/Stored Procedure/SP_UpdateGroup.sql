CREATE PROCEDURE [FilmApp].[SP_UpdateGroup]
	@Id int,
	@Name nvarchar(50)
AS
BEGIN
	UPDATE [Group] SET [Name] = @Name WHERE Id = @Id;
END