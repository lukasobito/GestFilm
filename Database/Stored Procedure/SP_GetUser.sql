CREATE PROCEDURE [FilmApp].[SP_GetUser]
	@Search varchar(50),
	@IdGroup int
AS
BEGIN
	SELECT u.Id, u.[Login], u.LastName, u.FirstName
	FROM [User] as u
	LEFT JOIN [UserGroup] as ug ON u.Id = ug.IdUser
	WHERE u.[Login] LIKE CONCAT('%',@Search,'%')
	AND u.IsActive = 1
	AND (ug.IdGroup != @IdGroup
	OR ug.IdGroup IS NULL)
END
