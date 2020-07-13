USE [$(dbName)]
Go

insert into TblTestNotPerformedReason(Id,Name,Alias,CreatedBy,CreatedOn) 
values (6,'Test Unreadable','TestUnreadable',1,getdate())