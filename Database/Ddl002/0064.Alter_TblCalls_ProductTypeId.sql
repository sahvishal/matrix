USE	[$(dbname)]
GO

Alter TABLE TblCalls
ADD ProductTypeId BIGINT NULL
GO

ALTER TABLE [dbo].TblCalls  WITH CHECK ADD  CONSTRAINT [FK_TblCalls_TblLookUp_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblCalls] CHECK CONSTRAINT [FK_TblCalls_TblLookUp_ProductTypeId]
GO
