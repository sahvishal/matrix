USE [$(dbName)]
Go

/****** Object:  StoredProcedure [dbo].[usp_SaveSeminarCampaignDetails]    Script Date: 03/23/2012 16:23:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaveSeminarCampaignDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_SaveSeminarCampaignDetails]
GO


/****** Object:  StoredProcedure [dbo].[usp_SaveSeminarCampaignDetails]    Script Date: 03/23/2012 16:23:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ashutosh
-- Create date: <Create Date,,>
-- Description:	Creates campaign for seminar
-- Modified - Change Source Code Logic [13/01/2010] - Viranjay
-- =============================================
CREATE PROCEDURE [dbo].[usp_SaveSeminarCampaignDetails] 
	-- Add the parameters for the stored procedure here
	(@EventID BIGINT
	,@SeminarID BIGINT
	,@SalesRepID BIGINT
	,@userid BIGINT,@roleid BIGINT,@shellid BIGINT
	,@returnResult BIGINT OUTPUT
	,@sourceCode varchar(100)='' )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	
	SET @returnResult=0

	DECLARE @SeminarDate VARCHAR(20)
			,@EventName VARCHAR(500)
			,@EventDate VARCHAR(20)
			,@AffiliateID BIGINT
			
	SELECT @SeminarDate=CONVERT(VARCHAR,[SeminarDate],101) FROM [TblSeminars] WHERE [SeminarID]=@SeminarID
	
	SELECT @EventName=[EventName],@EventDate=CONVERT(VARCHAR,[EventDate],101) FROM [TblEvents] WHERE EventID=@EventID
	
	DECLARE @campaignName VARCHAR(1000)
	SET @campaignName='Wellness Seminar - ' + @SeminarDate + ' - ' + @EventName + ' on ' + @EventDate

	SELECT @AffiliateID=TAA.[AffiliateID] 
	FROM [TblFranchiseeFranchiseeUser] TFFU
	INNER JOIN [TblFranchiseeUser] TFU ON TFFU.[FranchiseeUserID] = TFU.[FranchiseeUserID]
	INNER JOIN [TblAffiliateProfile] TAA ON TAA.[UserId]=TFU.[UserID]
	WHERE TFFU.[FranchiseeFranchiseeUserID]=@SalesRepID

	/************************************************************/

	DECLARE @CampaignType BIGINT
	SET @campaigntype=1 --- for cpa campaign 
				
	DECLARE @CouponCode VARCHAR(15)
	DECLARE @Couponid BIGINT 
	DECLARE @CampaignID BIGINT
	DECLARE @advertiserid BIGINT 
	DECLARE @IncomingPhone VARCHAR(50)
	DECLARE @startdate DATETIME
	DECLARE @enddate DATETIME
	DECLARE @Cost decimal(18,2)
	DECLARE @Commision decimal(18,2)
	DECLARE @ParentAffiliateCommision decimal(18,2)
	DECLARE @IsCommisionPercentage BIT 
	DECLARE @IsGlobale BIT 
	DECLARE @OwnerFranchiseeID BIGINT 
	DECLARE @createdByUserId BIGINT 

	SELECT TOP(1)@createdByUserId= FranchisorFranchisorUserID FROM dbo.TblFranchisorFranchisorUser WHERE IsActive=1

	SET @CouponCode=''

	DECLARE @marketingOfferID BIGINT
	SET @marketingOfferID=0
	SELECT @marketingOfferID=[value] FROM [TblGlobalConfiguration] WHERE [Name]='DefaultMarketingOfferForWelnessSeminar'

	IF  @marketingOfferID> 0
	BEGIN
		PRINT @marketingOfferID
		EXECUTE [dbo].[usp_CreateSeminarSourceCodeFromMarketingOffer] @marketingOfferID,@Couponid OUTPUT,@sourceCode
	END
	ELSE
	BEGIN
		--SET @CouponCode=dbo.fn_GenrateSimpleRandomCode(5,3,'W' )
		SET @CouponCode=@sourceCode
		IF NOT EXISTS (SELECT CouponId from TblCoupons where couponCode=@CouponCode)
		BEGIN
			INSERT INTO [dbo].[TblCoupons]([CouponTypeID],[IsPercentage],[CouponValue],[CouponDescription]
				,[MinimumPurchaseAmount],[CreatedByOrgRoleUserID],[ValidityStartDate],[ValidityEndDate]
				,[DateCreated] ,[DateModified] ,[IsActive],[MaximumNumberTimesUsed],[CouponCode],[CustomerRange])
			VALUES      (1,	0,	0,	'Phone Referral' ,	0,	@createdByUserId ,	'1/1/1901' ,	'1/1/1901',	GETDATE() ,
							GETDATE(),	1 ,	0 ,@CouponCode      ,0)

			SET @Couponid= @@IDENTITY

			INSERT INTO [TblCouponSignUpMode] ( [CouponID],[SignUpMode]) 
			VALUES (@Couponid,0)
		END
		ELSE
		BEGIN
			select @Couponid=CouponId from TblCoupons where couponCode=@CouponCode
		END
	END 
	
	/**********Setting Coupon validity date****************/
	UPDATE TblCoupons
	SET [ValidityStartDate]=@SeminarDate,[ValidityEndDate]=CAST(@EventDate AS DATETIME) + 1
	WHERE [CouponID]=@Couponid
/***********************************************************/
	------------------------------ insert into campaign table


	SELECT @advertiserid=[AdvertiserID],@IncomingPhone=[IncomingPhone],
		@startdate=[StartDate]  ,@enddate=[EndDate] ,@Cost=[Cost],@Commision=[Commision],
		@ParentAffiliateCommision=[ParentAffiliateCommision] ,@IsCommisionPercentage=[IsCommisionPercentage]
		,@IsGlobale=[IsGlobal] ,@OwnerFranchiseeID=OwnerOrganizationId
	 FROM [dbo].[tblAFCampaignTemplate] WHERE TemplateType=@campaigntype
	---------------------------
	DECLARE @campaignvaliditytime INT
	SET @campaignvaliditytime=0
	
	---------------------
	DECLARE @CreatedByOrgRoleUserId bigint
	select @CreatedByOrgRoleUserId =OrganizationRoleUserId from TblOrganizationRoleUser where UserId=@userid and RoleId=@roleid and OrganizationId=@shellid
	INSERT INTO [dbo].[tblAFCampaign]
			   ([CampaignName] ,[PromoCodeID] ,[AdvertiserID] ,[IncomingPhone] ,[StartDate],[EndDate],[Cost]
				,[Commision],[ParentAffiliateCommision],[IsCommisionPercentage],[CreatedDate],
				[LastModifiedDate],[IsActive] ,[IsGlobal],[OwnerOrgRoleUserId] ,[CompensationType],IsAutoGenerated,CreatedByOrgRoleUserId)
		 VALUES
			   (@CampaignName  ,@Couponid ,@advertiserid  ,@IncomingPhone ,@SeminarDate ,CAST(@EventDate AS DATETIME) + 1 ,0.00
			   ,0.00   ,0.00  ,0  ,GETDATE()  ,GETDATE()  ,1,@IsGlobale   ,null     ,1,0,@CreatedByOrgRoleUserId)			

	SET @CampaignID=@@IDENTITY

	/***************Setting Commission************************/
	DECLARE @AdvocateCommissionDollar DECIMAL(18,2)
			,@ParentAdvocateCommissionDollar DECIMAL(18,2)
			,@AdvocateCommissionPercentage DECIMAL(18,2)
			,@ParentAdvocateCommissionPercentage DECIMAL(18,2)
			

	SELECT @AdvocateCommissionDollar=[MaxCommisionDollar]
			,@ParentAdvocateCommissionDollar=[MaxParentCommisionDollar]
			,@AdvocateCommissionPercentage=[MaxCommisionPercentage]				
			,@ParentAdvocateCommissionPercentage=[MaxParentCommisionPercentage]		
	FROM [TblAffiliateProfile]
	WHERE [AffiliateID]=@AffiliateID

	IF(@AdvocateCommissionDollar=0 AND @ParentAdvocateCommissionDollar=0)
	BEGIN
		UPDATE [tblAFCampaign]
		SET [Commision]=@AdvocateCommissionPercentage
			,[ParentAffiliateCommision]=@ParentAdvocateCommissionPercentage
			,[IsCommisionPercentage]=1
		WHERE CampaignID=@CampaignID
	END 
	ELSE
	BEGIN
		UPDATE [tblAFCampaign]
		SET [Commision]=@AdvocateCommissionDollar
			,[ParentAffiliateCommision]=@ParentAdvocateCommissionDollar
			,[IsCommisionPercentage]=0
		WHERE CampaignID=@CampaignID
	END
	/****************************************/

	INSERT INTO dbo.tblAFAffiliateCampaign 
	(
		AffiliateID,
		CampaignID,
		AssignedDate,
		IsAssignmentActive,
		CreatedDate,
		LastModifiedDate,
		IsActive
	) 
	VALUES 
	( 
		/* AffiliateID - bigint */ @AffiliateID,
		/* CampaignID - bigint */ @CampaignID,
		/* AssignedDate - datetime */ GETDATE(),
		/* IsAssignmentActive - bit */ 1,
		/* CreatedDate - datetime */ GETDATE(),
		/* LastModifiedDate - datetime */ GETDATE(),
		/* IsActive - bit */ 1 
	) 
	IF(@@ERROR>0)
	BEGIN
		SET @returnResult=0
		ROLLBACK TRAN
	END
	
		
	SET @returnResult=@CampaignID
	
END

GO


