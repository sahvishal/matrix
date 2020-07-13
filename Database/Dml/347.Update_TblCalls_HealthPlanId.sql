USE [$(dbName)]
Go

update c set c.HealthPlanId=cqc.HealthPlanId from  TblCalls c 
inner join TblCallQueueCustomerCall cqcc on c.CallID = cqcc.CallId
inner join TblCallQueueCustomer cqc on cqc.CallQueueCustomerId = cqcc.CallQueueCustomerId where  cqc.HealthPlanId is not null

update c set HealthPlanId = a.AccountID from tblCalls c 
inner join TblCustomerProfile cp on c.CalledCustomerID = cp.CustomerID 
inner join TblAccount a on a.Tag = cp.Tag where c.CalledCustomerID is not null and c.HealthPlanId is null and cp.Tag <> '' and cp.Tag is not null




