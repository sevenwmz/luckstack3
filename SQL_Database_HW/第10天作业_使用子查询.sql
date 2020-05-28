--作业：
--使用子查询：
--1.删除悬赏相同的求助（只要相同的全部删除一个不留）
DELETE KeywordToProblem

Begin Transaction
Delete Problem
Where Reward IN 
(Select Reward From Problem 
Group By Reward HAVING  Count(Reward)>1)
RollBack

Select * From Problem

--2.删除每个作者悬赏最低的求助
Select * From Problem Order By Author
GO
Begin Transaction
Delete Problem Where Id In(
	Select Id From problem Op
	Where Reward = 
	(
		Select Min(Reward) From Problem Ip
		Where op.Author = ip.Author
	)
)
GO

--3.找到从未成为邀请人的用户

Select * From [User] 
Where Id Not In 
(Select InviteById From [User]
Where Id <> InviteById)

ALter Table [User]
Add InviteById Int Constraint FK_User_User_InviteById 
Foreign Key References [User](Id)
Update [User] Set InviteById = 16 Where Id>16
Select * From [user]
--4.查出所有发布一篇以上（不含一篇）文章的用户信息
Select * From Problem

Select Distinct Author From Problem
Where Author In (
Select  Author From Problem
Group By Author
Having Count(Title)>1
)

--5.为求助添加一个发布时间（PublishTime），查找每个作者最近发布的一篇求助
Select * From Problem

Select * From Problem OP
Where PublishTime =(
Select Max(PublishTime) From Problem [IP]
Where OP.Author = IP.Author
)

--6.查出每一篇求助的悬赏都大于5个帮帮币的作者
Select Distinct Author From Problem OP
Where Author In(
	Select Author From Problem IP
	Group By Author
	Having Min(Reward)>5
)

Select * From Problem  Order By Reward

--查出每个作者悬赏最多的3篇求助
