USE [$(dbName)]
Go 
alter table TblPhysicianMaster
add MailingAddress1 varchar(500) null,
 MailingAddress2	varchar(500) null ,
 MailingCity varchar(225) null,
 MailingState varchar(225) null,
 MailingZip varchar(10) null
 
 GO

 