USE [$(dbName)]
GO

Alter Table TblOrderDetail Drop constraint DF_TblOrderDetail_IsFromMedicare
GO
Alter Table TblOrderDetail Drop column IsFromMedicare
GO
Alter Table TblOrderDetail Add  SourceId bigint null

ALTER TABLE [dbo].[TblOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderDetail_TblLookup_AddingSourceId] FOREIGN KEY(SourceId)
REFERENCES [dbo].[TblLookup] ([LookupID])
GO