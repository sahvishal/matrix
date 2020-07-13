USE [$(dbName)]
GO    

IF EXISTS(SELECT 1 FROM SYS.VIEWS WHERE NAME='Vw_GetCustomersToGenerateFillEventCallQueue' AND TYPE='V')
DROP VIEW Vw_GetCustomersToGenerateFillEventCallQueue;
GO

CREATE VIEW [dbo].[Vw_GetCustomersToGenerateFillEventCallQueue]   
As 

 SELECT CP.CustomerID    
		,CP.IsLanguageBarrier    
		,CP.Tag    
		,ISNULL(CP.LanguageBarrierMarkedDate,'01/01/1900') as LanguageBarrierMarkedDate      
		,CAST (Case 
			when Exists (select CustomerId  from TblPreApprovedTest WITH(NOLOCK) where CustomerId = cp.CustomerID and IsActive = 1 and TestId = 29 )
				Then 1
			When Exists (select pap.CustomerId,t.TestID from  TblPreApprovedPackage pap  WITH(NOLOCK)
									inner join TblPackageTest pt  WITH(NOLOCK) on pt.PackageID = pap.PackageId
									inner join TblTest t  WITH(NOLOCK) on t.TestID = pt.TestId and pap.CustomerId  = cp.CustomerID and pap.IsActive = 1  AND t.TestID = 29
							)
				Then 1
			Else 0 
		 End AS BIT) As IsMammoPatient
		,A.ZipID  
  FROM TblCustomerProfile AS CP WITH (NOLOCK) INNER JOIN  
                         TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID   
       INNER JOIN TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID  
       INNER JOIN TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID  
       Left Outer join   
       (  
			select CustomerId, IsEligible as IsEligble from TblCustomerEligibility WITH (NOLOCK) where ForYear = DATEPART(YEAR, GETDATE())  
       ) CE on CP.CustomerID = CE.CustomerId  
  
    WHERE   
     ((CP.DoNotContactTypeId is null or CP.DoNotContactTypeId = 289) OR   
      (  
       (  
        CP.DoNotContactTypeId = 287 OR CP.DoNotContactTypeId = 288  
       )   
       AND  
       (  
        CP.DoNotContactUpdateDate IS NOT NULL   
        AND   
        CP.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)  
        AND (CP.DoNotContactUpdateSource IS NULL OR CP.DoNotContactUpdateSource <> 349)  
       )  
      )  
     )   
     and (CE.IsEligble is not null and CE.IsEligble = 1 )   
     and (CP.IsIncorrectPhoneNumber is null or CP.IsIncorrectPhoneNumber = 0 or (CP.IsIncorrectPhoneNumber = 1 and CP.IncorrectPhoneNumberMarkedDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) ))  
     and CP.CustomerID not in  
      (  
       SELECT pc.CustomerID FROM TblProspectCustomer pc WITH(NOLOCK)   
         WHERE CustomerID is not null and CustomerID > 0   
         and (  
           pc.Tag = 'Deceased'  or   
           (  
            pc.TagUpdateDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)   
            and pc.Tag in ('HomeVisitRequested','DoNotCall','MobilityIssue','InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther','NoLongeronInsurancePlan')   
           )  
          )  
  
      )  
     and CP.CustomerID not in   
     (  
      SELECT EC.CustomerID FROM tbleventcustomers ec WITH (NOLOCK)   
        inner join TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID   
        and ec.AppointmentID is not null and e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)
		and ec.NoShow = 0
     )  
     AND (CP.ActivityId = 2 OR CP.ActivityId = 3)   
     AND CP.Tag IS NOT NULL AND CP.Tag <> '' 

Go