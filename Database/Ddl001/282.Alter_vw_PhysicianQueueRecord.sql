USE [$(dbName)]
Go


/****** Object:  View [dbo].[vw_PhysicianQueueRecord]    Script Date: 04/22/2015 12:10:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER View [dbo].[vw_PhysicianQueueRecord]
As
Select Q.EventCustomerResultId, Q.EventId, Q.CustomerId, PhysicianId, OverreadPhysicianId, Convert(bit, (Case When Q.ResultState = 5 then 1 else 0 end)) IsAtOverreadState,  
	Z.EvaluatedByOrgRoleUserId,
	Convert(bit, Z.SelfPresent) CriticalMarkedByTechnician, 
	Q.ResultSummary,  
	Convert(bit, (Case when P.EventCustomerResultId is null then 0 when P.PhysicianOrgRoleUserId = PhysicianId then 1 else 0 end)) SentBackatPrimaryEval,   
	Convert(bit, (Case when P.EventCustomerResultId is null then 0 when P.PhysicianOrgRoleUserId = OverreadPhysicianId then 1 else 0 end)) SentBackatOverread,  
	Q.InQueuePriority
	,isnull(Z.UpdatedOn, Z.CreatedOn) as UpdatedOn 
	from 
	TblEventCustomerResult ECR inner join
	(Select EventCustomerResultId, Max(EvaluatedByOrgRoleUserId) EvaluatedByOrgRoleUserId, Max(CreatedOn) CreatedOn, Max(UpdatedOn) UpdatedOn, Max(Convert(int, SelfPresent)) SelfPresent 
		from TblCustomerEventScreeningTests X with(nolock)
		inner join TblCustomerEventTestState Y with(nolock) on X.CustomerEventScreeningTestId = Y.CustomerEventScreeningTestId 
		where evaluationstate between 4 and 5 group by X.EventCustomerResultId
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
left outer Join TblCustomerResultScreeningCommunication P with(nolock) on Q.EventCustomerResultId = P.EventCustomerResultId
where ECR.EventCustomerResultId not in (Select EventCustomerId from TblCustomerSkipReview with(nolock) where IsActive = 1)
GO