USE [$(dbName)]
Go

Update TblAccount 
set AttachCongitiveClockForm = 1
	,AttachChronicEvaluationForm = 1	
where AccountID = 966
GO

Update TblAccount 
set AttachCongitiveClockForm = 1
	,AttachQualityAssuranceForm = 1
	,AttachParicipantConsentForm = 1
where AccountID in (924, 946)
GO