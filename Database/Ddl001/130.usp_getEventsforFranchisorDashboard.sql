USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_getEventsforFranchisorDashboard]    Script Date: 05/07/2013 13:19:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Sandeep Raheja
-- Create date: Jan 11, 2008
-- Description:	Mode 0 = Tommorow, 1 = Next 7Days, 2 = Next 30Days, 3 = All
-- =============================================
ALTER PROCEDURE [dbo].[usp_getEventsforFranchisorDashboard](@mode tinyint)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@mode = 0)
	BEGIN
		
		SELECT Top 5 TE.EventID, TORU.OrganizationId FranchiseeID, TE.AssignedToOrgRoleUserId SalesRepID, EventName, EventDate,  0 as MarketingMaterialType, 
			TH.ProspectID HostID, TH.AddressID, isnull(TH.PhoneOffice,' ') as HostPhone, TH.[OrganizationName] HostName, 
			isnull(TFEC.customercount,0) customercount, isnull(vwPaidCount.PaidCustomers, 0) PaidCustomers,
			isnull(vwPaidCount.Amount, 0) PaidAmount, isnull(vwUnpaidCount.UnpaidCustomers, 0) UnpaidCustomers, 
			isnull(vwUnpaidCount.Amount, 0) UnpaidAmount, TC.[Name] CountryName, TS.[Name] StateName,
			TCY.[Name] CityName, TA.Address1, TZ.ZipCode, 
			isnull(vw_slots.TotalSlots, 0) TotalSlots, isnull(vw_slots.FilledSlots, 0) FilledSlots
			from TblEvents TE
			inner join TblOrganizationRoleUser TORU on TE.AssignedToOrgRoleUserId = TORU.OrganizationRoleUserId
			inner join TblHostEventDetails THED on TE.eventid = THED.eventid
			inner join TblProspects TH on TH.ProspectID = THED.HostID
			inner join TblAddress TA on TH.AddressID = TA.AddressID
			inner join TblCountry TC on TC.CountryID = TA.CountryID
			inner join TblState TS on TS.StateID = TA.StateID
			inner join TblCity TCY on TCY.CityID = TA.CityID
			inner join TblZip TZ on TZ.ZipID = TA.ZipID
			left outer join 
			(SELECT count(*) as customercount,eventid from tbleventcustomers where AppointmentID is not null
			group by eventid) TFEC on TFEC.eventid = TE.eventid
			left outer join
			(Select count(*) PaidCustomers, Sum(PaidAmount) as Amount, EventID from TblEventCustomers 
				inner join
				(
					Select EventCustomerID,PaidAmount from vw_CustomerEventBasicInfo where IsPaid = 1					
				) a on a.EventCustomerID = TblEventCustomers.EventCustomerID group by EventID 
			) vwPaidCount on vwPaidCount.EventID = TE.EventID
			left outer join
			(Select count(*) UnpaidCustomers, Sum(UnpaidAmount) as Amount, EventID from TblEventCustomers 
				inner join 
				(
					Select EventCustomerID,UnpaidAmount from vw_CustomerEventBasicInfo where IsPaid = 0
				) a on a.EventCustomerID = TblEventCustomers.EventCustomerID group by EventID
			) vwUnpaidCount on vwUnpaidCount.EventID = TE.EventID
			inner join 
			(Select TotalSlots, FilledSlots, vw_TotalSlots.EventID from (Select count(*) TotalSlots, EventID from TblEventSchedulingSlot with (nolock) group by eventid) vw_TotalSlots
				left outer join (Select count(*) FilledSlots, EventID from TblEventSchedulingSlot with (nolock) where [Status] = 150
					group by eventid) vw_FilledSlots on vw_FilledSlots.EventID = vw_TotalSlots.EventID) vw_slots
				on vw_slots.EventID = TE.EventID
			where TE.isactive = 1 and  (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)) = CONVERT(DATETIME, convert(varchar, getdate() + 1,101))) and 1=0
			order by (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)))

	END
	Else IF(@mode = 1)
	BEGIN

		SELECT Top 5 TE.EventID, TORU.OrganizationId FranchiseeID, TE.AssignedToOrgRoleUserId SalesRepID, EventName, EventDate,  0 as MarketingMaterialType, 
			TH.ProspectID HostID, TH.AddressID, isnull(TH.PhoneOffice,' ') as HostPhone, TH.[OrganizationName] HostName, 
			isnull(TFEC.customercount,0) customercount, isnull(vwPaidCount.PaidCustomers, 0) PaidCustomers,
			isnull(vwPaidCount.Amount, 0) PaidAmount, isnull(vwUnpaidCount.UnpaidCustomers, 0) UnpaidCustomers, 
			isnull(vwUnpaidCount.Amount, 0) UnpaidAmount, TC.[Name] CountryName, TS.[Name] StateName,
			TCY.[Name] CityName, TA.Address1, TZ.ZipCode,
			isnull(vw_slots.TotalSlots, 0) TotalSlots, isnull(vw_slots.FilledSlots, 0) FilledSlots
			from TblEvents TE
			inner join TblOrganizationRoleUser TORU on TE.AssignedToOrgRoleUserId = TORU.OrganizationRoleUserId
			inner join TblHostEventDetails THED on TE.eventid = THED.eventid
			inner join TblProspects TH on TH.ProspectID = THED.HostID
			inner join TblAddress TA on TH.AddressID = TA.AddressID
			inner join TblCountry TC on TC.CountryID = TA.CountryID
			inner join TblState TS on TS.StateID = TA.StateID
			inner join TblCity TCY on TCY.CityID = TA.CityID
			inner join TblZip TZ on TZ.ZipID = TA.ZipID
			left outer join 
			(SELECT count(*) as customercount,eventid from tbleventcustomers where AppointmentID is not null
			group by eventid) TFEC on TFEC.eventid = TE.eventid
			left outer join
			(Select count(*) PaidCustomers, Sum(PaidAmount) as Amount, EventID from TblEventCustomers 
				inner join
				(
					Select EventCustomerID,PaidAmount from vw_CustomerEventBasicInfo where IsPaid = 1					
				) a on a.EventCustomerID = TblEventCustomers.EventCustomerID group by EventID 
			) vwPaidCount on vwPaidCount.EventID = TE.EventID
			left outer join
			(Select count(*) UnpaidCustomers, Sum(UnpaidAmount) as Amount, EventID from TblEventCustomers 
				inner join 
				(
					Select EventCustomerID,UnpaidAmount from vw_CustomerEventBasicInfo where IsPaid = 0
				) a on a.EventCustomerID = TblEventCustomers.EventCustomerID group by EventID
			) vwUnpaidCount on vwUnpaidCount.EventID = TE.EventID
			inner join 
			(Select TotalSlots, FilledSlots, vw_TotalSlots.EventID from (Select count(*) TotalSlots, EventID from TblEventSchedulingSlot with (nolock) group by eventid) vw_TotalSlots
				left outer join (Select count(*) FilledSlots, EventID from TblEventSchedulingSlot with (nolock) where [Status] = 150
					group by eventid) vw_FilledSlots on vw_FilledSlots.EventID = vw_TotalSlots.EventID) vw_slots
				on vw_slots.EventID = TE.EventID
			where TE.isactive = 1 and  (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)) > CONVERT(DATETIME, convert(varchar, getdate(),101)))
			and (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)) <= CONVERT(DATETIME, convert(varchar, getdate() + 7,101))) and 1=0
			order by (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)))

	END
	Else IF(@mode = 2)
	BEGIN

		SELECT Top 5 TE.EventID, TORU.OrganizationId FranchiseeID, TE.AssignedToOrgRoleUserId SalesRepID, EventName, EventDate,  0 as MarketingMaterialType, 
			TH.ProspectID HostID, TH.AddressID, isnull(TH.PhoneOffice,' ') as HostPhone, TH.[OrganizationName] HostName, 
			isnull(TFEC.customercount,0) customercount, isnull(vwPaidCount.PaidCustomers, 0) PaidCustomers,
			isnull(vwPaidCount.Amount, 0) PaidAmount, isnull(vwUnpaidCount.UnpaidCustomers, 0) UnpaidCustomers, 
			isnull(vwUnpaidCount.Amount, 0) UnpaidAmount, TC.[Name] CountryName, TS.[Name] StateName,
			TCY.[Name] CityName, TA.Address1, TZ.ZipCode,
			isnull(vw_slots.TotalSlots, 0) TotalSlots, isnull(vw_slots.FilledSlots, 0) FilledSlots
			from TblEvents TE
			inner join TblOrganizationRoleUser TORU on TE.AssignedToOrgRoleUserId = TORU.OrganizationRoleUserId
			inner join TblHostEventDetails THED on TE.eventid = THED.eventid
			inner join TblProspects TH on TH.ProspectID = THED.HostID
			inner join TblAddress TA on TH.AddressID = TA.AddressID
			inner join TblCountry TC on TC.CountryID = TA.CountryID
			inner join TblState TS on TS.StateID = TA.StateID
			inner join TblCity TCY on TCY.CityID = TA.CityID
			inner join TblZip TZ on TZ.ZipID = TA.ZipID
			left outer join 
			(SELECT count(*) as customercount,eventid from tbleventcustomers where AppointmentID is not null
			group by eventid) TFEC on TFEC.eventid = TE.eventid
			left outer join
			(Select count(*) PaidCustomers, Sum(PaidAmount) as Amount, EventID from TblEventCustomers 
				inner join
				(
					Select EventCustomerID,PaidAmount from vw_CustomerEventBasicInfo where IsPaid = 1					
				) a on a.EventCustomerID = TblEventCustomers.EventCustomerID group by EventID 
			) vwPaidCount on vwPaidCount.EventID = TE.EventID
			left outer join
			(Select count(*) UnpaidCustomers, Sum(UnpaidAmount) as Amount, EventID from TblEventCustomers 
				inner join 
				(
					Select EventCustomerID,UnpaidAmount from vw_CustomerEventBasicInfo where IsPaid = 0
				) a on a.EventCustomerID = TblEventCustomers.EventCustomerID group by EventID
			) vwUnpaidCount on vwUnpaidCount.EventID = TE.EventID
			inner join 
			(Select TotalSlots, FilledSlots, vw_TotalSlots.EventID from (Select count(*) TotalSlots, EventID from TblEventSchedulingSlot with (nolock) group by eventid) vw_TotalSlots
				left outer join (Select count(*) FilledSlots, EventID from TblEventSchedulingSlot with (nolock) where [Status] = 150
					group by eventid) vw_FilledSlots on vw_FilledSlots.EventID = vw_TotalSlots.EventID) vw_slots
				on vw_slots.EventID = TE.EventID
			where TE.isactive = 1 and  (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)) > CONVERT(DATETIME, convert(varchar, getdate(),101)))
			and (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)) <= CONVERT(DATETIME, convert(varchar, getdate() + 30,101))) and 1=0
			order by (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)))

	END    
	Else IF(@mode = 3)
	BEGIN

		SELECT Top 5 TE.EventID, TORU.OrganizationId FranchiseeID, TE.AssignedToOrgRoleUserId SalesRepID, EventName, EventDate,  0 as MarketingMaterialType, 
			TH.ProspectID HostID, TH.AddressID, isnull(TH.PhoneOffice,' ') as HostPhone, TH.[OrganizationName] HostName, 
			isnull(TFEC.customercount,0) customercount, isnull(vwPaidCount.PaidCustomers, 0) PaidCustomers,
			isnull(vwPaidCount.Amount, 0) PaidAmount, isnull(vwUnpaidCount.UnpaidCustomers, 0) UnpaidCustomers, 
			isnull(vwUnpaidCount.Amount, 0) UnpaidAmount, TC.[Name] CountryName, TS.[Name] StateName,
			TCY.[Name] CityName, TA.Address1, TZ.ZipCode,
			isnull(vw_slots.TotalSlots, 0) TotalSlots, isnull(vw_slots.FilledSlots, 0) FilledSlots
			from TblEvents TE
			inner join TblOrganizationRoleUser TORU on TE.AssignedToOrgRoleUserId = TORU.OrganizationRoleUserId
			inner join TblHostEventDetails THED on TE.eventid = THED.eventid
			inner join TblProspects TH on TH.ProspectID = THED.HostID
			inner join TblAddress TA on TH.AddressID = TA.AddressID
			inner join TblCountry TC on TC.CountryID = TA.CountryID
			inner join TblState TS on TS.StateID = TA.StateID
			inner join TblCity TCY on TCY.CityID = TA.CityID
			inner join TblZip TZ on TZ.ZipID = TA.ZipID
			left outer join 
			(SELECT count(*) as customercount,eventid from tbleventcustomers where AppointmentID is not null
				group by eventid) TFEC on TFEC.eventid = TE.eventid
			left outer join
			(Select count(*) PaidCustomers, Sum(PaidAmount) as Amount, EventID from TblEventCustomers 
				inner join
				(
					Select EventCustomerID,PaidAmount from vw_CustomerEventBasicInfo where IsPaid = 1					
				) a on a.EventCustomerID = TblEventCustomers.EventCustomerID group by EventID 
			) vwPaidCount on vwPaidCount.EventID = TE.EventID
			left outer join
			(Select count(*) UnpaidCustomers, Sum(UnpaidAmount) as Amount, EventID from TblEventCustomers 
				inner join 
				(
					Select EventCustomerID,UnpaidAmount from vw_CustomerEventBasicInfo where IsPaid = 0
				) a on a.EventCustomerID = TblEventCustomers.EventCustomerID group by EventID
			) vwUnpaidCount on vwUnpaidCount.EventID = TE.EventID
			inner join 
			(Select TotalSlots, FilledSlots, vw_TotalSlots.EventID from (Select count(*) TotalSlots, EventID from TblEventSchedulingSlot with (nolock) group by eventid) vw_TotalSlots
				left outer join (Select count(*) FilledSlots, EventID from TblEventSchedulingSlot with (nolock) where [Status] = 150
					group by eventid) vw_FilledSlots on vw_FilledSlots.EventID = vw_TotalSlots.EventID) vw_slots
				on vw_slots.EventID = TE.EventID
			where TE.isactive = 1 and  (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)) > CONVERT(DATETIME, convert(varchar, getdate(),101))) and 1=0
			order by (CONVERT(DATETIME,CONVERT(VARCHAR,TE.EventDate,101)))

	END


END

