USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblSuspectCondition](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SuspectConditionUploadId] [bigint] NOT NULL,
	[CustomerId] [BigInt] NOT NULL,
	[GMPI] [varchar](255) NULL,
	[SubscriberID] [varchar](255) NULL,
	[FirstName] [varchar](255) NULL,
	[MiddleName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[DOB] [DateTime] NULL,
	[ICDCode] [varchar](255) NULL,
	[ICDDesc] [varchar](255) NULL,
	[ICDCodeVersion] [varchar](255) NULL,
	[HCC] [varchar](255) NULL,
	[HCCDesc] [varchar](255) NULL,
	[CaptureAction] [varchar](255) NULL,
	[CaptureLocation] [varchar](255) NULL,
	[CaptureReasonDescription] [nvarchar](4000) NULL,
	[CaptureReferenceDate] [DateTime] NULL,
	[SectionName] [varchar](255) NULL,
	[IsSynced] [bit] NOT NULL,
 CONSTRAINT [PK_TblSuspectCondition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblSuspectCondition]  WITH CHECK ADD  CONSTRAINT [FK_TblSuspectCondition_TblSuspectConditionUpload_Id] FOREIGN KEY([SuspectConditionUploadId])
REFERENCES [dbo].[TblSuspectConditionUpload] ([Id])
GO

ALTER TABLE [dbo].[TblSuspectCondition] CHECK CONSTRAINT [FK_TblSuspectCondition_TblSuspectConditionUpload_Id]
GO

GO

ALTER TABLE [dbo].[TblSuspectCondition]  WITH CHECK ADD  CONSTRAINT [FK_TblSuspectCondition_TblCustomerProfile_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblSuspectCondition] CHECK CONSTRAINT [FK_TblSuspectCondition_TblCustomerProfile_Id]
GO

