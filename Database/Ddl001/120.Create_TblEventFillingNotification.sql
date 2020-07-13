
USE [$(dbName)]
Go

/****** Object:  Table [dbo].[TblEventNotification]    Script Date: 02/25/2013 12:37:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblEventNotification](
	[EventId] [bigint] NOT NULL,
	[NotificationId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventNotification] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[NotificationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventNotification]  WITH CHECK ADD  CONSTRAINT [FK_TblEventNotification_TblNotification] FOREIGN KEY([NotificationId])
REFERENCES [dbo].[TblNotification] ([NotificationId])
GO

ALTER TABLE [dbo].[TblEventNotification] CHECK CONSTRAINT [FK_TblEventNotification_TblNotification]
GO

ALTER TABLE [dbo].[TblEventNotification]  WITH CHECK ADD  CONSTRAINT [FK_TblEventNotification_TblEvents] FOREIGN KEY([EventId])
REFERENCES [dbo].[TblEvents] ([EventId])
GO

ALTER TABLE [dbo].[TblEventNotification] CHECK CONSTRAINT [FK_TblEventNotification_TblEvents]
GO


