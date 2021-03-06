
USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotificationViewGet]    Script Date: 08/14/2014 14:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------------------------------      
-- Author  : Viranjay Singh        
-- Create date : 19-11-2008        
-- Description : Get Notification View    
-- Name   : usp_NotificationViewGet    
-- Example  : -- exec usp_NotificationViewGet 180    
--==========================================
ALTER PROCEDURE [dbo].[usp_NotificationViewGet]    
(    
 @NotificationID bigint    
)    
AS        
BEGIN      
      
  select TN.NotificationID, TU.UserID,     
  TU.FirstName + ' ' + isnull(TU.MiddleName,'') + '  ' + TU.LastName as [Name],    
  TU.Email1 as Email,    
  TC.CustomerID,    
  isnull(TC.Gender,'') as Gender,    
  Convert(varchar(20),TU.DOB,101) as DOB,      
  TU.Picture,    
  TUL.Username,    
  --(select Address1 + ' ' + Address2 from TblAddress  where AddressID=(select HomeAddressID from tbluser where userid=TN.userid)) as Address,    
  (    
   SELECT isnull(Address1,'') + ' ' + isnull(Address2,'') + ' '  +  isnull(TC.[Name],'') + ' '     
   + isnull(TS.[Name],'') + '-' + TZ.ZipCode  as Address    
   from TblAddress TA       
   inner join tblCity TC on TA.CityID=TC.CityID      
   inner join TblZip TZ on TZ.ZipID = TA.ZipID      
   inner join tblState TS on TA.StateID= TS.StateID      
   inner join tblCountry TCO on TA.CountryID=TCO.CountryID     
   where TA.AddressID=(select HomeAddressID from tbluser where userid=TN.userid)    
  )as Address,    
  case TU.PhoneCell when null then TU.PhoneOffice when '' then TU.PhoneOffice else TU.PhoneCell end as Phone,    
  Convert(varchar(12),TC.DateCreated,101) as SignupDate,    
  Convert(varchar(12),TUL.LastLogged,101) as LastLoginDate,    
  --TN.NotificationDate,    
  Convert(varchar(20),TN.NotificationDate,101) + '@' +    
  substring(Convert(varchar(20),TN.NotificationDate,100),len(Convert(varchar(20),TN.NotificationDate,100))-7,10) as NotificationDate,    
    
  NT.NotificationTypeName,     
  NM.NotificationMedium,    
 case when TN.RequestedByOrgRoleUserId=0 then 'System' 
 when TORU.userId=TN.UserID then 'System'
  else     
  (select FirstName +  ' ' + isnull(MiddleName,' ') + ' ' + LastName from tbluser where userid=TORU.userId)     
  end as [ServicedBy], 
 case when tn.NotificationMediumID=3 then nt.NotificationTypeName else
  TNE.Subject end as [Subject],
  case when tn.NotificationMediumID=3 then tnp.Message
  else  
  TNE.Body   
  end as [Body] 
  From Tbluser TU     
  inner join TblNotification TN on TU.UserId=TN.UserID 
  inner join TblOrganizationRoleUser TORU on TN.RequestedByOrgRoleUserId = TORU.OrganizationRoleUserId    
  inner join TblUserLogin TUL on TN.UserId=TUL.UserLoginId    
  inner join vw_Customers TC on TC.UserId=TN.UserID     
  inner join TblNotificationType NT on NT.NotificationTypeID=TN.NotificationTypeId     
  inner join TblNotificationMedium NM on NM.NotificationMediumID=TN.NotificationMediumID    
  left outer join TblNotificationEmail TNE on TNE.EmailNotificationId=TN.NotificationID   
  left outer join TblNotificationPhone tnp on tnp.PhoneNotificationID=tn.NotificationID 
  where     
  TN.NotificationID=@NotificationID    
END