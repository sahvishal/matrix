USE [$(dbName)]
Go

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblEventSchedulingSlot](
	[SlotId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [bigint] NOT NULL,	
	[StartTime] [datetime] NOT NULL,	
	[EndTime] [datetime] NOT NULL,		
	[Reason] [varchar](500) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Status] [bigint] NOT NULL,	
 CONSTRAINT [PK_TblEventSlot] PRIMARY KEY CLUSTERED 
(
	[SlotId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblEventSchedulingSlot]  WITH CHECK ADD  CONSTRAINT [FK_TblEventSchedulingSlot_TblLookup] FOREIGN KEY([Status])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblEventSchedulingSlot]  WITH CHECK ADD  CONSTRAINT [FK_TblEventSchedulingSlot_TblEvents] FOREIGN KEY([EventId])
REFERENCES [dbo].[TblEvents] ([EventId])
GO

-----------------------------------------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblEventSlotAppointment](
	[SlotId] [bigint]  NOT NULL,
	[AppointmentId] [bigint] NOT NULL
 CONSTRAINT [PK_TblEventSlotAppointment] PRIMARY KEY CLUSTERED 
(
	[SlotId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblEventSlotAppointment]  WITH CHECK ADD  CONSTRAINT [FK_TblEventSlotAppointment_TblEventSchedulingSlot] FOREIGN KEY([SlotId])
REFERENCES [dbo].[TblEventSchedulingSlot] ([SlotId])
GO

ALTER TABLE [dbo].[TblEventSlotAppointment]  WITH CHECK ADD  CONSTRAINT [FK_TblEventSlotAppointment_TblEventAppointment] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[TblEventAppointment] ([AppointmentId])
GO


