use [$(dbName)]
go

Update TblCustomerProfile set DoNotContactUpdateDate=DateModified  where DoNotContactTypeId is not null and IsEligble = 1

Update TblProspectCustomer Set TagUpdateDate = ContactedDate where Tag in ('HomeVisitRequested','DoNotCall','MobilityIssue','InLongTermCareNursingHome')
	

