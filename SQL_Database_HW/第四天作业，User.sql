--作业：
--在User表中：
--1.查找没有录入密码的用户
--2.删除用户名（UserName）中包含“管理员”或者“17bang”字样的用户
--在Problem表中：
--1.给所有悬赏（Reward）大于10的求助标题加前缀：【推荐】
--2.给所有悬赏大于20且发布时间（Created）在2019年10月10日之后的求助标题加前缀：【加急】
--3.删除所有标题以中括号【】开头（无论其中有什么内容）的求助
--在Keyword表中：
--1.找出所有被使用次数（Used）大于10小于50的关键字名称（Name）
--2.如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1
--3.删除所有使用次数为奇数的Keyword
--注意，上述作业需要自己插入数据进行测试。

Create Database [17bang]

Use [17bang]

Create Table [User](
	[Id] Int Identity,
	[InviteName] Nvarchar(10) Not Null,
	[InviteNumber] SmallInt Constraint CK_User_InviteNumber Check(InviteNumber>0),
	[UserName] char(20) Not Null,
	[Password] char(10) Not Null
);

Alter Table [User]
Alter Column  [Password] char(10) Null

Select * From [User]

Begin Transaction
Insert [User](InviteName,InviteNumber,UserName,[Password]) Values('wpzwpz',1234,'17bang','dsaw')
Insert [User](InviteName,InviteNumber,UserName) Values('wpzwpz',1234,'wang')
Insert [User](InviteName,InviteNumber,UserName,[Password]) Values('wpzwpz',1234,'管理员','dsaw')
Insert [User](InviteName,InviteNumber,UserName,[Password]) Values('wpzwpz',1234,'wang','dsaw')
Insert [User](InviteName,InviteNumber,UserName) Values('wpzwpz',1234,'wang')
Insert [User](InviteName,InviteNumber,UserName,[Password]) Values('wpzwpz',1234,'17bang','dsaw')
Insert [User](InviteName,InviteNumber,UserName,[Password]) Values('wpzwpz',1234,'wang','dsaw')
Insert [User](InviteName,InviteNumber,UserName) Values('管理员',1234,'管理员')
Insert [User](InviteName,InviteNumber,UserName) Values('wpzwpz',1234,'wang')
Insert [User](InviteName,InviteNumber,UserName) Values('wpzwpz',1234,'wang')
Insert [User](InviteName,InviteNumber,UserName,[Password]) Values('wpzwpz',1234,'wang','dsaw')
Insert [User](InviteName,InviteNumber,UserName) Values('wpzwpz',1234,'wang')
Insert [User](InviteName,InviteNumber,UserName,[Password]) Values('wpzwpz',1234,'wang','dsaw')
Insert [User](InviteName,InviteNumber,UserName) Values('管理员',1234,'17bang')


Select * From [User]
--在User表中：
--1.查找没有录入密码的用户
--2.删除用户名（UserName）中包含“管理员”或者“17bang”字样的用户

select * From [User] Where [Password] Is not Null

Begin Transaction
Declare @Condition_One Nchar(6) Set @Condition_One = '管理员' 
Declare @Condition_Two char(6) Set @Condition_Two = '17bang'
Delete [User] Where [UserName] = ( @Condition_One )
Delete [User] Where [UserName] = ( @Condition_Two )

--------------------------------------------------------------------------------
--Belong OF Problem

Use [17bang]

Create Table Problem(
	[Id] Int Identity Constraint PK_User_Id  Primary key,
	[Title] Nchar(20) Not Null,
	[Content] Ntext Not Null,
	[Reward] SmallInt Constraint CK_User_Reward Check(Reward>0) Constraint DF_User_Reward Default 0,
	[PublishTime] Datetime Not Null,
);

Alter Table Problem
--Alter Column Content Ntext Null
Alter Column Title Nvarchar(20) Not Null

Insert Problem(Title,Reward,PublishTime) Values('Day Is So buzy!',3,'2020/5/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',15,'2012/5/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',53,'2014/5/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',23,'2019/5/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',36,'2019/10/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',12,'2020/3/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',5,'2020/5/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',23,'2015/5/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',4,'2022/5/12 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',19,'2019/10/10 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',20,'2019/10/11 11:49:36')
insert problem(title,reward,publishtime) values('day is so buzy!!!',1,'2022/5/12 11:49:36')
--在Problem表中：
--1.给所有悬赏（Reward）大于10的求助标题加前缀：【推荐】
--2.给所有悬赏大于20且发布时间（Created）在2019年10月10日之后的求助标题加前缀：【加急】
--3.删除所有标题以中括号【】开头（无论其中有什么内容）的求助

select * from Problem

Begin Transaction
Declare @Recommend Nvarchar(10) Set @Recommend = N'【推荐】'
Update Problem Set Title = @Recommend+Title 
Where Reward>10


Begin Transaction
Declare @Buzy Nvarchar(10) Set @Buzy = '【加急】'
Update Problem Set Title = @Buzy +Title 
Where Reward>20 And PublishTime > 2019/10/10


--.删除所有标题以中括号【】开头（无论其中有什么内容）的求助
Begin Transaction
Delete Problem Where(title like '【%】%')

Begin Transaction
Update Problem Set Title = N'123'
commit

---------------------------------------------------------------------------------------
--在Keyword表中：
--1.找出所有被使用次数（Used）大于10小于50的关键字名称（Name）
--2.如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1
--3.删除所有使用次数为奇数的Keyword
Use [17bang]

Create Table Keyword(
	[Id] Int IDentity,
	[Name] Nvarchar(20)Not Null,
	[Used] TinyInt,
);

Insert [Keyword]([Name],[Used]) Values(N'C#',120)
Insert Keyword([Name],[Used]) Values(N'SQL',12)
Insert Keyword([Name]) Values(N'JS')
Insert Keyword([Name],[Used]) Values(N'asd#',0)
Insert Keyword([Name],[Used]) Values(N'Casd#',24)
Insert Keyword([Name],[Used]) Values(N'C#cas',40)
Insert Keyword([Name],[Used]) Values(N'Caw#',15)
Insert Keyword([Name],[Used]) Values(N'Cxzc#',9)
Insert Keyword([Name],[Used]) Values(N'Cvddd#',78)
Insert Keyword([Name],[Used]) Values(N'Cddds#',69)
Insert Keyword([Name],[Used]) Values(N'Caaa#',52)
Insert Keyword([Name],[Used]) Values(N'ggwC#',50)
Insert Keyword([Name],[Used]) Values(N'Csad#',33)
Insert Keyword([Name],[Used]) Values(N'Cwsx#',1)
Insert Keyword([Name],[Used]) Values(N'Cdawq#',46)


Select * From Keyword

--1.找出所有被使用次数（Used）大于10小于50的关键字名称（Name）
--2.如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1
--3.删除所有使用次数为奇数的Keyword

--Select * From [Keyword] 
--Where Used>10 and Used<50

--Begin Truncate

Begin Transaction
Select * From [Keyword] 
Update [Keyword] Set [Used]=1
Where([Used]<=0) Or ([Used] is null) Or ([Used]>100)
Commit
Rollback

Select * From [Keyword] 

Begin Transaction
Delete [Keyword] Where [Used]%2=1