USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblClaim_TblEncounter]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblClaim]'))
ALTER TABLE [dbo].[TblClaim] DROP CONSTRAINT [FK_TblClaim_TblEncounter]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblClaim_TblInsurancePayment]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblClaim]'))
ALTER TABLE [dbo].[TblClaim] DROP CONSTRAINT [FK_TblClaim_TblInsurancePayment]
GO

/****** Object:  Table [dbo].[TblClaim]    Script Date: 12/23/2013 14:33:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblClaim]') AND type in (N'U'))
DROP TABLE [dbo].[TblClaim]
GO

/****** Object:  Table [dbo].[TblClaim]    Script Date: 12/23/2013 14:33:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblClaim](
	[ClaimId] [bigint] NOT NULL,
	[EncounterId] [bigint] NOT NULL,
	[InsurancePaymentId] [bigint] NOT NULL,
	[BillingPatientId] [bigint] NOT NULL,
	[ProcedureCode] [varchar](50) NOT NULL,
	[ProcedureName] [varchar](255) NOT NULL,
	[Units] [int] NOT NULL,
	[UnitCharge] [decimal](18, 2) NOT NULL,
	[TotalCharges] [decimal](18, 2) NOT NULL,
	[AdjustedCharges] [decimal](18, 2) NOT NULL,
	[Receipts] [decimal](18, 2) NOT NULL,
	[PatientBalance] [decimal](18, 2) NOT NULL,
	[InsuranceBalance] [decimal](18, 2) NOT NULL,
	[TotalBalance] [decimal](18, 2) NOT NULL,
	[Status] [varchar](255) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[FirstBillDate] [datetime] NULL,
	[LastBillDate] [datetime] NULL,
 CONSTRAINT [PK_TblClaim] PRIMARY KEY CLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblClaim]  WITH CHECK ADD  CONSTRAINT [FK_TblClaim_TblEncounter] FOREIGN KEY([EncounterId])
REFERENCES [dbo].[TblEncounter] ([EncounterId])
GO

ALTER TABLE [dbo].[TblClaim] CHECK CONSTRAINT [FK_TblClaim_TblEncounter]
GO

ALTER TABLE [dbo].[TblClaim]  WITH CHECK ADD  CONSTRAINT [FK_TblClaim_TblInsurancePayment] FOREIGN KEY([InsurancePaymentId])
REFERENCES [dbo].[TblInsurancePayment] ([InsurancePaymentId])
GO

ALTER TABLE [dbo].[TblClaim] CHECK CONSTRAINT [FK_TblClaim_TblInsurancePayment]
GO


