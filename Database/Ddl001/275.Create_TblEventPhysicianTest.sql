USE [$(dbName)]
Go

ALTER TABLE dbo.TblHospitalPartner ADD	RestrictEvaluation bit NOT NULL CONSTRAINT DF_TblHospitalPartner_RestrictEvaluation DEFAULT 0
Go

ALTER TABLE dbo.TblEventHospitalPartner ADD RestrictEvaluation bit NOT NULL CONSTRAINT DF_TblEventHospitalPartner_RestrictEvaluation DEFAULT 0
Go

CREATE TABLE dbo.TblEventPhysicianTest
	(
	EventId bigint NOT NULL,
	PhysicianId bigint NOT NULL,
	TestId bigint NOT NULL,
	DateCreated [datetime] NOT NULL,
	DateModified [datetime] NOT NULL,
	AssignedByOrgRoleUserId [bigint] NOT NULL,
	ModifiedByOrgRoleUserId [bigint] NOT NULL,
	IsActive bit Not Null default 0,	
	)  ON [PRIMARY]
Go

ALTER TABLE dbo.TblEventPhysicianTest ADD CONSTRAINT
	PK_TblEventPhysicianTest PRIMARY KEY CLUSTERED 
	(
	EventId,
	PhysicianId,
	TestId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE dbo.TblEventPhysicianTest ADD CONSTRAINT
	FK_TblEventPhysicianTest_TblEvents FOREIGN KEY (EventId) REFERENCES dbo.TblEvents (EventID ) 
Go

ALTER TABLE dbo.TblEventPhysicianTest ADD CONSTRAINT
	FK_TblEventPhysicianTest_TblOrganizationRoleUser FOREIGN KEY (PhysicianId ) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID ) 
Go	 

ALTER TABLE dbo.TblEventPhysicianTest ADD CONSTRAINT
	FK_TblEventPhysicianTest_TblTest FOREIGN KEY(TestId) REFERENCES dbo.TblTest(TestID) 
Go
	
ALTER TABLE dbo.TblEventPhysicianTest ADD CONSTRAINT
	FK_TblEventPhysicianTest_AssignedByOrgRoleUserId FOREIGN KEY (AssignedByOrgRoleUserID) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) 
Go
	 
ALTER TABLE dbo.TblEventPhysicianTest ADD CONSTRAINT
	FK_TblEventPhysicianTest_ModifiedByOrgRoleUserId FOREIGN KEY (ModifiedByOrgRoleUserID) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) 
Go