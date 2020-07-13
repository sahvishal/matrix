USE [$(dbName)]
GO

/****** Object:  Table [dbo].[TblStaffEventScheduleUploadLog]    Script Date: 02-04-2018 15:15:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblStaffEventScheduleUploadLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UploadId] [bigint] NOT NULL,
	[StaffName] [varchar](50) NULL,
	[StaffEmail] [varchar](50) NULL,
	[Pod] [varchar](20) NULL,
	[Role] [varchar](20) NULL,
	[EventDate] [varchar](20) NULL,
	[EventId] [varchar](20) NULL,
	[IsSuccessful] [bit] NOT NULL,
	[ErrorMessage] [nvarchar](2048) NULL,
 CONSTRAINT [PK_TblStaffEventScheduleUploadLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUploadLog] ADD  CONSTRAINT [DF_TblStaffEventScheduleUploadLog_IsSuccessful]  DEFAULT ((0)) FOR [IsSuccessful]
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUploadLog]  WITH CHECK ADD  CONSTRAINT [FK_TblStaffEventScheduleUploadLog_TblStaffEventScheduleUpload_UploadId] FOREIGN KEY([UploadId])
REFERENCES [dbo].[TblStaffEventScheduleUpload] ([Id])
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUploadLog] CHECK CONSTRAINT [FK_TblStaffEventScheduleUploadLog_TblStaffEventScheduleUpload_UploadId]
GO
