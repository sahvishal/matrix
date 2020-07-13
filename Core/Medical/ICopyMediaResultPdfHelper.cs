using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ICopyMediaResultPdfHelper
    {
        void CopyOverMedia(long eventId, long customerId, string saveFilePath, IEnumerable<ResultMedia> resultMedia);
        void CopyOverAwvEkgGraph(long eventId, long customerId, string saveFilePath, AwvEkgTestResult testResult);
        void SetMediaForTestResult(IEnumerable<ResultMedia> testMedia, string sectionName, string testName, HtmlDocument doc);
        void SetSingleMediaForTestResult(ResultMedia media, string sectionName, string testName, HtmlDocument doc);
        void UpdateHTMLWithImages(HtmlDocument doc);
        void CopyOverSupportDirectorytotheDestination(string saveFilePath, string sourceFilePath, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, bool moveSupportMediaFolder = false, bool copySupportMediaOtherThanPhysician = true);
        void CopyOverEkgGraph(long eventId, long customerId, string saveFilePath, EKGTestResult testResult);
        void CopyOverAwvEkgIppeGraph(long eventId, long customerId, string saveFilePath, AwvEkgIppeTestResult testResult);
        void CopyOverSpiroGraph(long eventId, long customerId, string saveFilePath, SpiroTestResult testResult);
        void CopyOverAwvSpiroGraph(long eventId, long customerId, string saveFilePath, AwvSpiroTestResult testResult);
        void CopyOverFloChecAbiPdf(long eventId, long customerId, string saveFilePath, FloChecABITestResult testResult);
        void CopyOverQuantaFloABIPdf(long eventId, long customerId, string saveFilePath, QuantaFloABITestResult testResult);
    }
}
