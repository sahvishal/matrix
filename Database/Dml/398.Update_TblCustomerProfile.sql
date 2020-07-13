use [$(dbname)]
go


update TblCustomerProfile Set IsSubscribed = 1 where EnableTexting = 1

update TblEmailTemplate set EmailBody =  REPLACE(EmailBody, '1(855)755-8378', '1(888)822-3247')  Where NotificationTypeId in 
(
	select NotificationTypeId from TblNotificationType Where NotificationMediumId = 3
)

