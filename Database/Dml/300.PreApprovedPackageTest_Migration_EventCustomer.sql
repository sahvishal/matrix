USE [$(dbName)]
Go

Insert into [TblEventCustomerPreApprovedPackageTest] 

Select ec.EventCustomerId, pt.TestId,pap.PackageId from tblEventCustomers ec 
inner join  TblPreApprovedPackage pap on ec.CustomerID=pap.CustomerId
inner join TblPackageTest pt on pap.PackageId = pt.PackageID
