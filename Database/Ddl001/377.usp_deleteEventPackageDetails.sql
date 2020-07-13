USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteEventPackageDetails]    Script Date: 12/09/2015 01:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_deleteEventPackageDetails]
	-- Add the parameters for the stored procedure here
	(@EventID BIGINT,@PackageIds VARCHAR(1000), @returnResult BIGINT OUTPUT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	
		SET NOCOUNT ON;
		SET @returnResult=0
		
		DECLARE @noOfRegisteredCustomers BIGINT
				
		SET @noOfRegisteredCustomers=0
		
		-- Insert statements for procedure here
		DECLARE @selectQuery VARCHAR(2000)

		SET @selectQuery='SELECT TEC.EventCustomerId from TblEventCustomers TEC
		INNER JOIN TblEventCustomerOrderDetail TECOD on TECOD.EventCustomerId = TEC.EventCustomerID
		INNER JOIN TblOrderDetail TOD on TOD.OrderDetailId=TECOD.OrderDetailId
		INNER JOIN TblOrderDetail TOD1 on TOD1.OrderId=TOD.OrderId
		INNER JOIN TblOrderItem TPI ON TPI.OrderItemId = TOD1.OrderItemId 
		INNER JOIN TblEventPackageOrderItem TEPOI On TEPOI.OrderItemId = TPI.OrderItemId
		INNER JOIN [TblEventPackageDetails] TEPD ON TEPD.EventPackageId = TEPOI.EventPackageID
		where TEC.EventId=' + CAST(@EventID AS VARCHAR) + '
		AND TECOD.IsActive=1 AND TOD1.Status=1 AND TPI.Type=1 AND TEPD.[PackageID] NOT IN (' + @PackageIds + ')'

		EXECUTE (@selectQuery )
		SET @noOfRegisteredCustomers=@@ROWCOUNT
		IF(@noOfRegisteredCustomers>0)
		BEGIN
			SET @returnResult=0
		END
		ELSE
		BEGIN
			DECLARE @query VARCHAR(2000)
			set @query = 'delete from TblEventPackageTest where EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId =' + CAST(@EventID AS VARCHAR) + ' and PackageId not in (' + @PackageIds + '))'
			EXECUTE (@query)
			SET @query='DELETE FROM [TblEventPackageDetails] WHERE [EventID] = ' + CAST(@EventID AS VARCHAR) + ' AND [PackageID] NOT IN (' + @PackageIds + ')'
			EXECUTE (@query)
			SET @returnResult=@EventID
		END
END

