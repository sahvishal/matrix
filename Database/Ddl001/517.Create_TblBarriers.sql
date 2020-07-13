USE [$(dbName)]
Go

CREATE TABLE TblBarrier
(
	Id bigint not null identity(1,1),
	Name varchar(255) not null,
	Alias varchar(255) not null,
	DateCreated datetime not null,
	DateModified datetime  null,
	CreatedBy bigint null,
	ModifiedBy bigint null,
	IsActive bit not null
	CONSTRAINT PK_TblBarrier PRIMARY KEY (Id),
	CONSTRAINT FK_TblBarrier_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID),
	CONSTRAINT FK_TblBarrier_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)
)
GO

