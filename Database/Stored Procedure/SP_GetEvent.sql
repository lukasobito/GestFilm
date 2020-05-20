CREATE PROCEDURE [FilmApp].[SP_GetEvent]
	@Id int
AS
BEGIN
	SELECT [Id], [Name], [Film], [Date], [IsFilmValid], [IsDateValid], [GroupId] 
	FROM [Event]
	WHERE [Id] = @Id;
END
