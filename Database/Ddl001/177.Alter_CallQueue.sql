
USE [$(dbName)]
GO

Alter Table [TblCallQueueCriteria] Add [Sequence] int NOT null
GO

Alter Table [TblCallQueueCustomer] Add AssignedToOrgRoleUserId bigint NOT NULL
GO

ALTER TABLE [dbo].[TblCallQueueCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomer_TblOrganizationRoleUser_Assigned] FOREIGN KEY([AssignedToOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

Alter Table [TblCallQueueCustomer] Add CallQueueCriteriaId bigint NOT NULL
GO

ALTER TABLE [dbo].[TblCallQueueCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomer_TblCallQueueCriteria] FOREIGN KEY([CallQueueCriteriaId])
REFERENCES [dbo].[TblCallQueueCriteria] ([CallQueueCriteriaId])
GO