USE [$(dbname)]
GO

DECLARE @callQueueId BIGINT

INSERT INTO TblCallQueue([Name], [Description], [Attempts], [DateCreated], [DateModified], [CreatedByOrgRoleUserId], [ModifiedByOrgRoleUserId], [IsActive], 
							[IsQueueGenerated], [QueueGenerationInterval], [LastQueueGeneratedDate], [ScriptId], [IsManual], [Category], [IsHealthPlan])
     VALUES('Confirmation', 'This will give you the list of customers who are registered for future events.', 10, GETDATE(), GETDATE(), 1, 1, 1, 0, 0, NULL, NULL, 0, 'AppointmentConfirmation', 1)

SET @callQueueId = SCOPE_IDENTITY()

DECLARE AccountCursor CURSOR FOR 
SELECT A.AccountID, O.NAME FROM TblAccount A with(nolock)
JOIN TblOrganization O ON A.AccountID = O.OrganizationID
WHERE IsHealthPlan = 1

DECLARE @AccountId BIGINT, @AccountName VARCHAR(100)

OPEN AccountCursor

FETCH NEXT FROM AccountCursor INTO @AccountId, @AccountName

WHILE @@FETCH_STATUS = 0  
BEGIN
	INSERT INTO TblHealthPlanCallQueueCriteria (CallQueueId, Percentage, NoOfDays, RoundOfCalls, StartDate, EndDate, HealthPlanId, CustomTags, IsDefault, IsQueueGenerated, LastQueueGeneratedDate, DateCreated, 
												CreatedByOrgRoleUserId, ZipCode, Radius, IsDeleted, CampaignId, CriteriaName)
	VALUES (@callQueueId, 0, 0, 0, NULL, NULL, @AccountId, NULL, 0, 0, NULL, GETDATE(), 1, NULL, NULL, 0, NULL, @AccountName + ' Confirmation')

	UPDATE TblAccount SET EventConfirmationBeforeDays = 7 WHERE AccountID = @AccountId

	FETCH NEXT FROM AccountCursor INTO  @AccountId, @AccountName
END
CLOSE AccountCursor
DEALLOCATE AccountCursor
GO