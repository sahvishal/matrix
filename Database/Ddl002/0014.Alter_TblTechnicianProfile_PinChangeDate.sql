USE	[$(dbname)]
GO

ALTER TABLE TblTechnicianProfile
ADD PinChangeDate DATETIME NULL
GO


ALTER TABLE TblTechnicianProfile
ALTER COLUMN Pin VARCHAR(512) NULL