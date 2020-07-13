
USE [$(dbName)]
GO

insert into TblCustomerTargeted
	(CustomerId, ForYear, IsTargated, DateCreated, CreatedBy)

select CustomerID, ForYear, 0, GETDATE(), 1
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
	and (TC.Tag is NULL or Ltrim(Rtrim(TC.Tag)) = '')
	--and TEC.AppointmentID is NOT NULL
	--order by TEC.DateCreated
)tmp
group by CustomerID, ForYear
order by CustomerID, ForYear



--select TC.CustomerID, TA.Tag, TE.EventDate
--from TblCustomerProfile TC	 
--inner join TblEventCustomers TEC ON TEC.CustomerID = TC.CustomerID
--inner join TblEvents TE on TEC.EventID = TE.EventId
--inner join TblEventAccount TEA on TE.EventId = TEA.EventID
--inner join TblAccount TA on TEA.AccountID = TA.AccountID
--inner join 
--(
--	select TEC.CustomerID, max(TE.EventDate) as LastEventDate
--	from TblEventCustomers TEC 
--	inner join TblCustomerProfile TC ON TEC.CustomerID = TC.CustomerID
--	inner join TblEvents TE on TEC.EventID = TE.EventId
--	inner join TblEventAccount TEA on TE.EventId = TEA.EventID
--	inner join TblAccount TA on TEA.AccountID = TA.AccountID
--	where 1 = 1
--	and TA.IsHealthPlan = 1 
--	and (TC.Tag is NULL or Ltrim(Rtrim(TC.Tag)) = '')	
--	--and TEC.AppointmentID is NOT NULL
--	group by TEC.CustomerID
--)temp on TEC.CustomerID = temp.CustomerID and TE.EventDate = temp.LastEventDate
--where 1 = 1
--and TA.IsHealthPlan = 1 
--and (TC.Tag is NULL or Ltrim(Rtrim(TC.Tag)) = '')	
----and TEC.AppointmentID is NOT NULL

----and TC.CustomerId in 
----(
----1791508,
----1856619
----)
----group by TC.CustomerId
----having count(*)>1
--order by TC.CustomerId

-- Update Tag

Update TblCustomerProfile
set Tag = TA.Tag
from TblCustomerProfile TC	 
inner join TblEventCustomers TEC ON TEC.CustomerID = TC.CustomerID
inner join TblEvents TE on TEC.EventID = TE.EventId
inner join TblEventAccount TEA on TE.EventId = TEA.EventID
inner join TblAccount TA on TEA.AccountID = TA.AccountID
inner join 
(
	select TEC.CustomerID, max(TE.EventDate) as LastEventDate
	from TblEventCustomers TEC 
	inner join TblCustomerProfile TC ON TEC.CustomerID = TC.CustomerID
	inner join TblEvents TE on TEC.EventID = TE.EventId
	inner join TblEventAccount TEA on TE.EventId = TEA.EventID
	inner join TblAccount TA on TEA.AccountID = TA.AccountID
	where 1 = 1
	and TA.IsHealthPlan = 1 
	and (TC.Tag is NULL or Ltrim(Rtrim(TC.Tag)) = '')	
	--and TEC.AppointmentID is NOT NULL
	group by TEC.CustomerID
)temp on TEC.CustomerID = temp.CustomerID and TE.EventDate = temp.LastEventDate
where 1 = 1
and TA.IsHealthPlan = 1 
and (TC.Tag is NULL or Ltrim(Rtrim(TC.Tag)) = '')	