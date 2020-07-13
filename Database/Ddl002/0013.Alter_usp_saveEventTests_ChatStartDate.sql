USE [$(dbName)]
GO

ALTER PROCEDURE [dbo].[usp_saveEventTests]
	-- Add the parameters for the stored procedure here
(
	@EventId BIGINT,
	@TestId BIGINT,
	@TestPrice DECIMAL(18,2),
	@returnResult BIGINT OUTPUT, 
	@ShowInAlaCarte bit,
	@ScreeningTime int,
	@WithPackagePrice DECIMAL(18,2)
)
AS
BEGIN
	SET NOCOUNT ON;
	SET @returnResult=0
	DECLARE @EventTestId BIGINT
	DECLARE @RefundPrice decimal(18,2)
	DECLARE @PreQualificationQuestionTemplateId BIGINT, @ResultEntryTypeId BIGINT
	DECLARE @EventDate DATETIME, @IsHealthPlan BIT, @ChatStartDate DATETIME, @IsRecordable BIT
	DECLARE @HipQuestionnaire BIGINT = 420, @ChatQuestionnaire BIGINT = 421

	SET @EventTestId=0
	
	Declare @HafTemplateId bigint, @Gender bigint, @IsTestReviewableByPhysician bit, @AccountId bigint
	
	SET @AccountId = 0
	SET @IsTestReviewableByPhysician = null
	
	select TOP 1 @AccountId = A.AccountId, @IsHealthPlan = A.IsHealthPlan, @EventDate = E.EventDate FROM TblEvents E
									LEFT JOIN TblEventAccount EA ON E.EventID = EA.EventID
									LEFT JOIN TblAccount A ON EA.AccountID = A.AccountID WHERE E.EventID = @EventID
	IF(@AccountId > 0)
	BEGIN
		IF EXISTS(select TestId from TblAccountNotReviewableTest where AccountId = @AccountId and TestId = @TestId)
		BEGIN
			SET @IsTestReviewableByPhysician = 0
		END
	END
	
	SELECT @PreQualificationQuestionTemplateId = PreQualificationQuestionTemplateId FROM TblTest WHERE TestID = @TestId
	
	SELECT @RefundPrice = RefundPrice, @HafTemplateId = HAFTemplateId, @Gender = Gender, @ChatStartDate = ChatStartDate, @IsRecordable = IsRecordable FROM TblTest WHERE TestId = @TestId

	SET @ResultEntryTypeId = CASE WHEN @IsRecordable = 0 THEN NULL 
	WHEN (@IsHealthPlan = 0 OR (@ChatStartDate IS NOT NULL AND @EventDate < @ChatStartDate) OR @ChatStartDate IS NULL) THEN @HipQuestionnaire 
	WHEN (@IsHealthPlan = 1 AND @ChatStartDate IS NOT NULL AND @EventDate >= @ChatStartDate) THEN @ChatQuestionnaire 
	ELSE @HipQuestionnaire END

	-- Update Record
	IF EXISTS(SELECT EventTestId FROM dbo.TblEventTest WHERE EventID=@EventID AND TestId=@TestId)
	BEGIN
		SELECT @EventTestId=EventTestId FROM dbo.TblEventTest WHERE EventID=@EventID AND TestId=@TestId
		
		UPDATE dbo.TblEventTest
		SET Price=@TestPrice, RefundPrice = @RefundPrice, ShowInAlaCarte = @ShowInAlaCarte, ScreeningTime = @ScreeningTime, HAFTemplateId = @HafTemplateId
			,WithPackagePrice = @WithPackagePrice, Gender = @Gender, IsTestReviewableByPhysician = @IsTestReviewableByPhysician
			,PreQualificationQuestionTemplateId = @PreQualificationQuestionTemplateId, ResultEntryTypeId = @ResultEntryTypeId
		WHERE EventTestID=@EventTestId

		SET @returnResult=@EventTestId
	END
	-- Insert Record
    ELSE
    BEGIN
		INSERT INTO TblEventTest (EventID, TestId,Price,RefundPrice, ScreeningTime, DateCreated ,DateModified, ShowInAlaCarte, HAFTemplateId, WithPackagePrice, Gender, IsTestReviewableByPhysician, PreQualificationQuestionTemplateId, ResultEntryTypeId)
		VALUES(@EventID,@TestId,@TestPrice,@RefundPrice, @ScreeningTime, GETDATE(),GETDATE(), @ShowInAlaCarte, @HafTemplateId, @WithPackagePrice, @Gender, @IsTestReviewableByPhysician, @PreQualificationQuestionTemplateId, @ResultEntryTypeId)
		SET @returnResult=@@IDENTITY
	END
END



