CREATE TABLE Event(
	[Name] varchar(50) NOT NULL , 
	Film varchar(50) NOT NULL , 
	[Date] datetime NOT NULL, 
	IsFilmValid bit NOT NULL DEFAULT 0, 
	[IsDateValid] bit NOT NULL DEFAULT 0, 
    [Id] INT NOT NULL, 
    CONSTRAINT [PK_Event] PRIMARY KEY ([Id])
);
