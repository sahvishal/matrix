USE [$(dbname)]
GO

--------------------------------------------------------------------------------------------------------------------------------
-- Migration of IncorrectPhoneNumberMarkedDate in TblCustomerProfile from TblCalls
--------------------------------------------------------------------------------------------------------------------------------

  update cqc set cqc.IncorrectPhoneNumberMarkedDate = cp.IncorrectPhoneNumberMarkedDate 
  from TblCustomerProfile cp inner join TblCallQueueCustomer cqc on cp.CustomerID = cqc.CustomerId
	where cp.IsIncorrectPhoneNumber = 1

