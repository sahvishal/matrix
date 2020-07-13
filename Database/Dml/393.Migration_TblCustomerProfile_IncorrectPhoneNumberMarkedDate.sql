USE [$(dbname)]
GO

--------------------------------------------------------------------------------------------------------------------------------
-- Migration of IncorrectPhoneNumberMarkedDate in TblCustomerProfile from TblCalls
--------------------------------------------------------------------------------------------------------------------------------

  UPDATE CP SET CP.IncorrectPhoneNumberMarkedDate = C.DateCreated
  FROM TblCustomerProfile AS CP
  INNER JOIN 
  (
	select CalledCustomerID, MAX(DateCreated) as DateCreated from TblCalls  where [Status] = 243 group by CalledCustomerID 
  ) AS C
  ON CP.CustomerID = C.CalledCustomerID
  WHERE CP.IsIncorrectPhoneNumber = 1 

   update TblCustomerProfile set IncorrectPhoneNumberMarkedDate = '12/31/2017' Where IsLanguageBarrier = 1 and LanguageBarrierMarkedDate is null