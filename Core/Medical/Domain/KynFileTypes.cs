using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class KynFileTypes
    {
        public const string LetterWriter = "letterwriter";
        public const string ParticipantSummaryReport = "participantsummreport";
        public const string PhysicianSummaryReport = "physiciansummreport";
        public const string LongitudinalPrompt = "longitudinalprompt";

        public static string GetFileName(TestType testType, string fileType)
        {
            //"Kyn_" + fileType + ".pdf";
            return testType.ToString() + "_" + fileType + ".pdf";
        }
    }
}
