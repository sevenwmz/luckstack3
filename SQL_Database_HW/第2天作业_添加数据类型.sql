
--作业：
--观察“一起帮”的发布求助功能，试着建立表Problem，包含：
--1.Id，主键，自增
--2.字段Title（标题），不能为空
--3.Content（正文），不能为空
--4.NeedRemoteHelp（需要远程求助），默认为需要，
--5.Reward（悬赏），
--6.PublishDateTime（发布时间）……
--请为这些列选择合适的数据类型。

Create Table [dbo].[Problem](
    [Id] Int,
    [Title] Nvarchar(50) Not NUll,
    [Content] Ntext Not Null,
    [NeedRemoteHelp] Bit Constraint DF_NeedRemoteHelp Default('True'),
    [Reward] SmallInt,
    [PublishDateTime] Datetime
    Constraint PK_Id Primary Key,
);

