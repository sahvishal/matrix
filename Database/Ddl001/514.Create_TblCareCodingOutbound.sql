USE [$(dbname)]
GO

CREATE TABLE TblCareCodingOutbound
(
	CustomerId BIGINT NOT NULL,
	TenantId VARCHAR(50) NULL,
	CampaignId VARCHAR(50) NULL,
	IndividualId VARCHAR(50) NULL,
	ClientId VARCHAR(50) NULL,
	ContractNumber VARCHAR(50) NULL,
	ContractPersonNumber VARCHAR(50) NULL,
	ConsumerId VARCHAR(50) NULL,
	CampaignCode VARCHAR(50) NULL,
	CampaignMemberId VARCHAR(50) NULL,
	CareCodeLabType VARCHAR(50) NULL,
	CareCodeLabDescription VARCHAR(500) NULL,
	StatusOfCoding VARCHAR(50) NULL,
	MedicalCode VARCHAR(50) NULL,
	MedicalCodeType VARCHAR(50) NULL,
	MedicalCodeServiceDate DATETIME NULL,
	DateCreated DATETIME NOT NULL,
	DateUpdated DATETIME NULL,
	CONSTRAINT PK_TblCareCodingOutbound PRIMARY KEY (CustomerId)
)
GO