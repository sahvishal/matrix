USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomerForMailRoundInsertion]    Script Date: 3/30/2018 3:12:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[Vw_GetCustomerForMailRoundInsertion] 
As

	SELECT CP.CustomerID		
		,CP.DoNotContactReasonId
		,CP.DoNotContactReasonNotesId		
		,0 as IsEligble
		,CP.IsIncorrectPhoneNumber
		,CP.IsLanguageBarrier
		,CP.ActivityId
		,CP.DoNotContactTypeId
		,CP.Tag
		, 0 as ZipID
		FROM TblCustomerProfile AS CP WITH (NOLOCK) 

		WHERE CP.Tag IS NOT NULL AND CP.Tag <> ''
			


GO


