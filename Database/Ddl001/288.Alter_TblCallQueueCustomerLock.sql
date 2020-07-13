USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCallQueueCustomerLock ADD
	CreatedOn DateTime Not NULL ,
	CreatedBy bigint NOT NULL CONSTRAINT FK_TblCallQueueCustomerLock_TblOrganizationRoleUser 
								FOREIGN KEY (CreatedBy ) REFERENCES dbo.TblOrganizationRoleUser( OrganizationRoleUserID)
	
GO



