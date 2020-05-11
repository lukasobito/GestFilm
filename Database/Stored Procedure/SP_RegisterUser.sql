CREATE PROCEDURE [dbo].[SP_RegisterUser]
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@Login nvarchar(50),
	@Password nvarchar(30)
AS
	Insert into [User] (LastName, FirstName, Login, Password)
	values (@LastName, @FirstName, @Login, HASHBYTES('SHA2_256',[dbo].[PreSalt]+ @Password + [dbo].[PreSalt]));
RETURN 0
