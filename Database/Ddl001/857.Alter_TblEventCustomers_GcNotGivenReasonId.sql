USE[$(dbName)]

GO

ALTER TABLE TblEventCustomers
Add  GcNotGivenReasonId bigint null

GO

ALTER TABLE TblEventCustomers
WITH CHECK ADD CONSTRAINT [FK_TblEventCustomers_TblGcNotGivenReason_GcNotGivenReasonId]
FOREIGN KEY ([GcNotGivenReasonId])
REFERENCES [TblGcNotGivenReason](Id)

GO