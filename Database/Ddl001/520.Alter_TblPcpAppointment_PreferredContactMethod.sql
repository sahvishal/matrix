USE [$(dbName)]
Go

alter table TblPcpAppointment 
add PreferredContactMethod bigint null

alter table TblPcpAppointment add CONSTRAINT FK_TblPcpAppointment_TblLookup FOREIGN KEY (PreferredContactMethod) REFERENCES [TblLookup](LookupId) 