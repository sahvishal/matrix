
USE [$(dbName)]
GO

insert into TblCustomerEligibility
	(CustomerId, ForYear, IsEligible, CreatedBy, DateCreated)

SELECT Distinct CustomerId, 2018, 1, 1, GETDATE() FROM TblCustomerTag WHERE Tag in
(
	select Tag from TblCorporateTag where StartDate >= '01/01/2018' or Tag like '%2018%' and IsActive = 1
)
GO

insert into TblCustomerEligibility
	(CustomerId, ForYear, IsEligible, CreatedBy, DateCreated)

select CustomerId, 2018, 0, 1, GETDATE() from TblCustomerProfile where Tag is not NULL and Ltrim(Rtrim(Tag)) <> ''
and CustomerID not in 
(
	select CustomerId from TblCustomerEligibility where ForYear = 2018 and IsEligible = 1
)