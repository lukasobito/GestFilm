CREATE PROCEDURE [FilmApp].[SP_LoginUser]
	@Login nvarchar(50),
	@Password nvarchar(30)
AS
BEGIN
	Select Id, LastName, FirstName, [Login] 
	From [User]
	Where [Login] = @Login And [Password] = HASHBYTES('SHA2_256',[dbo].PreSalt()+ @Password + [dbo].PostSalt())
END
