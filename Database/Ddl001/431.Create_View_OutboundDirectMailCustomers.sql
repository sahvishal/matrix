
USE [$(dbName)]
Go

CREATE VIEW vw_OutboundDirectMailCustomers
As
select c.CallID ,c.CalledCustomerID,'Outbound' as OutreachType,c.DateCreated,cqc.HealthPlanId from TblCallQueueCustomerCall cqcc
join TblCalls c on cqcc.CallId =c.CallID
join TblCallQueueCustomer cqc on cqcc.CallQueueCustomerId=cqc.CallQueueCustomerId
where c.OutBound is not null and c.OutBound=1 and cqc.HealthPlanId is not null  and c.Status !=35
union All
select dm.Id,dm.CustomerId,'DirectMail',dm.MailDate ,'' from TblDirectMail dm