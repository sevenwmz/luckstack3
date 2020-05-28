Create Database [17bang];
Go;
Use [17bang]

--2.观察“一起帮”的注册和发布求助功能，试着建立表User：包含字段UserName（用户名），Password（密码）…… 
Create Table [dbo].[User]
(
[Id] Int Not Null Primary Key,
[InviteName] Nchar(10) Not Null,
[InviteNumber] int Not null,
[User] Nchar(10) Not Null,
[Password] Nchar(10) Not Null,
--ConfirmPassword here don't need it. Cause,database just save data.not compare
--Same as verification code.
);
Go;

Create Table [dbo].[Problem]
(
[Id] int Not Null Primary Key,
[Title] Nchar(10) Not Null,
[Body] Nchar(10) Not Null,
[FristKeywords] Nchar(10) Not Null,
[SecendKeywords] Nchar(10) Null,
[SelfMadeKeywords] Nchar(10) Null,
[DirectHelp] Nchar(10) Null,
[Reward] Int Not Null
);
Go;

Create Table [dbo].[FristKeywords]
(
[Id] Int Not Null Primary Key,
[Keyword] Nchar(10) Not Null
);
Go;

Create Table [dbo].[SecendKeywords]
(
[Id] Int Not Null Primary Key,
[Keyword] Nchar(10) Not Null
);
Go;

Create Table [dbo].[SelfMadeKeywords]
(
[UserId] Int Not Null Primary Key,
[Id] Int Not Null,
[Keyword] Nchar(10) Null
);
Go;

