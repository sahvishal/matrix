use [$(dbName)]
Go

CREATE TABLE TblSurveyQuestion
	(
		Id bigint NOT NULL,
		Question varchar(4000) NOT NULL,
		TypeId bigint NOT NULL,
		ParentId bigint NULL,
		Gender bigInt NOT NULL,
		ControlValues varchar(1000) NULL,
		ControlValueDelimiter varchar(5) NULL,
		[Index] int not null, 
		IsActive bit NOT NULL		
	)  ON [PRIMARY]
GO

ALTER TABLE TblSurveyQuestion ADD CONSTRAINT DF_TblSurveyQuestion_IsActive DEFAULT 1 FOR IsActive
GO

ALTER TABLE TblSurveyQuestion 
	ADD CONSTRAINT PK_TblSurveyQuestion PRIMARY KEY CLUSTERED (Id) 
		WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE TblSurveyQuestion 
	ADD CONSTRAINT FK_TblSurveyQuestion_TblSurveyQuestion 
		FOREIGN KEY (ParentId) REFERENCES TblSurveyQuestion	(Id) 
	
GO

ALTER TABLE TblSurveyQuestion 
	ADD CONSTRAINT FK_TblSurveyQuestion_TblLookup_TypeId 
		FOREIGN KEY	(TypeId) REFERENCES TblLookup(LookupId) 
GO


ALTER TABLE TblSurveyQuestion 
	ADD CONSTRAINT FK_TblSurveyQuestion_TblLookup_Gender 
		FOREIGN KEY	(Gender) REFERENCES TblLookup(LookupId) 
GO
