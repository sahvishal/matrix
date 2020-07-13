namespace Falcon.App.Core.Deprecated.Enum
{
    /// <summary>
    /// This enum will specify the kind of PDF. 
    /// </summary>
    public enum EPDFType
    {
        ResultPdf = 0,
        ClinicalForm,
        ResultPdfWithImages,
        ResultPdfPaperBack,
        ViewResult,
        All,
        PaperOnly,
        OnlineOnly,
        CdContent,
        PcpResultReport,
        AllPcpResultReportOnly,
        EAwvPreventionPlanReport,
        AllEawvPreventionPlanReportOnly,
        HealthPlanReport,
        AllHealthPlanReportOnly,
        IpResultPdf
    }
}