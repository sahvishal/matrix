
USE [$(dbName)]
Go 

insert Into TblTag ([Source], Name, Alias, IsActive, IsSystemDefined)
Values(107, 'All Events Full', 'AllEventsFull', 1, 0)

insert Into TblTag ([Source], Name, Alias, IsActive, IsSystemDefined)
Values(107, 'Doctor Concerns', 'DoctorConcerns', 1, 0)

insert Into TblTag ([Source], Name, Alias, IsActive, IsSystemDefined)
Values(107, 'Poor Location', 'PoorLocation', 1, 0)