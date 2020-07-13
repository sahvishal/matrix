USE [$(dbName)]
Go


CREATE View [dbo].[vw_PcpAppointmetnDisposition]
As
	select EventCustomerID,PcpAppointment,PcpAppointmentLastModified,PcpDispositionId,PcpDispositionLastModified
		,Case when PcpAppointmentLastModified > PcpDispositionLastModified Then PcpAppointmentLastModified Else PcpDispositionLastModified End as LastModified
		from 
		(
			select TEC.EventCustomerID
			,IsNull(TPA.AppointmentOn, '01/01/1901') as PcpAppointment
			,IsNull(ISNULL(TPA.ModifiedOn, TPA.CreatedOn), '01/01/1901') as PcpAppointmentLastModified
			,ISNULL(TPD.PcpDispositionId, 0) PcpDispositionId
			,ISNULL(TPD.CreatedOn, '01/01/1901') as PcpDispositionLastModified
			from TblEventCustomers TEC
			Left Outer Join TblPcpAppointment TPA on TEC.EventCustomerID = TPA.EventCustomerId
			Left Outer Join TblPcpDisposition TPD on TEC.EventCustomerID = TPD.EventCustomerId
			where TPA.EventCustomerId > 0 or TPD.EventCustomerId > 0
		) PcpAppointment 
