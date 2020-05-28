--观察并模拟17bang项目中的：
--用户资料，新建用户资料（Profile）表，和User形成1:1关联（有无约束？）。用SQL语句演示：

Alter Table [User]
Add Constraint PK_17bang_User_Id Primary Key(Id)

Create Table [Profile](
	[Id] Int Identity Primary Key,
	[ICon] Image,
	[IsFemale] Bit ,
	[BrithDay] Datetime,
	[Keyword] Nvarchar(20),
	[SelfDecription] Nvarchar(255),
	[ForUser] Int Constraint FK_Profile_User_ForUser Foreign Key References[User](Id)
);



Alter Table [User]
Add [MyDescription] Int

Alter Table [User]
Add Constraint FK_User_Profile_MyDescription Foreign Key(MyDescription)
References [Profile](Id)

Select * From [User]
Select * From [Profile]

Alter Table [User]
Alter Column InviteName Nvarchar(20) Null

Insert [User](UserName,[Password]) Values(N'wpzwpz',N'1234')
Insert [User](UserName,[Password]) Values(N'1wpzwpz',N'1234')
Insert [User](UserName,[Password]) Values(N'2wpzwpz',N'1234')


--o新建一个填写了用户资料的注册用户
Insert [Profile](IsFemale,ForUser) Values(1,16)
Update [User] Set MyDescription = 2 Where Id = 16

Select * From [User]
Select * From [Profile]
--o通过Id查找获得某注册用户及其用户资料
Select * From [Profile]
Where Id = 16

--o删除某个Id的注册用户
Begin Transaction
Update [User] Set MyDescription = null Where MyDescription = 2

begin Transaction
Delete [User] Where Id = 16

 
--帮帮点说明：新建Credit表，可以记录用户的每一次积分获得过程，即：某个用户，在某个时间，因为某某原因，获得若干积分
Create Table Credit(
	[Id] Int Identity,
	[UserName] Nvarchar(20),
	[GetCreditTime] Datetime,
	[Detail] Nvarchar(50),
	[integral] TinyInt
);


--发布求助，在Problem和Register之间建立1:n关联（含约束）。用SQL语句演示：
Select * From Problem
Select * From [User]

Alter Table [Problem]
Add Constraint PK_17bang_Problem_Id Primary Key(Id)

Alter Table [Problem]
Add Constraint FK_Problem_User_AuthorId Foreign Key(AuthorId)
References [User](Id)

Update Problem Set AuthorId = 17
Where Id = 14 Or Id = 45

--o某用户发布一篇求助， 
Insert Problem(Title,Reward,PublishTime,AuthorId) Values(N'王月半子的Problem',13,'2020/5/18',16)
--o将该求助的作者改成另外一个用户
Begin Transaction
Update Problem Set AuthorId = 18
Where Id = 45
Rollback
--o删除该用户
Select * From Problem
Select * From [User]
Update Problem Set AuthorId = null
Where Id = 3

--求助列表：新建Keyword表，和Problem形成n:n关联（含约束）。用SQL语句演示：
Alter Table Keyword
Add Id Int Primary Key Identity


Create Table KeywordToProblem(
	[Id] Int Primary Key Identity,
	[Keyword] Int Constraint FK_KeywordToProblem_Keyword_Id Foreign Key References Keyword(Id),
	[Problem] Int Constraint FK_KeywordToProblem_Problem_Id Foreign Key References Problem(Id)
);

Select * From Keyword  Select * From Problem  Select *From KeywordToProblem

Insert KeywordToProblem(Keyword,Problem) Values(1,5)
Insert KeywordToProblem(Keyword,Problem) Values(1,12)
Insert KeywordToProblem(Keyword,Problem) Values(1,14)
Insert KeywordToProblem(Keyword,Problem) Values(3,5)
Insert KeywordToProblem(Keyword,Problem) Values(4,5)
Insert KeywordToProblem(Keyword,Problem) Values(5,5)

--o查询获得：某求助使用了多少关键字，某关键字被多少求助使用
Select Count(*) From KeywordToProblem
Where Problem = 5

Select * From KeywordToProblem
Where Problem = 5

Select Count(*) From KeywordToProblem
Where Keyword = 3

Select * From KeywordToProblem
Where Keyword = 3


--o发布了一个使用了若干个关键字的求助
Select * From [User]
Select * From Keyword  Select * From Problem  Select *From KeywordToProblem
Insert Problem(Title,Reward,PublishTime,AuthorId) Values(N'Publish Use',14,'2020/5/19',18)
Insert KeywordToProblem(Keyword,Problem) Values(3,@@IDENTITY)
Insert KeywordToProblem(Keyword,Problem) Values(4,68)
Insert KeywordToProblem(Keyword,Problem) Values(5,68)

--o该求助不再使用某个关键字
Select * From KeywordToProblem

begin Transaction
Delete From KeywordToProblem
Where Problem = 12
Rollback

--o删除该求助
Select * From KeywordToProblem
Where Problem = 69

Delete KeywordToProblem Where Id = 16
Delete Problem Where Id = 69


--o删除某关键字
Select * From KeywordToProblem
Where Keyword = 1

Delete KeywordToProblem Where Id = 1
Delete Keyword Where Id = 1




