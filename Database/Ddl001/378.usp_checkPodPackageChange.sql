USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_checkPodPackageChange]    Script Date: 12/09/2015 01:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Changes to point new order system tables
-- =============================================
ALTER PROCEDURE [dbo].[usp_checkPodPackageChange] 
	-- Add the parameters for the stored procedure here
	(@PackageIds VARCHAR(100), @EventID BIGINT, @returnValue INT OUTPUT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @query VARCHAR(2000)

	DECLARE @CustomerCount INT
	
	SET @CustomerCount=0
	IF(len(@PackageIds) > 0)
	BEGIN
		SET @query='SELECT TEC.EventCustomerId from TblEventCustomers TEC
		INNER JOIN TblEventCustomerOrderDetail TECOD on TECOD.EventCustomerId = TEC.EventCustomerID
		INNER JOIN TblOrderDetail TOD on TOD.OrderDetailId=TECOD.OrderDetailId
		INNER JOIN TblOrderDetail TOD1 on TOD1.OrderId=TOD.OrderId
		INNER JOIN TblOrderItem TPI ON TPI.OrderItemId = TOD1.OrderItemId 
		INNER JOIN TblEventPackageOrderItem TEPOI On TEPOI.OrderItemId = TPI.OrderItemId
		INNER JOIN [TblEventPackageDetails] TEPD ON TEPD.EventPackageId = TEPOI.EventPackageID
		where TEC.EventId=' + CAST(@EventID AS VARCHAR) + '
		AND TECOD.IsActive=1 AND TOD1.Status=1 AND TPI.Type=1 AND TEPD.[PackageID] NOT IN (' + @PackageIds + ')'
		EXECUTE (@query )
		SET @CustomerCount=@@ROWCOUNT
		IF(@CustomerCount>0)
		BEGIN
			SET @returnValue=0
		END
		ELSE
		BEGIN
			SET @returnValue=1
		END
	END
	ELSE
	BEGIN
		SET @returnValue=1
	END
END
