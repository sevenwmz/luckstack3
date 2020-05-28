--作业：
--1.编写存储过程模拟“一起帮用户注册”的过程，包含以下逻辑：
--3.如果有邀请人：


	Create Procedure SelfTest
	@UserName Nvarchar(30),
	@Password Varchar(20),
	@InvitedBy Nvarchar(30),
	@InvitedCode Int ,
	@ScendOut Int OutPut
	As
	Set Nocount On
	--1.检查用户名是否重复。如果重复，返回错误代码：1
	If (@UserName In (Select u.UserName From [User] u Where @UserName = u.UserName))
	Set @ScendOut = 1
	--2.检查用户名密码是否符合“长度不小于4位”的要求。如果不符合，返回错误代码：2
	Else If (Len(@Password)<4)
	Set @ScendOut = 2
	--1.检查邀请人是否存在，如果不存在，返回错误代码：10
	Else If (@InvitedBy Not In (Select u.UserName From [User] u Where @InvitedBy = u.UserName))
	Set @ScendOut = 10
	--2.检查邀请码是否正确，如果邀请码不正确，返回错误代码：11
	Else If (@InvitedCode Not In (Select u.InviteNumber From [User] u Where @InvitedCode = u.InviteNumber))
	Set @ScendOut = 11
	Else
	Begin
	--4.将用户名、密码和邀请人存入数据库（Register）
	Insert [User](UserName,[Password],InviteById) 
		Values(@UserName,@Password,(Select Id From [User] u Where @InvitedBy = u.UserName))
	--5.给邀请人增加10个帮帮点积分
	Update HelpMoney Set BMoney += 10 
		Where Id = (Select u.InviteById From [User] u Where @InvitedBy = u.UserName)
	--6.通知邀请人（在Message中生成一条数据）某人使用了他作为邀请人。
	Insert [Message](FromUser,ToUser,Kind,Content) 
		Values(N'System',(Select u.InviteById From [User] u Where @InvitedBy = u.UserName),
				N'System Message',N'某人使用了他作为邀请人。')
	Set @ScendOut = 0
	End
	Print @ScendOut
	Set Nocount Off













--用户（Reigister）发布一篇悬赏币若干的求助（Problem），
--他的帮帮币（BMoney）也会相应减少，
--但他的帮帮币总额不能少于0分：
--请综合使用TRY...CATCH和事务完成上述需求。


Begin Try
	Begin Tran
	Insert Problem(Title,AuthorId,Reward,NeedRemote,PublishTime) 
		 Values (N'Test For Try',16,500,1,'2020/2/2')
	Update HelpMoney Set BMoney -= 500 Where Id = 
		(Select u.BMoneyId From [User] u Where Id = 16) 
	Commit
End Try
Begin Catch
	RollBack
End Catch



Begin Try
	Begin Tran
	Insert Problem(Title,AuthorId,Reward,NeedRemote,PublishTime) 
		 Values (N'Test For Try',16,12,1,'2020/2/2')
	Update HelpMoney Set BMoney -= 12 Where Id = 
		(Select u.BMoneyId From [User] u Where Id = 16) 
	Commit
End Try
Begin Catch
	RollBack
End Catch


























Dbcc Useroptions


Rollback
Print @@Trancount



Select * From Problem
Begin Tran 
Update Problem Set Reward += 10 Where Id = 16

Begin Tran 
Update Problem Set Reward += 10 Where Id = 15


--Create View V_Problem
--As
--Select Id,[Name]
--Year(Publishtime) YearPublishTime,
--Month(Publishtime) MonthPublishTime,
--Day(Publishtime) DayPublishTime,
--Age,Score
--From Problem


Select * From Major 

Select * From TSCORE OT
Where Score IN (Select MAX(Score) From TSCORE IT
Where OT.Name = IT.Name)

Select * From TSCORE


Begin  Transaction
Delete TSCORE Where Name not In (Select MAX(Name) From TSCORE Group By Subject)
Rollback


Select *,
Score - (Select Avg(score) From TSCORE) As gap From TSCORE

Update TSCORE  Set Score = 
(Select * From TSCORE Where Score = 
(Select * From TSCORE Where Subject = N'C#' And Name = N'路炜')
)
Where Subject = N'C#'  And Name = N'飞哥'


















--行列转行
Select [Name], 
Max(Case [Subject] When N'C#' Then Score Else 0 End )As C# ,
Max(Case [Subject] When N'JavaScript' Then Score Else 0 End )As JavaScript ,
Max(Case [Subject] When N'SQL' Then Score Else 0 End )As [SQL] 
From TSCORE
Group By [Name]

Select * From TSCORE

Select AVG(Score) From TSCORE Group By [Name]

Select *From TSCORE Ot
Where Score >(
	Select AVG(Score) From TSCORE It
	WHere Ot.Name = it.Name
	)












Select * From TSCORE

CREATE TABLE TSCORE
(
[Name] NVARCHAR(20),
[Subject] NVARCHAR(20),
Score INT
)

INSERT TSCORE VALUES(N'飞哥','SQL', 98)
INSERT TSCORE VALUES(N'飞哥','C#', 89)
INSERT TSCORE VALUES(N'飞哥','Javascript',76)
INSERT TSCORE VALUES(N'路炜','C#',87)
INSERT TSCORE VALUES(N'路炜','SQL',95)
INSERT TSCORE VALUES(N'路炜','Javascript',88)


Select * from Teacher

Create Table Teacher(
	Id Int,
	[Name] Nvarchar(25),
	Age Int,
	Gender Bit
);

Create Unique Clustered Index IX_Teacher_Id On Teacher(Id)
Create Unique NonClustered Index IX_TEACHER_Age On Teacher(age)

Create Index IX_TEACHER_GENDER ON TEACHER(GENDER)

Insert Teacher(Id,[Name],Age,Gender) VAlues(1,N'wpz',23,1);
Insert Teacher(Id,[Name],Age,Gender) VAlues(2,N'wpzq',39,0);

Create Unique Index IX_Teacher_Name_1 On Teacher([Name])
Drop Index Teacher.IX_Teacher_Id

Select * From Teacher


Alter Table Teacher
Add Constraint UQ_TEACHER_NAME Unique( [name] )

Select [Name],[Type],Is_UNIque,Is_primary_key,Is_Unique_Constraint
From sys.indexes
Where object_id = OBJECT_ID('Teacher')

Create Nonclustered Index Ix_teacher_Name On Teacher([Name])

Create Unique clustered Index Ix_teacher_Name2 On Teacher([Name])
Create Index Ix_teacher_Name4 On Teacher([Name])

Drop Index Teacher.Ix_teacher_Name4

Select  * From Teacher Where [Name] = 'Fg'

Alter Table Teacher
--Alter Column Id Int Not Null 
Add Constraint PK_Teacher_Id Primary Key(Id)

Declare @N Int = 0
While @N<5
Begin
	Set @N+=1
	Print @N
end

Go
Create Function YzAdd(@a Int,@b Int) 
Returns Int
Begin
	return @a + @b
end

go
Print dbo.YzAdd(3,5)




Declare @name Int Set @name = 1
Print @@Version

Declare @age Int = 17
if @age < 18 
Begin
Print 'Adult'
Print 'is ok'
Print 'Now'
end
else print 'Te' 

Declare @age Int = 17
While @age  <20
Begin
	Set @age+=1
	Print @age
end
Go
Alter Function WpzAdd(@A Int,@B Int)
Returns Int
Begin
	Return @A * @B
End
Go

Drop Function dbo.YzAdd
Print dbo.WpzAdd(3,5)
Go
Create Function TableFunction(@number Int)
Returns Table
Return Select Top(@number) * From Teacher
go
select * From TableFunction(3)

Go
Create Function TableMutipleFunction(@id Int,@name Nvarchar(20))
Returns @T Table(Id Int,[Name]Nvarchar(20))
Begin
	Insert @T Values(@id,@name)
	Return 
end


Go
Select * From TableMutipleFunction(2,'Teacher')
Select * From TableMutipleFunction(2,'Teacher')


Create Table Student(
	[Id]int Identity,
	[Name] Nvarchar(20),
	[Enroll] datetime,
	[Age] Int,
	[IsFemale] Bit,
	[Score] Int
);

Create Table Teacher(
	[Id]Int Identity,
	[Name]Nvarchar(20),
	[Age]Int,
	[Gender]Bit
);

Create Table [User](
	[Id]Int Identity,
	[Name] Nvarchar(20),
	[Password]Nvarchar(20),
	[InvitedBy]Int
);


Alter Table Student
Add TeacherId Int

ALter Table Teacher
Add Constraint PK_Teacher_Id Primary Key(Id)

Select * From Student

Alter Table Student
Add Constraint FK_Teacher_Id
Foreign Key (TeacherId)
References Teacher(Id)

Insert Student(Name,Age,IsFemale) Values(N'Wpz',12,1)
Insert Student(Name,Age,IsFemale) Values(N'Wp1z',22,1)
Insert Student(Name,Age,IsFemale) Values(N'2Wpz',32,1)
Insert Student(Name,Age,IsFemale) Values(N'3Wpz',42,1)
Insert Teacher(Name,Age,Gender) Values(N'FG',32,1)
Insert Teacher(Name,Age,Gender) Values(N'xy',42,0)


Insert Student([Name]) Values(N'4wpz')
Insert Student([Name],TeacherId) Values(N'4wpz',1)

Select * From [User]

Alter Table [User]
--Add VisitedBy Int
--Add Constraint PK_User_Id Primary Key(Id)

Add Constraint FK_User_VisitedById
Foreign Key(VisitedBy)
References [User](Id)


Insert [User](Name,Password) Values(N'wpz','1234')
Insert [User](Name,Password) Values(N'1wpz','1234')
Insert [User](Name,Password) Values(N'2wpz','1234')
Insert [User](Name,Password) Values(N'3wpz','1234')
Insert [User](Name,Password) Values(N'4wpz','1234')
Insert [User](Name,Password) Values(N'5wpz','1234')

Update [User] Set VisitedBy = 2 Where Id = 3
Select * From [User]
Delete [User] Where Id = 2
Update [User] Set VisitedBy = Null 
Where VisitedBy = 2
 
Select * From sys.indexes
Where object_id = OBJECT_ID('User')

Create Index IX_User_visitedBy On[User](VisitedBy)

Create Table Major(
	Id Int Identity Primary Key,
	[Name] Nvarchar(20),
	TaughtBy Int Constraint FK_Major_Teacher_Id 
	Foreign Key References Teacher(Id)
);


Select * From Teacher
Insert Teacher(Name) Values(N'Wpz')
Select * From Major

Insert Major(Name,TaughtBy) Values('C#',@@IDENTITY)


Select * From Student

Insert Student(Age,Name,Score) Values(22,N'sadw',23)

Select ROW_NUMBER()
Over(partition By Age Order By Score) As Gid,
Age,[Name],Score From Student

