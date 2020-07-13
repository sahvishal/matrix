USE [$(dbName)]
Go

Alter Table TblDirectMail Add CampaignId BigInt null constraint FK_TblDirectMail_TblCampaign_CampaignId Foreign Key(CampaignId) References TblCampaign(Id)
Go

Alter Table TblDirectMail Add DirectMailTypeId BigInt null constraint FK_TblDirectMail_TblDirectMailType_DirectMailTypeId Foreign Key(DirectMailTypeId) References TblDirectMailType(Id)
Go