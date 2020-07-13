
USE [$(dbname)]
GO

INSERT into TblChaperoneQuestion (Id, Question, TypeId, ParentId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (1, 'Chaperone Declined:', 322, NULL, 184, '', '', 1),
	   (2, 'Echo', 322, NULL, 184, '', '', 2),
	   (3, 'EKG', 322, NULL, 184, '', '', 3),
	   (4, 'AAA', 322, NULL, 184, '', '', 4),
	   (5, 'LEAD', 322, NULL, 184, '', '', 5),
	   (6, 'Testing Declined:', 322, NULL, 184, '', '', 6),
	   (7, 'Declined to partially disrobe', 322, NULL, 184, '', '', 7),
	   (8, 'Other:', 322, NULL, 184, '', '', 8),
	   (9, 'Echo', 322, NULL, 184, '', '', 9),
	   (10, 'EKG', 322, NULL, 184, '', '', 10),
	   (11, 'AAA', 322, NULL, 184, '', '', 11),
	   (12, 'LEAD', 322, NULL, 184, '', '', 12),
	   (13, 'Staff Witness', 323, NULL, 184, '', '', 13),
	   (14, 'Date:', 323, NULL, 184, '', '', 14),
	   (15, 'Patient verbally declined a chaperone, but has refused to sign.', 322, NULL, 184, '', '', 15)


