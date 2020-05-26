CREATE PROCEDURE [FilmApp].[SP_LinkUserGroup]
	@idUser int,
	@IdGroup int
AS
BEGIN
	INSERT INTO [UserGroup] (IdGroup,IdUser) VALUES (@IdGroup,@idUser)
END
