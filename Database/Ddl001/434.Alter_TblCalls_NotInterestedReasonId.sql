USE [$(dbName)]
Go

Alter table TblCalls Add NotInterestedReasonId bigint Null Constraint FK_TblCalls_TblLookup_NotInterestedReasonId Foreign Key (NotInterestedReasonId) References dbo.TblLookup (LookupId)