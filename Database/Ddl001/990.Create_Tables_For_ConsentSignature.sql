USE [$(dbName)]
GO

CREATE TABLE TblFluConsentSignature
(
	[EventCustomerId] BIGINT NOT NULL,
	[SignatureFileId] BIGINT NOT NULL,
	[ConsentSignedDate] DATETIME NOT NULL,
	[ClinicalProviderSignatureFileId] BIGINT NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[Version] INT NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblFluConsentSignature_IsActive DEFAULT 0,
	CONSTRAINT PK_TblFluConsentSignature PRIMARY KEY (EventCustomerId, SignatureFileId),
	CONSTRAINT FK_TblFluConsentSignature_TblEventCustomers FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers] ([EventCustomerId]),
	CONSTRAINT FK_TblFluConsentSignature_TblFile FOREIGN KEY ([SignatureFileId]) REFERENCES [TblFile] ([FileId]),
	CONSTRAINT FK_TblFluConsentSignature_TblFile_ClinicalProviderSignatureFileId FOREIGN KEY ([ClinicalProviderSignatureFileId]) REFERENCES [TblFile] ([FileId]),
	CONSTRAINT FK_TblFluConsentSignature_TblOrganizationRoleUser FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId])
)

GO


CREATE TABLE TblParticipationConsentSignature
(
	[EventCustomerId] BIGINT NOT NULL,
	[SignatureFileId] BIGINT NOT NULL,
	[ConsentSignedDate] DATETIME NOT NULL,
	[InsuranceSignatureFileId] BIGINT NOT NULL,
	[InsuranceConsentSignedDate] DATETIME NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[Version] INT NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblParticipationConsentSignature_IsActive DEFAULT 0,
	CONSTRAINT PK_TblParticipationConsentSignature PRIMARY KEY (EventCustomerId, SignatureFileId),
	CONSTRAINT FK_TblParticipationConsentSignature_TblEventCustomers FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers] ([EventCustomerId]),
	CONSTRAINT FK_TblParticipationConsentSignature_TblFile_SignatureFileId FOREIGN KEY ([SignatureFileId]) REFERENCES [TblFile] ([FileId]),
	CONSTRAINT FK_TblParticipationConsentSignature_TblFile_InsuranceSignatureFileId FOREIGN KEY ([InsuranceSignatureFileId]) REFERENCES [TblFile] ([FileId]),
	CONSTRAINT FK_TblParticipationConsentSignature_TblOrganizationRoleUser FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId])
)

GO


CREATE TABLE TblPhysicianRecordRequestSignature
(
	[EventCustomerId] BIGINT NOT NULL,
	[SignatureFileId] BIGINT NOT NULL,
	[ConsentSignedDate] DATETIME NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[Version] INT NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblPhysicianRecordRequestSignature_IsActive DEFAULT 0,
	CONSTRAINT PK_TblPhysicianRecordRequestSignature PRIMARY KEY (EventCustomerId, SignatureFileId),
	CONSTRAINT FK_TblPhysicianRecordRequestSignature_TblEventCustomers FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers] ([EventCustomerId]),
	CONSTRAINT FK_TblPhysicianRecordRequestSignature_TblFile FOREIGN KEY ([SignatureFileId]) REFERENCES [TblFile] ([FileId]),
	CONSTRAINT FK_TblPhysicianRecordRequestSignature_TblOrganizationRoleUser FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId])
)

GO


CREATE TABLE TblExitInterviewSignature
(
	[EventCustomerId] BIGINT NOT NULL,
	[QuestionId] BIGINT NOT NULL,
	[SignatureFileId] BIGINT NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] BIGINT NOT NULL,
	[Version] INT NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT DF_TblExitInterviewSignature_IsActive DEFAULT 0,
	CONSTRAINT PK_TblExitInterviewSignature PRIMARY KEY (EventCustomerId, QuestionId, SignatureFileId),
	CONSTRAINT FK_TblExitInterviewSignature_TblCheckListQuestion FOREIGN KEY ([QuestionId]) REFERENCES [TblCheckListQuestion] ([Id]),
	CONSTRAINT FK_TblExitInterviewSignature_TblEventCustomers FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers] ([EventCustomerId]),
	CONSTRAINT FK_TblExitInterviewSignature_TblFile FOREIGN KEY ([SignatureFileId]) REFERENCES [TblFile] ([FileId]),
	CONSTRAINT FK_TblExitInterviewSignature_TblOrganizationRoleUser FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserId])
)

GO