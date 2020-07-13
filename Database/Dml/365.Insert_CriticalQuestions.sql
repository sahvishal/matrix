USE [$(dbname)]
GO

INSERT INTO TblCriticalQuestion (Id, Question, ControlType, ControlValues, ControlValueDelimiter, IsActive)
VALUES  (1, 'Did patient fast?', 124, 'Yes,No', ',', 1),
		(2, 'Is patient on a statin?', 124, 'Yes,No', ',', 1),
		(3, 'Is patient on cholesterol Med?', 124, 'Yes,No', ',', 1),
		(4, 'Was patient stable at time of transfer?', 124, 'Yes,No', ',', 1),
		(5, 'Was pcp contacted?', 124, 'Yes,No', ',', 1),
		(6, 'Was patient symptomatic?', 124, 'Yes,No', ',', 1),
		(7, 'Did patient refuse transfer?', 124, 'Yes,No', ',', 1),
		(8, 'Where was the patient sent?', 124, 'ER Office,PCP Office', ',', 1)
GO