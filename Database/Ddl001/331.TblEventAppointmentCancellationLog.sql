USE [$(dbName)]
Go 


/****** Object:  Table [dbo].[TblEventAppointmentCancellationLog]    Script Date: 31-08-2015 16:27:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblEventAppointmentCancellationLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventCustomerId] [bigint] NOT NULL,
	[EventId] [bigint] NOT NULL,
	[ReasonId] [bigint] NOT NULL,
	[NoteId] [bigint] NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventAppointmentCancellationLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblEventAppointmentCancellationLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblEventCustomer] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerID])
GO

ALTER TABLE [dbo].[TblEventAppointmentCancellationLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblEvents] FOREIGN KEY([EventId])
REFERENCES [dbo].[TblEvents] ([EventID])
GO

ALTER TABLE [dbo].[TblEventAppointmentCancellationLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblLookup] FOREIGN KEY([ReasonId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblEventAppointmentCancellationLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblOrganizationRoleUsers] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblEventAppointmentCancellationLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblNotesDetails] FOREIGN KEY([NoteId])
REFERENCES [dbo].[TblNotesDetails] ([NoteID])
GO


