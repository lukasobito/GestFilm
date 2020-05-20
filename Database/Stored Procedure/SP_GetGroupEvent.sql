CREATE PROCEDURE [FilmApp].[SP_GetGroupEvent]
	@GroupId int
AS
BEGIN
	SELECT Id, [Name], Film, [Date], IsFilmValid, IsDateValid, GroupId FROM [Event]
		WHERE GroupId = @GroupId
END
