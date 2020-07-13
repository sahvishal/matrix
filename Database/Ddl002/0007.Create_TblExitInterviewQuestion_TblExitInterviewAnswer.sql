USE [$(dbName)]
GO

CREATE TABLE TblExitInterviewQuestion
(
	Id BIGINT NOT NULL,
	Question VARCHAR(2048) NOT NULL,
	TypeId BIGINT NOT NULL,
	Gender BIGINT NOT NULL,
	ParentId BIGINT NULL,
	ControlValues VARCHAR(128) NULL,
	ControlValueDelimiter VARCHAR(1) NULL,
	[Index] INT NOT NULL,
	CONSTRAINT PK_TblExitInterviewQuestion PRIMARY KEY (Id),
	CONSTRAINT FK_TblExitInterviewQuestion_TblLookup_TypeId FOREIGN KEY (TypeId) REFERENCES [TblLookup]([LookupId]),
	CONSTRAINT FK_TblExitInterviewQuestion_TblLookup_Gender FOREIGN KEY (Gender) REFERENCES [TblLookup]([LookupId]),
	CONSTRAINT FK_TblExitInterviewQuestion_TblExitInterviewQuestion FOREIGN KEY (ParentId) REFERENCES [TblExitInterviewQuestion]([Id])
)

GO


CREATE TABLE TblExitInterviewAnswer
(
	EventCustomerId BIGINT NOT NULL,
	QuestionId BIGINT NOT NULL,
	Answer VARCHAR(128) NOT NULL,
	[Version] INT NOT NULL,
	IsActive BIT NOT NULL CONSTRAINT DF_TblExitInterviewAnswer_IsActive DEFAULT 0,
	DateCreated DATETIME NOT NULL,
	CreatedBy BIGINT NOT NULL,
	DateModified DATETIME NULL,
	ModifiedBy BIGINT NULL,
	CONSTRAINT PK_TblExitInterviewAnswer PRIMARY KEY (EventCustomerId, QuestionId, [Version]),
	CONSTRAINT FK_TblExitInterviewAnswer_TblEventCustomers FOREIGN KEY (EventCustomerId) REFERENCES [TblEventCustomers]([EventCustomerId]),
	CONSTRAINT FK_TblExitInterviewAnswer_TblExitInterviewQuestion FOREIGN KEY ([QuestionId]) REFERENCES [TblExitInterviewQuestion]([Id]),
	CONSTRAINT FK_TblExitInterviewAnswer_TblOrganizationRoleUser_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserID]),
	CONSTRAINT FK_TblExitInterviewAnswer_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY ([ModifiedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserID])
)

GO


ALTER TABLE TblFluConsentSignature
ALTER COLUMN ClinicalProviderSignatureFileId BIGINT NULL
GO