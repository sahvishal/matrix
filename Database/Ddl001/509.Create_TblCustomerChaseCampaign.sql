USE [$(dbname)]
GO

CREATE TABLE TblCustomerChaseCampaign
(
	CustomerId BIGINT NOT NULL,
	ChaseCampaignId BIGINT NOT NULL,
	IsActive BIT NOT NULL CONSTRAINT DF_TblCustomerChaseCampaign_IsActive DEFAULT 0,
	CONSTRAINT PK_TblCustomerChaseCampaign PRIMARY KEY (CustomerId, ChaseCampaignId),
	CONSTRAINT FK_TblCustomerChaseCampaign_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblCustomerChaseCampaign_TblChaseCampaign FOREIGN KEY (ChaseCampaignId) REFERENCES [TblChaseCampaign](ChaseCampaignId)
)
GO