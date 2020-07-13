USE [$(dbname)]
GO

INSERT INTO TblRelationship (RelationshipId, Code, [Description], Alias)
VALUES (1, '01', 'SPOUSE', 'Spouse'),
	   (2, '03', 'FATHER OR MOTHER', 'FatherOrMother'),
	   (3, '05', 'GRANDSON OR GRANDDAUGHTER', 'GrandSonOrGrandDaughter'),
	   (4, '07', 'NEPHEW OR NIECE', 'NephewOrNiece'),
	   (5, '09', 'ADOPTED CHILD', 'AdoptedChild'),
	   (6, '10', 'FOSTER CHILD', 'FosterChild'),
	   (7, '11', 'SON-IN-LAW OR DAUGHTER-IN-LAW', 'SonInLawOrDaughterInLaw'),
	   (8, '13', 'MOTHER-IN-LAW OR FATHER-IN-LAW', 'MotherInLawOrFatherInLaw'),
	   (9, '14', 'BROTHER OR SISTER', 'BrotherOrSister'),
	   (10, '15', 'WARD', 'Ward'), 
	   (11, '17', 'STEPSON OR STEPDAUGHTER', 'StepSonOrStepDaughter'),
	   (12, '18', 'SELF', 'Self'),
	   (13, '19', 'CHILD', 'Child'),
	   (14, '22', 'HANDICAPPED DEPENDENT', 'HandicappedDependent'),
	   (15, '23', 'SPONSORED DEPENDENT', 'SponsoredDependent'),
	   (16, '24', 'DEPENDENT OF A MINOR DEPENDENT', 'DependentOfAMinorDependent'),
	   (17, '26', 'GUARDIAN', 'Guardian'), 
	   (18, '31', 'COURT APPOINTED GUARDIAN', 'CourtAppointedGuardian'),
	   (19, '38', 'COLLATERAL DEPENDENT', 'CollateralDependent'),
	   (20, '53', 'LIFE PARTNER', 'LifePartner'),
	   (21, 'G8', 'OTHER RELATIONSHIP', 'OtherRelationship')
GO
