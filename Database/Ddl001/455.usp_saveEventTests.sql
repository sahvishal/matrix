USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_saveEventTests]    Script Date: 10/18/2014 15:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
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
	
	SET @EventTestId=0
	
	Declare @HafTemplateId bigint, @Gender bigint, @IsTestReviewableByPhysician bit, @AccountId bigint
	
	SET @AccountId = 0
	SET @IsTestReviewableByPhysician = null
	
	select @AccountId = AccountId from TblEventAccount where EventID = @EventID
	IF(@AccountId > 0)
	BEGIN
		IF EXISTS(select TestId from TblAccountNotReviewableTest where AccountId = @AccountId and TestId = @TestId)
		BEGIN
			SET @IsTestReviewableByPhysician = 0
		END
	END
	
	
	select @RefundPrice = RefundPrice, @HafTemplateId = HAFTemplateId, @Gender = Gender from TblTest where TestId = @TestId
	-- Update Record
	IF EXISTS(SELECT EventTestId FROM dbo.TblEventTest WHERE EventID=@EventID AND TestId=@TestId)
	BEGIN
		SELECT @EventTestId=EventTestId FROM dbo.TblEventTest WHERE EventID=@EventID AND TestId=@TestId
		UPDATE dbo.TblEventTest
		SET Price=@TestPrice, RefundPrice = @RefundPrice, ShowInAlaCarte = @ShowInAlaCarte, ScreeningTime = @ScreeningTime, HAFTemplateId = @HafTemplateId
			,WithPackagePrice = @WithPackagePrice, Gender = @Gender, IsTestReviewableByPhysician = @IsTestReviewableByPhysician
		WHERE EventTestID=@EventTestId
		SET @returnResult=@EventTestId
	END
	-- Insert Record
    ELSE
    BEGIN
		INSERT INTO TblEventTest (EventID, TestId,Price,RefundPrice, ScreeningTime, DateCreated ,DateModified, ShowInAlaCarte, HAFTemplateId, WithPackagePrice, Gender, IsTestReviewableByPhysician)
		VALUES(@EventID,@TestId,@TestPrice,@RefundPrice, @ScreeningTime, GETDATE(),GETDATE(), @ShowInAlaCarte, @HafTemplateId, @WithPackagePrice, @Gender, @IsTestReviewableByPhysician)
		SET @returnResult=@@IDENTITY
	END
END

