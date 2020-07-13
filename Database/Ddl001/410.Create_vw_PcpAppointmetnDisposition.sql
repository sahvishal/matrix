USE [$(dbName)]
Go

Alter View [dbo].[vw_PcpAppointmetnDisposition]
As
	select EventCustomerID
,IsNull(AppointmentOn, '01/01/1901') as PcpAppointment
,IsNull(ISNULL(ModifiedOn, CreatedOn), '01/01/1901') as PcpAppointmentLastModified
,0 as PcpDispositionId
,'01/01/1901' as PcpDispositionLastModified
,IsNull(ISNULL(ModifiedOn, CreatedOn), '01/01/1901') as LastModified
from TblPcpAppointment

Union All

select EventCustomerID
,'01/01/1901' as PcpAppointment
,'01/01/1901' as PcpAppointmentLastModified
,PcpDispositionId
,CreatedOn as PcpDispositionLastModified
,CreatedOn as LastModified
from TblPcpDisposition  