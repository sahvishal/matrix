USE [$(dbname)]
GO

DECLARE MyCursor CURSOR FOR SELECT Id, HealthPlanId FROM TblCheckListTemplate where IsActive=1; 
DECLARE @ChecklistTemplateId INT;
DECLARE @AccountId BIGINT;
Declare @DefaultTempateId bigint
set @DefaultTempateId = 4


OPEN MyCursor;

FETCH NEXT FROM MyCursor INTO @ChecklistTemplateId, @AccountId

WHILE @@FETCH_STATUS = 0  
BEGIN  

       IF(@AccountId IS NOT NULL)
	   BEGIN
		  UPDATE TblAccount SET CheckListTemplateId = @ChecklistTemplateId WHERE AccountId = @AccountId
	   END

       FETCH NEXT FROM MyCursor INTO @ChecklistTemplateId, @AccountId
END;
CLOSE MyCursor;
DEALLOCATE MyCursor;




Update TblCheckListTemplate SEt IsDefault = 1 Where Id= @DefaultTempateId

--ALTER TABLE TblCheckListTemplate DROP COLUMN HealthPlanId
GO