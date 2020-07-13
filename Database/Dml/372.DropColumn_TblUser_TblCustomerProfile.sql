use [$(dbname)]
go

	Alter Table TblUser
		Drop Column AddedMethod, DigitalSignature
	Go
