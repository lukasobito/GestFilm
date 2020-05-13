CREATE PROCEDURE [FilmApp].[SP_GetGroupEvent]
	@GroupId int
AS
BEGIN
	SELECT e.Id, e.[Name], e.Film, e.[Date], e.IsFilmValid, e.IsDateValid FROM [Event] e
		INNER JOIN [GroupEvent] AS ge ON ge.IdEvent = e.Id
		INNER JOIN [Group] AS g ON g.Id = ge.IdGroup
		WHERE g.Id = @GroupId
END
