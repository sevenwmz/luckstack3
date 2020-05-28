--作业：
--1.以Problem中的数据为基础，使用SELECT INTO，新建一个Author和Reward都没有NULL值的新表
--：NewProblem （把原Problem里Author或Reward为NULL值的数据删掉）
Select * From Problem

Insert Problem(Title,PublishTime) Values(N'prepare into New Problem','2020/5/19')
Insert Problem(Title,PublishTime) Values(N'1prepare into New Problem','2020/5/19')
Insert Problem(Title,PublishTime) Values(N'2prepare into New Problem','2020/5/19')
Insert Problem(Title,PublishTime) Values(N'3prepare into New Problem','2020/5/19')


Select * Into NewProblem From Problem 
Where Reward Is Not Null 

Select * From NewProblem

Begin Transaction
Delete Problem Where Reward is null
Rollback

Select * From Problem

--2.使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中

SET IDENTITY_INSERT dbo.Newproblem ON

Begin Transaction
Insert Newproblem(Id, PublishTime,Title,Content,Reward,AuthorId)
Select Id, PublishTime ,Title,Content,Reward,AuthorId
From Problem
Where Reward Is null
rollback


Select * From NewProblem
Select * From Problem
Delete NewProblem Where Reward Is Null

SET IDENTITY_INSERT dbo.Newproblem Off

--3.使用OVER，统计出求助里每个Author悬赏值的平均值、最大值和最小值，
--然后用新表ProblemStatus存放上述数据

Select * From Problem


Select 
DIstinct Author,
Max(Reward)Over(Partition By Author ) As [Max] ,
Avg(Reward)Over(Partition By Author) As [Avg],
MIN(Reward)Over(Partition By Author) As [Min]
Into ProblemStatus
From Problem

Select * From  ProblemStatus


--4.使用CASE...WHEN，颠倒Problem中的NeedRemote（以前是1的，现在变成0；以前是0的，现在变成1）
Select * From Problem

Alter Table Problem
Add NeedRemote Bit 

Update Problem Set NeedRemote = 0 Where Id%2=0

Select * From Problem
Select * ,
Case NeedRemote
	When 1 Then 0
	When 0 Then 1
End
From Problem

--5.使用CASE...WHEN，用一条SQL语句，完成SQL入门-7：函数中第4题第3小题
--有一些标题以test、[test]后者Test-开头的求助，找打他们并把这些前缀都换成大写
Select * From Problem
Select * ,
Case 	
	When Title Like N'test%' Then ('TEST' + SUBSTRING(title,5,50))
	When Title Like N'_test%' Then (N'[TEST]'+ SUBSTRING(title,7,50))
	When Title Like N'Test-%' Then (N'TEST-'+ SUBSTRING(title,8,50))
	else Title
End
From Problem

Update Problem Set Title = N'test王test胖子test' Where Id = 63

