
USE [$(dbName)]
Go

Alter Table TblEvents Add SlotInterval int null
go

Alter Table TblEvents Add ServerRooms int null
go

Alter Table TblEvents Add LunchStartTime datetime null
go

Alter Table TblEvents Add LunchDuration int null
go
