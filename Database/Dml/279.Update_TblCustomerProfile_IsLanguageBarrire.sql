USE [$(dbName)]
GO

Update TblCustomerProfile set IsLanguageBarrier = 1 where CustomerID in 
	( select CustomerId from tblProspectCustomer where Tag ='LanguageBarrier' and CustomerId is Not Null )
