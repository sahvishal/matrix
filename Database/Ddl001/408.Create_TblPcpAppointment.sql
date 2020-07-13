USE [$(dbName)]
Go 

CREATE TABLE dbo.TblPcpAppointment
	(
	EventCustomerId bigint NOT NULL,
	AppointmentOn datetime NOT NULL,
	CreatedBy bigint NULL,
	CreatedOn datetime NULL,
	ModifiedBy bigint NULL,
	ModifiedOn datetime NULL
	)  
	 
GO

ALTER TABLE dbo.TblPcpAppointment 
			ADD CONSTRAINT PK_TblPcpAppointment 
					PRIMARY KEY CLUSTERED (EventCustomerId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.TblPcpAppointment 
			ADD CONSTRAINT FK_TblPcpAppointment_TblEventCustomers_EventCustomerId 
					FOREIGN KEY	(EventCustomerId) REFERENCES dbo.TblEventCustomers	(EventCustomerId) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.TblPcpAppointment 
			ADD CONSTRAINT FK_TblPcpAppointment_TblOrganizationRoleUser_CreatedBy 
					FOREIGN KEY (CreatedBy) REFERENCES dbo.TblOrganizationRoleUser(OrganizationRoleUserID) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.TblPcpAppointment 
			ADD CONSTRAINT FK_TblPcpAppointment_TblOrganizationRoleUser_ModifiedBy 
					FOREIGN KEY (ModifiedBy) REFERENCES dbo.TblOrganizationRoleUser(OrganizationRoleUserID) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
	
GO
