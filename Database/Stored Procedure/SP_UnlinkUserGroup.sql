CREATE PROCEDURE [FilmApp].[SP_UnlinkUserGroup]
	@IdGroup int,
	@IdUser int
AS
BEGIN
	DELETE FROM [UserGroup]
	WHERE [UserGroup].IdGroup = @IdGroup
	AND [UserGroup].IdUser = @IdUser
END
