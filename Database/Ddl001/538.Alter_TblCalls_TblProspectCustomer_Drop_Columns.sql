USE [$(dbName)]
Go

ALTER TABLE [TblProspectCustomer] DROP Constraint [FK_TblProspectCustomer_TblLookup_SubDispositionId]
Go

ALTER TABLE TblProspectCustomer Drop Column SubDispositionId
Go

ALTER TABLE [TblCalls] DROP Constraint [FK_TblCalls_TblLookup_SubDispositionId]
Go

ALTER Table TblCalls Drop Column SubDispositionId
Go

