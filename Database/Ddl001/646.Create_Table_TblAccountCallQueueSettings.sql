USE [$(dbname)]
GO


CREATE TABLE [dbo].[TblAccountCallQueueSetting](
	[AccountID] [bigint] NOT NULL,
	[CallQueueID] [bigint] NOT NULL,
	[SuppressionTypeID] [bigint] NOT NULL,
	[NoOfDays] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblAccountCallQueueSettings] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC,
	[CallQueueID] ASC,
	[SuppressionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblAccountCallQueueSetting]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountCallQueueSettings_TblAccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[TblAccount] ([AccountID])
GO

ALTER TABLE [dbo].[TblAccountCallQueueSetting] CHECK CONSTRAINT [FK_TblAccountCallQueueSettings_TblAccountID]
GO

ALTER TABLE [dbo].[TblAccountCallQueueSetting]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountCallQueueSettings_TblCallQueueID] FOREIGN KEY([CallQueueID])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO

ALTER TABLE [dbo].[TblAccountCallQueueSetting] CHECK CONSTRAINT [FK_TblAccountCallQueueSettings_TblCallQueueID]
GO

ALTER TABLE [dbo].[TblAccountCallQueueSetting]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountCallQueueSettings_TblLookupID] FOREIGN KEY([SuppressionTypeID])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblAccountCallQueueSetting] CHECK CONSTRAINT [FK_TblAccountCallQueueSettings_TblLookupID]
GO


