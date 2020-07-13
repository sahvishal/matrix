USE [$(dbName)]
GO

CREATE TABLE [TblCallRoundCallQueue]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[HealthPlanId] BIGINT NOT NULL,
	[CustomerId] BIGINT NOT NULL,
	[Status] BIGINT NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[DateModified] [datetime] NULL,		
	[CallDate] [datetime] NOT NULL,	
	CONSTRAINT PK_TblCallRoundCallQueue PRIMARY KEY([Id]),
	CONSTRAINT FK_TblCallRoundCallQueue_TblAccount FOREIGN KEY ([HealthPlanId]) REFERENCES [TblAccount] ([AccountID]),
	CONSTRAINT FK_TblCallRoundCallQueue_TblCustomerProfile_CustomerId FOREIGN KEY([CustomerId]) REFERENCES [TblCustomerProfile] ([CustomerID]),	
	CONSTRAINT FK_TblCallRoundCallQueue_TblLookup_Status FOREIGN KEY([Status]) REFERENCES [TblLookup] ([LookupId]),	
	CONSTRAINT FK_TblCallRoundCallQueue_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
)
GO

CREATE TABLE [TblCallRoundCallQueueCriteriaAssignment]
(
	[CallRoundCallQueueId] BIGINT NOT NULL,
	[CriteriaId] BIGINT NOT NULL,
	CONSTRAINT PK_TblCallRoundCallQueueCriteriaAssignment PRIMARY KEY([CallRoundCallQueueId], [CriteriaId]),
	CONSTRAINT FK_TblCallRoundCallQueueCriteriaAssignment_TblCallRoundCallQueue FOREIGN KEY([CallRoundCallQueueId]) REFERENCES [TblCallRoundCallQueue](Id),
	CONSTRAINT FK_TblCallRoundCallQueueCriteriaAssignment_TblHealthPlanCallQueueCriteria FOREIGN KEY([CriteriaId]) REFERENCES [TblHealthPlanCallQueueCriteria](Id)
)
GO

CREATE TABLE [TblFillEventCallQueue]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[HealthPlanId] BIGINT NOT NULL,
	[CustomerId] BIGINT NOT NULL,
	[Status] BIGINT NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[DateModified] [datetime] NULL,		
	[CallDate] [datetime] NOT NULL,
	[EventIds] [varchar](2048) NULL,
	CONSTRAINT PK_TblFillEventCallQueue PRIMARY KEY([Id]),
	CONSTRAINT FK_TblFillEventCallQueue_TblAccount FOREIGN KEY ([HealthPlanId]) REFERENCES [TblAccount] ([AccountID]),
	CONSTRAINT FK_TblFillEventCallQueue_TblCustomerProfile_CustomerId FOREIGN KEY([CustomerId]) REFERENCES [TblCustomerProfile] ([CustomerID]),	
	CONSTRAINT FK_TblFillEventCallQueue_TblLookup_Status FOREIGN KEY([Status]) REFERENCES [TblLookup] ([LookupId]),	
	CONSTRAINT FK_TblFillEventCallQueue_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
)
GO

CREATE TABLE [TblFillEventCallQueueCriteriaAssignment]
(
	[FillEventCallQueueId] BIGINT NOT NULL,
	[CriteriaId] BIGINT NOT NULL,
	CONSTRAINT PK_TblFillEventCallQueueCriteriaAssignment PRIMARY KEY([FillEventCallQueueId], [CriteriaId]),
	CONSTRAINT FK_TblFillEventCallQueueCriteriaAssignment_TblFillEventCallQueue FOREIGN KEY([FillEventCallQueueId]) REFERENCES [TblFillEventCallQueue](Id),
	CONSTRAINT FK_TblFillEventCallQueueCriteriaAssignment_TblHealthPlanCallQueueCriteria FOREIGN KEY([CriteriaId]) REFERENCES [TblHealthPlanCallQueueCriteria](Id)
)
GO


CREATE TABLE [TblNoShowCallQueue]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[HealthPlanId] BIGINT NOT NULL,
	[CustomerId] BIGINT NOT NULL,
	[Status] BIGINT NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[DateModified] [datetime] NULL,		
	[CallDate] [datetime] NOT NULL,	
	CONSTRAINT PK_TblNoShowCallQueue PRIMARY KEY([Id]),
	CONSTRAINT FK_TblNoShowCallQueue_TblAccount FOREIGN KEY ([HealthPlanId]) REFERENCES [TblAccount] ([AccountID]),
	CONSTRAINT FK_TblNoShowCallQueue_TblCustomerProfile_CustomerId FOREIGN KEY([CustomerId]) REFERENCES [TblCustomerProfile] ([CustomerID]),	
	CONSTRAINT FK_TblNoShowCallQueue_TblLookup_Status FOREIGN KEY([Status]) REFERENCES [TblLookup] ([LookupId]),	
	CONSTRAINT FK_TblNoShowCallQueue_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
)
GO

CREATE TABLE [TblNoShowCallQueueCriteriaAssignment]
(
	[NoShowCallQueueId] BIGINT NOT NULL,
	[CriteriaId] BIGINT NOT NULL,
	CONSTRAINT PK_TblNoShowCallQueueCriteriaAssignment PRIMARY KEY([NoShowCallQueueId], [CriteriaId]),
	CONSTRAINT FK_TblNoShowCallQueueCriteriaAssignment_TblNoShowCallQueue FOREIGN KEY([NoShowCallQueueId]) REFERENCES [TblNoShowCallQueue](Id),
	CONSTRAINT FK_TblNoShowCallQueueCriteriaAssignment_TblHealthPlanCallQueueCriteria FOREIGN KEY([CriteriaId]) REFERENCES [TblHealthPlanCallQueueCriteria](Id)
)
GO

CREATE TABLE [TblUncontactedCustomerCallQueue]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[HealthPlanId] BIGINT NOT NULL,
	[CustomerId] BIGINT NOT NULL,
	[Status] BIGINT NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[DateModified] [datetime] NULL,		
	[CallDate] [datetime] NOT NULL,	
	CONSTRAINT PK_TblUncontactedCustomerCallQueue PRIMARY KEY([Id]),
	CONSTRAINT FK_TblUncontactedCustomerCallQueue_TblAccount FOREIGN KEY ([HealthPlanId]) REFERENCES [TblAccount] ([AccountID]),
	CONSTRAINT FK_TblUncontactedCustomerCallQueue_TblCustomerProfile_CustomerId FOREIGN KEY([CustomerId]) REFERENCES [TblCustomerProfile] ([CustomerID]),	
	CONSTRAINT FK_TblUncontactedCustomerCallQueue_TblLookup_Status FOREIGN KEY([Status]) REFERENCES [TblLookup] ([LookupId]),	
	CONSTRAINT FK_TblUncontactedCustomerCallQueue_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
)
GO

CREATE TABLE [TblUncontactedCustomerCallQueueCriteriaAssignment]
(
	[UncontactedCustomerId] BIGINT NOT NULL,
	[CriteriaId] BIGINT NOT NULL,
	CONSTRAINT PK_TblUncontactedCustomerCallQueueCriteriaAssignment PRIMARY KEY([UncontactedCustomerId], [CriteriaId]),
	CONSTRAINT FK_TblUncontactedCustomerCallQueueCriteriaAssignment_TblUncontactedCustomerCallQueue FOREIGN KEY([UncontactedCustomerId]) REFERENCES [TblUncontactedCustomerCallQueue](Id),
	CONSTRAINT FK_TblUncontactedCustomerCallQueueCriteriaAssignment_TblHealthPlanCallQueueCriteria FOREIGN KEY([CriteriaId]) REFERENCES [TblHealthPlanCallQueueCriteria](Id)
)
GO

CREATE TABLE [TblMailRoundCallQueue]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[HealthPlanId] BIGINT NOT NULL,
	[CustomerId] BIGINT NOT NULL,
	[Status] BIGINT NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[DateModified] [datetime] NULL,		
	[CallDate] [datetime] NOT NULL,	
	CONSTRAINT PK_TblMailRoundCallQueue PRIMARY KEY([Id]),
	CONSTRAINT FK_TblMailRoundCallQueue_TblAccount FOREIGN KEY ([HealthPlanId]) REFERENCES [TblAccount] ([AccountID]),
	CONSTRAINT FK_TblMailRoundCallQueue_TblCustomerProfile_CustomerId FOREIGN KEY([CustomerId]) REFERENCES [TblCustomerProfile] ([CustomerID]),	
	CONSTRAINT FK_TblMailRoundCallQueue_TblLookup_Status FOREIGN KEY([Status]) REFERENCES [TblLookup] ([LookupId]),	
	CONSTRAINT FK_TblMailRoundCallQueue_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
)
GO

CREATE TABLE [TblMailRoundCallQueueCriteriaAssignment]
(
	[MailRoundCallQueueId] BIGINT NOT NULL,
	[CriteriaId] BIGINT NOT NULL,
	CONSTRAINT PK_TblMailRoundCallQueueCriteriaAssignment PRIMARY KEY([MailRoundCallQueueId], [CriteriaId]),
	CONSTRAINT FK_TblMailRoundCallQueueCriteriaAssignment_TblMailRoundCallQueue FOREIGN KEY([MailRoundCallQueueId]) REFERENCES [TblMailRoundCallQueue](Id),
	CONSTRAINT FK_TblMailRoundCallQueueCriteriaAssignment_TblHealthPlanCallQueueCriteria FOREIGN KEY([CriteriaId]) REFERENCES [TblHealthPlanCallQueueCriteria](Id)
)
GO


CREATE TABLE [TblLanguageBarrierCallQueue]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[HealthPlanId] BIGINT NOT NULL,
	[CustomerId] BIGINT NOT NULL,
	[Status] BIGINT NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[DateModified] [datetime] NULL,		
	[CallDate] [datetime] NOT NULL,	
	CONSTRAINT PK_TblLanguageBarrierCallQueue PRIMARY KEY([Id]),
	CONSTRAINT FK_TblLanguageBarrierCallQueue_TblAccount FOREIGN KEY ([HealthPlanId]) REFERENCES [TblAccount] ([AccountID]),
	CONSTRAINT FK_TblLanguageBarrierCallQueue_TblCustomerProfile_CustomerId FOREIGN KEY([CustomerId]) REFERENCES [TblCustomerProfile] ([CustomerID]),	
	CONSTRAINT FK_TblLanguageBarrierCallQueue_TblLookup_Status FOREIGN KEY([Status]) REFERENCES [TblLookup] ([LookupId]),	
	CONSTRAINT FK_TblLanguageBarrierCallQueue_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
)
GO

CREATE TABLE [TblLanguageBarrierCallQueueCriteriaAssignment]
(
	[LanguageBarrierCallQueueId] BIGINT NOT NULL,
	[CriteriaId] BIGINT NOT NULL,
	CONSTRAINT PK_TblLanguageBarrierCallQueueCriteriaAssignment PRIMARY KEY([LanguageBarrierCallQueueId], [CriteriaId]),
	CONSTRAINT FK_TblLanguageBarrierCallQueueCriteriaAssignment_TblLanguageBarrierCallQueue FOREIGN KEY([LanguageBarrierCallQueueId]) REFERENCES [TblLanguageBarrierCallQueue](Id),
	CONSTRAINT FK_TblLanguageBarrierCallQueueCriteriaAssignment_TblHealthPlanCallQueueCriteria FOREIGN KEY([CriteriaId]) REFERENCES [TblHealthPlanCallQueueCriteria](Id)
)
GO

CREATE TABLE [TblCustomerLockForCall]
(
	[CustomerId] [bigint] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	CONSTRAINT PK_TblCustomerLockForCall PRIMARY KEY([CustomerId]),
	CONSTRAINT FK_TblCustomerLockForCall_TblCustomerProfile FOREIGN KEY([CustomerId]) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblCustomerLockForCall_TblOrganizationRoleUser_CreatedBy FOREIGN KEY([CreatedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
)
GO

CREATE TABLE [TblCustomerCallAttempts]
(
	[CustomerId] [bigint] NOT NULL,
	[Attempt] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	CONSTRAINT PK_TblCustomerCallAttempts PRIMARY KEY([CustomerId]),
	CONSTRAINT FK_TblCustomerCallAttempts_TblCustomerProfile FOREIGN KEY([CustomerId]) REFERENCES [TblCustomerProfile](CustomerId),
	CONSTRAINT FK_TblCustomerCallAttempts_TblOrganizationRoleUser_CreatedBy FOREIGN KEY([UpdatedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
)
GO


ALTER TABLE TblCalls ADD HealthPlanId BIGINT NULL
GO

ALTER TABLE TblCalls
ADD CONSTRAINT FK_TblCalls_TblAccount_HealthPlanId FOREIGN KEY(HealthPlanId) REFERENCES TblAccount(AccountId)
GO

ALTER TABLE TblCalls ADD CallQueueId BIGINT NULL
GO

ALTER TABLE TblCalls
ADD CONSTRAINT FK_TblCalls_TblCallQueue_CallQueueId FOREIGN KEY(CallQueueId) REFERENCES TblCallQueue(CallQueueId)
GO