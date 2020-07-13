USE [$(dbName)]
Go

Insert into TblHospitalPartnerShippingOption
	(HospitalPartnerId, ShippingOptionId)
select HospitalPartnerId, 2
from TblHospitalPartner where HospitalPartnerId not in (select HospitalPartnerId from TblHospitalPartnerShippingOption where ShippingOptionId = 2)


Insert into TblHospitalPartnerShippingOption
	(HospitalPartnerId, ShippingOptionId)
select HospitalPartnerId, 1
from TblHospitalPartner where HospitalPartnerId not in (select HospitalPartnerId from TblHospitalPartnerShippingOption where ShippingOptionId = 1)