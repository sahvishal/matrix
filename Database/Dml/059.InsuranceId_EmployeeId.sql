USE [$(dbName)]
GO

update [TblCustomerProfile]
set [EmployeeId] = null
where [EmployeeId] = 'Not Available'

update [TblCustomerProfile]
set [InsuranceId] = null
where [InsuranceId] = 'Not Available'