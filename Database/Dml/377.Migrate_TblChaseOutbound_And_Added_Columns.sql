use [$(dbname)]
go

insert into TblChaseOutboundTemp 
	(CustomerId,TenantId,IndividualId,ClientId,VendorCD,ContractNumber,ContractPersonNumber,
		ConsumerId,CampaignMemberId,DistributionId,SubscriberIndicator,RelationshipId,IdentifiedIndicator,
		OutboundCallIndicator,WirelessIndicator,PriorityCode,BusinessCaseId,MedicareIndicator,ChaseGroupId,
		HmoLobIndicator,ReferMemberTo,ClosestRetailCenter, ConfidenceScoreId, LocationCode, ForecastedOutreachDate, 
		RecordProcessDate,AgentContextNameValueSet,DateCreated,DateUpdated)
select CustomerId,TenantId,IndividualId,ClientId,VendorCD,ContractNumber,ContractPersonNumber,
		ConsumerId,CampaignMemberId,DistributionId,SubscriberIndicator,RelationshipId,IdentifiedIndicator,
		OutboundCallIndicator,WirelessIndicator,PriorityCode,BusinessCaseId,MedicareIndicator,ChaseGroupId,
		HmoLobIndicator,ReferMemberTo,ClosestRetailCenter, ConfidenceScoreId, LocationCode, ForecastedOutreachDate, 
		RecordProcessDate,AgentContextNameValueSet,DateCreated,DateUpdated from TblChaseOutbound

insert into TblCustomerChaseCampaignTemp (CustomerId,ChaseCampaignId,IsActive)
select CustomerId,ChaseCampaignId,IsActive from TblCustomerChaseCampaign

insert into TblCustomerChaseChannelTemp (CustomerId,ChaseChannelLevelId)
select CustomerId,ChaseChannelLevelId from TblCustomerChaseChannel

insert into TblCustomerChaseProductTemp (CustomerId,ChaseProductId)
select CustomerId,ChaseProductId from TblCustomerChaseProduct

--Drop Table TblChaseOutbound---
 
	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblChaseOutbound_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblChaseOutbound]'))
		ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [FK_TblChaseOutbound_TblCustomerProfile]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblChaseOutbound_TblRelationship]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblChaseOutbound]'))
		ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [FK_TblChaseOutbound_TblRelationship]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblChaseOutbound_TblChaseGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblChaseOutbound]'))
		ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [FK_TblChaseOutbound_TblChaseGroup]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblChaseOutbound_TblLookup]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblChaseOutbound]'))
		ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [FK_TblChaseOutbound_TblLookup]
	GO

	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblChaseOutbound_SubscriberIndicator]') AND type = 'D' )
	BEGIN
	   ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [DF_TblChaseOutbound_SubscriberIndicator], COLUMN [SubscriberIndicator]
	END
	GO

	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblChaseOutbound_IdentifiedIndicator]') AND type = 'D' )
	BEGIN
	   ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [DF_TblChaseOutbound_IdentifiedIndicator], COLUMN [IdentifiedIndicator]
	END
	GO

	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblChaseOutbound_OutboundCallIndicator]') AND type = 'D' )
	BEGIN
	   ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [DF_TblChaseOutbound_OutboundCallIndicator], COLUMN [OutboundCallIndicator]
	END
	GO

	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblChaseOutbound_WirelessIndicator]') AND type = 'D' )
	BEGIN
	   ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [DF_TblChaseOutbound_WirelessIndicator], COLUMN [WirelessIndicator]
	END
	GO

	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblChaseOutbound_MedicareIndicator]') AND type = 'D' )
	BEGIN
	   ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [DF_TblChaseOutbound_MedicareIndicator], COLUMN [MedicareIndicator]
	END
	GO

	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblChaseOutbound_HmoLobIndicator]') AND type = 'D' )
	BEGIN
	   ALTER TABLE [dbo].[TblChaseOutbound] DROP CONSTRAINT [DF_TblChaseOutbound_HmoLobIndicator], COLUMN [HmoLobIndicator]
	END
	GO

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblChaseOutbound]') AND type in (N'U'))
	BEGIN
		DROP TABLE [dbo].[TblChaseOutbound]
	END
	GO

--- TblCustomerChaseChannel ------
	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerChaseChannel_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseChannel]'))
		ALTER TABLE [dbo].[TblCustomerChaseChannel] DROP CONSTRAINT [FK_TblCustomerChaseChannel_TblCustomerProfile]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerChaseChannel_TblChaseProduct]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseChannel]'))
		ALTER TABLE [dbo].[TblCustomerChaseChannel] DROP CONSTRAINT [FK_TblCustomerChaseChannel_TblChaseProduct]
	GO

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseChannel]') AND type in (N'U'))
	BEGIN
		DROP TABLE [dbo].[TblCustomerChaseChannel]
	END
	GO

--- TblCustomerChaseProduct ------
	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerChaseProduct_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseProduct]'))
		ALTER TABLE [dbo].[TblCustomerChaseProduct] DROP CONSTRAINT [FK_TblCustomerChaseProduct_TblCustomerProfile]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerChaseProduct_TblChaseProduct]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseProduct]'))
		ALTER TABLE [dbo].[TblCustomerChaseProduct] DROP CONSTRAINT [FK_TblCustomerChaseProduct_TblChaseProduct]
	GO

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseProduct]') AND type in (N'U'))
	BEGIN
		DROP TABLE [dbo].[TblCustomerChaseProduct]
	END
	GO

--- TblCustomerChaseCampaign ------
	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerChaseCampaign_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseCampaign]'))
		ALTER TABLE [dbo].[TblCustomerChaseCampaign] DROP CONSTRAINT [FK_TblCustomerChaseCampaign_TblCustomerProfile]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerChaseProduct_TblChaseProduct]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseCampaign]'))
		ALTER TABLE [dbo].[TblCustomerChaseCampaign] DROP CONSTRAINT [FK_TblCustomerChaseProduct_TblChaseProduct]
	GO

	IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCustomerChaseCampaign_IsActive]') AND type = 'D' )
	BEGIN
	   ALTER TABLE [dbo].[TblCustomerChaseCampaign] DROP CONSTRAINT [DF_TblCustomerChaseCampaign_IsActive], COLUMN [IsActive]
	END
	GO

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerChaseCampaign]') AND type in (N'U'))
	BEGIN
		DROP TABLE [dbo].[TblCustomerChaseCampaign]
	END
	GO

	CREATE TABLE TblChaseOutbound
	(
		[Id] [bigint] IDENTITY(1,1) NOT NULL,	
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
		EndDate DATETIME NULL,
		IsActive Bit Not Null,	
		CONSTRAINT PK_TblChaseOutbound PRIMARY KEY ([Id]),
		CONSTRAINT FK_TblChaseOutbound_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile](CustomerId),
		CONSTRAINT FK_TblChaseOutbound_TblRelationship FOREIGN KEY (RelationshipId) REFERENCES [TblRelationship](RelationshipId),
		CONSTRAINT FK_TblChaseOutbound_TblChaseGroup FOREIGN KEY (ChaseGroupId) REFERENCES [TblChaseGroup](ChaseGroupId),
		CONSTRAINT FK_TblChaseOutbound_TblLookup FOREIGN KEY (ConfidenceScoreId) REFERENCES [TblLookup](LookupId)
	)
GO

CREATE TABLE TblCustomerChaseCampaign
(
	ChaseOutboundId bigInt Not null,
	CustomerId BIGINT NOT NULL,
	ChaseCampaignId BIGINT NOT NULL,
	IsActive BIT NOT NULL CONSTRAINT DF_TblCustomerChaseCampaign_IsActive DEFAULT 0,

	CONSTRAINT PK_TblCustomerChaseCampaign PRIMARY KEY (ChaseOutboundId, ChaseCampaignId),
	CONSTRAINT FK_TblCustomerChaseCampaign_TblChaseOutbound FOREIGN KEY (ChaseOutboundId) REFERENCES [TblChaseOutbound](Id),
	CONSTRAINT FK_TblCustomerChaseCampaign_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblCustomerChaseCampaign_TblChaseCampaign FOREIGN KEY (ChaseCampaignId) REFERENCES [TblChaseCampaign](ChaseCampaignId)
)
GO


CREATE TABLE TblCustomerChaseChannel
(
	ChaseOutboundId bigInt Not null,
	CustomerId BIGINT NOT NULL,
	ChaseChannelLevelId BIGINT NOT NULL,
	CONSTRAINT PK_TblCustomerChaseChannel PRIMARY KEY (ChaseOutboundId, ChaseChannelLevelId),
	CONSTRAINT FK_TblCustomerChaseChannel_TblChaseOutbound FOREIGN KEY (ChaseOutboundId) REFERENCES [TblChaseOutbound](Id),
	CONSTRAINT FK_TblCustomerChaseChannel_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblCustomerChaseChannel_TblChaseProduct FOREIGN KEY (ChaseChannelLevelId) REFERENCES [TblChaseChannelLevel](ChaseChannelLevelId)
)
GO

CREATE TABLE TblCustomerChaseProduct
(
	ChaseOutboundId bigInt Not null,
	CustomerId BIGINT NOT NULL,
	ChaseProductId BIGINT NOT NULL,
	CONSTRAINT PK_TblCustomerChaseProduct PRIMARY KEY (ChaseOutboundId, ChaseProductId),
	CONSTRAINT FK_TblCustomerChaseProduct_TblChaseOutbound FOREIGN KEY (ChaseOutboundId) REFERENCES [TblChaseOutbound](Id),
	CONSTRAINT FK_TblCustomerChaseProduct_TblCustomerProfile FOREIGN KEY (CustomerId) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblCustomerChaseProduct_TblChaseProduct FOREIGN KEY (ChaseProductId) REFERENCES [TblChaseProduct](ChaseProductId)
)
GO


Insert Into TblChaseOutbound 
(CustomerId,TenantId,IndividualId,ClientId,VendorCD,ContractNumber,ContractPersonNumber,
		ConsumerId,CampaignMemberId,DistributionId,SubscriberIndicator,RelationshipId,IdentifiedIndicator,
		OutboundCallIndicator,WirelessIndicator,PriorityCode,BusinessCaseId,MedicareIndicator,ChaseGroupId,
		HmoLobIndicator,ReferMemberTo,ClosestRetailCenter, ConfidenceScoreId, LocationCode, ForecastedOutreachDate, 
		RecordProcessDate,AgentContextNameValueSet,DateCreated,EndDate,IsActive)

select CustomerId,TenantId,IndividualId,ClientId,VendorCD,ContractNumber,ContractPersonNumber,
		ConsumerId,CampaignMemberId,DistributionId,SubscriberIndicator,RelationshipId,IdentifiedIndicator,
		OutboundCallIndicator,WirelessIndicator,PriorityCode,BusinessCaseId,MedicareIndicator,ChaseGroupId,
		HmoLobIndicator,ReferMemberTo,ClosestRetailCenter, ConfidenceScoreId, LocationCode, ForecastedOutreachDate, 
		RecordProcessDate,AgentContextNameValueSet,DateCreated,null,1 from TblChaseOutboundTemp


Insert into TblCustomerChaseCampaign (ChaseOutboundId,CustomerId,ChaseCampaignId)

select cob.Id, ccct.CustomerId, ccct.ChaseCampaignId from TblChaseOutbound cob
	inner join TblCustomerChaseCampaignTemp ccct on cob.CustomerId = ccct.CustomerId

Insert into TblCustomerChaseChannel (ChaseOutboundId,CustomerId,ChaseChannelLevelId)

select cob.Id, ccct.CustomerId, ccct.ChaseChannelLevelId from TblChaseOutbound cob
	inner join TblCustomerChaseChannelTemp ccct on cob.CustomerId = ccct.CustomerId


Insert into TblCustomerChaseProduct (ChaseOutboundId,CustomerId,ChaseProductId)

select cob.Id, ccpt.CustomerId, ccpt.ChaseProductId from TblChaseOutbound cob
	inner join TblCustomerChaseProductTemp ccpt on cob.CustomerId = ccpt.CustomerId










