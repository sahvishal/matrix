USE [$(dbname)]
GO

CREATE TABLE TblChaseOutbound
(
	CustomerId BIGINT NOT NULL,
	TenantId VARCHAR(50) NULL,
	IndividualId VARCHAR(50) NULL,
	ClientId VARCHAR(50) NULL,
	VendorCD VARCHAR(50) NULL,
	ContractNumber VARCHAR(50) NULL,
	ContractPersonNumber VARCHAR(50) NULL,
	ConsumerId VARCHAR(50) NULL,
	CampaignMemberId VARCHAR(50) NULL,
	DistributionId VARCHAR(50) NULL,
	SubscriberIndicator BIT NOT NULL CONSTRAINT DF_TblChaseOutbound_SubscriberIndicator DEFAULT 0,
	RelationshipId BIGINT NULL,
	IdentifiedIndicator BIT NOT NULL CONSTRAINT DF_TblChaseOutbound_IdentifiedIndicator DEFAULT 0,
	OutboundCallIndicator BIT NOT NULL CONSTRAINT DF_TblChaseOutbound_OutboundCallIndicator DEFAULT 0,
	WirelessIndicator BIT NOT NULL CONSTRAINT DF_TblChaseOutbound_WirelessIndicator DEFAULT 0,
	PriorityCode VARCHAR(50) NULL,
	BusinessCaseId VARCHAR(50) NULL,
	MedicareIndicator BIT NOt NULL CONSTRAINT DF_TblChaseOutbound_MedicareIndicator DEFAULT 0,
	ChaseGroupId BIGINT NULL,
	HmoLobIndicator BIT NOT NULL CONSTRAINT DF_TblChaseOutbound_HmoLobIndicator DEFAULT 0,
	ReferMemberTo VARCHAR(255) NULL,
	ClosestRetailCenter VARCHAR(50) NULL,
	ConfidenceScoreId BIGINT NULL,
	LocationCode VARCHAR(50) NULL,
	ForecastedOutreachDate DATETIME NULL,
	RecordProcessDate DATETIME NULL,
	AgentContextNameValueSet NVARCHAR(MAX) NULL,
	DateCreated DATETIME NOT NULL,
	DateUpdated DATETIME NULL,
	CONSTRAINT PK_TblChaseOutbound PRIMARY KEY (CustomerId),
	CONSTRAINT FK_TblChaseOutbound_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblChaseOutbound_TblRelationship FOREIGN KEY (RelationshipId) REFERENCES [TblRelationship](RelationshipId),
	CONSTRAINT FK_TblChaseOutbound_TblChaseGroup FOREIGN KEY (ChaseGroupId) REFERENCES [TblChaseGroup](ChaseGroupId),
	CONSTRAINT FK_TblChaseOutbound_TblLookup FOREIGN KEY (ConfidenceScoreId) REFERENCES [TblLookup](LookupId)
)
GO