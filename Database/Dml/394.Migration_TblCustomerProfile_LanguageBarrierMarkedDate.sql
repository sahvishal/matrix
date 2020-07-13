USE [$(dbname)]
GO

--------------------------------------------------------------------------------------------------------------------------------
-- Migration of LanguageBarrierMarkedDate in TblCustomerProfile from TblCalls
--------------------------------------------------------------------------------------------------------------------------------

  UPDATE CP SET CP.LanguageBarrierMarkedDate = C.DateCreated
  FROM TblCustomerProfile AS CP
  INNER JOIN 
  (
	select CalledCustomerID, MAX(DateCreated) as DateCreated from TblCalls  where Disposition = 'LanguageBarrier' group by CalledCustomerID 
  ) AS C
  ON CP.CustomerID = C.CalledCustomerID
  WHERE CP.IsLanguageBarrier = 1 

   update TblCustomerProfile set LanguageBarrierMarkedDate = '12/31/2017' Where IsLanguageBarrier = 1 and LanguageBarrierMarkedDate is null