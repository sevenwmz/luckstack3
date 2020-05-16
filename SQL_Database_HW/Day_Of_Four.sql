
--Create Table Problem(
--	[Id]Int Identity,
--	[Title] Nvarchar(20) Not Null,
--	[Content] Ntext Not Null,
--	[NeedRemoteHelp] Bit Constraint DF_Problem_NeedRemoteHelp Default 1,
--	[Reward] SmallInt,
--	[PublishDateTime] DateTime
--);
----在Problem表的基础上：
----1.删除Title列，再添加Title列
--Alter Table Problem
----Drop Column Title
----Add Title Nvarchar(20)
--Alter Column Title Nvarchar(20) Not Null


----2.将Content的类型更改为NTEXT或NVARCHAR(MAX)
--Alter Table Problem
----Drop Column Content
--Add Content Nvarchar(Max) Not Null
----3.为NeedRemoteHelp添加NOT NULL约束，再删除NeedRemoteHelp上NOT NULL的约束
--Alter Table Problem
----Alter Column NeedRemoteHelp Bit Not Null
--Alter Column NeedRemoteHelp Bit Null


----4.添加自定义约束，让Reward不能小于10
--Alter Table Problem
--Add Constraint CK_Problem_Reward Check(Reward>10)
----5.备份TProblem表，再用两种方式删除/恢复TProblem中所有数据
--BackUp Database TProblem To Disk = 'F:\123.bak'
--Restore TProblem From Disk = 'F:\123.bak'

--Select * From TProblem
--Use SevenTest
--Create Database TProblem

--Begin Transaction
----Delete TProblem

----6.删除TProblem表本身（含表结构和行数据）


----在User表上的基础上：
----1.添加Id列，让Id成为主键
--Create Table [User](
--	[Id] Int ,
--	[UserName]Nvarchar(20),
--	[Password] Nvarchar(10)
--);
----2.添加约束，让UserName不能重复
--Alter Table [User]
----ALter Column [Id]Int Not Null
----Add Constraint PK_User_Id Primary Key(Id)
--Add COnstraint UQ_USer_UserName Unique(Username)
----3.将所有User的Password改为：'1234'
--Update [User] Set [Password] = '1234'
----观察一起帮的关键字功能，新建Keyword表，要求带一个自增的主键Id，起始值为10，步长为5。

--Create Table Keyword(
--	[Id] Int Identity(10,5)
--);

---------------------------------------------------------------------------------------------------

--作业：
--在User表中：【已完成】
--1.查找没有录入密码的用户

Insert [User](Id,UserName,[Password]) Values(1,N'17bang','12345');
Insert [User](Id,UserName) Values(2,N'dsagas');
Insert [User](Id,UserName,[Password]) Values(3,N'管理员','1234tw5');
Insert [User](Id,UserName) Values(4,N'wp12zwpz');
Insert [User](Id,UserName,[Password]) Values(5,N'wp125zwpz','1231345');
Insert [User](Id,UserName,[Password]) Values(6,N'wp36zwpz','12az345');
Insert [User](Id,UserName) Values(7,N'管理员');

Select * From [User]
Select * From [User] Where [Password] Is Not Null

--2.删除用户名（UserName）中包含“管理员”或者“17bang”字样的用户
Begin Transaction
Delete [User] Where [UserName] = N'管理员' Or [UserName] = N'17bang'
Select * From [User]
--在Problem表中：【已完成】
--1.给所有悬赏（Reward）大于10的求助标题加前缀：【推荐】

Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'1_Title',N'1_Content',10,'2015/2/9')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'2_Title',N'2_Content',20,'2019/2/9')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'3_Title',N'3_Content',30,'2010/2/9')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'4_Title',N'4_Content',14,'2020/2/9')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'5_Title',N'5_Content',50,'2019/12/9')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'6_Title',N'6_Content',110,'2019/12/19')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'7_Title',N'7_Content',17,'2020/2/19')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'8_Title',N'8_Content',30,'2015/2/9')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'9_Title',N'8_Content',40,'2020/2/9')
Insert Problem(Title,Content,Reward,PublishDateTime) Values(N'10_Title',N'10_Content',50,'2025/2/9')


Update Problem Set Title = N'【推荐】' + title
Where Reward>10 

Select * From Problem

--2.给所有悬赏大于20且发布时间（Created）在2019年10月10日之后的求助标题加前缀：【加急】
Declare @Buzy Nvarchar(20) = N'【加急】'
Update Problem Set Title = @Buzy + Title
Where PublishDateTime > '2019/10/10'

--3.删除所有标题以中括号【】开头（无论其中有什么内容）的求助
Begin Transaction
Delete Problem Where Title Like N'【%】%'
RollBack
--在Keyword表中：
--1.找出所有被使用次数（Used）大于10小于50的关键字名称（Name）
Select * From Keyword

Select * From Keyword 
Where Used > 10 And Used<50


--Alter Table Keyword
--Add Used SmallInt
--Add [Name] Nvarchar(20)

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


--2.如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1
Begin Transaction
Update Keyword Set Used = 1
Where Used<=0 Or Used Is Null Or Used>100
RollBack
Select * From Keyword

--3.删除所有使用次数为奇数的Keyword
Begin Transaction
Delete Keyword Where Used%2=1
RollBack
--注意，上述作业需要自己插入数据进行测试。

