CREATE PROCEDURE [FilmApp].[SP_CreateEvent]
	@Name nvarchar(50),
	@Film nvarchar(50),
	@Date datetime,
	@IsFilmValid bit,
	@IsDateValid bit,
	@GroupId int
AS
BEGIN
	INSERT INTO [Event] ([Name], [Film], [Date], [IsFilmValid], [IsDateValid], [GroupId])
	OUTPUT INSERTED.Id 
	VALUES (@Name, @Film, @Date, @IsFilmValid, @IsDateValid, @GroupId);
END
