Select * from Teacher

Create Table Teacher(
	Id Int,
	[Name] Nvarchar(25),
	Age Int,
	Gender Bit
);

Create Unique Clustered Index IX_Teacher_Id On Teacher(Id)
Create Unique NonClustered Index IX_TEACHER_Age On Teacher(age)

Create Index IX_TEACHER_GENDER ON TEACHER(GENDER)

Insert Teacher(Id,[Name],Age,Gender) VAlues(1,N'wpz',23,1);
Insert Teacher(Id,[Name],Age,Gender) VAlues(2,N'wpzq',39,0);

Create Unique Index IX_Teacher_Name_1 On Teacher([Name])
Drop Index Teacher.IX_Teacher_Id

Select * From Teacher


Alter Table Teacher
Add Constraint UQ_TEACHER_NAME Unique( [name] )

Select [Name],[Type],Is_UNIque,Is_primary_key,Is_Unique_Constraint
From sys.indexes
Where object_id = OBJECT_ID('Teacher')

Create Nonclustered Index Ix_teacher_Name On Teacher([Name])

Create Unique clustered Index Ix_teacher_Name2 On Teacher([Name])
Create Index Ix_teacher_Name4 On Teacher([Name])

Drop Index Teacher.Ix_teacher_Name4

Select  * From Teacher Where [Name] = 'Fg'

Alter Table Teacher
--Alter Column Id Int Not Null 
Add Constraint PK_Teacher_Id Primary Key(Id)

Declare @N Int = 0
While @N<5
Begin
	Set @N+=1
	Print @N
end

Go
Create Function YzAdd(@a Int,@b Int) 
Returns Int
Begin
	return @a + @b
end

go
Print dbo.YzAdd(3,5)

