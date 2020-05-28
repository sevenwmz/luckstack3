--作业：
--1.联表查出求助的标题和作者用户名
Select * From Problem p
Full Join [User] u
On p.AuthorId = u.Id

--2.查找并删除从未发布过求助的用户
Begin Transaction
Delete [User] 
Where Id in
(
Select u.Id From [User] u 
Left Join Problem p
On p.AuthorId = u.Id
Where u.Id Not in 
(select AuthorId From Problem Where p.AuthorId = u.Id)
)
Rollback

Select * From [User]

Begin Tran
--Delete [User]
--From [User] u Join Problem p
--On u.Id = p.AuthorId
--Where 

--3.用一句SELECT显示出用户和他的邀请人用户名
Select * From [User] uu
Join [User] iu
On uu.Id = iu.InviteById

Select * From [User]

--4.17bang的关键字有“一级”“二级”和其他“普通级”的区别：
--1.请在表Keyword中添加一个字段，记录这种关系
Select * from Keyword
Alter Table Keyword
Add KeywordId Int Constraint FK_Keyword_Keyword_KeywordId Foreign Key References Keyword(Id)

--2.然后用一个SELECT语句查出所有普通关键字的上一级、以及上上一级的关键字名称，比如：


Select 
k.Name N'普通关键字',
sk.Name N'上一级',
fk.Name N'上上一级'
From Keyword k
Join Keyword sk
On k.KeywordId = sk.Id
Join Keyword fk
On sk.KeywordId = fk.Id


--1.17bang中除了求助（Problem），还有意见建议（Suggest）和文章（Article），
--他们都包含Title、Content、PublishTime和Auhthor四个字段，但是：
--1.建议和文章没有悬赏（Reward）
Select Id,Title,Content,PublishTime,AuthorId Into Suggest From Problem
Select Id,Title,Content,PublishTime,AuthorId Into Article From Problem

Select * From Suggest
Select * From Article
Select * From Problem
--2.建议多一个类型：Kind NVARCHAR(20)）
Alter Table Suggest
Add Constraint FK_Suggest_Kind_Kind Foreign Key(Kind) References Kind(Name)

Create Table Kind(
	[name] Nvarchar(20) Primary Key
);

Insert kind(name) Values(N'未处理')
Insert kind(name) Values(N'Bug')
Insert kind(name) Values(N'建议')
Insert kind(name) Values(N'完成')
Insert kind(name) Values(N'全部')

Select * From Suggest

--3.文章多一个分类：Category INT）
Create Table Category(
	[Id] Int Primary Key,
	[name] Nvarchar(50)
);

Insert Category(Id,name) Values(1,N'Category_1')
Insert Category(Id,name) Values(2,N'Category_2')
Insert Category(Id,name) Values(3,N'Category_3')
Insert Category(Id,name) Values(4,N'Category_4')
Insert Category(Id,name) Values(5,N'Category_5')

Select * From Article
Alter Table Article

Add CategoryId Int

Select * From Article
--2.请按上述描述建表。然后，用一个SQL语句按显示某用户发表的求助、
--建议和文章的Title、Content，并按PublishTime降序排列

Select 
p.Title ProblemTitle,p.Content ProblemContent,p.PublishTime ProblemPublishTime,
a.Title AritcleTitle,a.Content AritcleContent,a.PublishTime AritclePublishTime,
s.Title SuggestTitle,s.Content SuggestContent,s.PublishTime SuggestPublishTime,
u.Id,u.UserName
From Problem p
Left Join Article a On p.AuthorId = a.AuthorId
Left Join Suggest s On a.AuthorId = s.AuthorId
Left Join [User] u On s.AuthorId = u.Id
Where u.Id = 16
Order By p.PublishTime desc


Select * From Problem

Select Title,Content,PublishTime,AuthorId From Problem
Union All
Select Title,Content,PublishTime,AuthorId From Suggest
Union All
Select Title,Content,PublishTime,AuthorId From Article
Where AuthorId = 16
Order By PublishTime Desc