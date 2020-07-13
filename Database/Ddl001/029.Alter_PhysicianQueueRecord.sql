USE [$(dbName)]
Go

ALTER View vw_PhysicianQueueRecord
As
Select Q.EventCustomerResultId, EventId, CustomerId, PhysicianId, OverreadPhysicianId, Convert(bit, (Case When ResultState = 5 then 1 else 0 end)) IsAtOverreadState,  Z.EvaluatedByOrgRoleUserId,
	Convert(bit, Z.SelfPresent) CriticalMarkedByTechnician, ResultSummary,  
	Convert(bit, (Case when P.EventCustomerResultId is null then 0 when P.PhysicianOrgRoleUserId = PhysicianId then 1 else 0 end)) SentBackatPrimaryEval,   
	Convert(bit, (Case when P.EventCustomerResultId is null then 0 when P.PhysicianOrgRoleUserId = OverreadPhysicianId then 1 else 0 end)) SentBackatOverread,   
	isnull(Z.UpdatedOn, Z.CreatedOn) as UpdatedOn from 
	(
		Select A.EventCustomerResultId, A.EventId, A.CustomerId, B.PhysicianId, B.OverReadPhysicianId, ResultState, ResultSummary  from TblEventCustomerResult A inner join TblPhysicianEventAssignment B
				on A.EventId = B.EventId
		where ((A.ResultState = 4 and A.IsPartial = 0) or (A.ResultState = 5 and A.IsPartial = 1)) and B.IsActive = 1
				and EventCustomerResultId not in (select EventCustomerId from TblPhysicianCustomerAssignment where IsActive = 1)
		union		
		Select A.EventCustomerResultId, A.EventId, A.CustomerId, B.PhysicianId, B.OverReadPhysicianId, ResultState, ResultSummary  from TblEventCustomerResult A inner join TblPhysicianCustomerAssignment B
				on A.EventCustomerResultId = B.EventCustomerId
		where ((A.ResultState = 4 and A.IsPartial = 0) or (A.ResultState = 5 and A.IsPartial = 1)) and B.IsActive = 1
	) Q
inner join 
	(Select EventCustomerResultId, Max(EvaluatedByOrgRoleUserId) EvaluatedByOrgRoleUserId, Max(CreatedOn) CreatedOn, Max(UpdatedOn) UpdatedOn, Max(Convert(int, SelfPresent)) SelfPresent from TblCustomerEventScreeningTests X 
		inner join TblCustomerEventTestState Y on X.CustomerEventScreeningTestId = Y.CustomerEventScreeningTestId 
		where evaluationstate between 4 and 5 group by X.EventCustomerResultId
	) Z
	on Q.EventCustomerResultId = Z.EventCustomerResultId
left outer Join TblCustomerResultScreeningCommunication P on Q.EventCustomerResultId = P.EventCustomerResultId