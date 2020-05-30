Create Table Series(
	[Id] Int Primary Key Identity,
	[Name] Nvarchar(50)
)

Alter Table Article
Add SeriesId Int Constraint FK_Article_Series_Id Foreign Key References Series(Id)

Select * From Article

Insert Series(Name) Values(N'默认分类')
Insert Series(Name) Values(N'讲课这些天')
Insert Series(Name) Values(N'ASP.NET')
Insert Series(Name) Values(N'Razor')
Insert Series(Name) Values(N'CSharp')
Insert Series(Name) Values(N'折腾')
Insert Series(Name) Values(N'空系列')


Select * From Article
Alter Table Article
Add AdId Int Constraint FK_Article_AD_Id Foreign Key References AD(Id)


Insert AD(ContentOfAd) Values(N'----- 使用新的广告 -----')
Insert AD(ContentOfAd) Values(N'微商宣传广告语 日加1000精准')
Insert AD(ContentOfAd) Values(N'如果你听了一课之后发现不喜欢这门课程，那你可以要求退回你的学费，但必须用法语说。')
Insert AD(ContentOfAd) Values(N'煮酒论英雄才子赢天下')

Select * From AD



Select ContentOfAd From AD


Create Table AD(
	[Id] Int Primary Key Identity,
	[ContentOfAd] Nvarchar(255),
	[Url] Nvarchar(1000)
)

Create Table Series(
	[Id] Int Primary Key Identity,
	[ContentOfSeries] Nvarchar(255),
);
Select Name,Id From Series

Select * From Article Order By Id


ALter Table Article
Add Constraint PK_17bang_Article_Id Primary key(Id)

Create Table KeywordToArticle(
	[Id] Int Primary Key Identity,
	[ArticleNameId] Int Constraint FK_Aritcle_Keyword_Id Foreign Key References Article(Id),
	[KeywordId] Int Constraint FK_Keyword_Article_Id Foreign Key References Keyword(Id)
);

Select * From KeywordToArticle
Select * From Keyword

--Select [name] From Keyword Where N'123'  In (select [name] From Keyword)
--if Select [name] From Keyword Where N'123' In (select [name] From Keyword)


If (Select name From Keyword Where name = N'123') <> null
Print 1

Select * From Article
Select * From KeywordToArticle
--Insert KeywordToArticle(ArticleNameId,KeywordId) 
--Values((Select id From Article Where Title = ),
--(Select Id From Keyword Where [Name] = ) )
--Update Keyword Set Used += 1 Where [Name] = 
--Insert Keyword([Name],Used) Values()

Begin Tran
IF N'编程开发语言'  In (Select [name] From Keyword Where[name] = N'编程开发语言')
Begin
Insert KeywordToArticle(ArticleNameId, KeywordId)
Values((Select Id From Article Where Title = N'王胖子的数据库' And AuthorId = (Select Id from [User] Where UserName = N'wpzwpz')),
(Select Id From Keyword Where[Name] = N'编程开发语言'))
Update Keyword Set Used += 1 Where [Name] = N'编程开发语言'
End



Rollback

Begin Tran
IF  N'编程开发语言'  In (Select [name] From Keyword Where[name] =  N'编程开发语言' ) 
Begin 
Insert KeywordToArticle(ArticleNameId, KeywordId) 
Values(
(Select Id From Article Where Title = N'我叫wpzKeywords' 
And SUBSTRING(Content,0,25) = SUBSTRING(N'dasda',0,25)  
And AuthorId = (Select Id from [User] Where UserName = N'wpzwpz')),

(Select Id From Keyword Where[Name] = N'编程开发语言'))
Update Keyword Set Used += 1 Where [Name] = N'编程开发语言'
End
ELSE 
Insert Keyword([Name],Used) Values(N'编程开发语言',0) 


Print @@TranCount


ELSE
Insert Keyword([Name],Used) Values(N'编程开发语言',0)




Select * From Article

Select * From Keyword


IF N'Word' Not In (Select [name] From Keyword Where [name] = N'Word') 
Print 1 else print 0
Insert Keyword([Name]) Values(@KeywordPage)
ELSE
Begin
Insert KeywordToArticle(ArticleNameId,KeywordId)
Values((Select id From Article Where Title = @Title),
(Select Id From Keyword Where[Name] = @KeywordPage))
Update Keyword Set Used += 1 Where [Name] = @KeywordDatebase
End

Select * From KeywordToArticle
Insert KeywordToArticle(ArticleNameId,KeywordId) 
Values()


Delete Article Where id between 98 and 117

Delete Keyword Where id between 40 and 42

