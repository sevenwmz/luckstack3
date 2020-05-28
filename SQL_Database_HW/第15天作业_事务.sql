--作业： 
--1.利用SQL语句演示从READ COMMITTED到SERIALIZABLE可能存在和可以避免的各种问题，同时用PPT演示上述现象背后的锁机制。
Use SevenTest
Dbcc Useroptions
--------------[Main]----------------------
Select * From Problem

------------------For Read Committed-----------------
Dbcc Useroptions
Begin Tran
Update Problem Set Reward+=10 Where Id = 14

--Read Committed Can not Let Other Transaction 'Select',Unless "Dirty Read"
--Let Me Show You At Other Transation



-----Here is Secendtime Update date
Update Problem Set Reward+=10 Where Id = 14
-----------------Guess what happning in another page of seleted?

Rollback
Print @@Trancount
-------------------------------	

---------------------
Begin Tran
Update Problem Set Reward+=10 Where Id = 14
------------------------Untill now Here is alread show (1 row(s) Affected)
Rollback

Select * From Problem
------------------------Goust Insert
Insert Problem(Reward,Title,Content) Values(100,N'Goust title',N'Goust Content')

------------------------Goust Brother
Insert Problem(Reward,Title,Content) Values(200,N'Goust title-2',N'Goust-2 Content')




-------------------lack Primary Key 
-------------------Work tommore
select * from Problem
Alter Table Problem
--Alter Column Reward smallInt Not Null
Add Constraint PK_Problem_Id Primary Key(Id)

Select * From Problem    
Begin Tran 
Update Problem Set Reward += 10 Where Id = 15
Begin Tran 
Update Problem Set Reward += 10 Where Id = 16


Rollback
Print @@Trancount
------------------------
------------------------
------------------------



----------------For Read Committed
Begin Tran
Select * From Problem
--If wanna continue Read Info Of Problem Need Change Isolation Level

-------------------------------------------------------------
-----------For Read UnCommitted-----
-- IF Wanna Read On Committed Status,Change Isolation Level Will Be Right.

Set Transaction Isolation Level Read Uncommitted
Dbcc UserOptions

--Now We TryAgain!
Select * From Problem
----------------Great Idea, You Gusy is talented!!! We solution can't read this problem!
----------------Wait guys,don't pleased too early!!!
----------------Think about some avoid issue we have ?!
----------------Let me show you at a other page!


---------------Select Again
Select * From Problem

-----------------What? Amazing!!!

-----------------Now you Clearly Sow What's "Dirty Read"
----------------------------------------------------------------------------------


---------------"Dirty Read" Can not Asure Twice Read Same
---------------You Got Date is not "Exactly!!"
---------------We Need Solution this Problem,So... Guess what i do next time?
---------------Is change Level!  Great Guys, All of you right!
---------------Let me show you!!!
Set Transaction Isolation Level Repeatable Read

Dbcc UserOptions

Begin Tran
Select * From Problem
----------------Hahaaaaz is not any issue right? i did it.
----------------Other page cannot do anything make me mistake.
----------------Untill i click "Rollback" Or "Commit"
Commit
Print @@Trancount
-----------------Everything go down? I know what you gusy thinkabout .
-----------------Some Issue hide too deeply!
-----------------Who can tell me the detail? is anybody now?

-----
-----------------Look His truely our Student of "YuanStack"!!!
-----
-----------------Now is Very famous "Goust Read" Comeing to you!!!
-----

Dbcc UserOptions
Print @@Trancount


Select * From Problem
Begin Tran
Update Problem Set Reward = 20  ---All Table Changing!!!

Select * From Problem
-----------------What happening?Why Comeing 1 data.Like 'Goust'
Rollback
-----------------is anybody know what happening?let me tell you the detail!!!
-----------------balabala ... balabala

					--------
-----------------So,what we do now?
-----------------Improve Level!!! 
Set Transaction Isolation Level Serializable  ---(MAX Level)
Begin Tran
Update Problem Set Reward = 20 
Select * From Problem

Print @@Trancount
Rollback


-----------------Dead Lock

Select * From Problem
Begin Tran 
Update Problem Set Reward += 10 Where Id = 16

Begin Tran 
Update Problem Set Reward += 10 Where Id = 15




--2.思考题：游戏买装备 
--1.比如某用户现有100个游戏币，某装备30个游戏币一套。 
--2.现该用户利用软件，瞬间向服务器发送无数条购买装备的请求。
--3.结果就真的到手了n套装备（n>3），这是怎么一回事呢？ 