
USE [$(dbName)]
GO

insert into TblCustomerTargeted
	(CustomerId, ForYear, IsTargated, DateCreated, CreatedBy)

select CustomerID, ForYear, 1, GETDATE(), 1
from
(
	select TEC.CustomerID, DATEPART(year, TE.EventDate) as ForYear
	from TblEventCustomers TEC 
	inner join TblCustomerProfile TC ON TEC.CustomerID = TC.CustomerID
	inner join TblEvents TE on TEC.EventID = TE.EventId
	inner join TblEventAccount TEA on TE.EventId = TEA.EventID
	inner join TblAccount TA on TEA.AccountID = TA.AccountID
	where 1 = 1
	and TA.IsHealthPlan = 1 
	and TC.Tag is NOT NULL 
	and TC.Tag <> ''
	--order by TEC.DateCreated
)tmp
group by CustomerID, ForYear
order by CustomerID, ForYear