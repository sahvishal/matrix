USE [$(dbName)]
GO


CREATE Table TblCustomerTargeted
(
Id bigint not null identity(1,1),
CustomerId bigint not null,
ForYear int not null,
IsTargated bit NOT NULL,
CreatedBy bigint not null,
DateCreated datetime not null,
ModifiedBy bigint null,
DateModified datetime null,
)

GO

Alter Table TblCustomerTargeted
Add Constraint PK_TblCustomerTargeted PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

Alter Table TblCustomerTargeted
Add Constraint FK_TblCustomerTargeted_TblCustomerProfile_CustomerId
Foreign Key (CustomerId)
References [TblCustomerProfile](CustomerId)
GO

Alter Table TblCustomerTargeted
Add Constraint FK_TblCustomerTargeted_TblOrganizationRoleUser_CreatedBy
Foreign Key ([CreatedBy])
References [TblOrganizationRoleUser](OrganizationRoleUserID)
GO

Alter Table TblCustomerTargeted
Add Constraint FK_TblCustomerTargeted_TblOrganizationRoleUser_ModifiedBy
Foreign Key (ModifiedBy)
References [TblOrganizationRoleUser](OrganizationRoleUserID)
GO