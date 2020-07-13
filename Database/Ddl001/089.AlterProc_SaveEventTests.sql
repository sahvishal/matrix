USE [$(dbName)]
Go


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE [dbo].[usp_saveEventTests]
	-- Add the parameters for the stored procedure here
(
	@EventId BIGINT,
	@TestId BIGINT,
	@TestPrice DECIMAL(18,2),
	@returnResult BIGINT OUTPUT, 
	@ShowInAlaCarte bit,
	@ScreeningTime int
)
AS
BEGIN
	SET NOCOUNT ON;
	SET @returnResult=0
	DECLARE @EventTestId BIGINT
	DECLARE @RefundPrice decimal(18,2)
	
	SET @EventTestId=0
	
	select @RefundPrice = RefundPrice from TblTest where TestId = @TestId
	-- Update Record
	IF EXISTS(SELECT EventTestId FROM dbo.TblEventTest WHERE EventID=@EventID AND TestId=@TestId)
	BEGIN
		SELECT @EventTestId=EventTestId FROM dbo.TblEventTest WHERE EventID=@EventID AND TestId=@TestId
		UPDATE dbo.TblEventTest
		SET Price=@TestPrice, RefundPrice = @RefundPrice, ShowInAlaCarte = @ShowInAlaCarte, ScreeningTime = @ScreeningTime
		WHERE EventTestID=@EventTestId
		SET @returnResult=@EventTestId
	END
	-- Insert Record
    ELSE
    BEGIN
		INSERT INTO TblEventTest (EventID, TestId,Price,RefundPrice, ScreeningTime, DateCreated ,DateModified, ShowInAlaCarte)
		VALUES(@EventID,@TestId,@TestPrice,@RefundPrice, @ScreeningTime, GETDATE(),GETDATE(), @ShowInAlaCarte)
		SET @returnResult=@@IDENTITY
	END
END

