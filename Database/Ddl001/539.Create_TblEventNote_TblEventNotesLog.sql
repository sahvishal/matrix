USE [$(dbname)]
GO

CREATE TABLE TblEventNote
(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	Note NVARCHAR(MAX) NULL,
	HealthPlanId BIGINT NULL,
	EventDateFrom DATETIME NULL,
	EventDateTo DATETIME NULL,
	Pod VARCHAR(50) NULL,
	IsPublished BIT NOT NULL CONSTRAINT DF_TblEventNote_IsPublished DEFAULT(0),
	DateCreated DATETIME NOT NULL CONSTRAINT DF_TblEventNote_DateCreated DEFAULT GETDATE(),
	DateModified DATETIME NULL,
	CreatedBy BIGINT NOT NULL,
	ModifiedBy BIGINT NULL,
	CONSTRAINT PK_TblEventNotes PRIMARY KEY (Id),
	CONSTRAINT FK_TblEventNotes_TblOrganizationRoleUser_CreatedBy FOREIGN KEY(CreatedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserId),
	CONSTRAINT FK_TblEventNotes_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY(ModifiedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserId)
)
GO

CREATE TABLE TblEventNotesLog
(
	EventNoteId BIGINT NOT NULL,
	EventId BIGINT NOT NULL,
	CONSTRAINT PK_TblEventNotesLog PRIMARY KEY (EventNoteId, EventId),
	CONSTRAINT FK_TblEventNotesLog_TblEventNote FOREIGN KEY(EventNoteId) REFERENCES TblEventNote(Id),
	CONSTRAINT FK_TblEventNotesLog_TblEvents FOREIGN KEY(EventId) REFERENCES TblEvents(EventId)
)
GO