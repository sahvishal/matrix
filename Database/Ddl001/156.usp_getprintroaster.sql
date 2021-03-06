USE $(dbName)
GO
/****** Object:  StoredProcedure [dbo].[usp_getprintroaster]    Script Date: 09/13/2013 12:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Abhinav Goel
-- Create date: 01-02-2008
-- Description:	To get the detail of the customer details for particular event contact details
-- Name: usp_getprintroaster
-- Parameter:	
--=============================================

ALTER  PROCEDURE [dbo].[usp_getprintroaster](@mode tinyint, @filterstring varchar(500))
AS
BEGIN 
	if(@mode = 0)
	BEGIN
		/* Get Print Roster, only registered customer list */
		
		SELECT 
		ISNULL(TEC.CustomerID, 0) CustomerID,
		ISNULL(TU.FirstName, '') FirstName,
		ISNULL(TU.MiddleName, '') MiddleName,
		ISNULL(TU.LastName, '') LastName,
		ecp.IsPaid,
		---ISNULL(TP.PackageName, '') PackageName,
		ISNULL(dbo.fn_getCustomerEventPackageName( TEC.[EventCustomerID] ),'') PackageName,  
		ISNULL(dbo.fn_getCustomerEventAdditionalTest( TEC.[EventCustomerID] ),'') AdditionalTest,		
		ISNULL(OrderCost, 0.00) CostPrice,
		ISNULL(OrderCost, 0.00) PackagePrice,
		Convert(datetime, convert(varchar, TEA.StartTime, 108)) StartTime,
		Convert(datetime, convert(varchar, TEA.EndTime, 108)) EndTime, 
		isnull(Convert(varchar, TEA.CheckInTime, 108), '__:__:__') CheckInTime,
		isnull(Convert(varchar, TEA.CheckOutTime, 108), '__:__:__') CheckOutTime,
		ISNULL(CouponCode, '') CouponCode, ISNULL(DiscountAmount, 0.00) DiscountAmount, NetPayment,
		ISNULL(TU.Email1, '') Email1,
		(Case When len(IsNull(TU.PhoneHome, '')) > 0 then TU.PhoneHome
			When len(IsNull(TU.PhoneCell, '')) > 0 then TU.PhoneCell
			When len(IsNull(TU.PhoneOffice, '')) > 0 then TU.PhoneOffice
			Else '' end) Phone, ISNULL(isShipping,0) isShipping
		,ISNULL(TEC.AppointmentId,0) as AppointmentId
		from TblEventCustomers TEC with(nolock)
		inner join TblOrganizationRoleUser TC with(nolock) on TC.OrganizationRoleUserId=TEC.CustomerID
		inner join TblUser TU with(nolock) on TU.UserID=TC.UserID		
		inner join TblEventAppointment TEA with(nolock) on TEA.AppointmentID=TEC.AppointmentID
		left outer join 
				fn_EventCustomerPayment(@filterstring) ecp on ecp.EventCustomerId = TEC.EventCustomerId
		INNER JOIN [TblEventCustomerOrderDetail] TECOD with(nolock) ON TECOD.eventcustomerid=TEC.eventcustomerid
		
		where TEC.EventID=@filterstring AND TECOD.[IsActive]=1 order by starttime
		
	
	END
	ELSE IF (@mode = 1)
	BEGIN
		
		/* Get Appointment Schedule, all appointment slots for that event.*/
		SELECT 
			ISNULL(TEC.CustomerID, 0) CustomerID,
			ISNULL(TU.FirstName, '') FirstName,
			ISNULL(TU.MiddleName, '') MiddleName,
			ISNULL(TU.LastName, '') LastName,
			isnull(ecp.IsPaid, 0) IsPaid,
			ISNULL(dbo.fn_getCustomerEventPackageName( TEC.[EventCustomerID] ),'') PackageName,  
			ISNULL(dbo.fn_getCustomerEventAdditionalTest( TEC.[EventCustomerID] ),'') AdditionalTest,
			ISNULL(OrderCost, 0.00) CostPrice,
			ISNULL(OrderCost, 0.00) PackagePrice,
			Convert(datetime, convert(varchar, TEA.StartTime, 108)) StartTime,
			Convert(datetime, convert(varchar, TEA.EndTime, 108)) EndTime, 
			isnull(Convert(varchar, TEA.CheckInTime, 108), '__:__:__') CheckInTime,
			isnull(Convert(varchar, TEA.CheckOutTime, 108), '__:__:__') CheckOutTime,
			ISNULL(CouponCode, '') CouponCode, ISNULL(DiscountAmount, 0.00) DiscountAmount, NetPayment,
			ISNULL(TU.Email1, '') Email1,
			(Case When len(IsNull(TU.PhoneHome, '')) > 0 then TU.PhoneHome
				When len(IsNull(TU.PhoneCell, '')) > 0 then TU.PhoneCell
				When len(IsNull(TU.PhoneOffice, '')) > 0 then TU.PhoneOffice
				Else '' end) Phone, ISNULL(isShipping,0) isShipping
			,ISNULL(TEC.AppointmentId,0) as AppointmentId
			FROM TblEventAppointment TEA 
			LEFT outer join TblEventCustomers TEC on TEA.AppointmentID=TEC.AppointmentID
			LEFT outer join TblOrganizationRoleUser TC with(nolock) on TC.OrganizationRoleUserId=TEC.CustomerID
			LEFT outer join TblUser TU on TU.UserID=TC.UserID
			---LEFT outer join TblEventPackageDetails TEP on TEP.EventPackageID=TEC.EventPackageID
			---LEFT outer join TblPackage TP on TP.PackageID=TEP.PackageID
			left outer join fn_EventCustomerPayment(@filterstring) ecp on ecp.EventCustomerId = TEC.EventCustomerId
			where TEA.EventID=@filterstring  order by starttime
		
	END
	
	
END




