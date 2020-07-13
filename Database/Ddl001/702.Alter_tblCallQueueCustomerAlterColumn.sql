use[$(dbname)]
Go

Alter Table TblCallQueueCustomer Alter column [ZipId] bigint null
Go

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCallQueueCustomer_HasFutureAppointment]') AND type = 'D')
BEGIN
	ALTER TABLE [dbo].[TblCallQueueCustomer] DROP CONSTRAINT [DF_TblCallQueueCustomer_HasFutureAppointment], COLUMN HasFutureAppointment
END

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblCallQueueCustomer_IsCallSkipped]') AND type = 'D')
BEGIN
	ALTER TABLE [dbo].[TblCallQueueCustomer] DROP CONSTRAINT [DF_TblCallQueueCustomer_IsCallSkipped], COLUMN IsCallSkipped
END
