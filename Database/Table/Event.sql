CREATE TABLE Event(
	[Name] NVARCHAR(50) NOT NULL , 
	Film NVARCHAR(50) NOT NULL , 
	[Date] datetime NOT NULL, 
	IsFilmValid bit NOT NULL DEFAULT 0, 
	[IsDateValid] bit NOT NULL DEFAULT 0, 
    [Id] INT IDENTITY NOT NULL, 
    CONSTRAINT [PK_Event] PRIMARY KEY ([Id])
);
