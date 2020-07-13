USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblEventPackageDetails]	
ADD [PodRoomID] [bigint] NULL;

ALTER TABLE [dbo].[TblEventPackageDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblEventPackageDetails_TblPodRoomID] FOREIGN KEY([PodRoomID])
REFERENCES [dbo].[TblPodRoom] ([PodRoomId])
GO

ALTER TABLE [dbo].[TblEventPackageDetails] CHECK CONSTRAINT [FK_TblEventPackageDetails_TblPodRoomID]
GO


