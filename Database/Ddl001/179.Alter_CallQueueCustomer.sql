
USE [$(dbName)]
GO


CREATE NONCLUSTERED INDEX [NIDX_Customer_Prospect_CallQueue] ON [dbo].[TblCallQueueCustomer] 
(
	[CallQueueId] ASC,
	[CustomerId] ASC,
	[ProspectCustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO