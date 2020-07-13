USE [$(dbName)]
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_saveEventPackageDetails]
	-- Add the parameters for the stored procedure here
	(@EventID BIGINT,@PackageID BIGINT,@PackagePrice DECIMAL(18,2),@returnResult BIGINT OUTPUT, @ScreeningTime int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET @returnResult=0
	DECLARE @EventPackageID BIGINT
	SET @EventPackageID=0	
	
	
	-- Insert statements for procedure here
	Declare @HafTemplateId bigint
	select @HafTemplateId = HAFTemplateId from TblPackage where PackageId = @PackageID
	
	IF EXISTS(SELECT EventPackageID FROM dbo.TblEventPackageDetails WHERE EventID=@EventID AND PackageID=@PackageID)
	BEGIN
		SELECT @EventPackageID=EventPackageID FROM dbo.TblEventPackageDetails WHERE EventID=@EventID AND PackageID=@PackageID
		UPDATE dbo.TblEventPackageDetails
		SET PackagePrice=@PackagePrice,  ScreeningTime = @ScreeningTime, HAFTemplateId = @HafTemplateId
		WHERE EventPackageID=@EventPackageID
		SET @returnResult=@EventPackageID
		
		delete from TblEventPackageTest where EventPackageId = @returnResult
	END
    ELSE
    BEGIN
		INSERT INTO TblEventPackageDetails (EventID, PackageID ,PackagePrice , ScreeningTime, DateCreated ,DateModified, HAFTemplateId)		
		VALUES(@EventID,@PackageID, @PackagePrice, @ScreeningTime, GETDATE(), GETDATE(), @HafTemplateId)
			
		SET @returnResult=@@IDENTITY
	END
	
	Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice], [DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
		inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
		inner join TblTest TT on TPT.TestId = TT.TestId
		inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId = @returnResult
	order by TET.EventTestId
			
	
END



