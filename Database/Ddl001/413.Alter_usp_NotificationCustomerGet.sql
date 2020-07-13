USE [$(dbName)]
Go

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
	 ,'-N/A-' as Notes
	 ,'-N/A-' AS CCRep
	 ,'-N/A-' AS CallType 
	 ,NULL AS CallDuration
	 ,0 as [CallOutcome]
	 ,'' as Disposition
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
 UNION
  
 select    TOP 100 PERCENT 0 AS NotificationID, 
	ISNULL(IncomingPhoneLine,'') AS [Name],
	ISNULL(CallStatus,'Not Available') AS NotificationTypeName,
	'Incoming Phone' AS NotificationMedium,
	'-N/A-' as ServiceStatus,
	ISNULL(CallersPhoneNumber,'')AS [ServicedBy],
	CAST(TblCalls.DateCreated as varchar(30))AS ServicedDate, 1 AS GroupID
	,TblCalls.DateCreated AS ServicedDateSort
	,ISNULL(TblCallCenterNotes.Notes,'') Notes
	,TblUser.FirstName + CASE WHEN LEN(ISNULL(TblUser.MiddleName,''))>0 THEN ' ' + TblUser.MiddleName + ' ' ELSE ' 'END + TblUser.LastName AS CCRep
	,CASE WHEN dbo.TblCalls.OutBound=1 THEN 'OUTBOUND' ELSE 'INBOUND' END CallType
	,(TimeEnd - TimeCreated) CallDuration
	,Tblcalls.[Status] as CallOutcome
	,ISNULL(TblCalls.Disposition,'') Disposition

FROM Tblcalls
LEFT OUTER JOIN dbo.TblCallCenterNotes ON dbo.TblCalls.CallID = dbo.TblCallCenterNotes.CallID --AND dbo.TblCalls.OutBound=1
INNER JOIN TblOrganizationRoleUser TORU ON Tblcalls.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
INNER JOIN dbo.TblUser ON TORU.UserID = dbo.TblUser.UserID	
WHERE CalledCustomerID=@CustomerID 
)vw ORDER BY vw.ServicedDateSort DESC