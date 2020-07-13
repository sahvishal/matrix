USE [$(dbName)]
Go


ALTER TABLE dbo.TblCustomerEventTestState ADD IsPriorityInQueue Bit Not Null CONSTRAINT [DF_TblCustomerEventTestState_IsPriorityInQueue] DEFAULT 0 
GO
