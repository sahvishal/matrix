use [$(dbName)]
Go

CREATE TABLE dbo.TblCheckListQuestion
	(
		Id bigint NOT NULL,
		Question varchar(4000) NOT NULL,
		TypeId bigint NOT NULL,
		ParentId bigint NULL,
		GroupId BigInt Not Null,
		Gender bigInt NOT NULL,
		ControlValues varchar(1000) NULL,
		ControlValueDelimiter varchar(5) NULL,
		[Index] int not null, 
		IsActive bit NOT NULL		
	)  ON [PRIMARY]
GO

ALTER TABLE dbo.TblCheckListQuestion ADD CONSTRAINT DF_TblCheckListQuestion_IsActive DEFAULT 1 FOR IsActive
GO

ALTER TABLE dbo.TblCheckListQuestion 
	ADD CONSTRAINT PK_TblCheckListQuestion PRIMARY KEY CLUSTERED (Id) 
		WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.TblCheckListQuestion 
	ADD CONSTRAINT FK_TblCheckListQuestion_TblCheckListQuestion 
		FOREIGN KEY (ParentId) REFERENCES dbo.TblCheckListQuestion	(Id) 
	
GO

ALTER TABLE dbo.TblCheckListQuestion 
	ADD CONSTRAINT FK_TblCheckListQuestion_TblCheckListGroup_GroupId 
		FOREIGN KEY	(GroupId) REFERENCES dbo.TblCheckListGroup(Id) 
GO

ALTER TABLE dbo.TblCheckListQuestion 
	ADD CONSTRAINT FK_TblCheckListQuestion_TblLookup_TypeId 
		FOREIGN KEY	(TypeId) REFERENCES dbo.TblLookup(LookupId) 
GO


ALTER TABLE dbo.TblCheckListQuestion 
	ADD CONSTRAINT FK_TblCheckListQuestion_TblLookup_Gender 
		FOREIGN KEY	(Gender) REFERENCES dbo.TblLookup(LookupId) 
GO
