CREATE PROCEDURE [FilmApp].[SP_UpdateEvent]
	@Id int,
	@Name nvarchar(50),
	@Film nvarchar(50),
	@Date datetime,
	@IsFilmValid bit,
	@IsDateValid bit
AS
BEGIN
	UPDATE [Event] SET [Name] = @Name, [Film] = @Film, [Date] = @Date, [IsFilmValid] = @IsFilmValid, [IsDateValid] = @IsDateValid
	WHERE Id = @Id;
END
