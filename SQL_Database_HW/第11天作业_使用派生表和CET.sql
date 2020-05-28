--作业：
--分别使用派生表和CET，查询求助表
--（表中只有一列整体的发布时间，没有年月的列），以获得：


--    一起帮每月各发布了求助多少篇

Select year(PublishTime)[Year],Month(publishtime)[Month],Count(Title)[Problem] From(
	Select PublishTime,Title
	From Problem 
) OP
Group By PublishTime



Select * From Problem Order By PublishTime

Go

With MonthedProblem AS(
	Select PublishTime,Title From Problem
)
Select year(PublishTime)[Year],Month(publishtime)[Month],Count(Title)[Problem] From MonthedProblem
Group By PublishTime
Go

--每月发布的求助中，悬赏最多的3篇
Select * From(
	Select PublishTime,Reward ,ROW_NUMBER() 
	Over(Partition By year(PublishTime),Month(publishtime)Order By Reward Desc) As Rid
	From Problem
) Top3Reward
Where Top3Reward.Rid <= 3

Select * From Problem Order By PublishTime

Go
With Top3Reward As(
	Select PublishTime,Reward ,ROW_NUMBER() 
	Over(Partition By year(PublishTime),Month(publishtime)Order By Reward Desc) As Rid
	From Problem
)
Select PublishTime,Reward From Top3Reward
Where Top3Reward.Rid <= 3
Go
--每个作者，每月发布的，悬赏最多的3篇
Select * From(
	Select Author,PublishTime,Reward, ROW_NUMBER()
	Over(Partition By Author,year(PublishTime),Month(publishtime) Order By Reward Desc,
	Month(publishtime) desc) As Rid
	From Problem
)RichAuthor
Where RichAuthor.Rid <=3
Select * From Problem Order By Reward

Go
With AuthorProblemTop3 As(
	Select Author,PublishTime,Reward, ROW_NUMBER()
	Over(Partition By Author,year(PublishTime),Month(publishtime) Order By Reward Desc,
	Month(publishtime) desc) As Rid
	From Problem 
)
Select PublishTime,Reward,Author From AuthorProblemTop3
Where AuthorProblemTop3.Rid <=3
GO
--分别按发布时间和悬赏数量进行分页查询的结果   
Select Top 3 * From Problem 
Where Id not In(
	Select top 3 Id
	From Problem
)
Select* From Problem  Order By PublishTime desc

Select * From (
	Select ROW_NUMBER() Over(Order By Reward Desc) As Rid,*From Problem
) R
Where R.Reward Between 1 And 3 



