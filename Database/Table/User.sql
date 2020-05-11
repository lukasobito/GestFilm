CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LastName] NCHAR(50) NOT NULL, 
    [FirstName] NCHAR(50) NOT NULL, 
    [Login] NCHAR(50) NOT NULL, 
    [Password] NCHAR(30) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1
)
