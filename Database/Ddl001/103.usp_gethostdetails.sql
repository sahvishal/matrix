USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_gethostdetails]    Script Date: 12/17/2012 20:17:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================  
-- Author:  Sharad  
-- Create date: 17-12-2007  
-- Description: To get the items of table TbProspectDetails  
-- Name: usp_getprospectdetails  
-- Parameter: Input (mode "0->All rows,1->Rows by ProspectListID,3->All inactive rows, 4->filter by TblProspectUserAccessDetails.UserID",name,dbid)  
-- Changed By Viranjay to accomodate new UI Feature  
--==========================================================================================  
ALTER PROCEDURE [dbo].[usp_gethostdetails]  
(   
 @mode tinyint,   
 @filterstring varchar(500)  
)   
AS
BEGIN   
 IF (@mode = 1)  
 BEGIN 
  Declare @SalesRepId BIGINT
  Declare @SalesRep varchar(255)
  Declare @EventName varchar(255)
  Declare @EventDate varchar(255)
  ---------- Get SalesRep
  set @SalesRep=''
  select @SalesRepId=OrgRoleUserId from TblProspects where ProspectId=@filterstring
  IF (@SalesRepID > 0)
  BEGIN
	select @SalesRep =case when len(TU.MiddleName) > 0 then TU.FirstName + ' ' + TU.MiddleName + ' ' + TU.LastName else TU.FirstName + ' ' + TU.LastName end
	from TblOrganizationRoleUser TORU 
	inner join TblUser TU on TU.UserId = TORU.UserId
	where TORU.OrganizationRoleUserId=@SalesRepId
  END
--  -- Get EventName,EventDate
--  SELECT @EventName=EventName,@EventDate=EventDate from TblEvents TE
--  INNER JOIN TblHostEventDetails THD ON THD.EventId=TE.EventId
--  Where THD.HostId=@filterstring

  SELECT    
  TblProspects.ProspectID,  
  TblProspects.EMailID,   
  TblProspects.PhoneOffice,   
  TblProspects.PhoneCell,   
  TblProspects.PhoneOther,  
  TblProspects.WebSite,   
  TblProspects.OrganizationName,   
  TblProspects.Notes,   
  TblProspects.AddressID,  
  TblProspects.ProspectTypeID,  
  TblProspects.ActualMembership,  
  TblProspects.ActualAttendance,  
  TblProspects.MethodObtainedID,  
  TblProspects.WillPromote,  
  TblProspects.ReasonWillPromote,  
  TblProspects.IsHost,  
  TblProspects.FUDate,  
  TblProspects.IsActive,  
  TblProspects.Status,  
  ISNULL(THD.EventName,'') AS EventName,  
  ISNULL(THD.EventDate,'') AS EventDate,  
  TblProspectType.[Name] ProspectType,--  
  isnull(TPD.ProspectDetailsID,'') ProspectDetailsID,    
  isnull(TPD.FacilitiesFee,'') FacilitiesFee,    
  isnull(TPD.PaymentMethod,'') PaymentMethod,    
  isnull(TPD.DepositsRequire,'') DepositsRequire,     
  TPD.DepositsAmount,    
  isnull(TPD.ViableHostSite,'') ViableHostSite,    
  isnull(TPD.HostedInPast,'') HostedInPast,    
  isnull(TPD.HostedInPastWith,'')HostedInPastWith,    
  isnull(TPD.WillHost,'') WillHost,  
  TPD.ReasonViableHostSite,    
  TPD.ReasonHostedInPast,    
  TPD.ReasonWillHost,TPD.ReasonWillHost,isnull(TblProspects.TaxIdNumber,'') TaxIdNumber,  
  isnull(@SalesRep,'') [SalesRep],
  isnull(TblProspects.Fax,'') Fax
  FROM  TblProspects  
  INNER JOIN dbo.TblProspectType ON dbo.TblProspectType.ProspectTypeID=dbo.TblProspects.ProspectTypeID  
  LEFT OUTER JOIN TblProspectDetails TPD on TblProspects.Prospectid=TPD.prospectid    
  LEFT OUTER JOIN  
   (  
    SELECT ProspectID,EventName,TE1.EventDate  
    FROM dbo.TblProspects TP1  
    INNER JOIN dbo.TblHostEventDetails THED1 ON THED1.HostID = TP1.ProspectID  
    INNER JOIN dbo.TblEvents TE1 ON TE1.EventID=THED1.EventID   
    where   
    (  
     convert(varchar, TP1.ProspectID) + '-' + convert(varchar, TE1.EventDate)  
    )  
    in   
    (  
     Select convert(varchar, THED1.HostID) + '-' + convert(varchar, max(TEE1.EventDate))   
     from TblHostEventDetails THD1  
     inner join TblEvents TEE1 on THD1.EventID = TEE1.EventID   
     group by THD1.HostID  
    )  
   )THD ON THD.ProspectID=TblProspects.ProspectID  
  where TblProspects.ProspectID=@filterstring AND TblProspects.IsActive=1  
  order by TblProspects.DateModified desc  
    
  -- Get AddressId as well as MailingAddressID  
  declare @AddressID bigint  
  declare @AddressIDMailing bigint  
  set @AddressID=(select AddressID from tblProspects where prospectid=@filterstring)  
  set @AddressIDMailing=(select AddressIDMailling from tblProspects where prospectid=@filterstring)  
    
  Select   
  tblAddress.AddressID,  
  tblAddress.Address1,  
  tblAddress.Address2,  
  tblAddress.ZIPID,  
  tblZip.Zipcode,  
  '' as PhoneNumber,  
  tblCity.Name CityName,  
  tblCity.CityID,  
  tblState.Name StateName,  
  tblState.StateID,  
  tblCountry.Name CountryName,  
  TblCountry.CountryID,  
  '' as Fax,
  ISNULL(case when len(TU.middlename) > 0 then TU.FirstName + ' ' + TU.MiddleName + ' ' + TU.LastName
  else TU.FirstName + ' ' + TU.LastName END,'') as [AddressVerifiedBy]    
  from tblAddress  
  inner join tblCity on tblCity.CityID = tblAddress.CityID  
  inner join TblZip on TblZip.ZipID = TblAddress.ZipID  
  inner join tblState on tblState.StateID = tblAddress.StateID  
  inner join tblCountry on tblCountry.CountryID = tblAddress.CountryID
  LEFT OUTER JOIN TblOrganizationRoleUser TORU ON TORU.OrganizationRoleUserID=tblAddress.VerificationOrgRoleUserId
  LEFT OUTER JOIN TblUser TU ON TU.UserID = TORU.UserID
  where tblAddress.AddressID In (@AddressID,@AddressIDMailing)  
    
  SELECT     
  ProspectID,    
  TC.ContactID,    
  isnull(Salutation,'') as Salutation,    
  isnull(FirstName,'') as FirstName,    
  isnull(MiddleName,'') as MiddleName,    
  isnull(LastName,'') as LastName,    
  isnull(EMail,'') as EMail,
  isnull(EMailOffice,'') as EMailOffice,    
  isnull(PhoneHome,'') as PhoneHome,    
  isnull(PhoneOffice,'') as PhoneOffice, 
  isnull(PhoneCell,'') as PhoneCell,    
  isnull(PhoneOfficeExtension,'') as PhoneOfficeExtension,    
  isnull(Fax,'') as Fax,    
  isnull(Title,'') as Title,    
  isnull(Address1,'') as Address1,    
  isnull(Address2,'')as Address2,     
  isnull(City,'') as City,    
  isnull(State,'') as State,    
  isnull(TC.ZipCode,'') as ZipCode,    
  isnull(TC.ZipCode,'') as ZipCode,    
  isnull(TCN.Notes,'') as Notes,
  isnull(TC.Gender,1) as Gender    
  FROM dbo.TblProspectContact TPC        
  INNER JOIN dbo.TblContacts TC ON TPC.ContactID=TC.ContactID    
  LeFT OUTER JOIN TblContactNotes TCN on TCN.ContactID=TC.ContactID    
  WHERE TPC.ProspectID=@filterstring  and TPC.IsActive = 1  
  
 Select TPC.ContactID, TPCR.ProspectContactRoleID, TPCR.ProspectContactRoleName from TblProspectContact TPC inner join TblProspectContactRoleMapping TPCRM  
 on TPCRM.ProspectContactID = TPC.ProspectContactID  
 inner join TblProspectContactRole TPCR on TPCRM.ProspectContactRoleID = TPCR.ProspectContactRoleID  
    WHERE TPC.ProspectID=@filterstring and TPC.IsActive = 1 and TPCRM.IsActive = 1  
  
 END  
END  
RETURN
