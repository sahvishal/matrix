namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportService
    {
        void ResultExport();
        //void ResultExport(DateTime? fromDate, DateTime toDate, long accountId, string destinationDirectory);
    }
}