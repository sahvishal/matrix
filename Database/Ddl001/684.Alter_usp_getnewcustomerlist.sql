USE [$(dbname)]
GO

/****** Object:  StoredProcedure [dbo].[usp_getnewcustomerlist]    Script Date: 15-12-2017 18:31:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:  Abhinav Goel  
-- Create date: 15-05-2008  
-- Description: to fetch customer data  
-- Parameters:   
-- =============================================  
ALTER PROCEDURE [dbo].[usp_getnewcustomerlist](   
@customerid BIGINT=null,   
@customername varchar(200) = null,   
@cityname varchar(200) = null,   
@statename varchar(200) = null,   
@zipcode varchar(100) = null,   
@fromdate varchar(20) = null,   
@todate varchar(20) = null,   
@franchiseeid bigint = null,   
@datetype bigint = null,   
@mode tinyint = null,  
@PageNo int = 1,  
@PageSize int = 10,  
@PageCount bigint OUTPUT )   
 -- Add the parameters for the stored procedure here  
AS
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
 SET @PageCount=0  
 
 Declare @sel_temp Nvarchar(MAX) 
 
 DECLARE @cityColl VARCHAR(max), @stateColl VARCHAR(max), @zipColl VARCHAR(max)
 DECLARE @likecity VARCHAR(200), @likestate VARCHAR(200), @likezip VARCHAR(200)
 
 DECLARE @FirstRec int, @LastRec int  
  SET  @FirstRec = (@PageNo  - 1) * @PageSize  
  SET  @LastRec  = (@PageNo * @PageSize)
 
 IF(@mode = 1 OR @mode=2)
 BEGIN
	 SET @cityColl=''''
	 SET @likecity =''
	 SET @stateColl=''''
	 SET @likestate =''
	 SET @zipColl=''''
	 SET @likezip =''
	 
	 if(@customername is not NULL)  
	  BEGIN  
	   set @customername= ltrim(rtrim(replace(@customername,'%','')))
	   set @customername = '%' + replace(@customername,' ','% ') +'%'  
	  END
	  ELSE
	  BEGIN  
	   set @customername = ''
	  END
	  
	  if(@cityname is null)  
	  BEGIN  
	   Set @cityname = '' 
	   SELECT @cityColl = '1=1'
	  END  
	  ELSE
	  BEGIN
		SET @cityColl=''
		set @likecity = '%' + @cityname +'%'  
		Select @cityColl =  @cityColl + '''' + CAST (CityID AS VARCHAR) + '''' + ','  from tblcity (NOLOCK) where [name] like @likecity
		if(len(@cityColl)>0)
		begin
			SELECT @cityColl = 'TA.CityID IN (' + SUBSTRING(@cityColl,0,LEN(@cityColl)) + ')'
		end
		else
		Begin
			SELECT @cityColl = '1=0'
		End
	  END
	  
	  if(@statename is null)  
	  BEGIN  
	   SET @statename = ''
	   SELECT @stateColl = '1=1'
	  END
	  ELSE
	  BEGIN
		SET @stateColl=''
		set @likestate = '%' + @statename +'%'  
		Select @stateColl =  @stateColl + '''' + CAST (StateID AS VARCHAR) + '''' + ','  from tblstate (NOLOCK) where [name] like @likestate
		if(len(@stateColl)>0)
		begin
			SELECT @stateColl = 'TA.StateID IN (' + SUBSTRING(@stateColl,0,LEN(@stateColl)) + ')'
		end
		else
		Begin
			SELECT @stateColl = '1=0'
		End
	  END  
	  
	   if(@zipcode is null)  
	  BEGIN
		SET @zipcode = ''
		SELECT @zipColl = '1=1'  
	  END
	  ELSE
	  BEGIN
		SET @zipColl=''
		set @likezip = '%' + @zipcode +'%'  
		Select @zipColl =  @zipColl + '''' + CAST (ZipID AS VARCHAR) + '''' + ','  from TblZip (NOLOCK) where ZipCode like @likezip
		if(len(@zipColl)>0)
		begin
			SELECT @zipColl = 'TA.ZipID IN (' + SUBSTRING(@zipColl,0,LEN(@zipColl)) + ')'
		end
		else
		Begin
			SELECT @zipColl = '1=0'
		End
	  END      
 END 
    -- Insert statements for procedure here  
 if(@mode = 0)  
 BEGIN  

		DECLARE @tblMode0 TABLE
			(
			EventName VARCHAR(500),EventID BIGINT,EventStatus INT,CustomerID BIGINT,EventDate DATETIME,OrganizationName VARCHAR(500),
			PackageName VARCHAR(500), AdditionalTest VARCHAR(Max), FranchiseeID BIGINT, FirstName VARCHAR(50),MiddleName VARCHAR(50),
			LastName VARCHAR(50),DateCreated DATETIME,DOB SMALLDATETIME, Gender nvarchar(40), RequestNewsLetter bit, HomeAddressID BIGINT, EMail1 VARCHAR(100),
			RoleID BIGINT,Phone VARCHAR(50),TrackingMarketingID VARCHAR(500),PaymentNet MONEY,IncomingPhoneLine VARCHAR(50),
			CallersPhoneNumber VARCHAR(50),IsLocked bit, DoNotContactReasonId INT, UserDefined1 VARCHAR(2000)
			)
 
		INSERT INTO @tblMode0
		SELECT TOP 10  
		TE.EventName,  
		TE.EventID,
		ISNULL(TE.EventStatus,1) EventStatus,		
		TEC.CustomerID,  
		TE.EventDate,  
		TP.OrganizationName,  
		ISNULL(Package.[PackageName],'') PackageName,  
		ISNULL(Test.AdditionalTest,'') AdditionalTest,
		TORU.OrganizationId FranchiseeID,  
		ISNULL(TU.FirstName, '') FirstName,  
		ISNULL(TU.MiddleName, '')MiddleName,  
		ISNULL(TU.LastName, '') LastName,  
		TU.DateCreated,  
		TU.DOB,  
		TC.Gender,  
		TC.RequestNewsLetter,
		TU.HomeAddressID,  
		TU.EMail1,  
		ISNULL(TC.AddedByRoleID, 0) RoleID,  
		ISNULL(IsNull(IsNull(TU.PhoneHome,TU.PhoneCell), TU.PhoneOffice) , '') as Phone,
		TEC.MarketingSource  TrackingMarketingID, 
		---TC.TrackingMarketingID,  
		tbSum.PaymentNet,
		IsNull(vwcalls.IncomingPhoneLine,'') as IncomingPhoneLine,
		IsNull(vwcalls.CallersPhoneNumber,'') as CallersPhoneNumber
		--IsNull(NULL,'') as IncomingPhoneLine,
		--IsNull(NULL,'') as CallersPhoneNumber
		,[TblUserLogin].[IsLocked]
		,ISNULL(TC.DoNotContactReasonId,0) as DoNotContactReasonId
		--,Replace(ISNULL(TC.UserDefined1,''),,'') as UserDefined1
		,'Not Available' as UserDefined1
		from  TblEventCustomers TEC WITH (NOLOCK) 
		inner join TblEvents TE WITH (NOLOCK) on TEC.EventID = TE.EventID  
		inner join TblOrganizationRoleUser TORU WITH (NOLOCK) on TORU.OrganizationRoleUserId = TE.AssignedToOrgRoleUserId
		inner join TblHostEventDetails TEH WITH (NOLOCK) on TEH.EventID=TE.EventID  
		inner join TblProspects TP WITH (NOLOCK) on TP.ProspectID=TEH.HostID  
		INNER JOIN TblEventCustomerOrderDetail TECOD WITH (NOLOCK) on TECOD.EventCustomerId = TEC.EventCustomerID
		INNER JOIN TblOrderDetail TOD WITH (NOLOCK) on  TOD.OrderDetailId=TECOD.OrderDetailId
		LEFT OUTER JOIN
		(
			SELECT TOD.OrderID, ISNULL(TP.PackageName,'') PackageName
			FROM [TblOrderDetail] TOD WITH (NOLOCK)
			INNER JOIN TblOrderItem TPI WITH (NOLOCK) ON TPI.OrderItemId = TOD.OrderItemId 
			INNER JOIN TblEventPackageOrderItem TEPOI WITH (NOLOCK) On TEPOI.OrderItemId = TPI.OrderItemId
			INNER JOIN [TblEventPackageDetails] TEPD WITH (NOLOCK) ON TEPOI.[EventPackageID]=TEPD.[EventPackageID]
			INNER JOIN [TblPackage] TP WITH (NOLOCK) ON TEPD.[PackageID] = TP.[PackageID]
			WHERE TOD.Status=1
		)Package ON Package.OrderID=TOD.OrderID	
		LEFT OUTER JOIN 
		(
			SELECT TOP 100 PERCENT b.EventCustomerID,
			STUFF
			(
				(SELECT  TOP 100 PERCENT ', ' + [Name] FROM 
					(     
						SELECT   [Name],[EventCustomerId]
						FROM tblOrderDetail od WITH (NOLOCK) INNER join  tblOrderItem oi WITH (NOLOCK) on od.OrderItemId = oi.OrderItemId
						INNER join  tblEventTestOrderItem etoi WITH (NOLOCK) on oi.OrderItemId = etoi.OrderItemId
						INNER join  tblEventTest et  WITH (NOLOCK) on etoi.EventTestId = et.EventTestId
						INNER JOIN [TblTest]  WITH (NOLOCK) ON et.[TestID] = [TblTest].[TestID] 
						INNER JOIN ( 
						SELECT [OrderID],[EventCustomerId]  from  tblEventCustomerOrderDetail ecod   WITH (NOLOCK)
						INNER JOIN tblOrderDetail od  WITH (NOLOCK) on ecod.OrderDetailId = od.OrderDetailId
						WHERE ecod.[IsActive]=1  ) ec ON ec.OrderID=od.[OrderID]
						AND  od.Status =1 AND  oi.Type = 4
					) 
					vw_Test
				WHERE b.eventcustomerid = vw_Test.eventcustomerid
				ORDER BY ',' + vw_Test.Name FOR XML PATH('')
			), 1, 1, '') AS AdditionalTest
			FROM  tbleventcustomers AS b WITH (NOLOCK)
			ORDER BY b.[EventCustomerID]
		)Test ON Test.EventCustomerID=TEC.EventCustomerID
		
		inner join vw_Customers TC WITH (NOLOCK) on TC.CustomerID=TEC.CustomerID  
		Inner Join TblUser TU WITH (NOLOCK) on TU.UserID=TC.UserID  
		INNER JOIN [TblUserLogin] WITH (NOLOCK) ON TU.[UserID]=[TblUserLogin].[UserLoginID]
		INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddressID=TU.HomeAddressID  
		INNER join (
						SELECT sum(ISNULL(TotalPayment,0)) PaymentNet  	,tbl1.UserID from TblUser tbl1 WITH (NOLOCK)     
						inner join vw_Customers tbl3 WITH (NOLOCK) on tbl3.userid=tbl1.userid  
						inner join TblEventCustomers tbl4 WITH (NOLOCK) on tbl4.customerid=tbl3.customerid  
						LEFT outer JOIN [vw_EventCustomerPaymentNewOrderSystem] WITH (NOLOCK) ON 
						tbl4.[EventCustomerID]=[vw_EventCustomerPaymentNewOrderSystem].[EventCustomerID]
						WHERE tbl4.AppointmentID IS NOT NULL  AND tbl4.datecreated >  DATEADD(d,-90,GETDATE())
						group by tbl1.UserID			
					) tbSum on tbSum.UserID=TU.UserID   
		INNER JOIN   
		(  
		Select vw1.CustomerID, EventDate from  
		(  
		select TEC.CustomerID, EventDate,   
		ROW_NUMBER() OVER(PARTITION BY TEC.CustomerID ORDER BY ABS(DATEDIFF(DAY, EventDate, GETDATE()))) RowNumber  
		from TblEventCustomers TEC WITH (NOLOCK) 
		inner join TblEvents TE WITH (NOLOCK) on TEC.EventID=TE.EventID  
		WHERE TEC.AppointmentID IS NOT NULL  
		) vw1  
		where RowNumber=1  
		) tbl1 ON TEC.CustomerID = tbl1.CustomerID AND TE.EventDate = tbl1.EventDate 
		
		LEFT OUTER JOIN (SELECT MAX(IncomingPhoneLine) AS IncomingPhoneLine,MAX(CallersPhoneNumber) AS CallersPhoneNumber,CalledCustomerID 
						  FROM Tblcalls WITH (NOLOCK) 
						  WHERE (CallStatus='Register New Customer' OR CallStatus='Existing Customer') AND EventID IS NOT NULL
						  GROUP BY CalledCustomerID) vwcalls ON vwcalls.CalledCustomerID=TC.CustomerID
		WHERE TEC.AppointmentID IS NOT NULL AND  TU.IsActive=1  AND TEC.datecreated >  DATEADD(d,-90,GETDATE()) 
		AND TECOD.IsActive=1     
		ORDER BY TU.DateCreated desc  
		
		
		SELECT * FROM @tblMode0
  
		Select  
		TA.AddressID,  
		TA.Address1,  
		TA.Address2,  
		TA.ZIPID,  
		TblZip.ZipCode,  
		tblCity.CityID,  
		tblState.StateID,  
		tblCountry.CountryID,  
		tblCity.Name CityName,  
		tblState.Name StateName,  
		tblCountry.Name CountryName  
		from TblAddress TA  WITH (NOLOCK) 
		INNER JOIN @tblMode0 tmp ON tmp.HomeAddressID = TA.AddressID
		inner join tblCity WITH (NOLOCK) on tblCity.CityID = TA.CityID  
		inner join TblZip WITH (NOLOCK) on TblZip.ZipID = TA.ZipID  
		inner join tblState WITH (NOLOCK) on tblState.StateID = TA.StateID  
		inner join tblCountry WITH (NOLOCK) on tblCountry.CountryID = TA.CountryID  
		INNER JOIN TblUser TU WITH (NOLOCK) ON TU.HomeAddressID=TA.AddressID  
		inner join vw_Customers TC WITH (NOLOCK) on TC.UserID=TU.UserID  
		inner join TblEventCustomers TEC WITH (NOLOCK) on TEC.CustomerID=TC.CustomerID  
		inner join TblEvents TE WITH (NOLOCK) on TE.EventID=TEC.EventID  
		where TE.IsActive = 1 

		------------------Begin Get record count ---------------------------------------
		SELECT COUNT(*) TotalRecords FROM  vw_Customers TC  WITH (NOLOCK) INNER JOIN tbluser  WITH (NOLOCK) ON TC.[UserID] = [TblUser].[UserID]
			WHERE [CustomerID] IN (SELECT DISTINCT customerid FROM [TblEventCustomers] WHERE [AppointmentID] IS NOT NULL )
			AND tbluser.[IsActive]=1
			
		

		------------------End Get record count ---------------------------------------
 END  
-- Case Mode 1
 ELSE IF(@mode = 1)  
 BEGIN  
  Declare @sel_events_query NVARCHAR(MAX)
  Declare @sel_address_query Nvarchar(MAX)  


  --print Cast(@todate as datetime)
  declare @zipcodetemp varchar(10)
  declare @citytemp varchar(50)
  declare @statetemp varchar(50)
  
	if(len(@zipcode)>1) set @zipcodetemp=@zipcode
	if(len(@statename)>1) set @statetemp=@statename
	if(len(@cityname)>1) set @citytemp=@cityname
	print @statetemp
			Select @sel_temp = (COALESCE(@sel_temp + ',' , '') + cast(EventCustomerId as varchar))
			
			from (
			select EventCustomerId, ROW_NUMBER() OVER (ORDER BY EventCustomerId) AS RowNumber from 
			(
				select max(EventCustomerId) as EventCustomerId from TblEventCustomers EC 
				where 
				1 = (Case when (len(isnull(@customername, '')) < 1 and len(isnull(@zipcode, '')) < 1 and len(isnull(@statename, '')) < 1 and len(isnull(@cityname, '')) < 1) then 1 
							else 
							(Select (Case When Count(*) > 0 then 1 else 0 end) from TblUser U inner join TblOrganizationRoleUser ORU on U.UserId = ORU.UserId 
								inner join TblAddress A on A.AddressId = U.HomeAddressId
								inner join TblState S on A.StateId = S.StateId
								inner join TblCity C on A.CityId = C.CityId 
								inner join TblZip Z on Z.ZipId = A.ZipId 
								where U.IsActive=1 
								and (rtrim(ltrim(Firstname)) + (case when len(rtrim(ltrim(isnull(middlename,'')))) > 0 then ' ' + middlename + ' ' else ' ' END) + rtrim(ltrim(LastName))) like ('%' + isnull(replace(@customername,'''''',''''), '') + '%') 
								and Z.Zipcode = isnull(@zipcodetemp,Z.ZipCode)
								and S.Name = isnull(@statetemp,S.Name)
								and C.Name = isnull(@citytemp,C.Name)
								and ORU.OrganizationRoleUserId = EC.CustomerId) end)
				and
				1 = (Case 
					when @datetype=1 then
						(Case when (len(isnull(@fromdate, '')) < 1 and len(isnull(@todate, '')) < 1) then 1 
								else
								(Select (Case When Count(*) > 0 then 1 else 0 end) from TblEvents E 
								where 1 = (Case When len(isnull(@todate, '')) < 1 then 1 else (Case When (E.EventDate <= Cast(@todate as datetime)) then 1 else 0 end) end)
									and 1 = (Case When len(isnull(@fromdate, '')) < 1 then 1 else (Case When E.EventDate >= cast(@fromdate as Datetime) then 1 else 0 end) end) and E.EventId = EC.EventId and EC.NoShow=0) end
						)
					when @datetype=0 then
						(Case when (len(isnull(@fromdate, '')) < 1 and len(isnull(@todate, '')) < 1) then 1 
								else
								(Select (Case When Count(*) > 0 then 1 else 0 end) from TblUser U inner join TblOrganizationRoleUser ORU on U.UserId = ORU.UserId 
									where 1 = (Case When len(isnull(@todate, '')) < 1 then 1 else (Case When (U.DateCreated <= Cast(@todate as datetime)) then 1 else 0 end) end)
									and 1 = (Case When len(isnull(@fromdate, '')) < 1 then 1 else (Case When U.DateCreated >= cast(@fromdate as Datetime) then 1 else 0 end) end) and ORU.OrganizationRoleUserId = EC.CustomerId) end
						)
					else 1
					End)
					
				and ec.DateCreated>= (case when @datetype=2 then cast(isnull(@fromdate,ec.DateCreated) as datetime) else ec.DateCreated end)
				and ec.DateCreated<= (case when @datetype=2 then cast(isnull(@todate,ec.DateCreated) as datetime) else ec.DateCreated end)
				and ec.CustomerId=isnull(@customerid,ec.CustomerId)								
				and EC.AppointmentID IS NOT NULL group by CustomerId
				)tt
			)DvCustomers WHERE RowNumber between @FirstRec+1 and @LastRec
			
			print @sel_temp
		/* *************************************************** */  
		/* Preparing string query for fetching TblEvents record */ 
		

		 		
		Set @sel_events_query = 
		'Select   
		TE.EventName,
		TE.EventID, 
		ISNULL(TE.EventStatus,1) EventStatus,
		TEC.CustomerID,  
		TE.EventDate,  
		TP.OrganizationName,  
		ISNULL(Package.[PackageName],'''') PackageName,   
		--ISNULL(Test.AdditionalTest,'''') AdditionalTest,
		'''' as AdditionalTest,
		TORU.OrganizationId FranchiseeID,  
		ISNULL(TU.FirstName, '''') FirstName,  
		ISNULL(TU.MiddleName, '''')MiddleName,  
		ISNULL(TU.LastName, '''') LastName,  
		TU.DateCreated,  
		TU.DOB,  
		TC.Gender,  
		TU.HomeAddressID,  
		ISNULL(TC.AddedByRoleID, 0) RoleID,  
		TU.EMail1,  TC.RequestNewsLetter,
		ISNULL(IsNull(IsNull(TU.PhoneHome,TU.PhoneCell), TU.PhoneOffice) , '''') as Phone,  
		TEC.MarketingSource  TrackingMarketingID, 
		---TC.TrackingMarketingID,  
		ISNULL(tbSum.PaymentNet,0) PaymentNet,  
		TEC.DateCreated,
		--vwPaymentDetails.DateModified as PaymentDate,
		TEC.DateCreated as PaymentDate,
		IsNull(vwcalls.IncomingPhoneLine,'''') as IncomingPhoneLine,
		IsNull(vwcalls.CallersPhoneNumber,'''') as CallersPhoneNumber  
		,[TblUserLogin].[IsLocked]   
		,ISNULL(TC.DoNotContactReasonId,0) as DoNotContactReasonId
		--,Replace(ISNULL(TC.UserDefined1,''''),''Not Available'','''') as UserDefined1
		,''Not Available'' as UserDefined1
		from  TblEventCustomers TEC WITH (NOLOCK) 
		inner join TblEvents TE WITH (NOLOCK) on TEC.EventID = TE.EventID and TEC.EventCustomerId in (' + @sel_temp +')
		inner join TblOrganizationRoleUser TORU WITH (NOLOCK) on TORU.OrganizationRoleUserId = TE.AssignedToOrgRoleUserId
		AND CASE WHEN ' + CAST(ISNULL(@franchiseeid,'') AS VARCHAR(10)) + ' > 0 THEN  TORU.OrganizationId ELSE 1 END = 
			CASE WHEN ' + CAST(ISNULL(@franchiseeid,'') AS VARCHAR(10)) + ' > 0 THEN  ' + CAST(ISNULL(@franchiseeid,'') AS VARCHAR(10)) + ' ELSE 1 END
		AND CASE WHEN ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' > 0 THEN  TEC.CustomerID ELSE 1 END = 
			CASE WHEN ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' > 0 THEN  ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' ELSE 1 END	
		inner join TblHostEventDetails TEH WITH (NOLOCK) on TEH.EventID=TE.EventID  
		inner join TblProspects TP WITH (NOLOCK) on TP.ProspectID=TEH.HostID  
		
		INNER JOIN TblEventCustomerOrderDetail TECOD (NOLOCK) on TECOD.EventCustomerId = TEC.EventCustomerID
		INNER JOIN TblOrderDetail TOD (NOLOCK) on TOD.OrderDetailId=TECOD.OrderDetailId
		LEFT OUTER JOIN
		(
			SELECT TOD.OrderID, ISNULL(TP.PackageName,'''') PackageName
			FROM [TblOrderDetail] TOD WITH (NOLOCK)
			INNER JOIN TblOrderItem TPI WITH (NOLOCK) ON TPI.OrderItemId = TOD.OrderItemId 
			INNER JOIN TblEventPackageOrderItem TEPOI WITH (NOLOCK) On TEPOI.OrderItemId = TPI.OrderItemId
			INNER JOIN [TblEventPackageDetails] TEPD WITH (NOLOCK) ON TEPOI.[EventPackageID]=TEPD.[EventPackageID]
			INNER JOIN [TblPackage] TP WITH (NOLOCK) ON TEPD.[PackageID] = TP.[PackageID]
			WHERE TOD.Status=1
		)Package ON Package.OrderID=TOD.OrderID	
			
		INNER JOIN dbo.TblEventAppointment WITH (NOLOCK) ON dbo.TblEventAppointment.AppointmentID=TEC.AppointmentID
		inner join vw_Customers TC WITH (NOLOCK) on TC.CustomerID=TEC.CustomerID
		Inner Join TblUser TU WITH (NOLOCK) on TU.UserID=TC.UserID
		AND CASE WHEN ''' + @customername + ''' = '''' THEN CAST(1 AS VARCHAR) ELSE (rtrim(ltrim(TU.FirstName)) + (case when len(rtrim(ltrim(isnull(middlename,'''')))) > 0 then '' '' + middlename + '' '' else '' '' END) +  rtrim(ltrim(TU.LastName))) END LIKE 
			CASE WHEN ''' + @customername + ''' = '''' THEN CAST(1 AS VARCHAR) ELSE ''' + @customername + ''' END
		INNER JOIN [TblUserLogin] WITH (NOLOCK) ON TU.[UserID]=[TblUserLogin].[UserLoginID]
		INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddressID=TU.HomeAddressID
		AND ' + @cityColl + '
		AND ' + @stateColl + '
		AND ' + @zipColl + '		
		INNER join (
					SELECT sum( isnull( TotalPayment,0)) PaymentNet,CustomerID FROM [TblEventCustomers] WITH (NOLOCK)
					LEFT outer JOIN  [vw_EventCustomerPaymentNewOrderSystem]  WITH (NOLOCK) ON [TblEventCustomers].[EventCustomerID]=[vw_EventCustomerPaymentNewOrderSystem].[EventCustomerID]
					GROUP BY CustomerID			
					) tbSum on tbSum.CustomerID=TC.CustomerID 
		
		 LEFT OUTER JOIN 
		(
			SELECT MAX(IncomingPhoneLine) AS IncomingPhoneLine,MAX(CallersPhoneNumber) AS CallersPhoneNumber,CalledCustomerID 
			FROM Tblcalls WITH (NOLOCK) 
			WHERE (CallStatus=''Register New Customer'' OR CallStatus=''Existing Customer'') AND EventID IS NOT NULL
			GROUP BY CalledCustomerID
		)vwcalls ON vwcalls.CalledCustomerID=TC.CustomerID
		WHERE TEC.AppointmentID IS NOT NULL AND TU.IsActive=1 AND TECOD.IsActive=1'   
    
	--print @sel_events_query
	if(@datetype=0)  
	Begin  
		if(@fromdate is not null and @todate is not null)  
		BEGIN   
			Set @sel_events_query = @sel_events_query + ' AND CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) <= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME) '  
		END  
		else if(@fromdate is not null )  
		BEGIN  
			Set @sel_events_query = @sel_events_query + ' and TU.DateCreated >= ''' + Cast(@fromdate as varchar(50)) + ''' '  
		END  
		else if(@todate is not null)  
		BEGIN  
			Set @sel_events_query = @sel_events_query + ' and TU.DateCreated <= ''' + Cast(@todate as varchar(50)) + ''' '  
		END  
		BEGIN  
		Set @sel_events_query = @sel_events_query + ' ORDER BY TU.DateCreated desc '  
		END  
	END  
	Else if(@datetype=1)  
	Begin  
		if(@fromdate is not null and @todate is not null)  
		BEGIN  
			Set @sel_events_query = @sel_events_query + ' AND CAST(CONVERT(VARCHAR,TE.EventDate,101) as DATETIME) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TE.EventDate,101) as DATETIME) <= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME) '  
		END  
		else if(@fromdate is not null )  
		BEGIN  
			Set @sel_events_query = @sel_events_query + ' and TE.EventDate >= ''' + Cast(@fromdate as varchar(50)) + ''' '  
		END  
		else if(@todate is not null)  
		BEGIN  
			Set @sel_events_query = @sel_events_query + ' and TE.EventDate <= ''' + Cast(@todate as varchar(50)) + ''' '  
		END  
		BEGIN  
			--set @sel_events_query= @sel_events_query + ' and ((TblEventAppointment.CheckinTime IS NOT NULL) or (TblEventAppointment.CheckoutTime IS NOT null))'
			set @sel_events_query= @sel_events_query + ' and TEC.NoShow = 0'
			Set @sel_events_query = @sel_events_query + ' ORDER BY TE.EventDate desc '  
		END  
	END  
	Else if(@datetype=2)  
	Begin  
		if(@fromdate is not null and @todate is not null)  
		BEGIN  
			Set @sel_events_query = @sel_events_query + ' AND TEC.DateCreated >= CAST(''' + convert(varchar, @fromdate,101) + ''' as datetime) and TEC.DateCreated <= CAST(''' + convert(varchar,@todate,101) + ''' as datetime) + 1'  
		END  
		else if(@fromdate is not null )  
		BEGIN  
			Set @sel_events_query = @sel_events_query + ' and TEC.DateCreated >= CAST(''' + convert(varchar, @fromdate,101) + '''as datetime) '  
		END  
		else if(@todate is not null)  
		BEGIN  
			Set @sel_events_query = @sel_events_query + ' and TEC.DateCreated <= CAST(''' + convert(varchar,@todate,101) + '''as datetime) + 1 '  
		END  
		Set @sel_events_query = @sel_events_query + ' ORDER BY TEC.DateCreated desc '  
	END  
	--Else if(@datetype=3)  
	--Begin  
	--	if(@fromdate is not null and @todate is not null)  
	--	BEGIN  
	--		Set @sel_events_query = @sel_events_query + ' AND vwPaymentDetails.DateModified >= CAST(''' + convert(varchar, @fromdate,101) + ''' as datetime) and vwPaymentDetails.DateModified <= CAST(''' + convert(varchar,@todate,101) + ''' as datetime) + 1'  
	--	END  
	--	else if(@fromdate is not null )  
	--	BEGIN  
	--		Set @sel_events_query = @sel_events_query + ' and vwPaymentDetails.DateModified >= CAST(''' + convert(varchar, @fromdate,101) + '''as datetime) '  
	--	END  
	--	else if(@todate is not null)  
	--	BEGIN  
	--		Set @sel_events_query = @sel_events_query + ' and vwPaymentDetails.DateModified <= CAST(''' + convert(varchar,@todate,101) + '''as datetime) + 1'  
	--	END  
	--	Set @sel_events_query = @sel_events_query + ' AND vwPaymentDetails.IsPaid=1 '
	--	Set @sel_events_query = @sel_events_query + ' ORDER BY vwPaymentDetails.DateModified desc '  
	--END 
  
  /* *************************************************** */  
  /* Preparing string query for fetching TblAddress record for corresponding events */  
  Set @sel_address_query = 'Select   
        TA.AddressID,  
        TA.Address1,  
        TA.Address2,  
        TA.ZIPID,  
        TblZip.ZipCode,  
        tblCity.CityID,  
        tblState.StateID,  
        tblCountry.CountryID,  
        tblCity.Name CityName,  
        tblState.Name StateName,  
        tblCountry.Name CountryName,  
        TEC.DateCreated,
        TEC.DateCreated
        --vwPaymentDetails.DateModified  
        from TblAddress TA WITH (NOLOCK)  
        inner join tblCity WITH (NOLOCK) on tblCity.CityID = TA.CityID  
        AND ' + @cityColl + '
		AND ' + @stateColl + '
		AND ' + @zipColl + '
        inner join TblZip WITH (NOLOCK) on TblZip.ZipID = TA.ZipID  
        inner join tblState WITH (NOLOCK) on tblState.StateID = TA.StateID  
        inner join tblCountry WITH (NOLOCK) on tblCountry.CountryID = TA.CountryID  
        INNER JOIN TblUser TU WITH (NOLOCK) ON TU.HomeAddressID=TA.AddressID
        AND CASE WHEN ''' + @customername + ''' = '''' THEN CAST(1 AS VARCHAR) ELSE  (rtrim(ltrim(TU.FirstName)) + (case when len(rtrim(ltrim(isnull(middlename,'''')))) > 0 then '' '' + middlename + '' '' else '' '' END) +  rtrim(ltrim(TU.LastName))) END LIKE
			CASE WHEN ''' + @customername + ''' = '''' THEN CAST(1 AS VARCHAR) ELSE ''' + @customername + ''' END  
        inner join vw_Customers TC WITH (NOLOCK) on TC.UserID=TU.UserID
		AND CASE WHEN ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' > 0 THEN  TC.CustomerID ELSE 1 END = 
			CASE WHEN ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' > 0 THEN  ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' ELSE 1 END	  
        inner join TblEventCustomers TEC WITH (NOLOCK) on TEC.CustomerID=TC.CustomerID  and TEC.EventCustomerId in (' + @sel_temp +')     
        INNER JOIN dbo.TblEventAppointment WITH (NOLOCK) ON dbo.TblEventAppointment.AppointmentID=TEC.AppointmentID         
        inner join TblEvents TE  WITH (NOLOCK) on TE.EventID=TEC.EventID    
        inner join TblOrganizationRoleUser TORU WITH (NOLOCK) on TORU.OrganizationRoleUserId = TE.AssignedToOrgRoleUserId 
        AND CASE WHEN ' + CAST(ISNULL(@franchiseeid,'') AS VARCHAR(10)) + ' > 0 THEN  TORU.OrganizationId ELSE 1 END = 
			CASE WHEN ' + CAST(ISNULL(@franchiseeid,'') AS VARCHAR(10)) + ' > 0 THEN  ' + CAST(ISNULL(@franchiseeid,'') AS VARCHAR(10)) + ' ELSE 1 END
        where TE.IsActive = 1'  

	if(@datetype=0)  
	Begin  
		if(@fromdate is not null and @todate is not null)  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' AND CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) <= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME) '  
		END  
		else if(@fromdate is not null )  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' and TU.DateCreated >= ''' + Cast(@fromdate as varchar(50)) + ''' '  
		END  
		else if(@todate is not null)  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' and TU.DateCreated <= ''' + Cast(@todate as varchar(50)) + ''' '  
		END  
	END  
	Else if(@datetype=1)  
	Begin  
		if(@fromdate is not null and @todate is not null)  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' AND CAST(CONVERT(VARCHAR,TE.EventDate,101) as DATETIME) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TE.EventDate,101) as DATETIME) <= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME) '  
		END  
		else if(@fromdate is not null )  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' and TE.EventDate >= ''' + Cast(@fromdate as varchar(50)) + ''' '  
		END  
		else if(@todate is not null)  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' and TE.EventDate <= ''' + Cast(@todate as varchar(50)) + ''' '  
		END
		--set @sel_address_query= @sel_address_query + ' and ((TblEventAppointment.CheckinTime IS NOT NULL) or (TblEventAppointment.CheckoutTime IS NOT null))'  
		set @sel_address_query= @sel_address_query + ' and TEC.NoShow = 0'
	END  
	Else if(@datetype=2)  
	Begin  
		if(@fromdate is not null and @todate is not null)  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' AND TEC.DateCreated >= CAST(''' + convert(varchar, @fromdate,101) + ''' as datetime) and TEC.DateCreated <= CAST(''' + convert(varchar,@todate,101) + ''' as datetime) + 1'  
		END  
		else if(@fromdate is not null )  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' and TEC.DateCreated >= CAST(''' + convert(varchar, @fromdate,101) + '''as datetime) '  
		END  
		else if(@todate is not null)  
		BEGIN  
			Set @sel_address_query = @sel_address_query + ' and TEC.DateCreated <= CAST(''' + convert(varchar,@todate,101) + '''as datetime) + 1 '  
		END  
	    BEGIN  
		Set @sel_address_query = @sel_address_query + ' ORDER BY TEC.DateCreated desc '  
		END  
	END
	--Else if(@datetype=3)  
	--Begin  
	--	if(@fromdate is not null and @todate is not null)  
	--	BEGIN  
	--		Set @sel_address_query = @sel_address_query + ' AND vwPaymentDetails.DateModified >= CAST(''' + convert(varchar, @fromdate,101) + ''' as datetime) and vwPaymentDetails.DateModified <= CAST(''' + convert(varchar,@todate,101) + ''' as datetime) + 1'  
	--	END  
	--	else if(@fromdate is not null )  
	--	BEGIN  
	--		Set @sel_address_query = @sel_address_query + ' and vwPaymentDetails.DateModified >= CAST(''' + convert(varchar, @fromdate,101) + '''as datetime) '  
	--	END  
	--	else if(@todate is not null)  
	--	BEGIN  
	--		Set @sel_address_query = @sel_address_query + ' and vwPaymentDetails.DateModified <= CAST(''' + convert(varchar,@todate,101) + '''as datetime) + 1 '  
	--	END  
	--	Set @sel_address_query = @sel_address_query + ' AND vwPaymentDetails.IsPaid=1 '
	--	Set @sel_address_query = @sel_address_query + ' ORDER BY vwPaymentDetails.DateModified desc '  
	--END  


  Exec sp_executesql @sel_events_query
  Exec sp_executesql @sel_address_query
  
  select count(distinct CustomerId) as TotalRecords from TblEventCustomers EC 
				where 
				1 = (Case when (len(isnull(@customername, '')) < 1 and len(isnull(@zipcode, '')) < 1 and len(isnull(@statename, '')) < 1 and len(isnull(@cityname, '')) < 1) then 1 
							else 
							(Select (Case When Count(*) > 0 then 1 else 0 end) from TblUser U inner join TblOrganizationRoleUser ORU on U.UserId = ORU.UserId 
								inner join TblAddress A on A.AddressId = U.HomeAddressId
								inner join TblState S on A.StateId = S.StateId
								inner join TblCity C on A.CityId = C.CityId 
								inner join TblZip Z on Z.ZipId = A.ZipId 
								where U.IsActive=1 
								and (rtrim(ltrim(Firstname)) + (case when len(rtrim(ltrim(isnull(middlename,'')))) > 0 then ' ' + middlename + ' ' else ' ' END) + rtrim(ltrim(LastName))) like ('%' + isnull(replace(@customername,'''''',''''), '') + '%') 
								and Z.Zipcode = isnull(@zipcodetemp,Z.ZipCode)
								and S.Name = isnull(@statetemp,S.Name)
								and C.Name = isnull(@citytemp,C.Name)
								and ORU.OrganizationRoleUserId = EC.CustomerId) end)
				and
				1 = (Case 
					when @datetype=1 then
						(Case when (len(isnull(@fromdate, '')) < 1 and len(isnull(@todate, '')) < 1) then 1 
								else
								(Select (Case When Count(*) > 0 then 1 else 0 end) from TblEvents E where 1 = (Case When len(isnull(@todate, '')) < 1 then 1 else (Case When (E.EventDate <= Cast(@todate as datetime)) then 1 else 0 end) end)
									and 1 = (Case When len(isnull(@fromdate, '')) < 1 then 1 else (Case When E.EventDate >= cast(@fromdate as Datetime) then 1 else 0 end) end) and E.EventId = EC.EventId and EC.NoShow=0) end
						)
					when @datetype=0 then
						(Case when (len(isnull(@fromdate, '')) < 1 and len(isnull(@todate, '')) < 1) then 1 
								else
								(Select (Case When Count(*) > 0 then 1 else 0 end) from TblUser U inner join TblOrganizationRoleUser ORU on U.UserId = ORU.UserId 
									where 1 = (Case When len(isnull(@todate, '')) < 1 then 1 else (Case When (U.DateCreated <= Cast(@todate as datetime)) then 1 else 0 end) end)
									and 1 = (Case When len(isnull(@fromdate, '')) < 1 then 1 else (Case When U.DateCreated >= cast(@fromdate as Datetime) then 1 else 0 end) end) and ORU.OrganizationRoleUserId = EC.CustomerId) end
						)
					else 1
					End)
					
				and ec.DateCreated>= (case when @datetype=2 then cast(isnull(@fromdate,ec.DateCreated) as datetime) else ec.DateCreated end)
				and ec.DateCreated<= (case when @datetype=2 then cast(isnull(@todate,ec.DateCreated) as datetime) else ec.DateCreated end)
				and ec.CustomerId=isnull(@customerid,ec.CustomerId)								
				and EC.AppointmentID IS NOT NULL
  
 END  
 ELSE IF(@mode = 2)  
 BEGIN  
  Declare @sel_ACevents_query nvarchar(max)  
  Declare @sel_ACaddress_query nvarchar(max)  
  
  
  /* *************************************************** */  
  /* Preparing string query for fetching TblEvents record */  
  Set @sel_ACevents_query = ' Select   
          '''' as EventName,
          ROW_NUMBER() OVER (ORDER BY TC.CustomerID) AS Row, 
          0 as EventID,
		  0 as EventStatus,  
          TC.CustomerID,  
          Null as EventDate,  
          '''' as OrganizationName,  
          '''' as PackageName,  
          '''' as AdditionalTest,
          0 as FranchiseeID,  
          ISNULL(TU.FirstName, '''') FirstName,  
          ISNULL(TU.MiddleName, '''')MiddleName,  
          ISNULL(TU.LastName, '''') LastName,  
          TU.DateCreated,  
          TU.DOB,  
          TC.Gender, 
          TU.HomeAddressID,  
          ISNULL(TC.AddedByRoleID, 0) RoleID,  
          TU.EMail1,   TC.RequestNewsLetter,
          ISNULL(IsNull(IsNull(TU.PhoneHome,TU.PhoneCell), TU.PhoneOffice) , '''') as Phone,  
          TC.TrackingMarketingID,  
          0 as PaymentNet,
          IsNull(vwcalls.IncomingPhoneLine,'''') as IncomingPhoneLine,
          IsNull(vwcalls.CallersPhoneNumber,'''') as CallersPhoneNumber
          ,[TblUserLogin].[IsLocked]
          ,ISNULL(TC.DoNotContactReasonId,0) as DoNotContactReasonId
          --,Replace(ISNULL(TC.UserDefined1,''''),''Not Available'','''') as UserDefined1
		  ,''Not Available'' as UserDefined1
          from  vw_Customers TC WITH (NOLOCK) 
           Inner Join TblUser TU WITH (NOLOCK) on TU.UserID=TC.UserID
           AND CASE WHEN ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' > 0 THEN  TC.CustomerID ELSE 1 END = 
			CASE WHEN ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' > 0 THEN  ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' ELSE 1 END	
			AND CASE WHEN ''' + @customername + ''' = '''' THEN CAST(1 AS VARCHAR) ELSE (rtrim(ltrim(TU.FirstName)) + (case when len(rtrim(ltrim(isnull(middlename,'''')))) > 0 then '' '' + middlename + '' '' else '' '' END) +  rtrim(ltrim(TU.LastName))) END LIKE
			CASE WHEN ''' + @customername + ''' = '''' THEN CAST(1 AS VARCHAR) ELSE ''' + @customername + ''' END  
           INNER JOIN [TblUserLogin] WITH (NOLOCK) ON TU.[UserID]=[TblUserLogin].[UserLoginID]  
          INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddressID=TU.HomeAddressID
			AND ' + @cityColl + '
			AND ' + @stateColl + '
			AND ' + @zipColl + ' 
          LEFT OUTER JOIN 
			(
				SELECT MAX(IncomingPhoneLine) AS IncomingPhoneLine,MAX(CallersPhoneNumber) AS CallersPhoneNumber,CalledCustomerID 
				FROM Tblcalls WITH (NOLOCK) 
				WHERE (CallStatus=''Register New Customer'' OR CallStatus=''Existing Customer'') --AND EventID IS NOT NULL
				GROUP BY CalledCustomerID
			)vwcalls ON vwcalls.CalledCustomerID=TC.CustomerID  
          WHERE CustomerID NOT IN (SELECT DISTINCT customerid FROM dbo.TblEventCustomers WHERE AppointmentID IS NOT null) '  
           
 

    
	if(@datetype=0)  
	Begin  
		if(@fromdate is not null and @todate is not null)  
		BEGIN   
			Set @sel_ACevents_query = @sel_ACevents_query + ' AND CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) <= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME) '  
		END  
		else if(@fromdate is not null )  
		BEGIN  
			Set @sel_ACevents_query = @sel_ACevents_query + ' and TU.DateCreated >= ''' + Cast(@fromdate as varchar(50)) + ''' '  
		END  
		else if(@todate is not null)  
		BEGIN  
			Set @sel_ACevents_query = @sel_ACevents_query + ' and TU.DateCreated <= ''' + Cast(@todate as varchar(50)) + ''' '  
		END  
		--BEGIN  
		--Set @sel_ACevents_query = @sel_ACevents_query + ' ORDER BY TU.DateCreated desc '  
		--END  
	END  
	
  
  /* *************************************************** */  
  /* Preparing string query for fetching TblAddress record for corresponding events */  
  Set @sel_ACaddress_query = 'Select distinct  
        TA.AddressID,  
        TA.Address1,  
        TA.Address2,  
        TA.ZIPID,  
        TblZip.ZipCode,  
        tblCity.CityID,  
        tblState.StateID,  
        tblCountry.CountryID,  
        tblCity.Name CityName,  
        tblState.Name StateName,  
        tblCountry.Name CountryName  
        from TblAddress TA WITH (NOLOCK) 
        inner join tblCity WITH (NOLOCK) on tblCity.CityID = TA.CityID  
        AND ' + @cityColl + '
		AND ' + @stateColl + '
		AND ' + @zipColl + '
        inner join TblZip WITH (NOLOCK) on TblZip.ZipID = TA.ZipID  
        inner join tblState WITH (NOLOCK) on tblState.StateID = TA.StateID  
        inner join tblCountry WITH (NOLOCK) on tblCountry.CountryID = TA.CountryID  
        INNER JOIN TblUser TU WITH (NOLOCK) ON TU.HomeAddressID=TA.AddressID  
        AND CASE WHEN ''' + @customername + ''' = '''' THEN CAST(1 AS VARCHAR) ELSE (rtrim(ltrim(TU.FirstName)) + (case when len(rtrim(ltrim(isnull(middlename,'''')))) > 0 then '' '' + middlename + '' '' else '' '' END) +  rtrim(ltrim(TU.LastName))) END LIKE
			CASE WHEN ''' + @customername + ''' = '''' THEN CAST(1 AS VARCHAR) ELSE ''' + @customername + ''' END  
        inner join vw_Customers TC WITH (NOLOCK) on TC.UserID=TU.UserID  
        AND CASE WHEN ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' > 0 THEN  TC.CustomerID ELSE 1 END = 
			CASE WHEN ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' > 0 THEN  ' + CAST(ISNULL(@customerid,'') AS VARCHAR(10)) + ' ELSE 1 END	
        WHERE CustomerID NOT IN (SELECT DISTINCT customerid FROM dbo.TblEventCustomers WHERE AppointmentID IS NOT null)'   
    
     
	if(@datetype=0)  
	Begin  
		if(@fromdate is not null and @todate is not null)  
		BEGIN  
			Set @sel_ACaddress_query = @sel_ACaddress_query + ' AND CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) <= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME) '  
		END  
		else if(@fromdate is not null )  
		BEGIN  
			Set @sel_ACaddress_query = @sel_ACaddress_query + ' and TU.DateCreated >= ''' + Cast(@fromdate as varchar(50)) + ''' '  
		END  
		else if(@todate is not null)  
		BEGIN  
			Set @sel_ACaddress_query = @sel_ACaddress_query + ' and TU.DateCreated <= ''' + Cast(@todate as varchar(50)) + ''' '  
		END  
	END  
  
  /* Executing both queries */  
    SET @sel_temp = 'Select Count(CustomerID) as TotalRecords from (' + @sel_ACevents_query + ') DvCustomers'
    
    SET @sel_ACevents_query = 'Select * from ( ' + @sel_ACevents_query + ') DvCustomers WHERE Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar)
    
	Exec sp_executesql @sel_ACevents_query
	Exec sp_executesql @sel_ACaddress_query
	EXEC sp_executesql @sel_temp
 END  
 
 
  
 
END

GO


