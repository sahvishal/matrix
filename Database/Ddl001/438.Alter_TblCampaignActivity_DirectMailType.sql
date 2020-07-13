USE [$(dbName)]
Go

Alter Table TblCampaignActivity Add DirectMailTypeId bigint null Constraint Fk_TblCampaignActivity_TblDirectMailType_DirectMailTypeId Foreign Key (DirectMailTypeId) References dbo.TblDirectMailType (Id)