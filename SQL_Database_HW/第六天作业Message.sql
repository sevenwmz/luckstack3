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


--唯一约束依赖于唯一索引
--主键上可以是非聚集索引 
--SQL Server不会为外键自动添加索引
--并利用“执行计划”图演示说明：Scan、Seek和Lookup的使用和区别。



