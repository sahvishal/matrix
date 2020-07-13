USE [$(dbName)]
Go 

Alter table [TblUserLogin]
ADD [LastPasswordChangeDate] [datetime]   NULL    
 
GO
  
   