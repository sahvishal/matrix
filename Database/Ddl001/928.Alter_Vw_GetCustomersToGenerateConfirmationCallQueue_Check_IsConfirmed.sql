USE [$(dbName)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersToGenerateConfirmationCallQueue]    Script Date: 7/31/2018 3:12:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[Vw_GetCustomersToGenerateConfirmationCallQueue]
AS
	SELECT EC.CustomerID
		,CP.Tag
		,EC.EventID
		,E.EventDate
		,EC.EventCustomerID
		,EA.StartTime AS AppointmentTime
		,E.TimeZone
		,A.StateID
		,S.StateCode
		,CP.LanguageId

		FROM TblEventCustomers EC WITH(NOLOCK)
		JOIN TblEvents E WITH(NOLOCK) ON EC.EventID = E.EventID
		JOIN TblEventAppointment EA WITH(NOLOCK) ON EC.AppointmentID = EA.AppointmentID
		JOIN TblCustomerProfile CP WITH(NOLOCK) ON EC.CustomerID = CP.CustomerID
		JOIN TblHostEventDetails HED WITH(NOLOCK) ON EC.EventID = HED.EventID
		JOIN TblProspects H WITH(NOLOCK) ON HED.HostID = H.ProspectID
		JOIN TblAddress A WITH(NOLOCK) ON H.AddressID = A.AddressID
		JOIN TblState S WITH(NOLOCK) ON A.StateID = S.StateID
		WHERE EC.AppointmentID IS NOT NULL AND EC.IsAppointmentConfirmed = 0
		AND E.EventDate >= CONVERT(DATE, GETDATE()) 
		AND CP.Tag IS NOT NULL AND CP.Tag <> ''
		

GO