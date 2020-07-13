USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblMedicationUploadLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MedicationUploadId] [bigint] NOT NULL,

	[ServiceDate] [varchar](25) NULL,
	[CmsHicn] [varchar](255) NULL,
	[MemberId] [varchar](255) NULL,
	[MemberDob] [varchar](25) NULL,
	[NdcProductCode] [varchar](20) NULL,

	[IsSuccessFull] [bit] NOT NULL,
	[ErrorMessage] [varchar](4000) NULL,
 CONSTRAINT [PK_TblMedicationUploadLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblMedicationUploadLog] ADD  CONSTRAINT [DF_TblMedicationUploadLog_IsSuccessFull]  DEFAULT ((0)) FOR [IsSuccessFull]
GO

ALTER TABLE [dbo].[TblMedicationUploadLog]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicationUploadLog_TblMedicationUpload_Id] FOREIGN KEY([MedicationUploadId])
REFERENCES [dbo].[TblMedicationUpload] ([Id])
GO

ALTER TABLE [dbo].[TblMedicationUploadLog] CHECK CONSTRAINT [FK_TblMedicationUploadLog_TblMedicationUpload_Id]
GO
