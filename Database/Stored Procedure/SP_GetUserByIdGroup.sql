CREATE PROCEDURE [FilmApp].[SP_GetUserByIdGroup]
	@IdGroup int
AS
BEGIN
	SELECT u.Id, u.FirstName, u.LastName, u.Login FROM [User] as u
	JOIN [UserGroup] as ug ON ug.IdUser = u.Id
	WHERE ug.IdGroup = @IdGroup
	AND u.IsActive = 1
END
