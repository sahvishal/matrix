Use [$(dbname)]
go

Insert Into TblCustomerIcdCodeTemp (CustomerId,IcdCodeId)
	select CustomerId,IcdCodeId from TblCustomerIcdCode

	insert into TblEventCustomerIcdCodes (EventCustomerId,IcdCodeId)
	select ec.EventCustomerID,cicdc.IcdCodeId from tblEventCustomers ec
		inner join TblCustomerIcdCode cicdc on ec.CustomerID = cicdc.CustomerId

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerIcdCode_CustomerProfile_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerIcdCode]'))
		ALTER TABLE [dbo].[TblCustomerIcdCode] DROP CONSTRAINT [FK_CustomerIcdCode_CustomerProfile_CustomerId]
	GO

	IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerIcdCode_IcdCodes_IcdCodeId]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerIcdCode]'))
		ALTER TABLE [dbo].[TblCustomerIcdCode] DROP CONSTRAINT [FK_CustomerIcdCode_IcdCodes_IcdCodeId]
	GO

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerIcdCode]') AND type in (N'U'))
		DROP TABLE [dbo].[TblCustomerIcdCode]
	GO

Create Table TblCustomerIcdCode
	(
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		CustomerId bigint not null constraint FK_CustomerIcdCode_CustomerProfile_CustomerId  FOREIGN KEY REFERENCES tblCustomerProfile(CustomerID),
		IcdCodeId bigint not null constraint FK_CustomerIcdCode_IcdCodes_IcdCodeId Foreign Key References TblIcdCodes(Id),
		[DateCreated] [datetime] NOT NULL,
		[DateEnd] [dateTime] null,
		[CreatedByOrgRoleUserId] [bigint] NOT NULL,
		[IsActive] [bit] NOT NULL,
		CONSTRAINT PK_TblCustomerIcdCode PRIMARY KEY ([Id]),	
	)
	Go

	
ALTER TABLE [dbo].[TblCustomerIcdCode]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerIcdCode_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCustomerIcdCode] CHECK CONSTRAINT [FK_TblCustomerIcdCode_TblOrganizationRoleUser_CreatedBy]
GO

insert Into TblCustomerIcdCode (CustomerId,IcdCodeId,DateCreated,CreatedByOrgRoleUserId,IsActive)
	select CustomerId,IcdCodeId,getDate(),1,1 from TblCustomerIcdCodeTemp
