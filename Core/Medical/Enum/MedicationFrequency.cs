using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum MedicationFrequency
    {
        [Description("QD (Once a day)")]
        QD = 386,

        [Description("BID (Twice a day)")]
        BID = 387,

        [Description("TID (3x a day)")]
        TID = 388,

        [Description("QID (4x a day)")]
        QID = 389,

        [Description("QOD (Every other day)")]
        QOD = 390,

        TIW = 391,

        [Description("PRN (As needed)")]
        PRN = 392,

        [Description("QHS (at bedtime)")]
        QHS = 393,

        QAM = 394,

        [Description("PC (After Meal)")]
        PC = 395,

        [Description("AC (Before Meal)")]
        AC = 396,

        [Description("Q2H (Every 2 hours)")]
        Q2H = 397,

        [Description("Q3H (Every 3 hours)")]
        Q3H = 398,

        [Description("Q4H (Every 4 hours)")]
        Q4H = 399,

        [Description("Q8H (Every 8 hours)")]
        Q8H = 400,

        Other = 401,

        QWQ = 402,

        TWT = 403,

        Unknown = 404,
    }
}