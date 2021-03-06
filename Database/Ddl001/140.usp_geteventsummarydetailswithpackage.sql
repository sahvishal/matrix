USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_geteventsummarydetailswithpackage]    Script Date: 06/17/2013 18:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_geteventsummarydetailswithpackage]
(@eventid bigint, @mode tinyint)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		DECLARE @totalcustomer BIGINT
		DECLARE @paidcustomer BIGINT
		DECLARE @unpaidcustomer bigint
		DECLARE @canceledcustomer BIGINT
		DECLARE @actualcustomer BIGINT
		DECLARE @noshowcustomer BIGINT

		DECLARE @phonecustomer BIGINT
		DECLARE @inetcustomer bigint
		DECLARE @onsitecustomer BIGINT
		DECLARE @upgradecustomer BIGINT
		DECLARE @downgradecustomer BIGINT
		DECLARE @phonepayment Decimal(10, 2)
		DECLARE @inetpayment Decimal(10, 2)
		DECLARE @onsitepayment Decimal(10, 2)
		DECLARE @upgradepayment Decimal(10, 2)
		DECLARE @downgradepayment Decimal(10, 2)
		DECLARE @gcpayment DECIMAL(18, 2)
		DECLARE @gcpaymentcount INT

		DECLARE @cardpayment DECIMAL(10, 2)
		DECLARE @cashpayment DECIMAL(10, 2)
		DECLARE @chequepayment DECIMAL(10, 2)
		DECLARE @echequepayment DECIMAL(10, 2)
		DECLARE @cardpaymentcount INT
		DECLARE @cashpaymentcount INT
		DECLARE @chequepaymentcount INT
		DECLARE @echequepaymentcount INT
		DECLARE @unpaidcustomerforaverage INT
		DECLARE @averagerevenuecount int		
		DECLARE @unpaidamount DECIMAL (12,2)
		DECLARE @averagerevenuetotal DECIMAL (12,2)
		DECLARE @medhistoryfilled BIT
		DECLARE @eventBookedBy varchar(255)
		
		SET @canceledcustomer = 0
		
		SELECT @canceledcustomer = COUNT(*) FROM dbo.TblEventCustomers WHERE AppointmentID is NULL AND  EventID = @eventid
		
		SELECT @totalcustomer = COUNT(*) FROM dbo.TblEventCustomers WHERE EventID = @eventid
		
		SELECT @noshowcustomer = COUNT(*) FROM dbo.TblEventCustomers WHERE NoShow = 1 and AppointmentID IS NOT NULL And EventID = @eventid
		
		-- add unpaid customer to average customer count
		if (@unpaidcustomerforaverage > 0 )
		set @averagerevenuecount= @averagerevenuecount + @unpaidcustomerforaverage

		-- Total average revenue per client
		IF (@averagerevenuetotal = 0 or @averagerevenuecount<=0)
			set @averagerevenuetotal=0
		ELSE
			select @averagerevenuetotal=(ISNULL(@chequepayment, 0) + ISNULL(@cardpayment, 0) + ISNULL(@cashpayment, 0) + ISNULL(@echequepayment, 0) + ISNULL(@unpaidamount, 0)) / @averagerevenuecount
		
		-- Event Booked By
		select @eventBookedBy=TU.FirstName + case when len(ltrim(rtrim(isnull(TU.MiddleName,'')))) > 0 then ' ' + ltrim(rtrim(isnull(TU.MiddleName,''))) + ' ' else ' ' end + TU.LastName from TblUser TU
		where userid = (
			select TORU.UserId from TblEvents 
			inner join TblOrganizationRoleUser TORU on TblEvents.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
			where eventid=@eventid
			)


		SELECT TE.EventID, TE.AssignedToOrgRoleUserId as SalesRepID, EventName, EventDate,TE.DateCreated, EventStartTime, EventEndTime,
			TimeZone, 
			TE.IsActive, TH.ProspectID HostID, TH.AddressID, isnull(TH.PhoneOffice,' ') as HostPhone, 
			TH.[OrganizationName] HostName, ISNULL(@totalcustomer, 0) AS TotalCustomers, 
			ISNULL(@unpaidcustomer, 0) AS UnPaidCustomers,	ISNULL(@paidcustomer, 0) AS PaidCustomers, 
			ISNULL(@noshowcustomer, 0) AS NoShowCustomer, ISNULL(@actualcustomer, 0) AS ActualCustomers,
			ISNULL(@canceledcustomer, 0) AS CanceledCustomers, ISNULL(@cardpayment, 0) AS CardPayment,
			ISNULL(@chequepayment, 0) AS ChequePayment, ISNULL(@cashpayment, 0) AS CashPayment,
			ISNULL(@echequepayment, 0) AS eCheckPayment,
			ISNULL((ISNULL(@chequepayment, 0) + ISNULL(@cashpayment, 0)), 0) AS EIPDeposit,
			(ISNULL(@chequepayment, 0) + ISNULL(@cardpayment, 0) + ISNULL(@cashpayment, 0) + ISNULL(@echequepayment, 0)+ ISNULL(@unpaidamount, 0) + ISNULL(@gcpayment, 0)) AS TotalPayment,
			ISNULL(@cardpaymentcount, 0) CardPaymentCount, ISNULL(@cashpaymentcount, 0) CashPaymentCount,
			ISNULL(@chequepaymentcount, 0) ChequePaymentCount,ISNULL(@echequepaymentcount, 0) eCheckPaymentCount,
			ISNULL(@phonepayment, 0.00) PhonePayment, ISNULL(@phonecustomer, 0) PhoneCustomer,
			ISNULL(@onsitepayment, 0.00) OnsitePayment, ISNULL(@onsitecustomer, 0) OnsiteCustomer,
			ISNULL(@inetpayment, 0.00) InetPayment, ISNULL(@inetcustomer, 0) InetCustomer,
			ISNULL(@upgradepayment, 0.00) UpgradePayment, ISNULL(@upgradecustomer, 0) UpgradeCustomer,
			ISNULL(@downgradepayment, 0.00) DowngradePayment, ISNULL(@downgradecustomer, 0) DowngradeCustomer,
			isnull(@averagerevenuetotal,0) TotalAverageRevenuePerClient,
			isnull(@averagerevenuecount,0) TotalAverageRevenuePerClientCount,
			isnull(@unpaidamount,0) as UnPaidAmount,
			isnull(@unpaidcustomerforaverage,0) as AverageRevenueUnPaidCount,
			isnull(TE.EventNotes, '') EventNotes,
			-- gc payment
			ISNULL(@gcpayment, 0) AS GCPaymentTotal,ISNULL(@gcpaymentcount, 0) GCPaymentCount,
			ISNULL(@eventBookedBy,'') AS EventBookedBy,
			ISNULL(TE.EventTypeId,0) AS EventTypeId,
			TE.EventStatus
			from TblEvents TE
			inner join TblHostEventDetails THED on TE.eventid = THED.eventid
			inner join TblProspects TH on TH.ProspectID = THED.HostID
			where TE.EventID = @eventid --AND TE.isactive = 1 /* commented to show details of inactive events*/


			
			---- Address for host holding the said events
		SELECT AddressID, Address1, Address2, TC.CityID,TC.Name as City,TS.StateID,
			   TS.Name as State,TCO.CountryID,TCO.Name as Country,	TZ.ZipID, TZ.ZipCode,
			   ISNULL(TA.Latitude,'') Latitude,ISNULL(TA.Longitude,'') Longitude,
			   TA.IsManuallyVerified IsManuallyVerified,
			   ISNULL(TA.UseLatLogForMapping,0) UseLatLogForMapping,
			   ISNULL(case when len(TU.middlename) > 0 then TU.FirstName + ' ' + TU.MiddleName + ' ' + TU.LastName
			   else TU.FirstName + ' ' + TU.LastName END,'') as [AddressVerifiedBy]
			from TblAddress TA 
			inner join tblCity	TC	on TA.CityID=TC.CityID
			inner join TblZip		TZ	on TZ.ZipID = TA.ZipID
			inner join tblState	TS	on TA.StateID= TS.StateID
			inner join tblCountry	TCO	on TA.CountryID=TCO.CountryID
			LEFT OUTER JOIN TblOrganizationRoleUser TORU ON TORU.OrganizationRoleUserID=TA.VerificationOrgRoleUserId
			LEFT OUTER JOIN TblUser TU ON TU.UserID = TORU.UserID
			where  TA.AddressID in 
			( Select addressid from TblProspects TH where ProspectID in 
				(Select HostID from TblEvents TE
					inner join tblhosteventdetails thed on te.eventid = thed.eventid
					where TE.EventID = @eventid --AND TE.isactive = 1 /* commented to show details of inactive events*/
				)
			 )

		
		SELECT distinct TPD.PodID, TPD.[Name] AS PodName, TPD.Description, TPD.PodProcessingCapacity,
			TVD.NAME AS vanname, TVD.Make, TVD.VIN, TVD.Description VanDescription
			FROM dbo.TblPodDetails TPD INNER JOIN dbo.TblEventPod  TEP
			ON TPD.PodID = TEP.PodID INNER JOIN dbo.TblVanDetails TVD ON
			TVD.VanID = TPD.VanID WHERE TEP.IsActive =1 AND TPD.IsActive = 1 AND
			TEP.EventID = @eventid


		
		SELECT PodID, [OrganizationRoleUserID] FranchiseeFranchiseeUserID,FirstName, ISNULL(MiddleName,'') MiddleName, 
			LastName, TblRole.[Name] AS rolename, StaffEventRoleID as EventRoleID 
			FROM TblEventStaffAssignment 
			INNER JOIN dbo.[TblOrganizationRoleUser]
			ON TblEventStaffAssignment.[ActualStaffOrgRoleUserId] = [TblOrganizationRoleUser].[OrganizationRoleUserID]
			INNER JOIN dbo.TblUser ON dbo.[TblOrganizationRoleUser].UserID = dbo.TblUser.UserID
			INNER JOIN dbo.TblRole ON dbo.[TblOrganizationRoleUser].RoleID = dbo.TblRole.RoleID
			WHERE eventID = @eventid AND TblEventStaffAssignment.IsActive = 1 
			ORDER BY [TblOrganizationRoleUser].RoleID
			

		SELECT OrganizationRoleUserId FranchiseeFranchiseeUserID, TblUser.UserID, TblUser.FirstName, isnull(TblUser.MiddleName, '') MiddleName, 
                      TblUser.LastName, isnull(TblUser.PhoneOffice, isnull(TblUser.PhoneCell, isnull(TblUser.PhoneHome, ''))) Phone,
						isnull(TblUser.EMail1, '') EMail
		FROM   [TblOrganizationRoleUser] INNER JOIN [TblUser] ON [TblOrganizationRoleUser].[UserID] = [TblUser].[UserID] 
		WHERE [TblOrganizationRoleUser].[OrganizationRoleUserID] =
			(select [AssignedToOrgRoleUserId] from tblevents where eventID = @eventid)
			

		SELECT *  FROM TblStaffEventRole
		-- get all package and customers

END