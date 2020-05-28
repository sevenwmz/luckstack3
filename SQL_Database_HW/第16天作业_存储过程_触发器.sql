--作业：
--1.编写存储过程模拟“一起帮用户注册”的过程，包含以下逻辑：
	--1.检查用户名是否重复。如果重复，返回错误代码：1
	--2.检查用户名密码是否符合“长度不小于4位”的要求。如果不符合，返回错误代码：2
--3.如果有邀请人：
	--1.检查邀请人是否存在，如果不存在，返回错误代码：10
	--2.检查邀请码是否正确，如果邀请码不正确，返回错误代码：11
	--4.将用户名、密码和邀请人存入数据库（Register）
	--5.给邀请人增加10个帮帮点积分
	--6.通知邀请人（在Message中生成一条数据）某人使用了他作为邀请人。
	Alter Procedure AffirmRegister
	@UserName Nvarchar(30) ,
	@Password Nvarchar(30),
	@InvitedBy Nvarchar(30),
	@InvitationCode Int,
	@answer int output
	As
	Set NoCount On
	If (@UserName In (Select UserName From [User] u Where u.UserName = @UserName))
	Set @answer = 1
	Else If( Len(@Password)<4 )
	Set @answer = 2
	Else If(@InvitedBy Not In 
			(Select u.UserName From [User] u Where u.UserName = @InvitedBy))
	Set @answer = 10
	Else If(@InvitationCode Not In 
			(Select u.InviteNumber From [User] u Where u.InviteNumber = @InvitationCode))
	Set @answer = 11
	Else
	Begin
	Insert [User](UserName,[Password],InviteById) 
			Values(@UserName,@Password,(Select Id From [User] u Where u.UserName = @InvitedBy)
			)
	
	Update HelpMoney Set BMoney += 10 Where Id = (Select u.BMoneyId From [User] u Where u.UserName = @InvitedBy)

	Insert [Message](FromUser,ToUser,UrgentLevel,Kind,HasRead,IsDelete,Content)
			Values(N'System',
			(Select Id From [User]u Where u.UserName = @InvitedBy),
			7,
			N'Invited Succefly',
			0,
			0,
			N'User @UserName use InvitationCode Register alread Success!!! Bmoney add you repository'
			)
	Set @answer = 0
	End
	Print @answer
	Set NoCount Off

	Declare @anwser Int
	Execute AffirmRegister
	@UserName=N'wpzwpqz',@Password='1234',@InvitedBy=N'wpzwpz',@InvitationCode=12234,@answer=@anwser Output


	Select * From [Message]
	Select * From HelpMoney
	Select * From [User]
	Delete [User] Where Id = 28

	--Message(Id, FromUser, ToUser, UrgentLevel, Kind, HasRead, IsDelete, Content)
	CREATE TABLE [dbo].[Message] (
    [Id]          INT            NOT NULL Primary Key Identity,
    [FromUser]    NVARCHAR (20)  NULL ,
    [ToUser]      Int  NULL Constraint FK_User_Message_ToUser Foreign Key References [User](Id),
    [UrgentLevel] TINYINT        NULL,
    [Kind]        NVARCHAR (20)  NULL,
    [HasRead]     BIT            NOT NULL,
    [IsDelete]    BIT            NOT NULL,
    [Content]     NVARCHAR (200) NULL,
);
GO

--2.确保Problem有“发布时间（PublishTime）”和“最后更新时间（LatestUpdateTime）”两列，创建触发器实现：
	--1.插入一条数据，自动将当前时间计入PublishTime
Insert Problem(PublishTime) Values(2011/3/2)
Select * From Problem
Alter Table Problem
Add LatestUpdateTime DateTime 

Go
Alter TRIGGER AddTime
ON Problem
AFTER Insert
AS 
Update Problem Set PublishTime = GETDATE()  Where Id = @@IDENTITY 
Update Problem Set LatestUpdateTime = GETDATE()  Where Id = @@IDENTITY 
Go

GO
--.更新一条数据，自动将当前时间计入LatestUpdateTime （提示：INSERTED伪表）
Alter Trigger LatesTime On Problem
For Update
As
If UPDATE(LatestUpdateTime)
Begin
Update Problem Set LatestUpdateTime = 
(GETDATE()) From Problem Inner Join inserted i On Problem.PublishTime = i.PublishTime
End

--Update Problem Set LatestUpdateTime = GETDATE() WHERE Id = (SELECT Id FROM inserted)
Go

Select * From Problem
Update Problem Set LatestUpdateTime = '2012/1/1' Where Title = N'王数据库'

go

