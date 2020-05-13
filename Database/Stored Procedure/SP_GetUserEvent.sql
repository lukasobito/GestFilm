CREATE PROCEDURE [FilmApp].[SP_GetUserEvent]
	@UserId int
AS
BEGIN
	SELECT e.Id, e.[Name], e.Film, e.[Date], e.IsFilmValid, e.IsDateValid FROM [Event] e
		INNER JOIN [GroupEvent] AS ge ON ge.IdEvent = e.Id
		INNER JOIN [Group] AS g ON g.Id = ge.IdGroup
		INNER JOIN [UserGroup] AS ug ON ug.IdGroup = g.Id
		INNER JOIN [User] AS u ON u.Id = ug.IdUser
		WHERE u.Id = @UserId
END
