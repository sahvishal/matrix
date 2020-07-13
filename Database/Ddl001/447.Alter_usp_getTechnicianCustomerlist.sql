USE [$(dbName)]
GO

/****** Object:  StoredProcedure [dbo].[usp_getTechnicianCustomerlist]    Script Date: 8/25/2016 6:01:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:        Abhinav Goel
-- Create date: 15-05-2008
-- Description:   to fetch customer data
-- Parameters:    
-- =============================================
ALTER  PROCEDURE [dbo].[usp_getTechnicianCustomerlist]( 

@FirstName varchar(100), 
@LastName varchar(100),
@zipcode varchar(100) = null,
@customerid bigint,
@datefrom varchar(50),
@dateto varchar(50),
@eventId varchar(50),
@mode int,
@PageIndex int=1,
@PageSize int=10,
@PhoneNumber varchar(12)=null,
@Email varchar(100)=null
) 
      -- Add the parameters for the stored procedure here
AS
BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET NOCOUNT ON;
      DECLARE @FirstRec int, @LastRec int  
	  SET  @FirstRec = (@PageIndex  - 1) * @PageSize  
	  SET  @LastRec  = (@PageIndex * @PageSize)
    -- Insert statements for procedure here
      BEGIN
			Declare @count_query nvarchar(max)
            Declare @sel_events_query nvarchar(max)
            Declare @sel_address_query nvarchar(4000)
			Declare @eventdate_query nvarchar(2000)
            if(@mode=0)
            Begin
				
				IF(@CustomerId > 0)
				BEGIN
					select * from 
					(
						SELECT  TC.CustomerID,
							isnull(RegData.EventName,'')EventName,                                                            
							isnull(RegData.EventID,0) EventID,                                                       
							RegData.EventDate,
							RegData.OrganizationName,
							ISNULL(RegData.PackageName,'') as PackageName,
							--'' as PackageName,
							'' as AdditionalTest,                                                             
							0 as FranchiseeID,                                                              
							ISNULL(TU.FirstName, '') FirstName,
							ISNULL(TU.MiddleName, '')MiddleName,
							ISNULL(TU.LastName, '') LastName,
							TU.DateCreated,
							TU.DOB,
							TC.Gender,
							TU.HomeAddressID,
							ISNULL(TC.AddedByRoleID, 0) RoleID,
							TU.EMail1,
							ISNULL(IsNull(IsNull(TU.PhoneHome,TU.PhoneCell), TU.PhoneOffice) , '') as Phone,
							TC.TrackingMarketingID,
							0 as PaymentNet,
							COUNT(*) OVER(PARTITION BY NULL) as TotalCount,
							ROW_NUMBER() OVER (ORDER BY TU.DateModified) AS RowNumber
							from  TblUser TU WITH (NOLOCK)
							INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddressID=TU.HomeAddressID							
								
							inner join vw_Customers TC WITH (NOLOCK) on TU.UserId = TC.UserId 								
								and TC.CustomerId = @customerid								
							left outer join 
							(
								select CustomerId, max(TEC.EventCustomerId) EventCustomerId from TblEventCustomers TEC
								INNER JOIN TblEventCustomerOrderDetail TECOD WITH (NOLOCK) on TECOD.EventCustomerId = TEC.EventCustomerID 														
								where TECOD.IsActive=1 and TEC.AppointmentID IS NOT NULL
								group by CustomerId
							)EventCust on EventCust.CustomerId = TC.CustomerId
							left outer join
							(
								select TE.EventId, TE.EventName, TE.EventDate, TP.OrganizationName, Package.PackageName,TEC.EventCustomerId
								from TblEventCustomers TEC WITH (NOLOCK)							
								inner join TblEvents TE WITH (NOLOCK) on TEC.EventID = TE.EventID 									
								inner join TblHostEventDetails TEH WITH (NOLOCK) on TEH.EventID=TEC.EventID
								inner join TblProspects TP WITH (NOLOCK) on TP.ProspectID=TEH.HostID
								inner JOIN TblEventCustomerOrderDetail TECOD WITH (NOLOCK) on TECOD.EventCustomerId = TEC.EventCustomerID and TECOD.IsActive = 1
								inner JOIN TblOrderDetail TOD WITH (NOLOCK) on  TOD.OrderDetailId=TECOD.OrderDetailId
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
							)RegData on RegData.EventCustomerId = EventCust.EventCustomerId
							WHERE TU.IsActive=1 and ((EventCust.EventCustomerId>0 and RegData.EventCustomerId>0) or (EventCust.EventCustomerId is null and RegData.EventCustomerId is null and @eventId is null and @datefrom is null and @dateto is null))
					   )DvCustomers WHERE RowNumber between @FirstRec+1 and @LastRec    
				END
				Else
				BEGIN
					select * from 
					(
						SELECT  TC.CustomerID,
							isnull(RegData.EventName,'')EventName,                                                            
							isnull(RegData.EventID,0) EventID,                                                       
							RegData.EventDate,
							RegData.OrganizationName,
							ISNULL(RegData.PackageName,'') as PackageName,
							--'' as PackageName,
							'' as AdditionalTest,                                                             
							0 as FranchiseeID,                                                              
							ISNULL(TU.FirstName, '') FirstName,
							ISNULL(TU.MiddleName, '')MiddleName,
							ISNULL(TU.LastName, '') LastName,
							TU.DateCreated,
							TU.DOB,
							TC.Gender,
							TU.HomeAddressID,
							ISNULL(TC.AddedByRoleID, 0) RoleID,
							TU.EMail1,
							ISNULL(IsNull(IsNull(TU.PhoneHome,TU.PhoneCell), TU.PhoneOffice) , '') as Phone,
							TC.TrackingMarketingID,
							0 as PaymentNet,
							COUNT(*) OVER(PARTITION BY NULL) as TotalCount,
							ROW_NUMBER() OVER (ORDER BY TU.DateModified) AS RowNumber
							from  TblUser TU WITH (NOLOCK)
							INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddressID=TU.HomeAddressID 
								and 1 = case when @zipcode is not null then (case when TA.ZipId in (select ZipId from TblZip where Zipcode = @zipcode) then 1 else 0 end) else 1 end
								
							inner join vw_Customers TC WITH (NOLOCK) on TU.UserId = TC.UserId 
								and TU.Firstname like  isnull(@FirstName, '') + '%' 
								and TU.LastName like  isnull(@LastName, '') + '%'
								and TC.CustomerId = isnull(@customerid,TC.CustomerId)
								and 1 = case when @PhoneNumber is not null then (case when TU.PhoneHome = @PhoneNumber then 1 else 0 end) else 1 end
								and 1 = case when @Email is not null then (case when TU.Email1 like '%'+ @Email + '%' then 1 else 0 end) else 1 end
							left outer join 
							(
								select CustomerId, max(TEC.EventCustomerId) EventCustomerId from TblEventCustomers TEC
								INNER JOIN TblEventCustomerOrderDetail TECOD WITH (NOLOCK) on TECOD.EventCustomerId = TEC.EventCustomerID and TEC.EventId = isnull(@eventId,TEC.EventId)
								inner join TblEvents TE WITH (NOLOCK) on TEC.EventID = TE.EventID 
									and 1 = Case When len(isnull(@datefrom, '')) < 1 then 1 else  (case when TE.EventDate >= cast(@datefrom as Datetime) then 1 else 0 end) end
									and 1=  Case When len(isnull(@dateto, '')) < 1 then 1 else  (case when TE.EventDate <= cast(@dateto as Datetime) then 1 else 0 end) end							
								where TECOD.IsActive=1 and TEC.AppointmentID IS NOT NULL
								group by CustomerId
							)EventCust on EventCust.CustomerId = TC.CustomerId
							left outer join
							(
								select TE.EventId, TE.EventName, TE.EventDate, TP.OrganizationName, Package.PackageName,TEC.EventCustomerId
								from TblEventCustomers TEC WITH (NOLOCK)							
								inner join TblEvents TE WITH (NOLOCK) on TEC.EventID = TE.EventID 
									and 1 = Case When len(isnull(@datefrom, '')) < 1 then 1 else  (case when TE.EventDate >= cast(@datefrom as Datetime) then 1 else 0 end) end
									and 1=  Case When len(isnull(@dateto, '')) < 1 then 1 else  (case when TE.EventDate <= cast(@dateto as Datetime) then 1 else 0 end) end
								inner join TblHostEventDetails TEH WITH (NOLOCK) on TEH.EventID=TEC.EventID
								inner join TblProspects TP WITH (NOLOCK) on TP.ProspectID=TEH.HostID
								inner JOIN TblEventCustomerOrderDetail TECOD WITH (NOLOCK) on TECOD.EventCustomerId = TEC.EventCustomerID and TECOD.IsActive = 1
								inner JOIN TblOrderDetail TOD WITH (NOLOCK) on  TOD.OrderDetailId=TECOD.OrderDetailId
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
							)RegData on RegData.EventCustomerId = EventCust.EventCustomerId
							WHERE TU.IsActive=1 and ((EventCust.EventCustomerId>0 and RegData.EventCustomerId>0) or (EventCust.EventCustomerId is null and RegData.EventCustomerId is null and @eventId is null and @datefrom is null and @dateto is null))
					   )DvCustomers WHERE RowNumber between @FirstRec+1 and @LastRec    
				END     
					
            END
            ELSE IF(@mode=1)
            BEGIN
                  Set @sel_events_query = 'Select distinct  
                                            '''' as EventName, 
                                            ROW_NUMBER() OVER (ORDER BY TC.CustomerID) AS Row, 
                                            0 as EventID,  
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
                                            TU.EMail1,  
                                            ISNULL(IsNull(IsNull(TU.PhoneCell,TU.PhoneHome), TU.PhoneOffice) , '''') as Phone,
                                            TC.TrackingMarketingID,  
                                            0 as PaymentNet,
                                            COUNT(*) OVER(PARTITION BY NULL) as TotalCount
                                            from  vw_Customers TC  WITH (NOLOCK) 
                                             Inner Join TblUser TU WITH (NOLOCK) on TU.UserID=TC.UserID  
                                            INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddressID=TU.HomeAddressID
                                            WHERE CustomerID NOT IN (SELECT DISTINCT customerid FROM dbo.TblEventCustomers WITH (NOLOCK) WHERE AppointmentID IS NOT null) '  
                  
--                if(@LastName is NULL)
--                BEGIN
--                      Set @sel_events_query = @sel_events_query + ' and ((rtrim(ltrim(TU.FirstName)) + (case when len(rtrim(ltrim(isnull(middlename,'''')))) > 0 then '' '' + middlename + '' '' else '' '' end) +  rtrim(ltrim(TU.LastName)))like ''%' + @FirstName + '%'' )'                
--                END
--                ELSE
--                BEGIN
                        if(@FirstName is not NULL)
                        BEGIN
                              Set @sel_events_query = @sel_events_query + ' and (rtrim(ltrim(TU.FirstName)) like ''' + @FirstName + '%'' )'            
                        END
                        
                        if(@LastName is not NULL)
                        BEGIN
                              IF(LEN(@LastName)=2)
                              BEGIN
                                    Set @sel_events_query = @sel_events_query + ' and (rtrim(ltrim(TU.LastName))like ''' + @LastName + ''' )'            
                              END
                              ELSE
                              BEGIN
                                    Set @sel_events_query = @sel_events_query + ' and (rtrim(ltrim(TU.LastName))like ''' + @LastName + '%'' )'            
                              END
                              
                        END
--                END

                  if(@zipcode is not null)
                  BEGIN
                        Set @sel_events_query = @sel_events_query + ' AND TA.ZipID in (Select ZipID from TblZip where ZipCode like ''%' + @zipcode + '%'' ) '
                  END
                  
                  if(@customerid is not null)
                  BEGIN
                        Set @sel_events_query = @sel_events_query + ' AND TC.CustomerID =''' + CAST(@customerid AS VARCHAR(10)) + ''' '
                  END
                  
                  if((@datefrom is not NULL) AND (@dateto is not null))
                  BEGIN
                        Set @sel_events_query = @sel_events_query + ' AND TU.DateCreated >=CAST(''' + CONVERT(VARCHAR,@datefrom,101) + '''AS DATETIME)  AND TU.DateCreated <=CAST(''' + CONVERT(VARCHAR,@dateto,101) + '''AS DATETIME) + 1'
                  END
                  ELSE if(@datefrom is not null)
                  BEGIN
                        Set @sel_events_query = @sel_events_query + ' AND TU.DateCreated >=CAST(''' + CONVERT(VARCHAR,@datefrom,101) + '''AS DATETIME) '
                  END
                  ELSE if(@dateto is not null)
                  BEGIN
                        Set @sel_events_query = @sel_events_query + ' AND TU.DateCreated <=CAST(''' + CONVERT(VARCHAR,@dateto,101) + '''AS DATETIME) + 1'
                  END
                  --Set @sel_events_query = @sel_events_query  + ' order by TU.DateCreated desc '
                  
                  Set @sel_address_query = 'Select distinct  
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
                                    inner join TblZip WITH (NOLOCK) on TblZip.ZipID = TA.ZipID  
                                    inner join tblState WITH (NOLOCK) on tblState.StateID = TA.StateID  
                                    inner join tblCountry WITH (NOLOCK) on tblCountry.CountryID = TA.CountryID  
                                    INNER JOIN TblUser TU WITH (NOLOCK) ON TU.HomeAddressID=TA.AddressID  
                                    inner join vw_Customers TC WITH (NOLOCK) on TC.UserID=TU.UserID  
                                    WHERE CustomerID NOT IN (SELECT DISTINCT customerid FROM dbo.TblEventCustomers WITH (NOLOCK) WHERE AppointmentID IS NOT null)'
                                    
--                if(@LastName is NULL)
--                BEGIN
--                      Set @sel_address_query = @sel_address_query + ' and ((rtrim(ltrim(TU.FirstName)) + (case when len(rtrim(ltrim(isnull(middlename,'''')))) > 0 then '' '' + middlename + '' '' else '' '' end) +  rtrim(ltrim(TU.LastName)))like ''%' + @FirstName + '%'' )'
--                END
--                ELSE
--                BEGIN
                        if(@FirstName is not null)
                        BEGIN
                              Set @sel_address_query = @sel_address_query +  ' and (rtrim(ltrim(TU.FirstName)) like ''' + @FirstName + '%'' )'              
                        END
                        
                        if(@LastName is not null)
                        BEGIN
                              Set @sel_address_query = @sel_address_query +  ' and (rtrim(ltrim(TU.LastName))like ''' + @LastName + '%'' )'              
                        END
--                END

                  if(@zipcode is not null)
                  BEGIN
                        Set @sel_address_query = @sel_address_query + ' and TblZip.ZipCode like ''%' + @zipcode + '%'' '
                  END
                        
                  if(@customerid is not null)
                  BEGIN
                        Set @sel_address_query = @sel_address_query + ' AND TC.CustomerID =''' + CAST(@customerid AS VARCHAR(10)) + ''' '
                  END
                  
                  if((@datefrom is not NULL) AND (@dateto is not null))
                  BEGIN
                        Set @sel_address_query = @sel_address_query + ' AND TU.DateCreated >=CAST(''' + CONVERT(VARCHAR,@datefrom,101) + '''AS DATETIME)  AND TU.DateCreated <=CAST(''' + CONVERT(VARCHAR,@dateto,101) + '''AS DATETIME) + 1 '
                  END
                  ELSE if(@datefrom is not null)
                  BEGIN
                        Set @sel_address_query = @sel_address_query + ' AND TU.DateCreated >=CAST(''' + CONVERT(VARCHAR,@datefrom,101) + '''AS DATETIME) '
                  END
                  ELSE if(@dateto is not null)
                  BEGIN
                        Set @sel_address_query = @sel_address_query + ' AND TU.DateCreated <=CAST(''' + CONVERT(VARCHAR,@dateto,101) + '''AS DATETIME) + 1 '
                  END
                  
                  
					SET @count_query = 'Select Count(CustomerID) as TotalCustomers from (' + @sel_events_query + ') DvCustomers'
		            
					/* Executing both queries */
					SET @sel_events_query = 'Select * from ( ' + @sel_events_query + ') DvCustomers WHERE Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar)
					Exec sp_executesql @sel_events_query
					Exec sp_executesql @sel_address_query
		            
		            
					Exec sp_executesql @count_query
            END
--          print @sel_events_query
--          print @sel_address_query
			
            


      END
      
      
      
      
END
