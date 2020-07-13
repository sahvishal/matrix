namespace Falcon.App.Core.Medical
{
    public interface IMemberTermByAbsencePublisher
    {
        void PublishCorporateUpload(long corporateUploadId);
    }
}