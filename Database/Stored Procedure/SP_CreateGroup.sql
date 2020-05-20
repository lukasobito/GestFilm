CREATE PROCEDURE [FilmApp].[SP_CreateGroup]
	@Name nvarchar(50),
	@UserId int
AS
BEGIN
	DECLARE @Id int;

	INSERT INTO [Group] (Name) VALUES (@name);
	SET @Id = SCOPE_IDENTITY();

	INSERT INTO [UserGroup] (IdGroup,IdUser) OUTPUT @Id VALUES (@Id, @UserId);
END
