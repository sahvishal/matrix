namespace Falcon.App.Core.Medical
{
    public interface IMemberTermByAbsenceService
    {
        void SubscribeForEligibiltyUpdate(long corporateUploadId);
    }
}