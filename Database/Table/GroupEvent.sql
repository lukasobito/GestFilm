CREATE TABLE [dbo].[GroupEvent]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [IdGroup] INT NOT NULL, 
    [IdEvent] INT NOT NULL, 
    CONSTRAINT [FK_GroupEvent_Group] FOREIGN KEY ([IdGroup]) REFERENCES [Group]([Id]), 
    CONSTRAINT [FK_GroupEvent_Event] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id])
)
