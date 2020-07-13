USE [$(dbName)]
Go


INSERT INTO [dbo].[TblPreQualificationResult]
		([EventId]
		,[CustomerId]
		,[TempCartId]
		,[SignUpModeId] 
		,[HighBloodPressure]
		,[Smoker]
		,[HeartDisease]
		,[Diabetic]
		,[ChestPain]
		,[DiagnosedHeartProblem]
		,[HighCholestrol]
		,[OverWeight]
		,[DateCreated]
		,[IsActive]
		,[AgreedWithPrequalificationQuestion]
		,[SkipPreQualificationQuestion]
		,[AgeOverPreQualificationQuestion])


SELECT        
		[EventId]
		,[CustomerId]
		,[Id]
		,3     
		,[HighBloodPressure]
		,[Smoker]
		,[HeartDisease]
		,[Diabetic]
		,[ChestPain]
		,[DiagnosedHeartProblem]
		,[HighCholestrol]
		,[OverWeight]
		,[DateCreated]
		,1
		,[AgreedWithPrequalificationQuestion]
		,[SkipPreQualificationQuestion]
		,[AgeOverPreQualificationQuestion]
	FROM [dbo].[TblTempCart]
	where EventId in 
	(
		select EventId from TblEvents where AskPreQualifierQuestion = 1
	)
	and 
	(
		(HighBloodPressure is not null or Smoker is not null)
		or SkipPreQualificationQuestion = 1
	)

GO