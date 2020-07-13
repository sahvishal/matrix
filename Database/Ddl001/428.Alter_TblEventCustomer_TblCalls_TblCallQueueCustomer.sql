USE [$(dbName)]
Go

ALTER TABLE TblEventCustomers Add CampaignId bigint null  CONSTRAINT FK_TblEventCustomers_TblCampaign_Id  Foreign Key (CampaignId) References dbo.TblCampaign (Id) On UPDATE No Action On Delete No ACTION
GO

ALTER TABLE TblCalls Add CampaignId bigint null  CONSTRAINT FK_TblCalls_TblCampaign_Id  Foreign Key (CampaignId) References dbo.TblCampaign (Id) On UPDATE No Action On Delete No ACTION
GO

ALTER TABLE TblCallQueueCustomer Add CampaignId bigint null  CONSTRAINT FK_TblCallQueueCustomer_TblCampaign_Id  Foreign Key (CampaignId) References dbo.TblCampaign (Id) On UPDATE No Action On Delete No ACTION
GO
