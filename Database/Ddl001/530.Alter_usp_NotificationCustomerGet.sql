USE [$(dbname)]
GO
/***** Object:  StoredProcedure [dbo].[usp_NotificationCustomerGet]    Script Date: 3/21/2017 5:51:11 AM *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_NotificationCustomerGet]  
(  
 @CustomerID bigint  
)  
AS
SELECT * FROM(
 select  
  TN.NotificationID,   
  TU.FirstName + ' ' + isnull(TU.MiddleName,'') + '  ' + TU.LastName as [Name],  
  NT.NotificationTypeName,  
  NM.NotificationMedium,  
  case   
  when TN.ServiceStatus=1 then 'Serviced'   
  when TN.ServiceStatus=0 and NT.NotificationTypeID=1 then 'Queued'  
  when TN.ServiceStatus=0 and NT.NotificationTypeID <>1 then 'Not Serviced'  
  when TN.ServiceStatus=2 then 'Error' end as ServiceStatus,  
  case when TN.RequestedByOrgRoleUserId=0 then 'System'   
  when TORU.UserId=TN.UserId then 'System'   
  else (select FirstName +  ' ' + isnull(MiddleName,' ') + ' ' + LastName from tbluser where userid=TORU.UserId) end as [ServicedBy],  
  isnull(cast(TN.ServicedDate as varchar(30)),'') as ServicedDate, 2 AS GroupID
  ,isnull(TN.ServicedDate,'') as ServicedDateSort
 -- ,'-N/A-' as Notes
  ,0 as [CallId]
  ,'-N/A-' AS CCRep
  ,'-N/A-' AS CallType 
  ,NULL AS CallDuration
  ,0 as [CallOutcome]
  ,'' as Disposition
  ,0 as NotInterestedReasonId
  ,'-N/A-' as Notes   
  , 0 as IsInvalidAddress
 From  
 Tbluser TU 
inner join TblNotification TN on TU.UserId=TN.UserID 
inner join TblOrganizationRoleUser TORU on TORU.OrganizationRoleUserId = TN.RequestedByOrgRoleUserId
 inner join vw_Customers TC on TC.UserId=TN.UserID   
 inner join TblNotificationType NT on NT.NotificationTypeID=TN.NotificationTypeId   
 inner join TblNotificationMedium NM on NM.NotificationMediumID=TN.NotificationMediumID  
 left outer join TblNotificationEmail on TN.NotificationId =  TblNotificationEmail.EmailNotificationId
 left outer join TblNotificationPhone on tn.NotificationID =TblNotificationPhone.PhoneNotificationID
  where TC.CustomerID=@CustomerID and  (TblNotificationEmail.ToEmail <>'JUNK765098@mailinator.com' or TblNotificationEmail.EmailNotificationID is null)
 --TODO: email not available communication
 UNION ALL
  
 select    TOP 100 PERCENT 0 AS NotificationID, 
 ISNULL(IncomingPhoneLine,'') AS [Name],
 ISNULL(CallStatus,'Not Available') AS NotificationTypeName,
 'Incoming Phone' AS NotificationMedium,
 '-N/A-' as ServiceStatus,
 ISNULL(CallersPhoneNumber,'')AS [ServicedBy],
 CAST(TblCalls.DateCreated as varchar(30))AS ServicedDate, 1 AS GroupID
 ,TblCalls.DateCreated AS ServicedDateSort
 --,ISNULL(TblCallCenterNotes.Notes,'') Notes
 ,TblCalls.CallID
 ,TblUser.FirstName + CASE WHEN LEN(ISNULL(TblUser.MiddleName,''))>0 THEN ' ' + TblUser.MiddleName + ' ' ELSE ' 'END + TblUser.LastName AS CCRep
 ,CASE WHEN dbo.TblCalls.OutBound=1 THEN 'OUTBOUND' ELSE 'INBOUND' END CallType
 ,(TimeEnd - TimeCreated) CallDuration
 ,Tblcalls.[Status] as CallOutcome
 ,ISNULL(TblCalls.Disposition,'') Disposition
 ,ISNULL(TblCalls.NotInterestedReasonId,0) NotInterestedReasonId 
 ,'-N/A-' as Notes 
 ,0 as IsInvalidAddress
FROM Tblcalls
--INNER JOIN dbo.TblCallCenterNotes ON dbo.TblCalls.CallID = dbo.TblCallCenterNotes.CallID 
--Left outer JOIN dbo.TblCallCenterNotes ON dbo.TblCalls.CallID = dbo.TblCallCenterNotes.CallID --AND dbo.TblCalls.OutBound=1
INNER JOIN TblOrganizationRoleUser TORU ON Tblcalls.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
INNER JOIN dbo.TblUser ON TORU.UserID = dbo.TblUser.UserID 
WHERE CalledCustomerID=@CustomerID and [Status] <> 325

UNION ALL

select TOP 100 PERCENT 
 0 AS NotificationID
 ,TU.FirstName + ' ' + isnull(TU.MiddleName,'') + '  ' + TU.LastName as [Name]   
 ,case when TDMT.Name is null then 'Direct Mail' 
  else ('Direct Mail (' + TDMT.Name +')' ) end as [NotificationTypeName]
 ,'DirectMail' AS NotificationMedium
 ,CASE 
 When isnull(TDM.IsInvalidAddress, 0) = 1 Then 'Invalid Address'
 WHEN TDM.MailDate <= CAST(CONVERT(VARCHAR,GETDATE() + 1, 101) AS datetime)  Then 'Sent' 
 Else 'Scheduled' End as ServiceStatus
 ,(select FirstName +  ' ' + isnull(MiddleName,' ') + ' ' + LastName from tbluser where userid=TORU.UserId) as [ServicedBy]
 ,CAST(TDM.MailDate as varchar(30))AS ServicedDate 
 ,1 AS GroupID
 ,TDM.MailDate AS ServicedDateSort
 ,0 as [CallId]
 ,'-N/A-' AS CCRep
 ,'-N/A-' AS CallType 
 ,NULL AS CallDuration
 ,0 as [CallOutcome]
 ,'' as Disposition
 ,0 as NotInterestedReasonId 
 ,isnull( TDM.Notes,'-N/A-') as Notes
 ,isnull(TDM.IsInvalidAddress,0) as  IsInvalidAddress
from TblDirectMail TDM
inner join vw_Customers TC on TC.CustomerID=TDM.CustomerId
inner join TblUser TU on TU.UserID = TC.UserId
inner join TblOrganizationRoleUser TORU on TORU.OrganizationRoleUserId = TDM.MailedBy

left outer join TblDirectMailType TDMT on TDM.DirectMailTypeId = TDMT.Id
where TDM.CustomerId = @CustomerID

)vw ORDER BY vw.ServicedDateSort DESC