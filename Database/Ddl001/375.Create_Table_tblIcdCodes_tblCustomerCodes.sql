USE [$(dbName)]
GO

Create Table TblIcdCodes
	(
		Id bigInt Identity(1,1)  CONSTRAINT PK_TblIcdCodes_Id  Primary Key, 
		IcdCode varchar(512) not null,
		DateCreated DateTime not Null,
		CreatedBy bigInt not null constraint FK_TblIcdCodes_TblOrganizationRoleUser_CreatedBy foreign key References TblOrganizationRoleUser (OrganizationRoleUserID),
		DateModified DateTime null,
		ModifiedBy bigInt null constraint FK_TblIcdCodes_TblOrganizationRoleUser_ModifiedBy foreign key References TblOrganizationRoleUser (OrganizationRoleUserID),
		IsActive bit not null CONSTRAINT DF_TblIcdCodes_IsActive Default (1) 
	)
	Go

Create Table TblCustomerIcdCode
	(
		CustomerId bigint not null constraint FK_CustomerIcdCode_CustomerProfile_CustomerId  FOREIGN KEY REFERENCES tblCustomerProfile(CustomerID),
		IcdCodeId bigint not null constraint FK_CustomerIcdCode_IcdCodes_IcdCodeId Foreign Key References TblIcdCodes(Id)
	)
	Go

ALTER TABLE dbo.TblCustomerIcdCode ADD CONSTRAINT PK_TblCustomerIcdCode PRIMARY KEY CLUSTERED 
		(CustomerId,	IcdCodeId)
		 WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	Go

