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




Declare @name Int Set @name = 1
Print @@Version

Declare @age Int = 17
if @age < 18 
Begin
Print 'Adult'
Print 'is ok'
Print 'Now'
end
else print 'Te' 

Declare @age Int = 17
While @age  <20
Begin
	Set @age+=1
	Print @age
end
Go
Alter Function WpzAdd(@A Int,@B Int)
Returns Int
Begin
	Return @A * @B
End
Go

Drop Function dbo.YzAdd
Print dbo.WpzAdd(3,5)
Go
Create Function TableFunction(@number Int)
Returns Table
Return Select Top(@number) * From Teacher
go
select * From TableFunction(3)

Go
Create Function TableMutipleFunction(@id Int,@name Nvarchar(20))
Returns @T Table(Id Int,[Name]Nvarchar(20))
Begin
	Insert @T Values(@id,@name)
	Return 
end


Go
Select * From TableMutipleFunction(2,'Teacher')
Select * From TableMutipleFunction(2,'Teacher')


