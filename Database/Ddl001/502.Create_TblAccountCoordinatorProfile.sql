USE [$(dbname)]
GO

CREATE TABLE TblAccountCoordinatorProfile
(
	OrganizationRoleUserId BIGINT NOT NULL ,
	IsClinicalCoordinator BIT NOT NULL CONSTRAINT DF_TblAccountCoordinatorProfile_IsClinicalCoordinator DEFAULT 0,
	CONSTRAINT FK_TblAccountCoordinatorProfile_TblOrganizationRoleUser FOREIGN KEY (OrganizationRoleUserId) REFERENCES [TblOrganizationRoleUser](OrganizationRoleUserId)
)
alter table TblAccountCoordinatorProfile add CONSTRAINT PK_TblAccountCoordinatorProfile PRIMARY KEY (OrganizationRoleUserId)
GO