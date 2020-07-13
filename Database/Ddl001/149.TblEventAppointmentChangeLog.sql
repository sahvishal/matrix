USE [$(dbName)]
GO
/****** Object:  Table [dbo].[TblEventAppointmentChangeLog]    Script Date: 07/24/2013 14:43:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEventAppointmentChangeLog]') AND type in (N'U'))
DROP TABLE [dbo].[TblEventAppointmentChangeLog]
GO

/****** Object:  Table [dbo].[TblEventAppointmentChangeLog]    Script Date: 08/06/2013 15:37:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEventAppointmentChangeLog]') AND type in (N'U'))
DROP TABLE [dbo].[TblEventAppointmentChangeLog]
GO

/****** Object:  Table [dbo].[TblEventAppointmentChangeLog]    Script Date: 07/24/2013 15:21:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblEventAppointmentChangeLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventCustomerId] [bigint] NOT NULL,
	[OldEventId] [bigint] NOT NULL,
	[OldAppointmentTime] [datetime] NOT NULL,
	[NewEventId] [bigint] NOT NULL,
	[NewAppointmentTime] [datetime] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventAppointmentChangeLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventAppointmentChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentChangeLog_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerId])
GO

ALTER TABLE [dbo].[TblEventAppointmentChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentChangeLog_TblEvents_OldEventId] FOREIGN KEY([OldEventId])
REFERENCES [dbo].[TblEvents] ([EventID])
GO

ALTER TABLE [dbo].[TblEventAppointmentChangeLog] CHECK CONSTRAINT [FK_TblEventAppointmentChangeLog_TblEvents_OldEventId]
GO

ALTER TABLE [dbo].[TblEventAppointmentChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentChangeLog_TblEvents_NewEventId] FOREIGN KEY([NewEventId])
REFERENCES [dbo].[TblEvents] ([EventID])
GO

ALTER TABLE [dbo].[TblEventAppointmentChangeLog] CHECK CONSTRAINT [FK_TblEventAppointmentChangeLog_TblEvents_NewEventId]
GO

ALTER TABLE [dbo].[TblEventAppointmentChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentChangeLog_TblOrganizationRoleUser] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblEventAppointmentChangeLog] CHECK CONSTRAINT [FK_TblEventAppointmentChangeLog_TblOrganizationRoleUser]
GO