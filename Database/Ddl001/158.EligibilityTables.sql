USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblInsuranceCompany_InNetwork]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblInsuranceCompany] DROP CONSTRAINT [DF_TblInsuranceCompany_InNetwork]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblInsuranceCompany_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblInsuranceCompany] DROP CONSTRAINT [DF_TblInsuranceCompany_IsActive]
END

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEligibility_TblInsuranceCompany]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEligibility]'))
ALTER TABLE [dbo].[TblEligibility] DROP CONSTRAINT [FK_TblEligibility_TblInsuranceCompany]
GO

/****** Object:  Table [dbo].[TblInsuranceCompany]    Script Date: 10/08/2013 20:41:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblInsuranceCompany]') AND type in (N'U'))
DROP TABLE [dbo].[TblInsuranceCompany]
GO

/****** Object:  Table [dbo].[TblInsuranceCompany]    Script Date: 10/08/2013 20:41:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblInsuranceCompany](
	[InsuranceCompanyId] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](2000) NOT NULL,
	[EdiPayerNumber] [varchar] (50) NOT NULL,
	[Address] [varchar](4000) NULL,
	[InNetwork] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblInsuranceCompany] PRIMARY KEY CLUSTERED 
(
	[InsuranceCompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblInsuranceCompany] ADD  CONSTRAINT [DF_TblInsuranceCompany_InNetwork]  DEFAULT ((1)) FOR [InNetwork]
GO

ALTER TABLE [dbo].[TblInsuranceCompany] ADD  CONSTRAINT [DF_TblInsuranceCompany_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

-------------------------------TblInsuranceServiceType------------------------

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblInsuranceServiceType_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblInsuranceServiceType] DROP CONSTRAINT [DF_TblInsuranceServiceType_IsActive]
END

GO

/****** Object:  Table [dbo].[TblInsuranceServiceType]    Script Date: 10/08/2013 20:42:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblInsuranceServiceType]') AND type in (N'U'))
DROP TABLE [dbo].[TblInsuranceServiceType]
GO

/****** Object:  Table [dbo].[TblInsuranceServiceType]    Script Date: 10/08/2013 20:42:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblInsuranceServiceType](
	[InsuranceServiceTypeId] [bigint] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblInsuranceServiceType] PRIMARY KEY CLUSTERED 
(
	[InsuranceServiceTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblInsuranceServiceType] ADD  CONSTRAINT [DF_TblInsuranceServiceType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

----------------------TblEligibility------------------------------------------
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEligibility_TblOrganizationRoleUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventCustomerEligibility]'))
ALTER TABLE [dbo].[TblEventCustomerEligibility] DROP CONSTRAINT [FK_TblEligibility_TblOrganizationRoleUser]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventCustomerEligibility_TblEligibility]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventCustomerEligibility]'))
ALTER TABLE [dbo].[TblEventCustomerEligibility] DROP CONSTRAINT [FK_TblEventCustomerEligibility_TblEligibility]
GO

/****** Object:  Table [dbo].[TblEligibility]    Script Date: 10/08/2013 20:45:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEligibility]') AND type in (N'U'))
DROP TABLE [dbo].[TblEligibility]
GO

/****** Object:  Table [dbo].[TblEligibility]    Script Date: 10/08/2013 20:45:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblEligibility](
	[EligibilityId] [bigint] IDENTITY(1,1) NOT NULL,
	[Guid] [varchar](500) NOT NULL,
	[InsuranceCompanyId] [bigint] NOT NULL,
	[PlanName] [varchar](255) NOT NULL,
	[GroupName] [varchar](255) NULL,
	[CoPayment] [decimal](18, 2) NOT NULL,
	[CoInsurance] [decimal](18, 2) NOT NULL,
	[Request] [varchar](4000) NOT NULL,
	[Response] [varchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedByOrgRoleUserId] [bigint] NULL,
 CONSTRAINT [PK_TblEligibility] PRIMARY KEY CLUSTERED 
(
	[EligibilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblEligibility]  WITH CHECK ADD  CONSTRAINT [FK_TblEligibility_TblInsuranceCompany] FOREIGN KEY([InsuranceCompanyId])
REFERENCES [dbo].[TblInsuranceCompany] ([InsuranceCompanyId])
GO

ALTER TABLE [dbo].[TblEligibility] CHECK CONSTRAINT [FK_TblEligibility_TblInsuranceCompany]
GO

ALTER TABLE [dbo].[TblEligibility]  WITH CHECK ADD  CONSTRAINT [FK_TblEligibility_TblOrganizationRoleUser] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

ALTER TABLE [dbo].[TblEligibility] CHECK CONSTRAINT [FK_TblEligibility_TblOrganizationRoleUser]
GO

------------------------------TblEventCustomerEligibility-----------------------------------------------


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventCustomerEligibility_TblEventCustomers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventCustomerEligibility]'))
ALTER TABLE [dbo].[TblEventCustomerEligibility] DROP CONSTRAINT [FK_TblEventCustomerEligibility_TblEventCustomers]
GO

/****** Object:  Table [dbo].[TblEventCustomerEligibility]    Script Date: 10/08/2013 20:47:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEventCustomerEligibility]') AND type in (N'U'))
DROP TABLE [dbo].[TblEventCustomerEligibility]
GO

/****** Object:  Table [dbo].[TblEventCustomerEligibility]    Script Date: 10/08/2013 20:47:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblEventCustomerEligibility](
	[EventCustomerId] [bigint] NOT NULL,
	[EligibilityId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventCustomerEligibility] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[EligibilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventCustomerEligibility]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerEligibility_TblEligibility] FOREIGN KEY([EligibilityId])
REFERENCES [dbo].[TblEligibility] ([EligibilityId])
GO

ALTER TABLE [dbo].[TblEventCustomerEligibility] CHECK CONSTRAINT [FK_TblEventCustomerEligibility_TblEligibility]
GO

ALTER TABLE [dbo].[TblEventCustomerEligibility]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerEligibility_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerID])
GO

ALTER TABLE [dbo].[TblEventCustomerEligibility] CHECK CONSTRAINT [FK_TblEventCustomerEligibility_TblEventCustomers]
GO

--------------------TblInsurancePayment-------------------------

/****** Object:  Table [dbo].[TblInsurancePayment]    Script Date: 10/08/2013 20:53:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblInsurancePayment]') AND type in (N'U'))
DROP TABLE [dbo].[TblInsurancePayment]
GO

/****** Object:  Table [dbo].[TblInsurancePayment]    Script Date: 10/08/2013 20:53:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblInsurancePayment](
	[InsurancePaymentId] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentId] [bigint] NOT NULL,
	[AmountToBePaid] [decimal](18, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TblInsurancePayment] PRIMARY KEY CLUSTERED 
(
	[InsurancePaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblInsurancePayment]  WITH CHECK ADD  CONSTRAINT [FK_TblInsurancePayment_TblPayment] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[TblPayment] ([PaymentId])
GO

ALTER TABLE [dbo].[TblInsurancePayment] CHECK CONSTRAINT [FK_TblInsurancePayment_TblPayment]
GO



