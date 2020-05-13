CREATE PROCEDURE [FilmApp].[SP_GetEvent]
	@Id int
AS
BEGIN
	SELECT [Id], [Name], [Film], [Date], [IsFilmValid], [IsDateValid] 
	FROM [Event]
	WHERE [Id] = @Id;
END
