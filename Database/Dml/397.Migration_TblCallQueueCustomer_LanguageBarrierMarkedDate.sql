USE [$(dbname)]
GO

--------------------------------------------------------------------------------------------------------------------------------
-- Migration of LanguageBarrierMarkedDate in TblCallQueueCustomer from TblCalls
--------------------------------------------------------------------------------------------------------------------------------

  update cqc set cqc.LanguageBarrierMarkedDate = cp.LanguageBarrierMarkedDate 
  from TblCustomerProfile cp inner join TblCallQueueCustomer cqc on cp.CustomerID = cqc.CustomerId
	where cp.IsLanguageBarrier = 1

