USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblPhysicianLabTest](
	[LabTestLicenseId] BIGINT IDENTITY(1,1) NOT NULL,
	[PhysicianId] BIGINT NOT NULL,
	[StateId] BIGINT NOT NULL,	
	[IfobtLicenseNo] [varchar](50) NOT NULL,	
	[MicroalbumineLicenseNo] [varchar](50) NOT NULL,	
	[DateCreated] DATETIME NOT NULL,
	[DateModified] DATETIME NULL,
	[IsActive] BIT NOT NULL,
	[IsDefault] BIT NOT NULL,
	CONSTRAINT PK_TblPhysicianLabTest PRIMARY KEY([LabTestLicenseId])
	) ON [PRIMARY]

GO


ALTER TABLE [dbo].[TblPhysicianLabTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPhysicianLabTest_TblPhysicianProfile] FOREIGN KEY([PhysicianID])
REFERENCES [dbo].[TblPhysicianProfile] ([PhysicianID])
GO

ALTER TABLE [dbo].[TblPhysicianLabTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPhysicianLabTest_TblState] FOREIGN KEY([StateId])
REFERENCES [dbo].[TblState] ([StateID])
GO


