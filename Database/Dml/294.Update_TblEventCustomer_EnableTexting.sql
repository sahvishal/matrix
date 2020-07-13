USE [$(dbName)]
Go

Update TblEventCustomers  set EnableTexting =  1 where CustomerID in ( select CustomerID from TblCustomerProfile where EnableTexting =1 )

GO