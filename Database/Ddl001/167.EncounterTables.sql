
USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEncounter_TblBillingAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEncounter]'))
ALTER TABLE [dbo].[TblEncounter] DROP CONSTRAINT [FK_TblEncounter_TblBillingAccount]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerBillingAccount_TblBillingAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerBillingAccount]'))
ALTER TABLE [dbo].[TblCustomerBillingAccount] DROP CONSTRAINT [FK_TblCustomerBillingAccount_TblBillingAccount]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblBillingAccountTest_TblBillingAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblBillingAccountTest]'))
ALTER TABLE [dbo].[TblBillingAccountTest] DROP CONSTRAINT [FK_TblBillingAccountTest_TblBillingAccount]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblBillingAccount_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblBillingAccount] DROP CONSTRAINT [DF_TblBillingAccount_IsActive]
END
GO

/****** Object:  Table [dbo].[TblBillingAccount]    Script Date: 12/18/2013 16:33:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblBillingAccount]') AND type in (N'U'))
DROP TABLE [dbo].[TblBillingAccount]
GO

/****** Object:  Table [dbo].[TblBillingAccount]    Script Date: 12/17/2013 19:01:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblBillingAccount](
	[BillingAccountId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[CustomerKey] [varchar](500) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblBillingAccount] PRIMARY KEY CLUSTERED 
(
	[BillingAccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblBillingAccount] ADD  CONSTRAINT [DF_TblBillingAccount_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

-----------------------TblBillingAccountTest---------------------------------

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblBillingAccountTest_TblTest]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblBillingAccountTest]'))
ALTER TABLE [dbo].[TblBillingAccountTest] DROP CONSTRAINT [FK_TblBillingAccountTest_TblTest]
GO

/****** Object:  Table [dbo].[TblBillingAccountTest]    Script Date: 12/17/2013 19:02:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblBillingAccountTest]') AND type in (N'U'))
DROP TABLE [dbo].[TblBillingAccountTest]
GO

/****** Object:  Table [dbo].[TblBillingAccountTest]    Script Date: 12/17/2013 19:02:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblBillingAccountTest](
	[BillingAccountId] [bigint] NOT NULL,
	[TestId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblBillingAccountTest] PRIMARY KEY CLUSTERED 
(
	[BillingAccountId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblBillingAccountTest]  WITH CHECK ADD  CONSTRAINT [FK_TblBillingAccountTest_TblBillingAccount] FOREIGN KEY([BillingAccountId])
REFERENCES [dbo].[TblBillingAccount] ([BillingAccountId])
GO

ALTER TABLE [dbo].[TblBillingAccountTest] CHECK CONSTRAINT [FK_TblBillingAccountTest_TblBillingAccount]
GO

ALTER TABLE [dbo].[TblBillingAccountTest]  WITH CHECK ADD  CONSTRAINT [FK_TblBillingAccountTest_TblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestID])
GO

ALTER TABLE [dbo].[TblBillingAccountTest] CHECK CONSTRAINT [FK_TblBillingAccountTest_TblTest]
GO

------------------TblCustomerBillingAccount----------------------------------------


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerBillingAccount_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerBillingAccount]'))
ALTER TABLE [dbo].[TblCustomerBillingAccount] DROP CONSTRAINT [FK_TblCustomerBillingAccount_TblCustomerProfile]
GO

/****** Object:  Table [dbo].[TblCustomerBillingAccount]    Script Date: 12/17/2013 19:08:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerBillingAccount]') AND type in (N'U'))
DROP TABLE [dbo].[TblCustomerBillingAccount]
GO

/****** Object:  Table [dbo].[TblCustomerBillingAccount]    Script Date: 12/17/2013 19:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCustomerBillingAccount](
	[CustomerId] [bigint] NOT NULL,
	[BillingAccountId] [bigint] NOT NULL,
	[BillingPatientId] [bigint] NOT NULL,
	[DateCreated] [DateTime] NOT NULL
 CONSTRAINT [PK_TblCustomerBillingAccount] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[BillingAccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblCustomerBillingAccount]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerBillingAccount_TblBillingAccount] FOREIGN KEY([BillingAccountId])
REFERENCES [dbo].[TblBillingAccount] ([BillingAccountId])
GO

ALTER TABLE [dbo].[TblCustomerBillingAccount] CHECK CONSTRAINT [FK_TblCustomerBillingAccount_TblBillingAccount]
GO

ALTER TABLE [dbo].[TblCustomerBillingAccount]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerBillingAccount_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCustomerBillingAccount] CHECK CONSTRAINT [FK_TblCustomerBillingAccount_TblCustomerProfile]
GO

---------------------TblEncounter-------------------------------------------

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventCustomerEncounter_TblEncounter]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventCustomerEncounter]'))
ALTER TABLE [dbo].[TblEventCustomerEncounter] DROP CONSTRAINT [FK_TblEventCustomerEncounter_TblEncounter]
GO

/****** Object:  Table [dbo].[TblEncounter]    Script Date: 12/17/2013 19:20:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEncounter]') AND type in (N'U'))
DROP TABLE [dbo].[TblEncounter]
GO

/****** Object:  Table [dbo].[TblEncounter]    Script Date: 12/17/2013 19:20:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblEncounter](
	[EncounterId] [bigint] NOT NULL,	
	[BillingAccountId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_TblEncounter] PRIMARY KEY CLUSTERED 
(
	[EncounterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblEncounter]  WITH CHECK ADD  CONSTRAINT [FK_TblEncounter_TblBillingAccount] FOREIGN KEY([BillingAccountId])
REFERENCES [dbo].[TblBillingAccount] ([BillingAccountId])
GO

ALTER TABLE [dbo].[TblEncounter] CHECK CONSTRAINT [FK_TblEncounter_TblBillingAccount]
GO
-----------------TblEventCustomerEncounter----------------------------------------

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventCustomerEncounter_TblEventCustomers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventCustomerEncounter]'))
ALTER TABLE [dbo].[TblEventCustomerEncounter] DROP CONSTRAINT [FK_TblEventCustomerEncounter_TblEventCustomers]
GO

/****** Object:  Table [dbo].[TblEventCustomerEncounter]    Script Date: 12/17/2013 19:22:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEventCustomerEncounter]') AND type in (N'U'))
DROP TABLE [dbo].[TblEventCustomerEncounter]
GO

/****** Object:  Table [dbo].[TblEventCustomerEncounter]    Script Date: 12/17/2013 19:22:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblEventCustomerEncounter](
	[EventCustomerId] [bigint] NOT NULL,
	[EncounterId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventCustomerEncounter] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[EncounterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventCustomerEncounter]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerEncounter_TblEncounter] FOREIGN KEY([EncounterId])
REFERENCES [dbo].[TblEncounter] ([EncounterId])
GO

ALTER TABLE [dbo].[TblEventCustomerEncounter] CHECK CONSTRAINT [FK_TblEventCustomerEncounter_TblEncounter]
GO

ALTER TABLE [dbo].[TblEventCustomerEncounter]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerEncounter_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerID])
GO

ALTER TABLE [dbo].[TblEventCustomerEncounter] CHECK CONSTRAINT [FK_TblEventCustomerEncounter_TblEventCustomers]
GO





