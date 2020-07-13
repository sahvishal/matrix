using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum TestResultStateLabel
    {
        [Description("Result Not Entered")]
        NoResults,

        [Description("Result Not Entered/Chart Signed")]
        NoResultsChartSigned,

        [Description("Result Entry - Partial/Chart Not Signed")]
        ResultEntryPartialChartNotSigned,

        [Description("Result Entry - Partial/Chart Signed")]
        ResultEntryPartialChartSigned,

        [Description("Result Entry Completed/Chart Not Signed")]
        ResultEntryCompletedChartNotSigned,

        [Description("Result Entry Completed/Chart Signed")]
        ResultEntryCompletedChartSigned,

        [Description("Failed during Parse")]
        ParsingFailure,

        [Description("Result Uploaded - Partial")]
        ResultUploadedPartial,

        [Description("Result Uploaded")]
        ResultUploaded,

        [Description("Manual Entry - Partial")]
        ManualEntryPartial,

        [Description("Manual Entry")]
        ManualEntry,

        [Description("Sent Back for Correction")]
        SentBackForCorrection,

        [Description("Pre Audit")]
        PreAudit,

        [Description("Overread Pending")]
        OverreadPending,

        [Description("Evaluated by Physician")]
        Evaluated,


        [Description("NP Notification Sent")]
        NpNotificationSent,

        [Description("NP Signed")]
        NpSigned,

        [Description("Ready For Coding")]
        ReadyForCoding,

        [Description("Coding Completed")]
        CodingCompleted,

        [Description("Artifact Synced")]
        ArtifactSynced,

        [Description("Post Audit")]
        PostAudit,

        [Description("Post Audit - Pdf Generated")]
        PostAuditWithPdf,

        [Description("Pdf Generated Waiting For Aces")]
        PdfGeneratedWaitingForAces,

        [Description("Result Delivered")]
        ResultDelivered
    }

    public enum OldTestResultStateLabel
    {
        [Description("Result Not Entered")]
        NoResults,
        [Description("Failed during Parse")]
        ParsingFailure,
        [Description("Result Uploaded - Partial")]
        ResultUploadedPartial,
        [Description("Result Uploaded")]
        ResultUploaded,
        [Description("Manual Entry - Partial")]
        ManualEntryPartial,
        [Description("Manual Entry")]
        ManualEntry,
        [Description("Sent Back for Correction")]
        SentBackForCorrection,
        [Description("Pre Audit")]
        PreAudit,
        [Description("Overread Pending")]
        OverreadPending,
        [Description("Evaluated by Physician")]
        Evaluated,
        [Description("Post Audit")]
        PostAudit,
        [Description("Post Audit - Pdf Generated")]
        PostAuditWithPdf,
        [Description("Result Delivered")]
        ResultDelivered
    }

    public enum NewTestResultStateLabel
    {
        [Description("Result Not Entered")]
        NoResults,

        [Description("Result Not Entered/Chart Signed")]
        NoResultsChartSigned,

        [Description("Result Entry - Partial/Chart Not Signed")]
        ResultEntryPartialChartNotSigned,

        [Description("Result Entry - Partial/Chart Signed")]
        ResultEntryPartialChartSigned,

        [Description("Result Entry Completed/Chart Not Signed")]
        ResultEntryCompletedChartNotSigned,

        [Description("Result Entry Completed/Chart Signed")]
        ResultEntryCompletedChartSigned,

        [Description("Sent Back for Correction")]
        SentBackForCorrection,

        [Description("Pre Audit")]
        PreAudit,

        [Description("Overread Pending")]
        OverreadPending,

        [Description("Evaluated by Physician")]
        Evaluated,


        [Description("NP Notification Sent")]
        NpNotificationSent,

        [Description("NP Signed")]
        NpSigned,

        [Description("Ready For Coding")]
        ReadyForCoding,

        [Description("Coding Completed")]
        CodingCompleted,

        [Description("Artifact Synced")]
        ArtifactSynced,

        [Description("Post Audit")]
        PostAudit,

        [Description("IP Pdf Generated")]
        PdfGeneratedWaitingForAces,

        [Description("Result Delivered")]
        ResultDelivered
    }
}