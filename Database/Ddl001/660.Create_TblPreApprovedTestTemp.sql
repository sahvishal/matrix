	use [$(dbname)]
	go

	Create Table TblPreApprovedTestTemp
	(
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		[CustomerId] [bigint] NOT NULL,
		[TestId] [bigint] NOT NULL,
		[DateCreated] [datetime] NOT NULL,
		[DateModified] [datetime] NULL,
		[CreatedByOrgRoleUserId] [bigint] NOT NULL,
		[ModifiedByOrgRoleUserId] [bigint] NULL,
		[IsActive] [bit] NOT NULL,
		CONSTRAINT PK_TblPreApprovedTestTemp PRIMARY KEY ([Id]),
	)
	Go

	Create Table TblPreApprovedPackageTemp
	(
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		[CustomerId] [bigint] NOT NULL,
		[PackageId] [bigint] NOT NULL,
		[DateCreated] [datetime] NOT NULL,
		[DateModified] [datetime] NULL,
		[CreatedByOrgRoleUserId] [bigint] NOT NULL,
		[ModifiedByOrgRoleUserId] [bigint] NULL,
		[IsActive] [bit] NOT NULL,
		CONSTRAINT PK_TblPreApprovedPackageTemp PRIMARY KEY ([Id]),		
	)
	Go

	Create Table TblCustomerIcdCodeTemp
	(
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		CustomerId bigint not null, 
		IcdCodeId bigint not null,
		CONSTRAINT PK_TblCustomerIcdCodeTemp PRIMARY KEY ([Id]),		 
	)
	Go

	CREATE TABLE [dbo].[TblEventCustomerIcdCodes](
	[EventCustomerId] [bigint] NOT NULL,
	[IcdCodeId] [bigint] NOT NULL,	
	 CONSTRAINT [PK_TblEventCustomerIcdCodes] PRIMARY KEY CLUSTERED 
		(
			[EventCustomerId] ASC,
			[IcdCodeId] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO

	ALTER TABLE [dbo].[TblEventCustomerIcdCodes]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerIcdCodes_TblEventCustomers] FOREIGN KEY([EventCustomerId])
	REFERENCES [dbo].[TblEventCustomers] ([EventCustomerId])
	GO

	ALTER TABLE [dbo].[TblEventCustomerIcdCodes]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerIcdCodes_TblIcdCodes] FOREIGN KEY([IcdCodeId])
	REFERENCES [dbo].[TblIcdCodes] ([Id])
	GO

	CREATE TABLE [dbo].[TblCurrentMedicationTemp]
	(
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		[CustomerId] [bigint] NOT NULL,
		[NdcId] [bigint] NOT NULL,
		[DateCreated] [datetime] NOT NULL,
		[DateModified] [datetime] NULL,
		[CreatedByOrgRoleUserId] [bigint] NOT NULL,
		[ModifiedByOrgRoleUserId] [bigint] NULL,
		IsPrescribed bit not null,
		IsOtc bit Not null,
		[IsActive] [bit] NOT NULL
		CONSTRAINT PK_TblCurrentMedicationTemp PRIMARY KEY ([Id]),		
	) 

	GO

		
	CREATE TABLE [dbo].[TblEventCustomerCurrentMedication](
	[EventCustomerId] [bigint] NOT NULL,
	[NdcId] [bigint] NOT NULL,
	IsPrescribed bit Not Null,
	IsOtc bit Not Null,

	CONSTRAINT [PK_TblEventCustomerCurrentMedication] PRIMARY KEY CLUSTERED 
		(
			[EventCustomerId] ASC,
			[NdcId] ASC
		)
	) 

	GO

	ALTER TABLE [dbo].[TblEventCustomerCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerCurrentMedication_TblEventCustomers] FOREIGN KEY([EventCustomerId])
	REFERENCES [dbo].[TblEventCustomers] ([EventCustomerId])
	GO

	ALTER TABLE [dbo].[TblEventCustomerCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerCurrentMedication_TblNdc] FOREIGN KEY([NdcId])
	REFERENCES [dbo].[TblNdc] ([Id])
	GO

	CREATE TABLE TblChaseOutboundTemp
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
		SubscriberIndicator BIT NOT NULL ,
		RelationshipId BIGINT NULL,
		IdentifiedIndicator BIT NOT NULL,
		OutboundCallIndicator BIT NOT NULL,
		WirelessIndicator BIT NOT NULL,
		PriorityCode VARCHAR(50) NULL,
		BusinessCaseId VARCHAR(50) NULL,
		MedicareIndicator BIT NOt NULL,
		ChaseGroupId BIGINT NULL,
		HmoLobIndicator BIT NOT NULL,
		ReferMemberTo VARCHAR(255) NULL,
		ClosestRetailCenter VARCHAR(50) NULL,
		ConfidenceScoreId BIGINT NULL,
		LocationCode VARCHAR(50) NULL,
		ForecastedOutreachDate DATETIME NULL,
		RecordProcessDate DATETIME NULL,
		AgentContextNameValueSet NVARCHAR(MAX) NULL,
		DateCreated DATETIME NOT NULL,
		DateUpdated DATETIME NULL,
		CONSTRAINT PK_TblChaseOutboundTemp PRIMARY KEY ([Id]),		
)
GO

CREATE TABLE TblCustomerChaseCampaignTemp
(
	CustomerId BIGINT NOT NULL,
	ChaseCampaignId BIGINT NOT NULL,
	IsActive BIT NOT NULL
)
GO

CREATE TABLE TblCustomerChaseChannelTemp
(
	CustomerId BIGINT NOT NULL,
	ChaseChannelLevelId BIGINT NOT NULL,
)
GO

CREATE TABLE TblCustomerChaseProductTemp
(
	CustomerId BIGINT NOT NULL,
	ChaseProductId BIGINT NOT NULL
)
GO