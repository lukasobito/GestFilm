CREATE TABLE Event(
	[Name] NVARCHAR(50) NOT NULL , 
	Film NVARCHAR(50) NOT NULL , 
	[Date] datetime NOT NULL, 
	IsFilmValid bit NOT NULL DEFAULT 0, 
	[IsDateValid] bit NOT NULL DEFAULT 0, 
    [Id] INT IDENTITY NOT NULL, 
    [GroupId] INT NOT NULL, 
    CONSTRAINT [PK_Event] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Event_Group] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id])
);
