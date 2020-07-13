USE [$(dbName)]
Go
if not exists(select TagId from TblTag where Name='Customer Service' and  IsSystemDefined=0 and IsHealthPlanTag =0 and IsActive = 1 and Source =107 and Alias='CustomerService')
Begin
	insert into TblTag(Source,Name, Alias,IsActive,IsSystemDefined,IsHealthPlanTag) values(107,'Customer Service','CustomerService',1,0,0)
End

