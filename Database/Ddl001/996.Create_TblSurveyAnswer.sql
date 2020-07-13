use [$(dbName)]
Go

CREATE TABLE TblSurveyAnswer
	(
	EventCustomerId bigint NOT NULL,
	QuestionId bigint NOT NULL,
	Answer nvarchar(4000) NOT NULL,
	CreatedOn datetime NOT NULL,
	CreatedBy bigint NOT NULL,
	[Version] int NOT NULL,
	IsActive bit NOT NULL,
	ModifiedOn date NULL,
	ModifiedBy bigint NULL
	)  ON [PRIMARY]
GO
ALTER TABLE TblSurveyAnswer 
	ADD CONSTRAINT PK_TblSurveyAnswer PRIMARY KEY CLUSTERED 
	(EventCustomerId,QuestionId,[Version]) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE TblSurveyAnswer 
	ADD CONSTRAINT	FK_TblSurveyAnswer_TblEventCustomers_EventCustomerId 
		FOREIGN KEY (EventCustomerId) REFERENCES TblEventCustomers (EventCustomerID) 
	
GO
ALTER TABLE TblSurveyAnswer 
	ADD CONSTRAINT	FK_TblSurveyAnswer_TblSurveyQuestion_QuestionId 
		FOREIGN KEY (QuestionId)	REFERENCES TblSurveyQuestion (Id)
	
GO
ALTER TABLE TblSurveyAnswer 
	ADD CONSTRAINT FK_TblSurveyAnswer_TblOrganizationRoleUser_CreatedBy 
		FOREIGN KEY (CreatedBy) REFERENCES TblOrganizationRoleUser (OrganizationRoleUserID)
	
GO
ALTER TABLE TblSurveyAnswer 
	ADD CONSTRAINT	FK_TblSurveyAnswer_TblOrganizationRoleUser_Modifiedby 
		FOREIGN KEY	(ModifiedBy) REFERENCES TblOrganizationRoleUser	(OrganizationRoleUserID)
	
GO
