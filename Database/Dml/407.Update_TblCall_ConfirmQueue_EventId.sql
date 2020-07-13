USE [$(dbname)]
GO

update TblCalls
set EventId = TCQC.EventId
from TblCalls TC 
inner join TblCallQueueCustomerCall TCQCC on TC.CallID = TCQCC.CallID
inner join TblCallQueueCustomer TCQC on TCQCC.CallQueueCustomerId = TCQC.CallQueueCustomerId
where TCQC.CallQueueId = 153 and TCQC.EventCustomerId is NOT NULL
