USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblEvents]  
ADD EventCancellationReasonId BIGINT null, CONSTRAINT [FK_TblEvents_TblLookup_EventCancellationReasonId] FOREIGN KEY([EventCancellationReasonId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO
 
 


