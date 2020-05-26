CREATE PROCEDURE [FilmApp].[SP_GetUserEvent]
	@UserId int
AS
BEGIN
	SELECT e.Id, e.[Name], e.Film, e.[Date], e.IsFilmValid, e.IsDateValid, e.GroupId FROM [Event] e
		INNER JOIN [Group] AS g ON g.Id = e.GroupId
		INNER JOIN [UserGroup] AS ug ON ug.IdGroup = g.Id
		INNER JOIN [User] AS u ON u.Id = ug.IdUser
		WHERE u.Id = @UserId
END
