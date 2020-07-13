use [$(dbName)]
Go

CREATE TABLE dbo.TblCheckListAnswer
	(
	EventCustomerId bigint NOT NULL,
	QuestionId bigint NOT NULL,
	Answer nvarchar(50) NOT NULL,
	CreatedOn datetime NOT NULL,
	CreatedBy bigint NOT NULL,
	[Version] int NOT NULL,
	IsActive bit NOT NULL,
	ModifiedOn date NULL,
	ModifiedBy bigint NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblCheckListAnswer 
	ADD CONSTRAINT PK_TblCheckListAnswer PRIMARY KEY CLUSTERED 
	(EventCustomerId,QuestionId,[Version]) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE dbo.TblCheckListAnswer 
	ADD CONSTRAINT	FK_TblCheckListAnswer_TblEventCustomers_EventCustomerId 
		FOREIGN KEY (EventCustomerId) REFERENCES dbo.TblEventCustomers (EventCustomerID) 
	
GO
ALTER TABLE dbo.TblCheckListAnswer 
	ADD CONSTRAINT	FK_TblCheckListAnswer_TblCheckListQuestion_QuestionId 
		FOREIGN KEY (QuestionId)	REFERENCES dbo.TblCheckListQuestion (Id)
	
GO
ALTER TABLE dbo.TblCheckListAnswer 
	ADD CONSTRAINT FK_TblCheckListAnswer_TblOrganizationRoleUser_CreatedBy 
		FOREIGN KEY (CreatedBy) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID)
	
GO
ALTER TABLE dbo.TblCheckListAnswer 
	ADD CONSTRAINT	FK_TblCheckListAnswer_TblOrganizationRoleUser_Modifiedby 
		FOREIGN KEY	(ModifiedBy) REFERENCES dbo.TblOrganizationRoleUser	(OrganizationRoleUserID)
	
GO
