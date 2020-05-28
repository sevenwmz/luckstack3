--作业：
--1.创建求助的应答表 Response(Id, Content, AuthorId, ProblemId, CreateTime) 
Create Table Response(
	[Id] Int Primary Key Identity,
	[Content] Ntext,
	[CreateTime] Datetime,
	[AuthorId] Int Constraint FK_Response_User_AuthorId Foreign Key References [User](Id),
	[ProblemId] Int Constraint FK_Response_Problem_AuthorId Foreign Key References [Problem](Id),
);
Alter Table Response
Add AuthorName Nvarchar(50)

--2.然后生成一个视图 VResponse(ResponseId, Content, ResponseAuthorId
--，ReponseAuthorName, ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)，
--要求该视图： 
--1.能展示应答作者的用户名、应答对应求助的标题和作者用户名 （JOIN） 
Go
Alter View VResponse (ResponseId, Content, ResponseAuthorId,ReponseAuthorName,
ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)
As
Select 
r.Id ResponseId,
r.Content Content, 
r.AuthorId ResponseAuthorId, 
r.AuthorName ReponseAuthorName ,
p.Id ProblemId,
p.AuthorId ProblemAuthorName,
p.Title ProblemTitle,
p.PublishTime CreateTime
From Response r
Join TProblem p
On r.ProblemId = p.Id 
Join [User] u
On p.AuthorId = u.Id
GO

Select * From VResponse
Select * Into TProblem  From Problem
Alter Table TProblem
Drop Column Author


--2.只显示求助悬赏值大于5的数据 （JOIN）
Go
Alter View VResponse (ResponseId, Content, ResponseAuthorId,ReponseAuthorName,
ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)
As
Select 
r.Id ResponseId,
r.Content Content, 
r.AuthorId ResponseAuthorId, 
r.AuthorName ReponseAuthorName ,
p.Id ProblemId,
p.AuthorId ProblemAuthorName,
p.Title ProblemTitle,
p.PublishTime CreateTime
From Response r
Join TProblem p
On r.ProblemId = p.Id 
Join [User] u
On p.AuthorId = u.Id

Where Reward>5
With Check Option


--3.已被加密 
GO
Alter View VResponse (ResponseId, Content, ResponseAuthorId,ReponseAuthorName,
ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)
With Encryption
As
Select 
r.Id ResponseId,
r.Content Content, 
r.AuthorId ResponseAuthorId, 
r.AuthorName ReponseAuthorName ,
p.Id ProblemId,
p.AuthorId ProblemAuthorName,
p.Title ProblemTitle,
p.PublishTime CreateTime
From Response r
Join TProblem p
On r.ProblemId = p.Id 
Join [User] u
On p.AuthorId = u.Id
--4.保证其使用的基表结构无法更改 
Go
Alter View VResponse (ResponseId, Content, ResponseAuthorId,ReponseAuthorName,
ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)
With SchemaBinding
As
Select 
r.Id ResponseId,
r.Content Content, 
r.AuthorId ResponseAuthorId, 
r.AuthorName ReponseAuthorName ,
p.Id ProblemId,
p.AuthorId ProblemAuthorName,
p.Title ProblemTitle,
p.PublishTime CreateTime
From dbo.Response r
Join dbo.TProblem p
On r.ProblemId = p.Id 
Join dbo.[User] u
On p.AuthorId = u.Id
Go
--3.演示：在VResponse中插入一条数据，却不能在视图中显示
Go
Alter View VResponse (ResponseId, Content, ResponseAuthorId,ReponseAuthorName,
ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)
As
Select 
r.Id ResponseId,
r.Content Content, 
r.AuthorId ResponseAuthorId, 
r.AuthorName ReponseAuthorName ,
p.Id ProblemId,
p.AuthorId ProblemAuthorName,
p.Title ProblemTitle,
p.PublishTime CreateTime
From Response r
Full Join TProblem p
On r.ProblemId = p.Id 
Full Join [User] u
On p.AuthorId = u.Id
Where p.PublishTime > '2000/1/1'
GO
Insert VResponse(CreateTime) Values('2000/1/1')

Insert VResponse(CreateTime) Values('2001/1/1')

Select * From Vresponse
--4.修改Response，让其能避免上述情形 
Go
Alter View VResponse (ResponseId, Content, ResponseAuthorId,ReponseAuthorName,
ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)
As
Select 
r.Id ResponseId,
r.Content Content, 
r.AuthorId ResponseAuthorId, 
r.AuthorName ReponseAuthorName ,
p.Id ProblemId,
p.AuthorId ProblemAuthorName,
p.Title ProblemTitle,
p.PublishTime CreateTime
From Response r
Join TProblem p
On r.ProblemId = p.Id 
Join [User] u
On p.AuthorId = u.Id
GO
--5.创建视图VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)，要求该视图： 
Alter View VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)
As
Select 
p.Id ProblemId,
p.Title ProblemTitle,
p.Reward ProblemReward,
k.Problem KeywordAmount 
From Problem p
Join KeywordToProblem k
On k.Problem = p.Id

GO
Select * From Problem
Select * From KeywordToProblem
Go
--1.能反映求助的标题、使用关键字数量和悬赏
Alter View VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)
As
Select 
p.Id ProblemId ,
p.Title ProblemTitle,
p.Reward ProblemReward,
Count(k.Keyword )KeywordAmount 
From Problem p
Join KeywordToProblem k
On k.Problem = p.Id
Group By p.id,p.Title,p.Reward
Go
Select * From KeywordToProblem



Select * From VProblemKeyword
Select * From Problem


--2.在ProblemId上有一个唯一聚集索引 
Go
Alter View VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)
With SchemaBinding
As
Select 
p.Id ProblemId,
p.Title ProblemTitle,
p.Reward ProblemReward,
k.Problem KeywordAmount 
From dbo.Problem p
Join dbo.KeywordToProblem k
On k.Problem = p.Id
Go
Create Unique Clustered Index IX_VproblemKeyword_ProblemId On VProblemKeyword(ProblemId)
Drop Index IX_VproblemKeyword_ProblemId On VProblemKeyword
GO
--3.在ProblemReward上有一个非聚集索引 
Create Index IX_VproblemKeyword_ProblemReward On VProblemKeyword(ProblemReward)
Create Index IX_VproblemKeyword_KeywordAmount On VProblemKeyword(KeywordAmount)
Go
--6.在基表中插入/删除数据，观察VProblemKeyword是否相应的发生变化

Select * From VProblemKeyword
