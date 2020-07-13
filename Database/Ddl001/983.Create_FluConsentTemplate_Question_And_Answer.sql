USE [$(dbName)]
GO

CREATE TABLE TblFluConsentTemplate
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(512) NULL,
	[IsPublished] BIT NOT NULL CONSTRAINT DF_TblFluConsentTemplate_IsPublished DEFAULT 0,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblFluConsentTemplate_IsActive DEFAULT 0,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[DateModified] DATETIME NULL,
	[ModifiedBy] BIGINT NULL,
	CONSTRAINT PK_TblFluConsentTemplate PRIMARY KEY ([Id]),
	CONSTRAINT FK_TblFluConsentTemplate_TblOrganizationRoleUser_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId]),
	CONSTRAINT FK_TblFluConsentTemplate_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId])
)
GO


CREATE TABLE TblFluConsentQuestion
(
	[Id] BIGINT NOT NULL,
	[Question] VARCHAR(4000) NOT NULL,
	[TypeId] BIGINT NOT NULL,
	[Gender] BIGINT NOT NULL,
	[ParentId] BIGINT NULL,
	[ControlValues] VARCHAR(1000) NULL,
	[ControlValueDelimiter] VARCHAR(5) NULL,
	[Index] BIGINT NOT NULL,
	CONSTRAINT PK_TblFluConsentQuestion PRIMARY KEY ([Id]),
	CONSTRAINT FK_TblFluConsentQuestion_TblLookup_TypeId FOREIGN KEY ([TypeId]) REFERENCES [TblLookup] ([LookupId]),
	CONSTRAINT FK_TblFluConsentQuestion_TblLookup_Gender FOREIGN KEY ([Gender]) REFERENCES [TblLookup] ([LookupId]),
	CONSTRAINT FK_TblFluConsentQuestion_TblFluConsentQuestion_ParentId FOREIGN KEY ([ParentId]) REFERENCES [TblFluConsentQuestion] ([Id])
)
GO


CREATE TABLE TblFluConsentTemplateQuestion
(
	[TemplateId] BIGINT NOT NULL,
	[QuestionId] BIGINT NOT NULL,
	CONSTRAINT PK_TblFluConsentTemplateQuestion PRIMARY KEY ([TemplateId], [QuestionId]),
	CONSTRAINT FK_TblFluConsentTemplateQuestion_TblFluConsentTemplate FOREIGN KEY ([TemplateId]) REFERENCES [TblFluConsentTemplate] ([Id]),
	CONSTRAINT FK_TblFluConsentTemplateQuestion_TblFluConsentQuestion FOREIGN KEY ([QuestionId]) REFERENCES [TblFluConsentQuestion] ([Id])
)
GO


CREATE TABLE TblFluConsentAnswer
(
	[EventCustomerId] BIGINT NOT NULL,
	[QuestionId] BIGINT NOT NULL,
	[Answer] VARCHAR(100) NOT NULL,
	[Version] INT NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblFluConsentAnswer_IsActive DEFAULT 0,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[DateModified] DATETIME NULL,
	[ModifiedBy] BIGINT NULL,
	CONSTRAINT PK_TblFluConsentAnswer PRIMARY KEY ([EventCustomerId], [QuestionId], [Version]),
	CONSTRAINT FK_TblFluConsentAnswer_TblEventCustomers_EventCustomerId FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers] ([EventCustomerId]),
	CONSTRAINT FK_TblFluConsentAnswer_TblFluConsentQuestion_QuestionId FOREIGN KEY ([QuestionId]) REFERENCES [TblFluConsentQuestion] ([Id]),
	CONSTRAINT FK_TblFluConsentAnswer_TblOrganizationRoleUser_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId]),
	CONSTRAINT FK_TblFluConsentAnswer_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId])
)
GO