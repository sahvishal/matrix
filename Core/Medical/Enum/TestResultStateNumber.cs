namespace Falcon.App.Core.Medical.Enum
{
    public enum TestResultStateNumber
    {
        NoResults = 1,
        ResultsUploaded = 2,
        ManualEntry = 3,
        PreAudit = 4,
        Evaluated = 5,
        PostAudit = 6,
        ResultDelivered = 7,
    }

    public enum NewTestResultStateNumber
    {
        NoResults = 1,

        ResultEntryPartial = 2,
        ResultEntryCompleted = 3,
        PreAudit = 4,
        Evaluated = 5,
        NpNotificationSent = 6,
        NpSigned = 7,
        CodingCompleted = 8,
        ArtifactSynced = 9,
        PostAuditNew = 10,
        PdfGenerated = 11,
        ResultDelivered = 12
    }
}