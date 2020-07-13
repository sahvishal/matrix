using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using HtmlAgilityPack;

namespace Falcon.App.Core.Medical
{
    public interface IBloodPanelResultHelper
    {
        void LoadThyroidResult(ThyroidTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab);
        void LoadPsaResult(PsaTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab, bool isHanson);
        void LoadCrpResult(CrpTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab);
        void LoadTestosteroneResult(TestosteroneTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab);
        void LoadVitaminDResult(VitaminDTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab);
        void LoadMenBloodPanelResult(MenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab);
        void LoadWomenBloodPanelResult(WomenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab);
    }
}