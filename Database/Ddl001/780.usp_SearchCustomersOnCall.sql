USE [$(dbname)]
GO


/****** Object:  StoredProcedure [dbo].[usp_SearchCustomersOnCall]    Script Date: 01-03-2018 21:48:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
ALTER PROCEDURE [dbo].[usp_SearchCustomersOnCall]   
(@firstname varchar(50),   
@lastname varchar(50),  
@zipcode varchar(50),   
@mode tinyint,   
@callbacknumber varchar(50),  
@customerid bigint=NULL,
@InsuranceId varchar(50),
@hicn varchar(50),
@PhoneNumber varchar(50),
@Email varchar(100),
@OrganizationId bigint=NULL
)  
AS  
BEGIN  
  
 IF(@callbacknumber = '(___)-___-____')  
  Set @callbacknumber = ''  
    
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
 if(@mode = 0)  
 BEGIN  
  Declare @sel_users_query nvarchar(4000)  
  Declare @sel_address_query nvarchar(4000)  
  Declare @sel_query_conditions nvarchar(1000)  
  Declare @sel_CorporateCustomerTag nvarchar(4000)
  Declare @sel_CustomerPreApprovedTest nvarchar(4000)
  DECLARE @tempQuery nvarchar (500)  
  set @sel_query_conditions = ''  
  SET @tempQuery = ' '  
  
  Declare @MemberId_query nvarchar(1000)
  SET @MemberId_query = ''
  
  if((@firstname is not null) AND @firstname <>'')  
  BEGIN  
   Set @sel_query_conditions = @sel_query_conditions + ' and (TU.FirstName like ''%' + @firstname + '%'')'   
  END  
    
  if((@lastname is not null) AND @lastname <>'')  
  BEGIN  
   IF (LEN(@lastname)=2)  
   BEGIN  
    Set @sel_query_conditions = @sel_query_conditions + ' and (TU.Lastname = ''' + @lastname + ''')'   
   END  
   ELSE  
   BEGIN  
    Set @sel_query_conditions = @sel_query_conditions + ' and (TU.Lastname like ''%' + @lastname + '%'')'   
   END  
  END  
     
  if((@zipcode is not null) AND @zipcode <>'')  
  BEGIN  
   Set @sel_query_conditions = @sel_query_conditions + ' and TA.ZipID not in (Select ZipID from TblZip where ZipCode = ''' + @zipcode + ''')'  
  END  
    
  if(@customerid is not null )  
  BEGIN  
   Set @sel_query_conditions = @sel_query_conditions + ' and TC.CustomerID = ''' + CAST(@customerid AS varchar) + ''' '  
  END  
  
  if((@InsuranceId is not null) AND @InsuranceId <>'')  
  BEGIN  
	if((@zipcode is not null) AND @zipcode <>'')  
	BEGIN  
		Set @sel_query_conditions = ' AND (TA.ZipID not in (Select ZipID from TblZip where ZipCode = ''' + @zipcode + ''') AND TC.InsuranceId = ''' + @InsuranceId + ''')'
	END 
	else
	BEGIN 
		Set @sel_query_conditions = ' AND (TC.InsuranceId = ''' + @InsuranceId + ''')'  
	END  
  END
    
  if((@hicn is not null) AND @hicn <>'')  
  BEGIN  
   Set @sel_query_conditions = @sel_query_conditions + ' and (TC.HICN = ''' + @hicn + ''')'   
  END 
   if ((@PhoneNumber is not null) and  @PhoneNumber <> '')
  Begin
	set @sel_query_conditions = @sel_query_conditions + ' and (TU.PhoneHome = ''' + @PhoneNumber + ''' or TU.PhoneCell= ''' + @PhoneNumber + ''' or TU.PhoneOffice= ''' + @PhoneNumber  + ''') '
  End

  if((@Email is not null) and @Email <> '')
  Begin
	set @sel_query_conditions = @sel_query_conditions +  ' and ( TU.Email1 like  ''%' + @Email + '%'')'
  End
--  if((@callbacknumber is not null)AND @callbacknumber<>'')  
--  BEGIN  
--   Set @sel_query_conditions = @sel_query_conditions + ' AND (TblCalls.CallBackNumber is null or  TblCalls.CallBackNumber <>''' + @callbacknumber + ''')'  
--   --SET @tempQuery=' left outer join TblCalls on TblCalls.CalledCustomerID=TC.CustomerID '  
--  END  

  if(@OrganizationId is not null AND @OrganizationId > 0)
  BEGIN
  Set @sel_query_conditions = @sel_query_conditions + ' And (
										TC.Tag is null
										OR
										TC.Tag = ''''
										OR
										TC.Tag in 
										(
											select Tag from TblAccount where RestrictHealthPlanData = 0 or AccountId in 
											(
												select AccountId from TblAccountCallCenterOrganization where IsDeleted = 0 and OrganizationId = ''' + CAST(@OrganizationId AS varchar) + '''   
											)
										)
									 )'
  END
    
  Set @sel_users_query = 'SELECT DISTINCT TOP 21  TU.UserID, TU.HomeAddressID, TU.FirstName,   
     TU.MiddleName, TU.LastName, isnull(TC.CustomerID,0)CustomerID,''0'' as EventID,TU.Email1, TUL.UserName, getdate() as EventDate,  
     isnull(TUL.HintQuestion,'''') as Question,isnull(TUL.HintAnswer,'''') as Answer,TU.DOB
     ,isnull(TC.Tag,'''') as Tag ,isnull(TC.InsuranceId, '''') as InsuranceId ,isnull(TC.HICN, '''') as HICN ,TC.Copay,isnull(TC.MedicareAdvantagePlanName, '''') as MedicareAdvantagePlanName,
     TC.IsEligble, ISNULL(TC.DoNotContactReasonId,0) as DoNotContactReasonId, ISNULL(TC.DoNotContactTypeId,0) as DoNotContactTypeId, ISNULL(TC.DoNotContactReasonNotesId,0) as DoNotContactReasonNotesId
     from TblUser TU 
     inner join TblAddress TA on TA.AddressID = TU.HomeAddressID   
     inner join TblUserLogin TUL on TU.UserID=TUL.UserLoginID  
     left outer join vw_Customers TC on  TU.UserID = TC.UserID        
     where TU.IsActive=1 ' +   @sel_query_conditions  +  @MemberId_query
	 --where TU.IsActive=1 and ((TC.CustomerId is null or isnull(TC.DoNotContactReasonId, 0) = 0) ' +   @sel_query_conditions  + ')' + @MemberId_query
     --+ 'GROUP BY TU.UserID, TU.HomeAddressID, TU.FirstName,   
     --TU.MiddleName, TU.LastName, TC.CustomerID, TU.Email1, TUL.UserName,   
     --HintQuestion, HintAnswer, TU.DOB'  
  
  Set @sel_address_query = 'SELECT AddressID, Address1, Address2, TC.CityID,TC.[Name] as City,TS.StateID,  
       TS.[Name] as State,TCO.CountryID,TCO.[Name] as Country, TZ.ZipId, TZ.ZipCode  
     from TblAddress TA inner join tblCity TC on TA.CityID=TC.CityID  
      inner join TblZip   TZ on TZ.ZipID = TA.ZipID  
     inner join tblState TS on TA.StateID= TS.StateID  
     inner join tblCountry TCO on TA.CountryID=TCO.CountryID where TA.AddressID in   
     (SELECT  TU.HomeAddressID 
     from TblUser TU 
     inner join TblAddress TA on TA.AddressID = TU.HomeAddressID
     left outer join vw_Customers TC on  TU.UserID = TC.UserID   
     where TU.IsActive=1 ' +  @sel_query_conditions  + @MemberId_query + ')'  
	 --where TU.IsActive=1 and ((TC.CustomerId is null or isnull(TC.DoNotContactReasonId, 0) = 0) ' +  @sel_query_conditions + ')' + @MemberId_query + ')'  

  set @sel_CorporateCustomerTag= 'Select CustomerId,Tag from TblCustomerTag where CustomerId in (SELECT isnull(TC.CustomerID,0)CustomerID 
     from TblUser TU 
     inner join TblAddress TA on TA.AddressID = TU.HomeAddressID   
     inner join TblUserLogin TUL on TU.UserID=TUL.UserLoginID  
     left outer join vw_Customers TC on  TU.UserID = TC.UserID        
     where TU.IsActive=1 ' +   @sel_query_conditions   + @MemberId_query + ')'
	 --where TU.IsActive=1 and ((TC.CustomerId is null or isnull(TC.DoNotContactReasonId, 0) = 0) ' +   @sel_query_conditions  + ')' + @MemberId_query + ')'
     
  set @sel_CustomerPreApprovedTest = 'select TEAT.CustomerId, TT.Name as TestName from TblPreApprovedTest TEAT inner join TblTest TT on TEAT.TestId = TT.TestId where TEAT.IsActive = 1 
	 and CustomerId in (SELECT isnull(TC.CustomerID,0)CustomerID 
     from TblUser TU 
     inner join TblAddress TA on TA.AddressID = TU.HomeAddressID   
     inner join TblUserLogin TUL on TU.UserID=TUL.UserLoginID  
     left outer join vw_Customers TC on  TU.UserID = TC.UserID        
     where TU.IsActive=1 ' +   @sel_query_conditions  +  @MemberId_query + ')'
	 --where TU.IsActive=1 and ((TC.CustomerId is null or isnull(TC.DoNotContactReasonId, 0) = 0) ' +   @sel_query_conditions  + ')' + @MemberId_query + ')'
  --print @sel_users_query  
  --print @sel_address_query  
   
  Execute sp_executesql @sel_users_query  
  Execute sp_executesql @sel_address_query
  Execute sp_executesql @sel_CorporateCustomerTag
  Execute sp_executesql @sel_CustomerPreApprovedTest
  
 END  
 ELSE if(@mode = 1)  
 BEGIN  
  Declare @sel_users1_query nvarchar(4000)  
  Declare @sel_address1_query nvarchar(4000)  
  Declare @sel_query1_conditions nvarchar(1000)  
  Declare @sel_CorporateCustomerTag1 nvarchar(4000)
  Declare @sel_CustomerPreApprovedTest1 nvarchar(4000)

  DECLARE @tempQuery1 nvarchar (500)  
  set @sel_query1_conditions = ''  
  SET @tempQuery1 = ' '  
  
  Declare @MemberId_query1 nvarchar(1000)
  SET @MemberId_query1 = ''
  
  if((@zipcode is not null) AND @zipcode <>'')  
  BEGIN  
   Set @sel_query1_conditions = @sel_query1_conditions + ' and TA.ZipID in (Select ZipID from TblZip where ZipCode = ''' + @zipcode + ''')'  
  END  
  
  if((@firstname is not null) AND @firstname <>'')  
  BEGIN  
   Set @sel_query1_conditions = @sel_query1_conditions + ' and (TU.FirstName like ''%' + @firstname + '%'')'   
  END  
    
  if((@lastname is not null) AND @lastname <>'')  
  BEGIN  
   IF (LEN(@lastname)=2)  
   BEGIN  
    Set @sel_query1_conditions = @sel_query1_conditions + ' and (TU.Lastname = ''' + @lastname + ''')'   
   END  
   ELSE  
   BEGIN  
    Set @sel_query1_conditions = @sel_query1_conditions + ' and (TU.Lastname like ''%' + @lastname + '%'')'   
   END  
  END  
    
  if(@customerid is not null )  
  BEGIN  
   Set @sel_query1_conditions = @sel_query1_conditions + ' and TC.CustomerID = ''' + CAST(@customerid AS varchar) + ''' '  
  END  
  
  if((@InsuranceId is not null) AND @InsuranceId <>'')  
  BEGIN  
	if((@zipcode is not null) AND @zipcode <>'')  
	BEGIN  
		Set @sel_query1_conditions = ' AND (TA.ZipID in (Select ZipID from TblZip where ZipCode = ''' + @zipcode + ''') AND TC.InsuranceId = ''' + @InsuranceId + ''')'
	END 
	else
	BEGIN 
		Set @sel_query1_conditions = ' AND (TC.InsuranceId = ''' + @InsuranceId + ''')'  
	END 
  END  
    
  if((@hicn is not null) AND @hicn <>'')  
  BEGIN  
   Set @sel_query1_conditions = @sel_query1_conditions + ' and (TC.HICN = ''' + @hicn + ''')'   
  END 

   if ((@PhoneNumber is not null) and  @PhoneNumber <> '')
  Begin
	set @sel_query_conditions = @sel_query_conditions + ' and (TU.PhoneHome = ''' + @PhoneNumber + ''' or TU.PhoneCell= ''' + @PhoneNumber + ''' or TU.PhoneOffice= ''' + @PhoneNumber  + ''') '
  End

  if((@Email is not null) and @Email <> '')
  Begin
	set @sel_query_conditions = @sel_query_conditions +  ' and ( TU.Email1 like  ''%' + @Email + '%'')'
  End

--  if((@callbacknumber is not null)AND @callbacknumber<>'')  
--  BEGIN  
--   Set @sel_query1_conditions = @sel_query1_conditions + ' AND TblCalls.CallBackNumber=''' + @callbacknumber + ''''  
--   --SET @tempQuery1=' left outer join TblCalls on TblCalls.CalledCustomerID=TC.CustomerID '  
--  END  
    
if(@OrganizationId is not null AND @OrganizationId > 0)
  BEGIN
  Set @sel_query_conditions = @sel_query_conditions + ' And (
										TC.Tag is null
										OR
										TC.Tag = ''
										OR
										TC.Tag in 
										(
											select Tag from TblAccount where RestrictHealthPlanData = 0 or AccountId in 
											(
												select AccountId from TblAccountCallCenterOrganization where IsDeleted = 0 and OrganizationId = ''' + CAST(@OrganizationId AS varchar) + '''  
											)
										)
									 )'
  END

  Set @sel_users1_query = 'SELECT DISTINCT TOP 21 TU.UserID, TU.HomeAddressID, TU.FirstName,   
     TU.MiddleName, TU.LastName, isnull(TC.CustomerID,0)CustomerID,''0'' as EventID,TU.Email1, TUL.UserName, getdate() as EventDate,  
     isnull(TUL.HintQuestion,'''') as Question,isnull(TUL.HintAnswer,'''') as Answer,TU.DOB  
     ,isnull(TC.Tag,'''') as Tag ,isnull(TC.InsuranceId, '''') as InsuranceId ,isnull(TC.HICN, '''') as HICN ,TC.Copay,isnull(TC.MedicareAdvantagePlanName, '''') as MedicareAdvantagePlanName,
     TC.IsEligble , ISNULL(TC.DoNotContactReasonId,0) as DoNotContactReasonId, ISNULL(TC.DoNotContactTypeId,0) as DoNotContactTypeId, ISNULL(TC.DoNotContactReasonNotesId,0) as DoNotContactReasonNotesId
     from TblUser TU 
     inner join TblAddress TA on TA.AddressID = TU.HomeAddressID   
     inner join TblUserLogin TUL on TU.UserID=TUL.UserLoginID  
     left outer join vw_Customers TC on TU.UserID = TC.UserID      
     where TU.IsActive=1 ' +   @sel_query1_conditions   + @MemberId_query1
	 --where TU.IsActive=1 and ((TC.CustomerId is null or isnull(TC.DoNotContactReasonId, 0) = 0) ' +   @sel_query1_conditions  + ')' + @MemberId_query1
     --+ 'GROUP BY TU.UserID, TU.HomeAddressID, TU.FirstName,   
     --TU.MiddleName, TU.LastName, TC.CustomerID, TU.Email1, TUL.UserName,   
     --HintQuestion, HintAnswer, TU.DOB'  
  
  Set @sel_address1_query = 'SELECT AddressID, Address1, Address2, TC.CityID,TC.[Name] as City,TS.StateID,  
       TS.[Name] as State,TCO.CountryID,TCO.[Name] as Country, TZ.ZipId, TZ.ZipCode  
     from TblAddress TA inner join tblCity TC on TA.CityID=TC.CityID  
      inner join TblZip   TZ on TZ.ZipID = TA.ZipID  
     inner join tblState TS on TA.StateID= TS.StateID  
     inner join tblCountry TCO on TA.CountryID=TCO.CountryID where TA.AddressID in   
     (SELECT  TU.HomeAddressID 
     from TblUser TU
     inner join TblAddress TA on TA.AddressID = TU.HomeAddressID
     left outer join vw_Customers TC on  TU.UserID = TC.UserID       
     where TU.IsActive=1 ' +  @sel_query1_conditions  + @MemberId_query1 + ')'  
	 --where TU.IsActive=1 and ((TC.CustomerId is null or isnull(TC.DoNotContactReasonId, 0) = 0) ' +  @sel_query1_conditions + ')' + @MemberId_query1 + ')'  
       
  Set @sel_CorporateCustomerTag1 ='Select CustomerId,Tag from TblCustomerTag where CustomerId in (SELECT isnull(TC.CustomerID,0)CustomerID
     from TblUser TU 
     inner join TblAddress TA on TA.AddressID = TU.HomeAddressID   
     inner join TblUserLogin TUL on TU.UserID=TUL.UserLoginID  
     left outer join vw_Customers TC on TU.UserID = TC.UserID      
     where TU.IsActive=1 ' +   @sel_query1_conditions   + @MemberId_query1 + ')'
	 --where TU.IsActive=1 and ((TC.CustomerId is null or isnull(TC.DoNotContactReasonId, 0) = 0) ' +   @sel_query1_conditions  + ')' + @MemberId_query1 + ')'
     
  set @sel_CustomerPreApprovedTest1 = 'select TEAT.CustomerId, TT.Name as TestName from TblPreApprovedTest TEAT inner join TblTest TT on TEAT.TestId = TT.TestId where TEAT.IsActive = 1 
	 and CustomerId in (SELECT isnull(TC.CustomerID,0)CustomerID 
     from TblUser TU 
     inner join TblAddress TA on TA.AddressID = TU.HomeAddressID   
     inner join TblUserLogin TUL on TU.UserID=TUL.UserLoginID  
     left outer join vw_Customers TC on  TU.UserID = TC.UserID        
     where TU.IsActive=1 ' +   @sel_query1_conditions   + @MemberId_query1 + ')'
	 --where TU.IsActive=1 and ((TC.CustomerId is null or isnull(TC.DoNotContactReasonId, 0) = 0) ' +   @sel_query1_conditions  + ')' + @MemberId_query1 + ')'

  --print @sel_users1_query  
  --print @sel_address1_query  
   
  Execute sp_executesql @sel_users1_query  
  Execute sp_executesql @sel_address1_query  
  Execute sp_executesql @sel_CorporateCustomerTag1  
  Execute sp_executesql @sel_CustomerPreApprovedTest1

 END  
   
  
  
END  



GO


