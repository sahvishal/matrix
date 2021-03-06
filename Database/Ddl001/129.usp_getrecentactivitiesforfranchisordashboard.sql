USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_getrecentactivitiesforfranchisordashboard]    Script Date: 05/07/2013 13:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sandeep Raheja
-- Create date: 27th Feb, 2009
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[usp_getrecentactivitiesforfranchisordashboard](@mode tinyint)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@mode = 0) -- Panel Customer
	BEGIN
		Select TE.EventID, ProspectID, OrganizationName from TblEvents TE inner join TblHostEventDetails THED on TE.EventID = THED.EventID
		inner join TblProspects TP on TP.ProspectID = THED.HostID where TE.EventID in
		(Select Top 4 EventID from TblEventCustomers where appointmentid is not null order by DateCreated desc)

		Select top 4 EventCustomerID, TC.CustomerID, TEC.EventID, isnull(TC.TrackingMarketingID, '') MarketingSource, isnull(CampaignName, '') CampaignName, 
		TU.FirstName, TU.LastName, isnull(TC.Gender, 'N/A') Gender, isnull(Datediff(year,DOB,getdate()), 0) Age
--		, Case When patindex('%total%', PackageName) > 0 then 'T'
--			When patindex('%heart%', PackageName) > 0 then 'CH'
--			When patindex('%bone%', PackageName) > 0 then 'CB'
--			When patindex('%Osteo%', PackageName) > 0 then 'PO'
--			Else 'C' 
--		end as PackageName
		from TblEventCustomers TEC inner join vw_Customers TC on TC.CustomerID = TEC.CustomerID
		inner join TblUser TU on TU.UserID = TC.UserID
--		inner join TblEventPackageDetails TEPD on TEPD.EventPackageID = TEC.EventPackageID
--		inner join TblPackage TP on TP.PackageID = TEPD.PackageID
		left outer join TblAFAffiliateCampaign TAFAC on TEC.AffiliateCampaignID =  TAFAC.AffiliateCampaignID 
		left outer join TblAFCampaign TAFC on TAFC.CampaignID = TAFAC.CampaignID
		where appointmentid is not null order by TEC.DateCreated desc

	END
	ELSE IF(@mode = 1) -- Panel Calls
	BEGIN
		Select top 5 TU.FirstName, TU.LastName, isnull(TC.CustomerID, 0) CustomerID, TimeCreated, TimeEnd, CallBackNumber, IncomingPhoneLine, 
		CallersPhoneNumber, CallStatus from TblCalls TCS 
		left outer join vw_Customers TC on TCS.CalledCustomerID = TC.CustomerID
		inner join TblUser TU on TU.UserID = TC.UserID order by TimeCreated desc
	END
	ELSE IF(@mode = 2) -- Panel Check-Ins
	BEGIN
		Select Top 5 TU.FirstName, TU.LastName, TC.CustomerID, TEC.EventID, CheckInTime From TblEventCustomers TEC 
		inner join (
			Select Convert(DateTime, (Convert(varchar, starttime, 101) + ' ' + Convert(varchar, checkintime, 108))) CheckInTime, AppointmentID  
			from TblEventAppointment where Checkintime is not null) vw_appointment on vw_appointment.AppointmentID = TEC.AppointmentID
		inner join vw_Customers TC on TEC.CustomerID = TC.CustomerID
		inner join TblUser TU on TU.UserID = TC.UserID
		order by CheckInTime desc

	END    

END
