USE [$(dbName)]
Go

Alter table TblHealthPlanCallQueueCriteria Add CampaignId bigint Null Constraint FK_TblHealthPlanCallQueueCriteria_tblCampaign_Id Foreign Key (CampaignId) References dbo.TblCampaign (Id)

