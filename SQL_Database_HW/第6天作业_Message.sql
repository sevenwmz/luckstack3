--作业：
--新建表Message(Id, FromUser, ToUser, UrgentLevel, Kind, HasRead, IsDelete, Content)，使用该表和SQL语句，证明：
Create Table [Message](
	[Id] Int Primary Key,
	[FromUser] Nvarchar(20) Not Null,
	[ToUser] Nvarchar(20) Not Null,
	[UrgentLevel] TinyInt Not Null,
	[Kind] Nvarchar(20) Not Null,
	[HasRead] Bit Not Null,
	[IsDelete] Bit Not Null,
	[Content] Nvarchar(200) Not Null
);

--Use SevenTest
Select [Name],[Type],Is_UNIque,Is_primary_key,Is_Unique_Constraint
From sys.indexes
Where object_id = OBJECT_ID('Message')

--唯一约束依赖于唯一索引
Alter Table [Message]
Add Constraint UQ_Message_FromUser Unique(FromUser) 
--主键上可以是非聚集索引 
Alter Table [Message]
Drop Constraint PK__Message__3214EC072A4B4B5E 
Go
Create Unique Clustered Index IX_Message_FromUser On [Message](FromUser)

Alter Table [Message]
Add Constraint PK_Message_Id Primary Key(Id)
Create Index IX_Message_Id On [Message](Id)

--并利用“执行计划”图演示说明：Scan、Seek和Lookup的使用和区别。
Select Content From Message
Where Content > 2

Select * From [Message]
Where FromUser = '1'

Select * From [Message]
Where Id = 1




