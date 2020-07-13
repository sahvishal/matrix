USE [$(dbName)]
Go

/****** Object:  StoredProcedure [dbo].[usp_CreateSourceCodeFromMarketingOffer]    Script Date: 03/23/2012 16:12:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CreateSourceCodeFromMarketingOffer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_CreateSourceCodeFromMarketingOffer]
GO

/****** Object:  StoredProcedure [dbo].[usp_CreateSourceCodeFromMarketingOffer]    Script Date: 03/23/2012 16:12:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nitin
-- Create date: 04-09-2008
-- Description:	To insert into affiliate
-- Name: [usp_AFCreateAppUserAffiliate]

--=============================================
CREATE PROCEDURE [dbo].[usp_CreateSourceCodeFromMarketingOffer] (
    @marketingofferid BIGINT, @sourcecodeid BIGINT OUTPUT,@sourceCode varchar(100)=''
)
AS

	BEGIN 
		DECLARE @couponid BIGINT 
		SET @couponid=0
		
		IF NOT EXISTS (select couponid from tblcoupons where CouponCode=@sourceCode)
		BEGIN
			INSERT INTO [TblCoupons]
			   ([CouponTypeID] ,[IsPercentage],[CouponValue] ,
			   [CouponDescription] ,[MinimumPurchaseAmount] ,[CreatedByOrgRoleUserid],[ValidityStartDate]
			   ,[ValidityEndDate] ,[DateCreated] ,[DateModified]  ,[IsActive]  ,[MaximumNumberTimesUsed] ,[CouponCode]  ,
			   [CustomerRange])
				     
			SELECT [MarketingOfferTypeID],[IsPercentage],[MarketingOfferValue]
				  ,[MarketingOfferDescription] ,[MinimumPurchaseAmount],1 ,[ValidityStartDate]
				  ,[ValidityEndDate]   ,GETDATE()  ,GETDATE() ,1   ,[MaximumNumberTimesUsed] ,@sourceCode--dbo.fn_GenrateSimpleRandomCode(5,3,'' )
				  ,[CustomerRange]  FROM [TblMarketingOffers] WHERE [MarketingOfferID]=@marketingofferid
			 
			 SET @couponid=@@IDENTITY     
			 
			-----------------------------------------------------------------      
			INSERT INTO [TblCouponSignUpMode]   ([CouponID] ,[SignUpMode])
		     
			SELECT @couponid  ,[SignUpMode]  FROM [TblMarketingOfferSignUpMode] WHERE [MarketingOfferID]=@marketingofferid
			----------------------------------------------------------------------------
			INSERT INTO [TblPackageSourceCodeDiscount]
			([PackageID]  ,[SourceCodeID] ,[Discount] ,[IsPercentage] )

			SELECT [PackageID] ,@couponid  ,[Discount] ,[IsPercentage] 
			FROM [TblPackageMarketingOfferDiscount] WHERE [MarketingOfferID]=@marketingofferid
			--------------------------------------------------------------------------
			INSERT INTO [TblEventCoupons]
			([EventID] ,[CouponID] )
			SELECT [EventID]  ,@couponid   
			FROM [TblEventMarketingOffers]WHERE [MarketingOfferID]=@marketingofferid
		END
		ELSE
		BEGIN
			-- get couponid
			UPDATE tblcoupons set IsActive=1,DateModified=getdate() where CouponCode=@sourceCode
			select @couponid=couponid from tblcoupons where CouponCode=@sourceCode and isactive=1	
		END
		
		SET @sourcecodeid=@couponid	
	END 
RETURN



GO


