USE [$(dbName)]
GO

CREATE TABLE TblChaperoneQuestion
(
	[Id] BIGINT NOT NULL,
	[Question] VARCHAR(4000) NOT NULL,
	[TypeId] BIGINT NOT NULL,
	[Gender] BIGINT NOT NULL,
	[ParentId] BIGINT NULL,
	[ControlValues] VARCHAR(1000) NULL,
	[ControlValueDelimiter] VARCHAR(5) NULL,
	[Index] BIGINT NOT NULL,
	CONSTRAINT PK_TblChaperoneQuestion PRIMARY KEY ([Id]),
	CONSTRAINT FK_TblChaperoneQuestion_TblLookup_TypeId FOREIGN KEY ([TypeId]) REFERENCES [TblLookup] ([LookupId]),
	CONSTRAINT FK_TblChaperoneQuestion_TblLookup_Gender FOREIGN KEY ([Gender]) REFERENCES [TblLookup] ([LookupId]),
	CONSTRAINT FK_TblChaperoneQuestion_TblChaperoneQuestion_ParentId FOREIGN KEY ([ParentId]) REFERENCES [TblChaperoneQuestion] ([Id])
)
GO


CREATE TABLE TblChaperoneAnswer
(
	[EventCustomerId] BIGINT NOT NULL,
	[QuestionId] BIGINT NOT NULL,
	[Answer] VARCHAR(MAX) NULL,
	[Version] INT NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblChaperoneAnswer_IsActive DEFAULT 0,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[DateModified] DATETIME NULL,
	[ModifiedBy] BIGINT NULL,
	CONSTRAINT PK_TblChaperoneAnswer PRIMARY KEY ([EventCustomerId], [QuestionId], [Version]),
	CONSTRAINT FK_TblChaperoneAnswer_TblEventCustomers_EventCustomerId FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers] ([EventCustomerId]),
	CONSTRAINT FK_TblChaperoneAnswer_TblChaperoneQuestion_QuestionId FOREIGN KEY ([QuestionId]) REFERENCES [TblChaperoneQuestion] ([Id]),
	CONSTRAINT FK_TblChaperoneAnswer_TblOrganizationRoleUser_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId]),
	CONSTRAINT FK_TblChaperoneAnswer_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId])
)
GO


CREATE TABLE TblChaperoneSignature
(
	[EventCustomerId] BIGINT NOT NULL,
	[SignatureFileId] BIGINT NOT NULL,
	[ConsentSignedDate] DATETIME NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[Version] INT NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblChaperoneSignature_IsActive DEFAULT 0,
	CONSTRAINT PK_TblChaperoneSignature PRIMARY KEY (EventCustomerId, SignatureFileId),
	CONSTRAINT FK_TblChaperoneSignature_TblEventCustomers FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers] ([EventCustomerId]),
	CONSTRAINT FK_TblChaperoneSignature_TblFile FOREIGN KEY ([SignatureFileId]) REFERENCES [TblFile] ([FileId]),
	CONSTRAINT FK_TblChaperoneSignature_TblOrganizationRoleUser FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId])
)
