--作业：
--在Problem中插入不同作者（Author）不同悬赏（Reward）的若干条数据，以便能完成以下操作： 
--3.所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序
--4.查找并统计出每个作者的：求助数量、悬赏总金额和平均值 



Select * From Problem

--Alter Table Problem
----Add Author Nvarchar(10)


--1.查找出Author为“飞哥”的、Reward最多的3条求助
Begin Transaction
Update Problem Set Title = N'王胖子的数据库'
Where Reward>1 And Reward<5

Begin Transaction
Update Problem Set Reward +=12
Where Reward>1 And Reward<5


--2.查找Title中第5个起，字符不为“数据库”的求助 
Begin Transaction
Update Problem Set Author = N'飞哥'
Where PublishTime<'2019/2/15'


-----------------------------------------------------------------------

--1.查找出Author为“飞哥”的、Reward最多的3条求助
Select top 3 Title From Problem
where Author=N'飞哥' 
Order By Reward desc

--2.查找Title中第5个起，字符不为“数据库”的求助 
Select Title From Problem
Where (title Not Like N'_____数据库%' )



--3.所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序
select Author AS N'作者' , Reward  As N'悬赏' From Problem
Order By Author desc, Reward Desc

--4.查找并统计出每个作者的：求助数量、悬赏总金额和平均值 
Select Author As N'作者', Count(Title) As N'求助数量',
						  SUM(Reward) As N'悬赏金额',
						  AVG(Reward) As N'平均值' 
						  From Problem 
						  Group By Author

Select * From Problem
Begin Transaction
Update Problem Set Author = N'wpz'
Where  Id>2 And Id<30 And Id%2=0

Insert  Problem(Title,Reward,PublishTime,Author)Values(N'wwwwww的数据库',34,'2019/3/15')




Insert Problem(Title, Reward,PublishTime,Author) Values(N'wwwwww的数据库',34,'2019/3/15','atai')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'王数据库',23,'2023/3/25',N'飞哥')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'王胖子的数据库',31,'2019/7/25','wpz')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'胖子的据库',14,'2015/2/15',N'飞哥')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'王胖子的据库',43,'2014/1/15',N'飞哥')
Insert Problem(Title,Reward,PublishTime) Values(N'王胖子的数据',24,'2011/4/15')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'大胖飞的1数据库',31,'2011/3/15','atai')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'大胖飞的数据库',24,'2019/4/15','wpz')
Insert Problem(Title,Reward,PublishTime) Values(N'大胖飞的数据库',21,'2011/3/15')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'大胖飞的数2据库',26,'2011/5/15','atai')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'大胖飞的数据3库',27,'2017/7/15',N'飞哥')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'大胖飞的数据库4',17,'2019/3/15','wpz')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'5大胖飞的数据库',33,'2014/1/15','atai')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'胖飞的数据库',12,'2013/3/19',N'飞哥')