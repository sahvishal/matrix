USE [$(dbName)]
Go

Update TblAccount set RemoveLongDescription=1 where AccountID in(929,966)
GO

Update TblAccount set GenerateBatchLabel=1 where AccountID=966
GO