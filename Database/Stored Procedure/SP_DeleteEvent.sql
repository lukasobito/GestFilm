CREATE PROCEDURE [FilmApp].[SP_DeleteEvent]
	@Id int
AS
BEGIN
	DELETE FROM [Event] 
	WHERE Id = @Id;
END
