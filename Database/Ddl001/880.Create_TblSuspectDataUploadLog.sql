USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblSuspectConditionUploadLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SuspectConditionUploadId] [bigint] NOT NULL,
	[GMPI] [varchar](25) NULL,
	[SubscriberID] [varchar](255) NULL,
	[MemberName] [varchar](255) NULL,
	[DOB] [varchar](25) NULL,
	[ICDCode] [varchar](255) NULL,
	[ICDDesc] [varchar](255) NULL,
	[ICDCodeVersion] [varchar](255) NULL,
	[HCC] [varchar](255) NULL,
	[HCCDesc] [varchar](255) NULL,
	[CaptureAction] [varchar](255) NULL,
	[CaptureLocation] [varchar](255) NULL,
	[CaptureReasonDescription] [nvarchar](4000) NULL,
	[CaptureReferenceDate] [varchar](25) NULL,
	[SectionName] [varchar](255) NULL,
	[IsSuccessFull] [bit] NOT NULL,
	[ErrorMessage] [varchar](4000) NULL,
 CONSTRAINT [PK_TblSuspectConditionUploadLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblSuspectConditionUploadLog] ADD  CONSTRAINT [DF_TblSuspectConditionUploadLog_IsSuccessFull]  DEFAULT (0) FOR [IsSuccessFull]
GO

ALTER TABLE [dbo].[TblSuspectConditionUploadLog]  WITH CHECK ADD  CONSTRAINT [FK_TblSuspectConditionUploadLog_TblSuspectConditionUpload_Id] FOREIGN KEY([SuspectConditionUploadId])
REFERENCES [dbo].[TblSuspectConditionUpload] ([Id])
GO

ALTER TABLE [dbo].[TblSuspectConditionUploadLog] CHECK CONSTRAINT [FK_TblSuspectConditionUploadLog_TblSuspectConditionUpload_Id]
GO
