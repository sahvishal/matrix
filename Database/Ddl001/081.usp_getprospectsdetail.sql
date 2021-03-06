USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_getprospectsdetail]    Script Date: 10/08/2012 13:09:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  -- =============================================            
-- Author:  Gaurav Malhotra            
-- Create date: 08-12-2008            
-- Description: To get the detail of the all prospects (with search criteria)            
-- Name: [usp_getprospectsdetail]  
-- =============================================            
ALTER PROCEDURE [dbo].[usp_getprospectsdetail]             
(            
 @ProspectName VARCHAR(500),            
 @StartDate VARCHAR(100),            
 @EndDate VARCHAR(100),            
 @franchiseeID BIGINT,--franchiseeid if mode 0, salesrepid if mode 1            
 @StatusId INT,            
 @TypeId INT,            
 @mode int,--0 stands for franchisor ,1 for salesrep            
 @zipcode varchar(20),          
 @distance int,        
 @IsHost int,    
 @AssignedStatus INT=NULL,  
 @UserID INT=NULL,  
 @TerritoryID int=NULL,  
 @SortColumn VARCHAR(255)=NULL,  
 @SortOrder VARCHAR(10)=NULL,  
 @PageSize INT=10,  
 @PageIndex INT=1,  
 @WillPromote INT=3,  
 @WillHost INT=3,  
 @HostedInPast INT =3,  
 @assignedTo BIGINT,  
 @role varchar(100)=NULL,  
 @prospectTypeId BIGINT  
)            
AS  
BEGIN        
  Declare @SalesRepId BIGINT  
  Declare @roleid int  
  Declare @strquery nvarchar(4000)  
  Declare @strquery1 nvarchar(4000)  
  Declare @strCondition nvarchar(4000)  
  Declare @strJoin nvarchar(4000)  
  Declare @strCondition1 nvarchar(4000)  
  Declare @TerritotyCondition nvarchar(500)  
  Declare @TerritotyConditionZipCodeNull nvarchar(4000)  
  set @strCondition=''set @strJoin=''  
  SET @strquery=''SET @strquery1=''  
  SET @strCondition1='' set @TerritotyCondition=''  
  SET @TerritotyConditionZipCodeNull=''  
    
    
  IF (LEN(@SortColumn) <= 0)  
  SET @SortColumn = ' DateModified '  
    
  DECLARE @FirstRec int, @LastRec int    
  SET  @FirstRec = (@PageIndex  - 1) * @PageSize    
  SET  @LastRec  = (@PageIndex * @PageSize)   
  
select @roleid=roleid from TblRole where alias='SalesRep'  
  
Select @ProspectName = Replace(@ProspectName,'''', '''''')  
IF (@mode=0)  
BEGIN  
------ Main Query ----------------------------------------------------------------------------------------------  
 SET @strquery=  
 'SELECT *FROM (  
 SELECT   
 ROW_NUMBER() OVER (ORDER BY P.DateModified DESC) AS Row,  
 P.OrgRoleUserId as SalesRepId,  
 P.ProspectID "ProspectId",  
 P.OrganizationName "ProspectName",  
 P.DateCreated "ProspectCreatedDate",  
 P.PhoneOffice "PhoneOffice",  
 P.DateModified,  
 ISNULL(PA.ProspectAddressId,0) "ProspectAddressId",  
 PA.Address1 "ProspectAddress1",  
 PA.Address2 "ProspectAddress2",  
 PA.City "ProspectCity",  
 PA.State "ProspectState",  
 PA.Zip "ProspectZip",  
 PA.Country "ProspectCountry",  
 P.Status "ProspectStatus",            
 Contacts.FirstName ContactFirstName,  
 Contacts.LastName "ContactLastName",  
 Contacts.PhoneOffice "ContactPhone",  
 IsNull(Contacts.Email, Contacts.EmailOffice) "ContactEmail",  
 CASE  WHEN TCCS.Status IS NULL then '+''''+'N/A'+''''+'  ELSE TCCS.Status End as "ContactCallStatus",  
 convert(varchar(20),TCC1.StartDate,101) as "ContactCallDate",      
 TCC.NoOFCalls as NoOFCalls,  
 (select Count(contactid)  from TblProspectContact where ProspectID=P.ProspectID and IsActive=1) as NoOfContacts,  
 TCM.NoOfMeetings as NoOFMeeting,  
 O.Name "FranchiseeName",  
 TCC1.Duration,  
 TCC1.Notes,   
 RoleId,O.OrganizationId FranchiseeID,  
 P.ISActive,  
 P.IsHost,  
 CASE  WHEN (P.OrgRoleUserId Is NOT NULL OR P.OrgRoleUserId > 0) THEN 1 ELSE 2 END AssignedStatus,  
 TU.FirstName "SalesPersonFirstName",TU.LastName "SalesPersonLastName"  
 '  
   
  ------ Secondary Query ----------------------------------------------------------------------------------------------  
  SET @strquery1='SELECT COUNT(P.ProspectID) AS TotalRecord'  
  ------ Join Tables --------------------------------------------------------------------------------------------------  
 SET @strJoin=  
 'from tblprospects P  
 LEFT OUTER JOIN TblProspectDetails TPD ON TPD.ProspectID = P.ProspectID             
 LEFT JOIN TblProspectAddress PA ON P.ProspectID =PA.ProspectID AND PA.IsMailing=0  
-- LEFT JOIN ( SELECT * FROM TblProspectContact  WHERE IsActive=1   
-- AND ProspectContactId in  
-- (  
--  SELECT ProspectContactID FROM DvProspectContact  
-- )  
-- )  AS PC ON PC.ProspectID =P.ProspectID            
 --LEFT JOIN TblContacts C ON C.ContactID=PC.ContactID and C.IsActive = 1  
 LEFT OUTER JOIN  
 (  
     SELECT PhoneHome,PhoneCell,PhoneOffice,EMail,ContactID,ProspectID AS ProspectID,  
     FirstName,MiddleName,LastName,EmailOffice
     FROM   
     (  
      SELECT PhoneHome,PhoneCell,PhoneOffice,EMail,TPC.[ProspectID],TC.ContactID, TC.EmailOffice, 
      TPC.[ProspectContactID]  
      ,TC.[FirstName],TC.[MiddleName],[LastName]   
      ,ROW_NUMBER() OVER(PARTITION BY TPC.[ProspectID] ORDER BY TPCRM.ProspectContactRoleId) AS Row  
      FROM [TblProspectContact] TPC  
      INNER JOIN [TblContacts] TC ON TPC.[ContactID] = TC.[ContactID]  
      LEFT OUTER JOIN [TblProspectContactRoleMapping] TPCRM ON TPC.[ProspectContactID] = TPCRM.[ProspectContactID] and TPCRM.IsActive=1  
     ) tblTemp WHERE Row=1  
 )Contacts ON Contacts.[ProspectID]=P.[ProspectID]  
  
 LEFT OUTER JOIN ( SELECT *FROM DvProspectCalls) TCC on TCC.ProspectID=P.ProspectID  
 Left Outer JOIN TblContactCall TCC1 on TCC1.ContactCallID=TCC.CallID and TCC1.IsActive = 1  
 LEFT OUTER JOIN TblContactCallStatus TCCS on TCCS.ContactCallStatusID=TCC1.ContactCallStatusID   
   
 LEFT OUTER JOIN (SELECT *FROM DvProspectMeetings) TCM on TCM.ProspectID=P.ProspectID  
 Left Outer JOIN TblContactMeeting TCM1 on TCM1.ContactMeetingID=TCM.MeetingID and TCM1.IsActive = 1  
   
 LEFT OUTER JOIN TblOrganizationRoleUser ORU ON ORU.[OrganizationRoleUserId]=P.[OrgRoleUserId]  
 LEFT OUTER JOIN TblUSER TU ON TU.UserID=ORU.UserID  
 LEFT OUTER JOIN TblOrganization O ON O.OrganizationId=ORU.OrganizationId'  
  
 -- filter for active records and for prospect/host  
 SET @strJoin = @strJoin + ' WHERE  P.IsActive=1 AND p.IsHost=' + CAST (@IsHost  AS VARCHAR)  
  
 if ( @franchiseeID > 0 and @franchiseeID is not NULL)  
 BEGIN   
  --SET @strJoin = @strJoin + ' INNER JOIN TblFranchisee FU ON FU.FranchiseeID=FFU.FranchiseeID AND FFU.FranchiseeID=' +CAST (@franchiseeID  AS VARCHAR)  
  SET @strJoin = @strJoin + ' AND (O.OrganizationId=' +CAST (@franchiseeID  AS VARCHAR)  
  SET @strJoin = @strJoin + ' OR P.ProspectListID IN (SELECT [ProspectFileID] FROM [TblProspectListDetails] WHERE OrganizationId =' + CAST (@franchiseeID  AS VARCHAR) + '))'    
 END   
 --ELSE   
 --BEGIN  
 -- SET @strJoin = @strJoin + ' LEFT OUTER JOIN TblFranchisee FU ON FU.FranchiseeID=FFU.FranchiseeID'  
 --END   
   
 ---------------------------------------------------------------------------------------------------------------  
 --  filter based on owning SalesRep  
 ---------------------------------------------------------------------------------------------------------------  
 if ( @UserID > 0 and @UserID is not NULL)  
 BEGIN   
   Select @SalesRepId=OrganizationRoleUserId from TblOrganizationRoleUser where UserId=@UserID and RoleId=@roleid  
   
   SET @strJoin = @strJoin + ' AND P.OrgRoleUserId=' +CAST (@SalesRepId AS VARCHAR)  
   --select @SalesRepId  
 END   
 ------ Condition ------ ----------------------------------------------------------------------------------------------  
 IF(@ProspectName<>'')            
 BEGIN            
  SET @strCondition=@strCondition+' AND P.OrganizationName LIKE '+''''+'%'+ @ProspectName +'%'+''''    
 END            
 IF((@StartDate<>'')AND (@EndDate<>''))  
 BEGIN            
  SET @strCondition =@strCondition +   
  ' AND convert(datetime,convert(VARCHAR(10),P.DateCreated,101),101) >= Convert(DateTime,'+''''+@StartDate+''''+',101)             
  AND convert(datetime,convert(VARCHAR(10),P.DateCreated,101),101) <=Convert(DateTime,'+''''+@EndDate+''''+',101)'            
 END  
  
 IF(@franchiseeID>0)            
 BEGIN            
  SET @strCondition = @strCondition +' AND O.OrganizationID='+CAST (@franchiseeID  AS VARCHAR)  
 END   
        
 IF(@StatusId<>0)            
 BEGIN            
  SET @strCondition = @strCondition +' AND P.Status ='+CAST (@StatusId  AS VARCHAR)  
 END            
 IF(@TypeId<>0)            
 BEGIN            
  SET @strCondition= @strCondition +' AND P.ProspectTypeId ='+CAST (@TypeId  AS VARCHAR)  
 END   
 ---------------Begin case added for filter record based on zipcode and distance          
 IF (@zipcode!='' AND @zipcode > 0 and @distance<>0)          
 BEGIN          
  if (@distance=1)  
  BEGIN  
   SET @strCondition=@strCondition+ ' AND PA.Zip = ''' + @zipcode   + '''' 
  END  
  ELSE  
  BEGIN    
   SET @strCondition=@strCondition+ ' AND PA.Zip in ( SELECT DISTINCT zipcode FROM TblZip  
             WHERE zipid IN ('          
   SET @strCondition=@strCondition+ ' (select zipid from dbo.fn_getzips(''' + @zipcode + ''',' + CAST (@distance  AS VARCHAR) + '))))'  
  END  
 END          
 ---------------END case added for filter record based on zipcode and distance     
 --  Assigned Status  
 IF (@AssignedStatus>0 and @AssignedStatus<=2)    
 BEGIN    
  IF (@AssignedStatus=1)  
  SET @strCondition = @strCondition +' AND (P.OrgRoleUserId Is NOT NULL And P.OrgRoleUserId > 0) '  
  ELSE   
  SET @strCondition = @strCondition +' AND (P.OrgRoleUserId Is NULL OR P.OrgRoleUserId <= 0) '  
 END    
 ---------------------------------------------------------------------------------------------  
   
 ---------------------------------------------------------------------------------------------  
 -- Will Promote  
 IF (@WillPromote >=0 AND @WillPromote < 3)    
 BEGIN  
  SET @strCondition = @strCondition +' AND P.WillPromote=' + Cast(@WillPromote as varchar)  
 END   
 ---------------------------------------------------------------------------------------------  
 ---------------------------------------------------------------------------------------------  
 -- Will Host  
 IF (@WillHost >=0 AND @WillHost < 3)    
 BEGIN  
  SET @strCondition = @strCondition +' AND TPD.WillHost=' + Cast(@WillHost as varchar)  
 END   
 ---------------------------------------------------------------------------------------------  
 ---------------------------------------------------------------------------------------------  
 -- HostedInPast  
 IF (@HostedInPast >=0 and @HostedInPast < 3)    
 BEGIN  
  SET @strCondition = @strCondition +' AND TPD.HostedInPast=' + Cast(@HostedInPast as varchar)  
 END   
 ---------------------------------------------------------------------------------------------  
  
 ---------------------------------------------------------------------------------------------  
 -- Assigned To  
 IF (@assignedTo >0 AND @assignedTo is not null)    
 BEGIN  
  SET @strCondition = @strCondition +' AND P.OrgRoleUserId=' + Cast(@assignedTo as varchar)  
 END   
 ---------------------------------------------------------------------------------------------  
  
 -- set condition to query  
 set @strquery = @strquery + ' ' + @strJoin + ' ' + @strCondition  
 set @strquery1 = @strquery1 + ' ' + @strJoin + ' ' + @strCondition  
 ---------------------------------------------------------------------------------------------   
 -- Close View Bracket  
 set @strquery = @strquery + ' ) DEV Where 1=1'  
   
 set @strquery = @strquery + ' And Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar)  
   
 -- Sort column   
 IF(len(@SortColumn) > 0)  
 BEGIN  
   IF (@SortColumn='ContactName')   
   SET @SortColumn='ContactFirstName ' + @SortOrder + ', ' + 'ContactLastName '  
   set @strquery = @strquery + ' ORDER BY ' + @SortColumn   
     
 END  
 -- Sort Order  
 IF(len(@SortOrder) > 0)  
 BEGIN  
   set @strquery = @strquery +  ' ' + @SortOrder  
 END   
   
 Execute(@strquery +  ' ' + @strquery1)  
 --print   (@strquery)  
 --PRINT(@strquery1)  
   
END  
           
ELSE IF (@mode=1)--Salesrep (Prospect)  
BEGIN             
      
  ------ Main Query ----------------------------------------------------------------------------------------------  
 SET @strquery='select *from (select ROW_NUMBER() OVER (ORDER BY DateModified DESC) AS Row,*from (Select *FROM Dv_Prospects WHERE 1=1 '   
  -------- Secondary Query ----------------------------------------------------------------------------------------------  
  SET @strquery1='select count(prospectid) as TotalRecord from (select ROW_NUMBER() OVER (ORDER BY DateModified DESC) AS Row,*from (Select *FROM Dv_Prospects WHERE 1=1 '  
  
 --------search condition-------------------------------------------------------------------------------------  
 if((@TerritoryID is not null) and @TerritoryID>0)  
 BEGIN  
  SET @strCondition =@strCondition  + ' AND ProspectZip in   
  (   
   SELECT TZ.ZipCode  
   FROM dbo.TblTerritory TT  
   INNER JOIN  dbo.TblTerritoryZip TTZM ON TT.TerritoryID = TTZM.TerritoryID  
   INNER JOIN dbo.TblZip TZ ON TZ.ZipID=TTZM.ZipID  
   WHERE TTZM.TerritoryID IN(' + CAST (@TerritoryID AS VARCHAR)+ ')  
  ) '  
 END  
   
 -------------------------------------------------------------------------------------------------------------  
 IF(@ProspectName<>'')  
 BEGIN            
  SET @strCondition=@strCondition+' AND ProspectName LIKE '+''''+'%'+ @ProspectName +'%'+''''            
 END            
 IF((@StartDate<>'')AND (@EndDate<>''))            
 BEGIN            
  SET @strCondition=@strCondition +   
  ' AND convert(datetime,convert(VARCHAR(10),ProspectCreatedDate,101),101) >=   
  Convert(DateTime,'+''''+@StartDate+''''+',101)             
  AND convert(datetime,convert(VARCHAR(10),ProspectCreatedDate,101),101) <=  
  Convert(DateTime,'+''''+@EndDate+''''+',101)'  
 END      
  
 -- Filter prospect on salesRep territory  
 IF(@UserID IS NOT NULL  AND @UserID>0)            
 BEGIN            
  --SET @strCondition=@strCondition+' AND RoleID=7 AND UserID='+CAST (@UserID  AS VARCHAR)  
  select @roleid=roleid from TblRole where alias='SalesRep'  
  
  IF EXISTS  
  (  
   SELECT TT.TerritoryID FROM dbo.TblTerritory TT  
   INNER JOIN [TblOrganizationRoleUserTerritory] TORUT ON TORUT.TerritoryID=TT.TerritoryID  
   INNER JOIN [TblOrganizationRoleUser] TORU ON TORU.OrganizationRoleUserID= TORUT.OrganizationRoleUserID  
   where userid=CAST (@UserID  AS VARCHAR) and roleid=@roleid  
  )  
  BEGIN  
    SET @TerritotyCondition = @TerritotyCondition +  
    ' AND ProspectZip IN ( select distinct TZ.ZipCode from TblOrganizationRoleuser TOR   
    inner join TblOrganizationRoleUserTerritory TORUT on TORUT.OrganizationRoleUserID=TOR.OrganizationRoleUserID  
    inner join TblTerritoryZip TTZ on TTZ.TerritoryID=TORUT.TerritoryID  
    inner join TblZip TZ on TZ.ZipId=TTZ.ZipID  
    where TOR.userid=' + +CAST (@UserID  AS VARCHAR) + ' and TOR.roleid=7) '   
     
  END  
 END  
  
 IF(@franchiseeID > 0 AND @UserID < 0)        
 BEGIN            
  SET @strCondition=@strCondition+' AND RoleID=7 AND OrganizationId='+CAST (@franchiseeID  AS VARCHAR)              
 END  
  
 IF(@StatusId<>0)            
 BEGIN            
  SET @strCondition=@strCondition+' AND ProspectStatus ='+CAST (@StatusId  AS VARCHAR)            
 END       
 IF(@TypeId<>0)            
 BEGIN            
  SET @strCondition=@strCondition+' AND ProspectTypeId ='+CAST (@TypeId  AS VARCHAR)             
 END            
 ---------------Begin case added for filter record based on zipcode and distance          
 IF (@zipcode!='' AND @zipcode > 0 and @distance<>0)          
 BEGIN          
  if (@distance=1)  
  BEGIN  
   SET @strCondition=@strCondition+ ' AND ProspectZip = ''' + @zipcode  + ''''  
  END  
  ELSE  
  BEGIN    
   SET @strCondition=@strCondition+ ' AND ProspectZip in ( SELECT DISTINCT zipcode FROM TblZip  
             WHERE zipid IN ('          
   SET @strCondition=@strCondition+ ' (select zipid from dbo.fn_getzips(''' + @zipcode + ''',' + CAST (@distance  AS VARCHAR) + '))))'  
  END  
 END          
 ---------------END case added for filter record based on zipcode and distance          
 -- Is Feeder     
 IF (@AssignedStatus > 0 and @AssignedStatus<=2)    
 BEGIN    
 SET @strCondition=@strCondition+' AND AssignedStatus='+CAST (@AssignedStatus AS VARCHAR)   
 END  
 ----------------------------------------------------------------------------------------------  
 ---------------------------------------------------------------------------------------------  
 -- Will Promote  
 IF (@WillPromote >=0 AND @WillPromote < 3)    
 BEGIN  
  SET @strCondition = @strCondition +' AND WillPromote=' + Cast(@WillPromote as varchar)  
 END   
 ---------------------------------------------------------------------------------------------  
 ---------------------------------------------------------------------------------------------  
 -- Will Host  
 IF (@WillHost >=0 AND @WillHost < 3)     
 BEGIN  
  SET @strCondition = @strCondition +' AND WillHost=' + Cast(@WillHost as varchar)  
 END   
 ---------------------------------------------------------------------------------------------  
 ---------------------------------------------------------------------------------------------  
 -- HostedInPast  
 IF (@HostedInPast >=0 AND @HostedInPast < 3)    
 BEGIN  
  SET @strCondition = @strCondition +' AND HostedInPast=' + Cast(@HostedInPast as varchar)  
 END   
 ---------------------------------------------------------------------------------------------  
   
 ---------------------------------------------------------------------------------------------   
 -- Assigned To  
 IF (@assignedTo >0 AND @assignedTo is not null)    
 BEGIN  
  SET @strCondition = @strCondition +' AND OrgRoleUserId=' + Cast(@assignedTo as varchar)  
 END   
 ---------------------------------------------------------------------------------------------  
  
 ---------------------------------------------------------------------------------------------  
 SET @TerritotyConditionZipCodeNull =' Union Select *FROM Dv_Prospects where ProspectZip=0 '  
   
 -- combind query  
 IF (@TerritotyCondition != '' and len(@TerritotyCondition)>0)  
 BEGIN  
  set @strquery = @strquery + @TerritotyCondition  
  set @strquery1 = @strquery1 + @TerritotyCondition  
 END  
 set @strquery = @strquery + @TerritotyConditionZipCodeNull  
 set @strquery = @strquery + ' ) Dev where 1=1 '  
 set @strquery = @strquery + @strCondition  
  
 set @strquery1 = @strquery1 + @TerritotyConditionZipCodeNull  
 set @strquery1 = @strquery1 + ' ) Dev where 1=1 '  
 set @strquery1 = @strquery1 + @strCondition  
   
   
   
  
-- --set @strquery1 = @strquery1 + ' ' + @strCondition1 + ' '   
-- set @strquery1 = @strquery1 + ' ) Dev WHERE 1=1 ' + @TerritotyCondition + @TerritotyConditionZipCodeNull  
-- set @strquery1 = @strquery1 + @strCondition  
 ---------------------------------------------------------------------------------------------   
 -- Close View Bracket  
 --set @strquery1 = @strquery1 + ' ) Dev1  '  
   
 set @strquery = @strquery + ' )Dev Where Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar)  
 set @strquery1 = @strquery1 + ' )Dev Where 1=1 '  
   
 -- Sort column   
 IF(len(@SortColumn) > 0)  
 BEGIN  
   IF (@SortColumn='ContactName')   
   SET @SortColumn='ContactFirstName ' + @SortOrder + ', ' + 'ContactLastName '  
   set @strquery = @strquery + ' ORDER BY ' + @SortColumn      
 END  
 -- Sort Order  
 IF(len(@SortOrder) > 0)  
 BEGIN  
   set @strquery = @strquery +  ' ' + @SortOrder  
 END   
   
 Execute(@strquery +  ' ' + @strquery1)  
 print   (@strquery)  
 PRINT(@strquery1)       
   
END            
--- Case Host search (SalesRep)    
ELSE IF (@mode=2)    
BEGIN    
 ------ Main Query ----------------------------------------------------------------------------------------------  
 SET @strquery=  
 '  
       SELECT *FROM (  
       SELECT   
       ROW_NUMBER() OVER (ORDER BY P.DateModified DESC) AS Row,  
       P.ProspectID "ProspectId",  
       P.OrgRoleUserId as SalesRepId,  
       P.OrganizationName "ProspectName",  
       P.DateCreated "ProspectCreatedDate",  
       P.PhoneOffice "PhoneOffice",  
       P.DateModified,  
       ISNULL(TA.AddressId,0) "ProspectAddressId",            
       TA.Address1 "ProspectAddress1",  
       TA.Address2 "ProspectAddress2",  
       TC.[Name] "ProspectCity",TS.[Name] "ProspectState",            
       TZ.ZipCode "ProspectZip",  
       TCC.Name "ProspectCountry",   
       P.Status "ProspectStatus",            
       Contacts.FirstName ContactFirstName,  
       Contacts.LastName "ContactLastName",  
       Contacts.PhoneOffice "ContactPhone",  
       IsNull(Contacts.Email, Contacts.EmailOffice) "ContactEmail",  
       CASE  WHEN TCCS.Status IS NULL then'+ ''''+'N/A'+''''+'  ELSE TCCS.Status End as "ContactCallStatus",  
       convert(varchar(20),TCC1.StartDate,101) as "ContactCallDate",  
       TCC12.NoOFCalls NoOFCalls,  
       (select Count(contactid)  from TblProspectContact where ProspectID=P.ProspectID and IsActive=1) as NoOfContacts,       
       TCM.NoOfMeetings as NoOFMeeting,    
       U.FirstName "SalesPersonFirstName",U.LastName "SalesPersonLastName",  
       TCC1.Duration,  
       TCC1.Notes,  
       o.Name "FranchiseeName",     
       1 AssignedStatus  '  
 
 print (@strquery)

 -------- Secondary Query ----------------------------------------------------------------------------------------------  
 SET @strquery1='SELECT COUNT(P.ProspectID) AS TotalRecord'  
 
 
-- LEFT OUTER JOIN ( SELECT * FROM TblProspectContact  WHERE IsActive=1 AND  
-- ProspectContactId in  
-- (  
-- SELECT ProspectContactID FROM DvProspectContact  
-- )  
-- )  AS PC ON PC.ProspectID =P.ProspectID             
 --LEFT JOIN TblContacts C ON C.ContactID=PC.ContactID  and C.IsActive = 1  
 
 
 ------ Join Tables --------------------------------------------------------------------------------------------------  
 SET @strJoin=  
 '  
       from tblprospects P            
       LEFT OUTER JOIN TblAddress TA ON P.AddressID =TA.AddressID      
       LEFT OUTER JOIN TblCity TC ON TC.CityID=TA.CityID    
       LEFT OUTER JOIN dbo.TblState TS ON TS.StateID=TA.StateID    
       LEFT OUTER JOIN TblZip TZ ON TZ.ZipID=TA.ZipID  
       LEFT OUTER JOIN TblCountry TCC ON TCC.CountryID=TA.CountryID    
       
      LEFT OUTER JOIN  
   (  
     SELECT PhoneHome,PhoneCell,PhoneOffice,EMail,ContactID,ProspectID AS ProspectID,  
     FirstName,MiddleName,LastName,EmailOffice  
     FROM   
     (  
      SELECT PhoneHome,PhoneCell,PhoneOffice,EMail,TPC.[ProspectID],TC.ContactID, TC.EmailOffice,
      TPC.[ProspectContactID]  
      ,TC.[FirstName],TC.[MiddleName],[LastName]   
      ,ROW_NUMBER() OVER(PARTITION BY TPC.[ProspectID] ORDER BY TPCRM.ProspectContactRoleId) AS Row  
      FROM [TblProspectContact] TPC  
      INNER JOIN [TblContacts] TC ON TPC.[ContactID] = TC.[ContactID]  
      LEFT OUTER JOIN [TblProspectContactRoleMapping] TPCRM ON TPC.[ProspectContactID] = TPCRM.[ProspectContactID] and TPCRM.IsActive=1  
     ) tblTemp WHERE Row=1  
 )Contacts ON Contacts.[ProspectID]=P.[ProspectID]  
  

      LEFT OUTER JOIN ( SELECT *FROM DvProspectCalls) TCC12 on TCC12.ProspectID=P.ProspectID   
      LEFT OUTER JOIN TblContactCall TCC1 on TCC1.ContactCallID=TCC12.CallID and TCC1.IsActive = 1  
      LEFT OUTER JOIN TblContactCallStatus TCCS on TCCS.ContactCallStatusID=TCC1.ContactCallStatusID   
      LEFT OUTER JOIN (SELECT *FROM DvProspectMeetings) TCM on TCM.ProspectID=P.ProspectID  
      LEFT OUTER JOIN TblContactMeeting TCM1 on TCM1.ContactMeetingID=TCM.MeetingID and TCM1.IsActive = 1  

      LEFT OUTER JOIN TblOrganizationRoleUser ORU ON ORU.[OrganizationRoleUserId]=P.[OrgRoleUserId]  
      LEFT OUTER JOIN TblUSER U ON U.UserID=ORU.UserID  
      LEFT OUTER JOIN TblOrganization O ON O.OrganizationId=ORU.OrganizationId'  


 ------ Conditions --------------------------------------------------------------------------------------------------  
 if((@TerritoryID is not null) and @TerritoryID>0)  
 BEGIN  
  SET @strCondition=@strCondition+ ' inner join   
  (SELECT TTZM.TerritoryID,TTZM.ZipID  
  FROM dbo.TblTerritory TT  
  INNER JOIN  dbo.TblTerritoryZip TTZM ON TT.TerritoryID = TTZM.TerritoryID  
  WHERE TTZM.TerritoryID IN(' + CAST (@TerritoryID AS VARCHAR)+ ')  
  )vwTerritory on vwTerritory.ZipID=TZ.ZipID '  
 END  
   
 SET @strCondition= @strCondition + ' WHERE  P.IsActive=1 AND p.IsHost=' + CAST (@IsHost  AS VARCHAR)              
  
 IF(@ProspectName<>'')            
 BEGIN            
      SET @strCondition= @strCondition + ' AND P.OrganizationName LIKE '+''''+'%'+ @ProspectName +'%'+''''        
 END            
 
 
 IF((@StartDate<>'')AND (@EndDate<>''))            
 BEGIN            
  SET @strCondition = @strCondition+  
  ' AND convert(datetime,convert(VARCHAR(10),P.DateCreated,101),101) >=   
  Convert(DateTime,'+''''+@StartDate+''''+',101)             
  AND convert(datetime,convert(VARCHAR(10),P.DateCreated,101),101)  
  <=Convert(DateTime,'+''''+@EndDate+''''+',101)'  
 END

 
 
 -- Filter host based on salesRep territory  
IF(@UserID IS NOT NULL  AND @UserID>0 AND @role='SalesRep')            
BEGIN         
      PRINT '1'   
      IF EXISTS  
      (             
            SELECT TT.TerritoryID FROM dbo.TblTerritory TT  
            INNER JOIN [TblOrganizationRoleUserTerritory] TORUT ON TORUT.TerritoryID=TT.TerritoryID  
            INNER JOIN [TblOrganizationRoleUser] TORU ON TORU.OrganizationRoleUserID= TORUT.OrganizationRoleUserID  
            where userid=@UserID and roleid=@roleid  
      )  
      BEGIN  
            SET @strCondition = @strCondition +  
                  ' AND TZ.ZipCode IN ( select distinct TZ.ZipCode from TblOrganizationRoleuser TOR   
                        inner join TblOrganizationRoleUserTerritory TORUT on TORUT.OrganizationRoleUserID=TOR.OrganizationRoleUserID  
                        inner join TblTerritoryZip TTZ on TTZ.TerritoryID=TORUT.TerritoryID  
                        inner join TblZip TZ on TZ.ZipId=TTZ.ZipID  
                        where TOR.userid=' + CAST (@UserID  AS VARCHAR) + ' and TOR.roleid=7) '   
     
      END  
END  
ELSE IF (@UserID IS NOT NULL  AND @UserID>0 AND (@role='FranchisorAdmin' or @role='FranchiseeAdmin'))  
BEGIN       
   Select @SalesRepId=OrganizationRoleUserId from [TblOrganizationRoleUser] where UserId=@UserID and RoleId=@roleid  
   SET @strCondition = @strCondition +' AND P.OrgRoleUserId=' + Cast(@SalesRepId as varchar)  
END  

  
IF(@franchiseeID>0)           
BEGIN            
      SET @strCondition = @strCondition + ' AND (P.OrgRoleUserId IS NULL OR (RoleID=7 AND O.OrganizationId='+CAST (@franchiseeID  AS VARCHAR) + '))'        
END  
  
IF(@StatusId<>0)            
BEGIN            
      SET @strCondition=@strCondition +' AND P.Status ='+CAST (@StatusId  AS VARCHAR)  
END 
           
IF(@TypeId<>0 and @TypeId=1)            
BEGIN              
      SET @strCondition = @strCondition +' AND P.ProspectId IN ' + '(select hostid from TblHostEventDetails)'  
END    
ELSE IF(@TypeId<>0 and @TypeId=2)            
BEGIN              
      SET @strCondition = @strCondition + ' AND P.ProspectId not IN ' + '(select hostid from TblHostEventDetails)'    
END    


---------------Begin case added for filter record based on zipcode and distance          
IF (@zipcode!='' and @distance<>0)          
BEGIN          
      if (@distance=1)  
      BEGIN  
            SET @strCondition=@strCondition+ ' AND TZ.ZipCode = ''' + @zipcode  + ''''
      END  
      ELSE  
      BEGIN  
            SET @strCondition = @strCondition + ' AND TZ.ZipID in '          
            SET @strCondition = @strCondition + ' (select zipid from dbo.fn_getzips(''' + @zipcode + ''',' + CAST (@distance  AS VARCHAR) + '))'          
      END  
END          
---------------END case added for filter record based on zipcode and distance          
   
---------------------------------------------------------------------------------------------   
-- Assigned To  
IF (@assignedTo >0 AND @assignedTo is not null AND @role='SalesRep')    
BEGIN  
      SET @strCondition = @strCondition +' AND P.OrgRoleUserId=' + Cast(@assignedTo as varchar)  
END   
---------------------------------------------------------------------------------------------  
  
 ---------------------------------------------------------------------------------------------  
 PRINT (@strJoin + @strCondition)
-- set condition,join to query  
 set @strquery = @strquery + ' ' + @strJoin + ' ' + @strCondition  
 set @strquery1 = @strquery1 + ' ' + @strJoin + ' ' + @strCondition  
 ---------------------------------------------------------------------------------------------   
 -- Close View Bracket  
 set @strquery = @strquery + ' ) DEV '  
   
 set @strquery = @strquery + ' Where Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar)  
   
 -- Sort column   
 IF(len(@SortColumn) > 0)  
 BEGIN  
   IF (@SortColumn='ContactName')   
   SET @SortColumn='ContactFirstName ' + @SortOrder + ', ' + 'ContactLastName '  
   set @strquery = @strquery + ' ORDER BY ' + @SortColumn      
 END  
 -- Sort Order  
 IF(len(@SortOrder) > 0)  
 BEGIN  
   set @strquery = @strquery +  ' ' + @SortOrder  
 END  
 
 --print   (@strquery)
--PRINT(@strquery1)   
 Execute(@strquery +  ' ' + @strquery1)  
   
END          
END 
