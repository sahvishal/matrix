USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_getprospectdetails]    Script Date: 12/17/2012 20:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------------------------------------
-- =============================================  
-- Author:  Sharad
-- Create date: 17-12-2007  
-- Description: To get the items of table TbProspectDetails  
-- Name: usp_getprospectdetails  
-- Parameter: Input (mode "0->All rows,1->Rows by ProspectListID,3->All inactive rows, 4->filter by TblProspectUserAccessDetails.UserID",name,dbid)  
--exec usp_getprospectdetails @filterString='87',@mode=5
--=============================================  
ALTER PROCEDURE [dbo].[usp_getprospectdetails]
( 
	@mode tinyint, 
	@filterstring varchar(500)
)   
AS
DECLARE @ProspectId VARCHAR(500)
BEGIN   
	IF(@mode = 1)  
	BEGIN  
		SELECT ProspectID,  EMailID, PhoneOffice, PhoneCell, PhoneOther, WebSite, OrganizationName,   
               Notes, AddressID, DateCreated, DateModified,isnull(TblProspects.Fax,'') Fax 
		FROM TblProspects  
		where ProspectID = @filterstring   
	END  
  
	ELSE IF(@mode = 2)  
	BEGIN  
		select  
		TblProspects.ProspectID,  
		TblProspects.EMailID,   
		TblProspects.PhoneOffice,   
		TblProspects.PhoneCell,   
		TblProspects.PhoneOther,  
		TblProspects.WebSite,   
		TblProspects.OrganizationName,   
		TblProspects.Notes,   
		TblProspects.ProspectTypeID,  
		TblProspects.ActualMembership,  
		TblProspects.ActualAttendance,  
		TblProspects.MethodObtainedID,  
		TblProspects.WillPromote,  
		TblProspects.IsHost,  
		TblProspects.FUDate,  
		TblProspects.IsActive,  
		TblProspects.Status,
		isnull(TblProspects.Fax,'') Fax   
		FROM  TblProspects where TblProspects.IsHost = 0 AND TblProspects.IsActive=1  
		order by TblProspects.DateModified desc  
  
		Select   
		tblProspectAddress.ProspectAddressID,  
		tblProspectAddress.ProspectID,  
		tblProspectAddress.Address1,  
		tblProspectAddress.ZIP,  
		tblProspectAddress.City CityName,  
		tblProspectAddress.State StateName,  
		tblProspectAddress.Country CountryName,
		isnull(tblProspectAddress.Fax,'') as Fax  
		from tblProspectAddress
		 
	END
	ELSE IF	(@mode = 3)  
	BEGIN  
  Set @filterstring= '%'+@filterstring+'%'  
		SELECT    
		TblProspects.ProspectID,  
		TblProspects.EMailID,   
		TblProspects.PhoneOffice,   
		TblProspects.PhoneCell,   
		TblProspects.PhoneOther,  
		TblProspects.WebSite,   
		TblProspects.OrganizationName,   
		TblProspects.Notes,   
		TblProspects.ProspectTypeID,  
		TblProspects.ActualMembership,  
		TblProspects.ActualAttendance,  
		TblProspects.MethodObtainedID,  
		TblProspects.WillPromote,  
		TblProspects.IsHost,  
		TblProspects.FUDate,  
		TblProspects.IsActive,  
		TblProspects.Status,
		isnull(TblProspects.Fax,'') Fax  
		FROM  TblProspects where TblProspects.OrganizationName like @filterstring AND TblProspects.IsHost=0 AND TblProspects.IsActive=1  
		order by TblProspects.DateModified desc  

		Select   
		tblProspectAddress.ProspectAddressID,  
		tblProspectAddress.ProspectID,  
		tblProspectAddress.Address1,  
		tblProspectAddress.ZIP,  
		tblProspectAddress.City CityName,  
		tblProspectAddress.State StateName,  
		tblProspectAddress.Country CountryName,
		isnull(tblProspectAddress.Fax,'') as Fax
		from tblProspectAddress 
END  
 Else if(@mode = 4)  
 BEGIN  
		Declare @SalesRepId BIGINT
		Declare @SalesRep varchar(255)
		set @SalesRep=''
		select @SalesRepId=OrgRoleUserId from TblProspects where ProspectId=@filterstring
		IF (@SalesRepID > 0)
		BEGIN
			select @SalesRep =case when len(TU.MiddleName) > 0 then TU.FirstName + ' ' + TU.MiddleName + ' ' + TU.LastName else TU.FirstName + ' ' + TU.LastName end
			from TblOrganizationRoleUser TORU
			inner join TblUser TU on TU.UserId = TORU.UserId
			where TORU.OrganizationRoleUserId=@SalesRepId
	  END
	SELECT
	TblProspects.ProspectID,    
	TblProspects.EMailID,     
	TblProspects.PhoneOffice,     
	TblProspects.PhoneCell,     
	TblProspects.PhoneOther,    
	TblProspects.WebSite,     
	TblProspects.OrganizationName,     
	TblProspects.Notes,     
	isnull(TblProspects.ProspectTypeID,'') ProspectTypeID,
	isnull(TblProspectType.Name,'') as ProspectType,
	TblProspects.ActualMembership,    
	TblProspects.ActualAttendance,    
	TblProspects.MethodObtainedID,    
	TblProspects.WillPromote, 
	TblProspects.ReasonWillPromote,    
	TblProspects.IsHost,    
	TblProspects.FUDate,    
	TblProspects.IsActive,    
	isnull(TblProspects.Status,'') as Status,
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
	TPD.ReasonWillHost,
	isnull(@SalesRep,'') [SalesRep],
	isnull(TblProspects.Fax,'') Fax
	FROM  TblProspects 
	left outer join TblProspectDetails TPD on TblProspects.Prospectid=TPD.prospectid
	left outer join TblProspectType on TblProspectType.ProspectTypeID=TblProspects.ProspectTypeID
	where TblProspects.ProspectID=@filterstring AND TblProspects.IsActive=1    
	order by TblProspects.DateModified desc
      
	Select     
	tblProspectAddress.ProspectAddressID,    
	tblProspectAddress.ProspectID,    
	isnull(tblProspectAddress.Address1,'') as Address1,  
	isnull(tblProspectAddress.Address2,'') as Address2,    
	isnull(tblProspectAddress.ZIP,'') as ZIP,    
	isnull(tblProspectAddress.City,'') CityName,    
	isnull(tblProspectAddress.State,'') StateName,    
	isnull(tblProspectAddress.Country,'') CountryName,  
	isnull(tblProspectAddress.Fax,'') as Fax,
	tblProspectAddress.IsMailing 
	from tblProspectAddress	WHERE ProspectID=@filterstring AND isActive=1
      
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
	isnull(PhoneOfficeExtension,'') as PhoneOfficeExtension,
	isnull(PhoneCell,'') as PhoneCell,
	ISNULL(Convert(VARCHAR,DateOfBirth,101),'') AS DateOfBirth,
	isnull(Fax,'') as Fax,
	isnull(Title,'') as Title,
	isnull(Address1,'') as Address1,
	isnull(Address2,'')as Address2, 
	isnull(City,'') as City,
	isnull(State,'') as State,
	isnull(TC.ZipCode,'') as ZipCode,
	isnull(TCN.Notes,'') as Notes,
	isnull(TC.Gender,1) as Gender  
   FROM dbo.TblProspectContact TPC    
   INNER JOIN dbo.TblContacts TC ON TPC.ContactID=TC.ContactID
   LeFT OUTER JOIN TblContactNotes TCN on TCN.ContactID=TC.ContactID
   WHERE TPC.ProspectID=@filterstring AND TC.[IsActive] = 1 AND TPC.[IsActive] = 1

	Select TPC.ContactID, TPCR.ProspectContactRoleID, TPCR.ProspectContactRoleName from TblProspectContact TPC inner join TblProspectContactRoleMapping TPCRM
	on TPCRM.ProspectContactID = TPC.ProspectContactID
	inner join TblProspectContactRole TPCR on TPCRM.ProspectContactRoleID = TPCR.ProspectContactRoleID
    WHERE TPC.ProspectID=@filterstring and TPC.IsActive = 1 and TPCRM.IsActive = 1

	 
 END  
 Else if(@mode = 5)  
 BEGIN
	SELECT @ProspectId=ProspectID FROM [TblProspects] WHERE ProspectListID=@filterstring
	SELECT
	TblProspects.ProspectID,    
	TblProspects.EMailID,     
	TblProspects.PhoneOffice,     
	TblProspects.PhoneCell,     
	TblProspects.PhoneOther,    
	TblProspects.WebSite,     
	TblProspects.OrganizationName,     
	TblProspects.Notes,     
	isnull(TblProspects.ProspectTypeID,'') ProspectTypeID,
	isnull(TblProspectType.Name,'') as ProspectType,
	TblProspects.ActualMembership,    
	TblProspects.ActualAttendance,    
	TblProspects.MethodObtainedID,    
	TblProspects.WillPromote, 
	TblProspects.ReasonWillPromote,    
	TblProspects.IsHost,    
	TblProspects.FUDate,    
	TblProspects.IsActive,    
	isnull(TblProspects.Status,'') as Status,
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
	TPD.ReasonWillHost
	FROM  TblProspects 
	left outer join TblProspectDetails TPD on TblProspects.Prospectid=TPD.prospectid
	left outer join TblProspectType on TblProspectType.ProspectTypeID=TblProspects.ProspectTypeID
	where TblProspects.ProspectID=@ProspectId AND TblProspects.IsActive=1    
	order by TblProspects.DateModified desc
      
	Select     
	tblProspectAddress.ProspectAddressID,    
	tblProspectAddress.ProspectID,    
	isnull(tblProspectAddress.Address1,'') as Address1,  
	isnull(tblProspectAddress.Address2,'') as Address2,    
	isnull(tblProspectAddress.ZIP,'') as ZIP,    
	isnull(tblProspectAddress.City,'') CityName,    
	isnull(tblProspectAddress.State,'') StateName,    
	isnull(tblProspectAddress.Country,'') CountryName,  
	isnull(tblProspectAddress.Fax,'') as Fax,
	tblProspectAddress.IsMailing 
	from tblProspectAddress	WHERE ProspectID=@ProspectId AND isActive=1
      
	SELECT 
	ProspectID,
	TC.ContactID,
	isnull(Salutation,'') as Salutation,
	isnull(FirstName,'') as FirstName,
	isnull(MiddleName,'') as MiddleName,
	isnull(LastName,'') as LastName,
	isnull(EMailOffice,'') as EMailOffice,
	isnull(PhoneHome,'') as PhoneHome,
	isnull(PhoneOffice,'') as PhoneOffice,
	isnull(PhoneOfficeExtension,'') as PhoneOfficeExtension,
	isnull(PhoneCell,'') as PhoneCell,
	ISNULL(Convert(VARCHAR,DateOfBirth,101),'') AS DateOfBirth,
	isnull(Fax,'') as Fax,
	isnull(Title,'') as Title,
	isnull(Address1,'') as Address1,
	isnull(Address2,'')as Address2, 
	isnull(City,'') as City,
	isnull(State,'') as State,
	isnull(TC.ZipCode,'') as ZipCode,
	isnull(TCN.Notes,'') as Notes,
	isnull(TC.Gender,1) as Gender  
   FROM dbo.TblProspectContact TPC    
   INNER JOIN dbo.TblContacts TC ON TPC.ContactID=TC.ContactID
   LeFT OUTER JOIN TblContactNotes TCN on TCN.ContactID=TC.ContactID
   WHERE TPC.ProspectID=@ProspectId AND TC.[IsActive] = 1 AND TPC.[IsActive] = 1

	Select TPC.ContactID, TPCR.ProspectContactRoleID, TPCR.ProspectContactRoleName from TblProspectContact TPC inner join TblProspectContactRoleMapping TPCRM
	on TPCRM.ProspectContactID = TPC.ProspectContactID
	inner join TblProspectContactRole TPCR on TPCRM.ProspectContactRoleID = TPCR.ProspectContactRoleID
    WHERE TPC.ProspectID=@ProspectId and TPC.IsActive = 1 and TPCRM.IsActive = 1
 END
END
RETURN
