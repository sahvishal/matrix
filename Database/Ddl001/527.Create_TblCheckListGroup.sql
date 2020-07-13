use [$(dbName)]
Go

CREATE TABLE dbo.TblCheckListGroup
	(
		Id bigint NOT NULL IDENTITY (1, 1),
		Name varchar(512) NOT NULL,
		[Description] varchar(1024) NOT NULL,
		TypeId bigint NOT NULL,
		ParentId bigint NULL,
		Alias varchar(512) Not Null,
		IsActive bit NOT NULL
	)  ON [PRIMARY]	 
GO

ALTER TABLE dbo.TblCheckListGroup ADD CONSTRAINT DF_TblCheckListGroup_IsActive DEFAULT 1 FOR IsActive
GO

ALTER TABLE dbo.TblCheckListGroup 
	ADD CONSTRAINT PK_TblCheckListGroup PRIMARY KEY CLUSTERED (Id) 
		WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TblCheckListGroup 
	ADD CONSTRAINT FK_TblCheckListGroup_TblLookup_TypeId 
		FOREIGN KEY (TypeId) REFERENCES dbo.TblLookup (LookupId) 
	
GO
ALTER TABLE dbo.TblCheckListGroup 
	ADD CONSTRAINT FK_TblCheckListGroup_TblCheckListGroup_ParentId 
		FOREIGN KEY (ParentId) REFERENCES dbo.TblCheckListGroup (Id) 
	
GO