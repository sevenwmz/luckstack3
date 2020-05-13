--作业：
--在Problem中插入不同作者（Author）不同悬赏（Reward）的若干条数据，以便能完成以下操作： 
--1.查找出Author为“飞哥”的、Reward最多的3条求助
--2.查找Title中第5个起，字符不为“数据库”的求助 
--3.所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序
--4.查找并统计出每个作者的：求助数量、悬赏总金额和平均值 



Select * From Problem

--Alter Table Problem
----Add Author Nvarchar(10)

Begin Transaction
Update Problem Set Title = N'王胖子的数据库'
Where Reward>1 And Reward<5

Begin Transaction
Update Problem Set Reward +=12
Where Reward>1 And Reward<5

Insert Problem(Title, Reward,PublishTime) Values(N'wwwwww的数据库',34,'2019/3/15')
Insert Problem(Title,Reward,PublishTime) Values(N'王数据库',23,'2023/3/25')
Insert Problem(Title,Reward,PublishTime) Values(N'王胖子的数据库',31,'2019/7/25')
Insert Problem(Title,Reward,PublishTime) Values(N'胖子的据库',14,'2015/2/15')
Insert Problem(Title,Reward,PublishTime) Values(N'王胖子的据库',43,'2014/1/15')
Insert Problem(Title,Reward,PublishTime) Values(N'王胖子的数据',24,'2011/4/15')
Insert Problem(Title,Reward,PublishTime) Values(N'大胖飞的数据库',21,'2011/3/15')


Begin Transaction
Update Problem Set Author = N'飞哥'
Where PublishTime<'2019/2/15'

Begin Transaction
Update Problem Set Author = N'wpz'
Where  Id>2 And Id<30 And Id%2=0
-----------------------------------------------------------------------

--1.查找出Author为“飞哥”的、Reward最多的3条求助
Begin Transaction 
Select top 3 Title From Problem
where Author=N'飞哥' 
Order By Reward desc
Commit


--2.查找Title中第5个起，字符不为“数据库”的求助 

Begin Transaction 
Select Title From Problem
Where (title Not Like N'_____数据库%' )


--3.所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序
--select Author AS N'作者' ,Reward As N'悬赏' From Problem
--Group By Author,Reward
--Order By Reward Desc

select Author AS N'作者' , Reward  As N'悬赏' From Problem
Order By Author desc, Reward Desc


Select * From Problem

--4.查找并统计出每个作者的：求助数量、悬赏总金额和平均值 
Select Author As N'作者', Count(Title) As N'求助数量',
						  SUM(Reward) As N'悬赏金额',
						  AVG(Reward) As N'平均值' 
						  From Problem 
						  Group By Author


