USE [$(dbname)]
GO

CREATE TABLE TblChaseCampaignType
(
	ChaseCampaignTypeId BIGINT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(255) NOT NULL,
	Alias VARCHAR(255) NOT NULL,
	CONSTRAINT PK_TblChaseCampaignType PRIMARY KEY (ChaseCampaignTypeId)
)
GO

CREATE TABLE TblChaseCampaign
(
	ChaseCampaignId BIGINT IDENTITY(1,1) NOT NULL,
	CampaignId VARCHAR(50) NULL,
	CampaignFileId VARCHAR(50) NULL,
	CampaignName VARCHAR(255) NULL,
	CampaignCode VARCHAR(50) NULL,
	CampaignHouseholdId VARCHAR(100) NULL,
	ChaseCampaignTypeId BIGINT NULL,
	KeyCode VARCHAR(50) NULL,
	CONSTRAINT PK_TblChaseCampaign PRIMARY KEY (ChaseCampaignId),
	CONSTRAINT FK_TblChaseCampaign_TblChaseCampaignType FOREIGN KEY (ChaseCampaignTypeId) REFERENCES [TblChaseCampaignType](ChaseCampaignTypeId)
)
GO