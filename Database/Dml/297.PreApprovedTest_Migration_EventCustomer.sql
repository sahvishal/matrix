USE [$(dbName)]
Go

Insert into [TblEventCustomerPreApprovedTest] 
	Select ec.EventCustomerId, pat.TestId from tblEventCustomers ec 
	join TblPreApprovedTest pat on ec.CustomerId = pat.CustomerId Where pat.IsActive = 1

