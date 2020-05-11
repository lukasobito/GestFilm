CREATE TABLE [dbo].[UserGroup]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdUser] INT NOT NULL, 
    [IdGroup] INT NOT NULL, 
    CONSTRAINT [FK_UserGroup_User] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserGroup_Group] FOREIGN KEY ([IdGroup]) REFERENCES [Group]([Id])
)
