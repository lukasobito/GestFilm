CREATE PROCEDURE [FilmApp].[SP_GetUserGroup]
	@UserId INT
AS
BEGIN
	SELECT g.Id, g.Name FROM [Group] AS g 
		INNER JOIN [UserGroup] AS ug ON ug.IdGroup = g.Id 
		INNER JOIN [User] AS u ON u.Id = ug.IdUser
		WHERE u.Id = @UserId;
END
