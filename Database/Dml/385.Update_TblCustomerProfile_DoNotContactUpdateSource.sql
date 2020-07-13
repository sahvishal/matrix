USE [$(dbname)]
GO

UPDATE TblCustomerProfile SET DoNotContactUpdateSource = 348
where DoNotContactTypeId IS NOT NULL
and CustomerID in
(
	select CalledCustomerID from TblCalls
	where Disposition = 'DoNotCall'
	and CONVERT(date, TimeCreated) = CONVERT(date, DoNotContactUpdateDate)
	and DateCreated >= '1/1/2017' 
	and OutBound = 1
)
GO


UPDATE TblCustomerProfile SET DoNotContactUpdateSource = 348
where DoNotContactTypeId IS NOT NULL
and CustomerID in
(
	select CalledCustomerID from TblCalls
	where Disposition = 'DoNotCall'
	and DateCreated < '1/1/2017' 
	and OutBound = 1
)
and CustomerID not in
(
	select CalledCustomerID from TblCalls
	where Disposition = 'DoNotCall'
	and CONVERT(date, TimeCreated) = CONVERT(date, DoNotContactUpdateDate)
	and DateCreated >= '1/1/2017' 
	and OutBound = 1
)
GO


UPDATE TblCustomerProfile SET DoNotContactUpdateSource = 349
where DoNotContactTypeId IS NOT NULL
and CustomerID not in
(
	select CalledCustomerID from TblCalls
	where Disposition = 'DoNotCall'
	and CONVERT(date, TimeCreated) = CONVERT(date,DoNotContactUpdateDate)
	and DateCreated >= '1/1/2017' 
	and OutBound = 1
)
and CustomerID not in
(
	select CalledCustomerID from TblCalls
	where Disposition = 'DoNotCall'
	and DateCreated < '1/1/2017' 
	and OutBound = 1
)