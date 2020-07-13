USE [$(dbName)]
Go 

CREATE TABLE dbo.TblPcpDisposition
	(
	PcpDispositionId Bigint IDENTITY (1, 1),
	EventCustomerId bigint NOT NULL ,
	DispositionId bigint NOT NULL,
	Notes text NULL,
	CreatedBy bigint NOT NULL,
	CreatedOn datetime NOT NULL,
	ModifiedBy bigint NULL,
	ModifiedOn datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE dbo.TblPcpDisposition 
			ADD CONSTRAINT PK_TblPcpDisposition 
					PRIMARY KEY CLUSTERED (PcpDispositionId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.TblPcpDisposition 
			ADD CONSTRAINT FK_TblPcpDisposition_TblEventCustomers_EventCustomerId 
					FOREIGN KEY	(EventCustomerId) REFERENCES dbo.TblEventCustomers (EventCustomerId) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.TblPcpDisposition 
			ADD CONSTRAINT FK_TblPcpDisposition_TblLookup_LookupId 
					FOREIGN KEY (DispositionId) REFERENCES dbo.TblLookup(LookupId) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.TblPcpDisposition 
			ADD CONSTRAINT FK_TblPcpDisposition_TblOrganizationRoleUser_CreatedBy 
					FOREIGN KEY (CreatedBy) REFERENCES dbo.TblOrganizationRoleUser(OrganizationRoleUserID) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.TblPcpDisposition 
			ADD CONSTRAINT FK_TblPcpDisposition_TblOrganizationRoleUser_ModifiedBy 
					FOREIGN KEY (ModifiedBy) REFERENCES dbo.TblOrganizationRoleUser(OrganizationRoleUserID) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
	
GO
