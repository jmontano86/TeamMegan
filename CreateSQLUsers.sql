USE [234a_Megan];
GO
DROP TABLE Users;
GO
CREATE TABLE Users 
(
UserID INT IDENTITY(1,1) PRIMARY KEY,
Username NVARCHAR(60) NOT NULL,
Password NVARCHAR(128) NOT NULL,
Email NVARCHAR(60) NOT NULL,
Type NVARCHAR(1) NOT NULL,
CONSTRAINT USER_TYPE CHECK (Type IN ('U', 'A', 'T'))
);
GO

CREATE UNIQUE INDEX Users_Email_IDX ON Users (Email);
GO
DROP PROCEDURE SPCreateNewUser;
GO

CREATE PROCEDURE SPCreateNewUser
    @Username NVARCHAR(60),
	@Password NVARCHAR(128),
	@Email    NVARCHAR(60)

AS

    INSERT INTO Users (Username, Password, Email, Type )
	VALUES (@Username, @Password, @Email, 'U');

GO
DROP PROCEDURE SPGetUser;
GO
CREATE PROCEDURE SPGetUser
    @Email NVARCHAR(60)

AS

    SELECT Username,
	       Password,
		   Email,
		   Type
    FROM   Users
	WHERE  Email = @Email;

GO
