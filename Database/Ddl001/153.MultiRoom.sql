USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPodRoom_TblPodDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPodRoom]'))
ALTER TABLE [dbo].[TblPodRoom] DROP CONSTRAINT [FK_TblPodRoom_TblPodDetails]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPodRoomTest_TblPodRoom]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPodRoomTest]'))
ALTER TABLE [dbo].[TblPodRoomTest] DROP CONSTRAINT [FK_TblPodRoomTest_TblPodRoom]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPodRoomTest_TblTest]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPodRoomTest]'))
ALTER TABLE [dbo].[TblPodRoomTest] DROP CONSTRAINT [FK_TblPodRoomTest_TblTest]
GO

/****** Object:  Table [dbo].[TblPodRoom]    Script Date: 08/27/2013 16:30:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPodRoom]') AND type in (N'U'))
DROP TABLE [dbo].[TblPodRoom]
GO

/****** Object:  Table [dbo].[TblPodRoom]    Script Date: 08/27/2013 16:30:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblPodRoom](
	[PodRoomId] [bigint] IDENTITY(1,1) NOT NULL,
	[PodId] [bigint] NOT NULL,
	[RoomNo] [int] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_TblPodRoom] PRIMARY KEY CLUSTERED 
(
	[PodRoomId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblPodRoom]  WITH CHECK ADD  CONSTRAINT [FK_TblPodRoom_TblPodDetails] FOREIGN KEY([PodId])
REFERENCES [dbo].[TblPodDetails] ([PodID])
GO

ALTER TABLE [dbo].[TblPodRoom] CHECK CONSTRAINT [FK_TblPodRoom_TblPodDetails]
GO


/****** Object:  Table [dbo].[TblPodRoomTest]    Script Date: 08/27/2013 16:33:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPodRoomTest]') AND type in (N'U'))
DROP TABLE [dbo].[TblPodRoomTest]
GO

/****** Object:  Table [dbo].[TblPodRoomTest]    Script Date: 08/27/2013 16:33:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblPodRoomTest](
	[PodRoomId] [bigint] NOT NULL,
	[TestId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblPodRoomTest] PRIMARY KEY CLUSTERED 
(
	[PodRoomId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblPodRoomTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPodRoomTest_TblPodRoom] FOREIGN KEY([PodRoomId])
REFERENCES [dbo].[TblPodRoom] ([PodRoomId])
GO

ALTER TABLE [dbo].[TblPodRoomTest] CHECK CONSTRAINT [FK_TblPodRoomTest_TblPodRoom]
GO

ALTER TABLE [dbo].[TblPodRoomTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPodRoomTest_TblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestId])
GO

ALTER TABLE [dbo].[TblPodRoomTest] CHECK CONSTRAINT [FK_TblPodRoomTest_TblTest]
GO

------------Event level-----------------------------------------------

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventPodRoom_TblEventPod]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventPodRoom]'))
ALTER TABLE [dbo].[TblEventPodRoom] DROP CONSTRAINT [FK_TblEventPodRoom_TblEventPod]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventPodRoomTest_TblEventPodRoom]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventPodRoomTest]'))
ALTER TABLE [dbo].[TblEventPodRoomTest] DROP CONSTRAINT [FK_TblEventPodRoomTest_TblEventPodRoom]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventPodRoomTest_TblTest]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventPodRoomTest]'))
ALTER TABLE [dbo].[TblEventPodRoomTest] DROP CONSTRAINT [FK_TblEventPodRoomTest_TblTest]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventSchedulingSlot_TblEventPodRoom]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventSchedulingSlot]'))
ALTER TABLE [dbo].[TblEventSchedulingSlot] DROP CONSTRAINT [FK_TblEventSchedulingSlot_TblEventPodRoom]
GO

IF EXISTS(SELECT * FROM SYS.COLUMNS WHERE NAME = N'EventPodRoomId' AND OBJECT_ID = OBJECT_ID(N'TblEventSchedulingSlot'))    
BEGIN
    ALTER TABLE dbo.TblEventSchedulingSlot Drop Column EventPodRoomId 
END
GO

/****** Object:  Table [dbo].[TblEventPodRoom]    Script Date: 08/27/2013 16:38:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEventPodRoom]') AND type in (N'U'))
DROP TABLE [dbo].[TblEventPodRoom]
GO

/****** Object:  Table [dbo].[TblEventPodRoom]    Script Date: 08/27/2013 16:38:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblEventPodRoom](
	[EventPodRoomId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventPodId] [bigint] NOT NULL,
	[RoomNo] [int] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_TblEventPodRoom] PRIMARY KEY CLUSTERED 
(
	[EventPodRoomId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventPodRoom]  WITH CHECK ADD  CONSTRAINT [FK_TblEventPodRoom_TblEventPod] FOREIGN KEY([EventPodId])
REFERENCES [dbo].[TblEventPod] ([EventPodID])
GO

ALTER TABLE [dbo].[TblEventPodRoom] CHECK CONSTRAINT [FK_TblEventPodRoom_TblEventPod]
GO


/****** Object:  Table [dbo].[TblEventPodRoomTest]    Script Date: 08/27/2013 16:40:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEventPodRoomTest]') AND type in (N'U'))
DROP TABLE [dbo].[TblEventPodRoomTest]
GO


/****** Object:  Table [dbo].[TblEventPodRoomTest]    Script Date: 08/27/2013 16:40:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblEventPodRoomTest](
	[EventPodRoomId] [bigint] NOT NULL,
	[TestId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventPodRoomTest] PRIMARY KEY CLUSTERED 
(
	[EventPodRoomId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventPodRoomTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventPodRoomTest_TblEventPodRoom] FOREIGN KEY([EventPodRoomId])
REFERENCES [dbo].[TblEventPodRoom] ([EventPodRoomId])
GO

ALTER TABLE [dbo].[TblEventPodRoomTest] CHECK CONSTRAINT [FK_TblEventPodRoomTest_TblEventPodRoom]
GO

ALTER TABLE [dbo].[TblEventPodRoomTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventPodRoomTest_TblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestId])
GO

ALTER TABLE [dbo].[TblEventPodRoomTest] CHECK CONSTRAINT [FK_TblEventPodRoomTest_TblTest]
GO


ALTER TABLE dbo.TblEventSchedulingSlot ADD EventPodRoomId bigint NULL
GO

ALTER TABLE dbo.TblEventSchedulingSlot ADD CONSTRAINT FK_TblEventSchedulingSlot_TblEventPodRoom 
FOREIGN KEY (EventPodRoomId) REFERENCES dbo.TblEventPodRoom(EventPodRoomId) 
GO
