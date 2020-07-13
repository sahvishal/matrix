USE [$(dbName)]
Go

Create Table TblExportableReports
(
		Id bigint NOT NULL  CONSTRAINT PK_TblExportableReports PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		Name varchar(1024) Not Null,		
		Alias varchar(1024) Not Null,
		CreatedOn Datetime Not Null,		
)
Go

Create Table TblExportableReportsQueue
(
		Id bigint NOT NULL IDENTITY (1, 1) CONSTRAINT PK_TblExportableReportsQueue PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		ReportId bigInt Not Null CONSTRAINT FK_TblExportableReportsQueue_TblExportableReports_ReportId FOREIGN KEY (ReportId) REFERENCES dbo.TblExportableReports  (Id),
		FilterData nvarchar (max) null,
		RequestedBy bigint NOT NULL CONSTRAINT FK_TblExportableReportsQueue_TblOrganizationRoleUser_RequestedBy FOREIGN KEY (RequestedBy) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID),
		RequestedOn DateTime not null,
		FileId bigint NULL CONSTRAINT FK_TblExportableReportsQueue_TblFile_FileId FOREIGN KEY (FileId) REFERENCES dbo.TblFile (FileId),
		StartedOn DateTime Null,
		EndedOn DateTime Null,
		StatusId bigint Not Null CONSTRAINT FK_TblExportableReportsQueue_TblLookup_StatusId FOREIGN KEY (StatusId) REFERENCES dbo.TblLookup (lookupId),
)
