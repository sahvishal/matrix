
using Falcon.App.Core.Medical.ViewModels;
namespace Falcon.App.Core.Medical
{
    public interface IChatAssessmentService
    {
        ChatAssessmentPdfViewModel GetChatAssessmentPdfPath(long eventId, string acesId);
        bool SaveAssessmentPdfVerification(long eventId, long customerId, bool isVerified, bool isforOveread, long physicianId);
    }
}
