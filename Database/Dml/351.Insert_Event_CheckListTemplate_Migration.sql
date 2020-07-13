USE [$(dbname)]
GO

delete from TblEventChecklistTemplate where EventId in 
(
	select EventID from tblEvents where EventDate > getDate() - 1
)
and EventID not in 
(
	select EventID from TblEventAccount where AccountID = 1037
) 


INSERT INTO [TblEventChecklistTemplate]
	(EventId,ChecklistTemplateId)
select EventID,(SELECT Id FROM TblCheckListTemplate WHERE HealthPlanId IS NULL and IsActive = 1) AS TemplateId 
	from tblEvents where EventDate < getDate() -1	and EventID not in 
	(
		select EventID from TblEventAccount where AccountID = 1037
	)
	and EventID not in 
	(
		select EventId from TblEventChecklistTemplate
	)
	AND EventDate >= '2017-03-28'
	and EventID in 
	(
		select EventID from TblEventAccount where AccountID in 
		(
			select AccountID from TblAccount where IsHealthPlan = 1
		) 
	)



