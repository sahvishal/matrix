USE [$(dbName)]
Go

DECLARE @EasiestToConvertProspectQueueId BIGINT ,
		@AnnualCallQueueId BIGINT ,
		@CallBackQueueId BIGINT ,
		@FillEventCallQueueId BIGINT ,
		@UpsellCallQueueId BIGINT ,
		@ConfirmationCallQueueId BIGINT,
		@date datetime
		 
SELECT @date = GETDATE()

SELECT @EasiestToConvertProspectQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'EasiestToConvertProspect'
SELECT @AnnualCallQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'Annual'
SELECT @CallBackQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'CallBack'
SELECT @FillEventCallQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'FillEvents'
SELECT @UpsellCallQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'Upsell'
SELECT @ConfirmationCallQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'Confirmation'

UPDATE TblCallQueue SET [Description] = 'This will give you the list of prospects who have visited our system but did not register for the event. Most recent prospect will appear at the top of list.'
WHERE  [CallQueueId] = @EasiestToConvertProspectQueueId  

UPDATE TblCallQueue SET [Description] = 'This list gives to the list of all customers who were screened more than 1 year ago.'
WHERE  [CallQueueId] = @AnnualCallQueueId 

UPDATE TblCallQueue SET [Description] = 'This list give the list of all prospects/customers who have requested a call back by us.'
WHERE  [CallQueueId] = @CallBackQueueId 

UPDATE TblCallQueue SET [Description] = 'This will give you the list events for which booking percentage is less than expected and are scheduled in near future.'
WHERE  [CallQueueId] = @FillEventCallQueueId 

UPDATE TblCallQueue SET [Description] = 'This will give the list of all customers who are registered for events scheduled in near future and there is scope of upsales.'
WHERE  [CallQueueId] = @UpsellCallQueueId 

UPDATE TblCallQueue SET [Description] = 'This will give you the list of customers who are registered for an event in next day or two.'
WHERE  [CallQueueId] = @ConfirmationCallQueueId 