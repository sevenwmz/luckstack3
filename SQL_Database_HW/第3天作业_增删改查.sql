--作业：
--在Problem表的基础上：
--1.删除Title列，再添加Title列
--2.将Content的类型更改为NTEXT或NVARCHAR(MAX)
--3.为NeedRemoteHelp添加NOT NULL约束，再删除NeedRemoteHelp上NOT NULL的约束
--4.添加自定义约束，让Reward不能小于10
--5.备份TProblem表，再用两种方式删除/恢复TProblem中所有数据
--6.删除TProblem表本身（含表结构和行数据）
--在User表上的基础上：
--1.添加Id列，让Id成为主键
--2.添加约束，让UserName不能重复
--3.将所有User的Password改为：'1234'
--观察一起帮的关键字功能，新建Keyword表，要求带一个自增的主键Id，起始值为10，步长为5。


Select * From Keyword

Insert Keyword(Name) Values('2331')
Insert Keyword(Name) Values('2331')
Insert Keyword(Name) Values('2331')

Alter Table Keyword
Add [Name] Nvarchar(20)

Insert Keyword(Id) Values(10)
Insert Keyword(Id) Values(101)
Insert Keyword(Id) Values(102)

Create Table Keyword(
	[Id] Int Identity(10,5)
);
------------------------------------------------------

Select * From [User]

Update [User] Set [Password] = '1234'


Insert [User](Id,[Password]) Values(1,'eqas2d')
Insert [User](Id,[UserName],[Password]) Values(2,'wsz21c','eqa1231sd')
Insert [User](Id,[UserName],[Password]) Values(3,'wszc','eqa31sd')
Insert [User](Id,[UserName],[Password]) Values(4,'w5szc','eq22asd')
Insert [User](Id,[UserName],[Password]) Values(5,'w2szc','eqa1sd')
Insert [User](Id,[UserName],[Password]) Values(6,'ws6zc','eqaq2sd')
Insert [User](Id,[UserName],[Password]) Values(7,'wsz4c','eqewd')
Insert [User](Id,[UserName],[Password]) Values(8,'w1szc','ewqqasd')
Insert [User](Id,[UserName],[Password]) Values(9,'ws22zc','eqawqesd')
Insert [User](Id,[UserName],[Password]) Values(10,'ws34zc','eqqasd')

--Alter Table [User]
--Add Constraint UQ_USER_UserName Unique(UserName)
--Alter Column Id Int Not Null
--Add Constraint PK_USER_ID Primary Key(Id)

--Create Table [User](
--	[Id] Int,
--	[UserName] Nvarchar(10),
--	[Password] varchar(10)
--);

--Use TProblem

------------------------------------------------------------------------


--BackUp database TProblem To disk = 'G:\1231234.bak'
--Restore Database TProblem From Disk = 'G:\1231234.bak'

--use SevenTest

--Drop Database TProblem

--Begin Transaction


--commit
--rollback
--Delete Tproblem

--Select * From TProblem

--Create Database TProblem

--Create Table Tproblem(
--[Id]Int,
--)
--Alter Table Problem
--Add Constraint CK_Problem_Reward Check(Reward>10)

--在Problem表的基础上：
--1.删除Title列，再添加Title列
--2.将Content的类型更改为NTEXT或NVARCHAR(MAX)
--3.为NeedRemoteHelp添加NOT NULL约束，再删除NeedRemoteHelp上NOT NULL的约束
--4.添加自定义约束，让Reward不能小于10
--5.备份TProblem表，再用两种方式删除/恢复TProblem中所有数据
--6.删除TProblem表本身（含表结构和行数据）

--Alter Column NeedRemoteHelp Bit Null

--Alter Column NeedRemoteHelp Bit Not Null
--Drop column Content
--Add Content Nvarchar(max)

--Add Title Nvarchar(20)

--Drop Column Title

--use  SevenTest
--Create Table Problem(
--	[Id] Int ,
--	[Title] Nvarchar(20),
--	[Content] Ntext,
--	[NeedRemoteHelp] Bit,
--);

--select * from Problem