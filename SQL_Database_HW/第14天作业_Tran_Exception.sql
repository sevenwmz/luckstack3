Select * From [User]

Create Table HelpMoney(
	[Id] Int Primary Key Identity,
	[BMoney] Int Null Constraint CK_17bang_HelpMoney_BMoney Check(BMoney>0)
);

ALter Table [User]
Add BMoneyId Int Constraint FK_User_HelpMoney_id 
Foreign Key References HelpMoney(Id)

Select * From HelpMoney
Insert HelpMoney Values(50)
Insert HelpMoney Values(50)
Insert HelpMoney Values(50)

--作业：
--用户（Reigister）发布一篇悬赏币若干的求助（Problem），
--他的帮帮币（BMoney）也会相应减少，
--但他的帮帮币总额不能少于0分：
--请综合使用TRY...CATCH和事务完成上述需求。
	Select p.Id,p.Title,p.Reward,u.UserName,h.BMoney
	From Problem p
	Join [User] u
	On p.AuthorId = u.Id
	Join HelpMoney h
	On u.BMoneyId = h.Id
-----------------------Can't Discount------------------------------------------
Begin Try
	Begin Tran
	Insert Problem(Title,PublishTime,AuthorId,Reward) 
	Values(N'For14DayHW','2020/5/24',16,60)
	Update HelpMoney Set BMoney -= 60 Where Id = 1 
	Commit
End Try
Begin Catch
	Rollback
End Catch
-----------------------Can Discount------------------------------------------
Begin Try
	Begin Tran
	Insert Problem(Title,PublishTime,AuthorId,Reward) 
	Values(N'For14DayHW','2020/5/24',16,6)
	Update HelpMoney Set BMoney -= 6 Where Id = 1 
	Commit
End Try
Begin Catch
		Rollback
End Catch
Select * From Problem
Select * From HelpMoney

Print @@TranCount

Begin Try
	Begin Tran
	Update HelpMoney Set BMoney -=112 Where Id = 1
	Commit
End Try
Begin Catch
	RollBack
End Catch

