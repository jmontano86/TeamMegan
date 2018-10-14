USE [234a_Megan];
GO
DROP TABLE Users;
GO
CREATE TABLE Users 
(
UserID INT IDENTITY(1,1) PRIMARY KEY,
Username NVARCHAR(64) NOT NULL,
Password NVARCHAR(128) NOT NULL,
Email NVARCHAR(64) NOT NULL,
Role NVARCHAR(16) NOT NULL
);
GO

CREATE UNIQUE INDEX Users_Email_IDX ON Users (Email);
GO

CREATE PROCEDURE SPCreateNewUser
    @Username NVARCHAR(64),
	@Password NVARCHAR(64),
	@Email    NVARCHAR(64)

AS

    INSERT INTO Users (Username, Password, Email, Role )
	VALUES (@Username, @Password, @Email, 'User');

GO

CREATE PROCEDURE SPGetUser
    @Email NVARCHAR(64)

AS

    SELECT Username,
	       Password,
		   Email,
		   Role
    FROM   Users
	WHERE  Email = @Email;

GO
