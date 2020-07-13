using System.ComponentModel;

namespace Falcon.App.Core.Users.Enum
{
    public enum Relationship
    {
        [Description("SPOUSE")]
        Spouse = 1,

        [Description("FATHER OR MOTHER")]
        FatherOrMother = 2,

        [Description("GRANDSON OR GRANDDAUGHTER")]
        GrandSonOrGrandDaughter = 3,

        [Description("NEPHEW OR NIECE")]
        NephewOrNiece = 4,

        [Description("ADOPTED CHILD")]
        AdoptedChild = 5,

        [Description("FOSTER CHILD")]
        FosterChild = 6,

        [Description("SON-IN-LAW OR DAUGHTER-IN-LAW")]
        SonInLawOrDaughterInLaw = 7,

        [Description("MOTHER-IN-LAW OR FATHER-IN-LAW")]
        MotherInLawOrFatherInLaw = 8,

        [Description("BROTHER OR SISTER")]
        BrotherOrSister = 9,

        [Description("WARD")]
        Ward = 10,

        [Description("STEPSON OR STEPDAUGHTER")]
        StepSonOrStepDaughter = 11,

        [Description("SELF")]
        Self = 12,

        [Description("CHILD")]
        Child = 13,

        [Description("HANDICAPPED DEPENDENT")]
        HandicappedDependent = 14,

        [Description("SPONSORED DEPENDENT")]
        SponsoredDependent = 15,

        [Description("DEPENDENT OF A MINOR DEPENDENT")]
        DependentOfAMinorDependent16,

        [Description("GUARDIAN")]
        Guardian = 17,

        [Description("COURT APPOINTED GUARDIAN")]
        CourtAppointedGuardian = 18,

        [Description("COLLATERAL DEPENDENT")]
        CollateralDependent = 19,

        [Description("LIFE PARTNER")]
        LifePartner = 20,

        [Description("OTHER RELATIONSHIP")]
        OtherRelationship = 21
    }
}
