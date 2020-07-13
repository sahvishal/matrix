USE [$(dbName)]
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
		WHERE CP.Tag IS NOT NULL AND CP.Tag <> '' AND CP.ProductTypeId IS NOT NULL
			



