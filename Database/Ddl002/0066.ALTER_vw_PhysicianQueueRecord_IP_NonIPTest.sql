USE [$(dbName)]
GO 

ALTER View [dbo].[vw_PhysicianQueueRecord]
As
Select Q.EventCustomerResultId, Q.EventId, Q.CustomerId, PhysicianId, OverreadPhysicianId, Convert(bit, (Case When Q.ResultState = 5 then 1 else 0 end)) IsAtOverreadState,  
	Z.EvaluatedByOrgRoleUserId,

	CASE WHEN (T2.CriticalHIPTest = 1 ) THEN Convert(bit, 1)
	     WHEN (T1.CriticalCHATTest = 1 ) THEN Convert(bit, 0) ELSE Convert(bit, Z.SelfPresent) END CriticalMarkedByTechnician,
	Q.ResultSummary,
	Convert(bit, (select TOP 1 Case when PhysicianOrgRoleUserId > 0 Then 1 Else 0 End from TblCustomerResultScreeningCommunication TCRSC with(nolock) where TCRSC.EventCustomerResultId =
	 Q.EventCustomerResultId and TCRSC.PhysicianOrgRoleUserId = PhysicianId))

 SentBackatPrimaryEval,   
	Convert(bit, (select TOP 1 Case when PhysicianOrgRoleUserId > 0 Then 1 Else 0 End from TblCustomerResultScreeningCommunication TCRSC with(nolock) where TCRSC.EventCustomerResultId = 
	Q.EventCustomerResultId and TCRSC.PhysicianOrgRoleUserId = OverreadPhysicianId)) SentBackatOverread, 
	  Q.InQueuePriority  InQueuePriority
	,isnull(Z.UpdatedOn, Z.CreatedOn) as UpdatedOn ,T1.CriticalChatTest
	, isnull(Z.UpdatedOn, Z.CreatedOn) as CriticalChatDate
	,T2.CriticalHIPTest CriticalHIPTest
	from 
	TblEventCustomerResult ECR 
	inner join
	(
		Select EventCustomerResultId, Max(EvaluatedByOrgRoleUserId) EvaluatedByOrgRoleUserId, Max(CreatedOn) CreatedOn, Max(UpdatedOn) UpdatedOn
		, Max(Convert(int, SelfPresent)) SelfPresent
		from TblCustomerEventScreeningTests X with(nolock)
		inner join TblCustomerEventTestState Y with(nolock) on X.CustomerEventScreeningTestId = Y.CustomerEventScreeningTestId 
		where evaluationstate between 4 and 5  group by X.EventCustomerResultId --, y.CreatedOn
		--order by EventCustomerResultId desc
	) Z
	on ECR.EventCustomerResultId = Z.EventCustomerResultId
    inner join 
	(
		Select A.EventCustomerResultId, A.EventId, A.CustomerId, B.PhysicianId, B.OverReadPhysicianId, ResultState, ResultSummary, isnull(P.InQueuePriority, 0) InQueuePriority 
			from TblEventCustomerResult A with(nolock) 
			inner join TblPhysicianEventAssignment B with(nolock) on A.EventId = B.EventId
			left join TblPriorityInQueue P with(nolock) on P.EventCustomerResultId = A.EventCustomerResultId and P.IsActive = 1
		where ((A.ResultState = 4 and A.IsPartial = 0) or (A.ResultState = 5 and A.IsPartial = 1)) and B.IsActive = 1
				and A.EventCustomerResultId not in (select EventCustomerId from TblPhysicianCustomerAssignment with(nolock) where IsActive = 1)
		union		
		Select A.EventCustomerResultId, A.EventId, A.CustomerId, B.PhysicianId, B.OverReadPhysicianId, ResultState, ResultSummary, isnull(P.InQueuePriority, 0) InQueuePriority 
		from TblEventCustomerResult A with(nolock) 
		inner join TblPhysicianCustomerAssignment B with(nolock) on A.EventCustomerResultId = B.EventCustomerId
		left join TblPriorityInQueue P with(nolock) on P.EventCustomerResultId = A.EventCustomerResultId and P.IsActive = 1
		where ((A.ResultState = 4 and A.IsPartial = 0) or (A.ResultState = 5 and A.IsPartial = 1)) and B.IsActive = 1
	) Q
	on Q.EventCustomerResultId = ECR.EventCustomerResultId
	LEFT JOIN 
	(
	        SELECT cest.EventCustomerResultId,
			Max(Convert(int, cets.SelfPresent)) CriticalChatTest
			FROM TblCustomerEventScreeningTests cest with(nolock)
			inner join TblEventCustomerResult ecr with(nolock) on ecr.EventCustomerResultId = cest.EventCustomerResultId 
			inner join TblCustomerEventTestState cets with(nolock) on cest.CustomerEventScreeningTestId = cets.CustomerEventScreeningTestId 
			inner join TblEventTest et with(nolock) on et.EventID = ecr.EventID AND cest.TestId = et.TestID
			Where et.ResultEntryTypeId = 421 AND evaluationstate between 4 and 5
			Group by cest.EventCustomerResultId
	) T1 ON T1.EventCustomerResultId = ECR.EventCustomerResultId
	LEFT JOIN 
	(
	        SELECT cest.EventCustomerResultId,
			Max(Convert(int, cets.SelfPresent)) CriticalHIPTest
			FROM TblCustomerEventScreeningTests cest with(nolock)
			inner join TblEventCustomerResult ecr with(nolock) on ecr.EventCustomerResultId = cest.EventCustomerResultId 
			inner join TblCustomerEventTestState cets with(nolock) on cest.CustomerEventScreeningTestId = cets.CustomerEventScreeningTestId 
			inner join TblEventTest et with(nolock) on et.EventID = ecr.EventID AND cest.TestId = et.TestID
			Where et.ResultEntryTypeId = 420 AND evaluationstate between 4 and 5
			Group by cest.EventCustomerResultId
	) T2 ON T2.EventCustomerResultId = ECR.EventCustomerResultId
    where ECR.EventCustomerResultId not in (Select EventCustomerId from TblCustomerSkipReview with(nolock) where IsActive = 1)





