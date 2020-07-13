USE [$(dbName)]
go
UPDATE E SET E.TimeZone=
CASE WHEN (Z.TimeZone='10' AND Z.DayLightSaving='N') THEN 'GMT -10:00  U.S. Hawaiian Time'  
     WHEN (Z.TimeZone='9' AND Z.DayLightSaving='Y')  THEN 'GMT -09:00  U.S. Alaska Time'  
     WHEN (Z.TimeZone='8' AND Z.DayLightSaving='Y')  THEN 'GMT -08:00  Pacific Time'  
     WHEN (Z.TimeZone='7' AND Z.DayLightSaving='Y')  THEN 'GMT -07:00  U.S. Mountain Time'  
     WHEN (Z.TimeZone='7' AND Z.DayLightSaving='N')  THEN 'GMT -07:00  U.S. Mountain Time (Arizona)'  
     WHEN (Z.TimeZone='6' AND Z.DayLightSaving='Y')  THEN 'GMT -06:00  U.S. Central Time'  
     WHEN (Z.TimeZone='6' AND Z.DayLightSaving='N')  THEN 'GMT -06:00  Mexico'  
     WHEN (Z.TimeZone='5' AND Z.DayLightSaving='Y')  THEN 'GMT -05:00  U.S. Eastern Time'  
	 ELSE '-N\A-'
	 END 
FROM TblEvents E
JOIN TblHostEventDetails HE ON HE.EventID=E.EventID
JOIN TblProspects Prs ON Prs.ProspectID=HE.HostID AND Prs.IsHost=1
Join TblAddress Ad ON Ad.AddressID=Prs.AddressID  
Join TblZip Z ON Z.ZipID=Ad.ZipID