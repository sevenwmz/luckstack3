--作业： 
--1.利用循环，打印如下所示的等腰三角形：
Declare @number Int = 1
Declare @add Int = 1
While @number<=7
Begin
Declare @tempVariable varchar(50) =''
Set @tempVariable+=Space(7-@add)
Set @add+=1
Declare @Compear Int =1;
	While @Compear<=@number
	Begin
		Set @tempVariable+=cast(@number as varchar)
		Set @Compear+=1
	End
print @tempVariable Set @number+=2 
End

--1.定义一个函数GetBigger(INT a, INT b)，可以取a和b之间的更大的一个值
Go
Create Function GetBigger(@a Int, @b Int)
Returns Int
Begin
	IF @a < @b  Return @b
	else if @a > @b Return @a
	Return 0
End
Go
Print dbo.GetBigger(3,3)
--2.创建一个单行表值函数GetLatestPublish(INT n)，返回最近发布的n篇求助
Go
Create Function GetLatestPublish(@n INT)
Returns Table
Return Select Top (@n) * from Problem Order By PublishTime desc
GO
Select * From GetLatestPublish(3)

--3.创建一个多行表值函数GetByReward(INT n, BIT asc)，如果asc为1，
--返回悬赏最少的n位同学；否则，返回悬赏最多的n位同学。
Select * From Problem
Go
Create Function GetByReward( @n INT,@asc BIT)
Returns @t Table([Name] Nvarchar(20))
Begin
	IF @asc = 1 
	Insert @t Select Top (@n) Title From Problem  Order By Reward Asc 
	Else
	Insert @t Select Top (@n) Title From Problem  Order By Reward Desc 
	Return
End
Go
Select * From Problem

--4.在表TProblem中： 
--找出所有周末发布的求助（添加CreateTime列，如果还没有的话）
Select * From Problem
where datepart(weekday,PublishTime) between 6 and 8

Update Problem Set PublishTime = '2020/5/16' Where Id = 68
Update Problem Set PublishTime = '2020/5/17' Where Id = 69

Insert Problem(Title,Reward,PublishTime,Author) Values(N'test的作业',49,'2019/6/15','wpz')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'[test]的作业',49,'2019/6/15','wpz')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'test的作业',49,'2019/6/15','wpz')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'[test]的作业',49,'2019/6/15','wpz')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'test的作业',49,'2019/6/15','wpz')
Insert Problem(Title,Reward,PublishTime,Author) Values(N'Test-的作业',49,'2019/6/15','wpz')

Select * From Problem


--找出每个作者所有求助悬赏的平均值，精确到小数点后两位 
Select Author ,Round(AVG(Reward),3) From Problem
Group By Author

--有一些标题以test、[test]或者Test-开头的求助，找打他们并把这些前缀都换成大写
Select * From Problem
Select Replace(Title,'test','TEXT'),* From Problem 
--Where Title Like 'test%' Or Title Like '_test%' Or Title Like 'Test-%'

Begin Transaction
Update Problem Set Title = N'test的ypz作业' Where Id = 63


