﻿CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Login] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(30) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1
)
