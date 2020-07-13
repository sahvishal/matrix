using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using HtmlAgilityPack;
using System;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BloodPanelResultHelper : IBloodPanelResultHelper
    {
        private readonly IResultPdfHelper _resultPdfHelper;

        public BloodPanelResultHelper(IResultPdfHelper resultPdfHelper)
        {
            _resultPdfHelper = resultPdfHelper;
        }

        public void LoadThyroidResult(ThyroidTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null)
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='thyroidNewLab-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='thyroid-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }


                _resultPdfHelper.SetInputBox(doc, "thyroidtextbox", testResult.TSHSCR);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Thyroid, "thyroidUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpThyroid", "criticalThyroid", "physicianRemarksThyroid");
                _resultPdfHelper.SetTechnician(doc, testResult, "techThyroid", "technotesThyroid", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='thyroid-rpp-resultspan']");
                if (selectedNodes != null && testResult.TSHSCR != null && !string.IsNullOrEmpty(testResult.TSHSCR.Reading))
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.TSHSCR.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Thyroid, "thyroidUnableToScreen", null);
            }
        }

        public void LoadPsaResult(PsaTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab, bool isHanson)
        {
            if (testResult != null)
            {
                HtmlNode selectedNode;
                if (!isHanson) // Old case 
                {
                    if (isFromNewBloodLab)
                    {
                        selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='psaNewLab-rpp-section']");
                        if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                            selectedNode.SetAttributeValue("style", "display:block;");
                    }
                    else
                    {
                        selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='psa-rpp-section']");
                        if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0))
                            selectedNode.SetAttributeValue("style", "display:block;");
                    }
               
                _resultPdfHelper.SetInputBox(doc, "psatextbox", testResult.PSASCR);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Psa, "psaUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpPsa", "criticalPsa", "physicianRemarksPsa");
                _resultPdfHelper.SetTechnician(doc, testResult, "techPsa", "technotesPsa", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='psa-rpp-resultspan']");
                if (selectedNodes != null && testResult.PSASCR != null && !string.IsNullOrEmpty(testResult.PSASCR.Reading))
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.PSASCR.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }

                }
                else // New case 
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='psaHensonsection-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        selectedNode.SetAttributeValue("style", "display:block;");

                    _resultPdfHelper.SetInputBox(doc, "psatextbox", testResult.PSASCR);
                    _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Psa, "psaUnableToScreen", testResult.UnableScreenReason);
                    _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpPsa", "criticalPsa", "physicianRemarksPsa");
                    _resultPdfHelper.SetTechnician(doc, testResult, "techPsa", "technotesPsa", technicianIdNamePairs);

                    var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='psa-rpp-resultspan']");
                    if (selectedNodes != null && testResult.PSASCR != null && !string.IsNullOrEmpty(testResult.PSASCR.Reading))
                    {
                        foreach (var node in selectedNodes)
                        {
                            node.InnerHtml = testResult.PSASCR.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                        }
                    }
                  
                    var chkPsaNormalNodes = doc.DocumentNode.SelectSingleNode("//input[@id='chkPsaNormal']"); 
                    var chkPsaAbNormalNodes = doc.DocumentNode.SelectSingleNode("//input[@id='chkPsaAbNormal']");
                      if (selectedNodes != null && testResult.PSASCR != null && !string.IsNullOrEmpty(testResult.PSASCR.Reading))
                      {
                          var PSASCRReading = Convert.ToDecimal(testResult.PSASCR.Reading);

                          if (PSASCRReading > 4)
                          {
                              chkPsaAbNormalNodes.SetAttributeValue("checked", "checked");
                          }
                          else
                          {
                              chkPsaNormalNodes.SetAttributeValue("checked", "checked");
                          }
                      }
               }
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Psa, "psaUnableToScreen", null);
            }
        }

        public void LoadCrpResult(CrpTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null)
            {
                HtmlNode selectedNode;

                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='crpNewLab-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='crp-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetInputBox(doc, "crptextbox", testResult.LCRP);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Crp, "crpUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpCrp", "criticalCrp", "physicianRemarksCrp");
                _resultPdfHelper.SetTechnician(doc, testResult, "techCrp", "technotesCrp", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='crp-rpp-resultspan']");
                if (selectedNodes != null && testResult.LCRP != null && !string.IsNullOrEmpty(testResult.LCRP.Reading))
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.LCRP.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Crp, "crpUnableToScreen", null);
            }
        }

        public void LoadTestosteroneResult(TestosteroneTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null)
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='testosteroneNewLab-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='testosterone-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0))
                        selectedNode.SetAttributeValue("style", "display:block;");

                }

                _resultPdfHelper.SetInputBox(doc, "testosteronetextbox", testResult.TESTSCRE);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Testosterone, "testosteroneUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpTestosterone", "criticalTestosterone", "physicianRemarksTestosterone");
                _resultPdfHelper.SetTechnician(doc, testResult, "techTestosterone", "technotesTestosterone", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='testosterone-rpp-resultspan']");
                if (selectedNodes != null && testResult.TESTSCRE != null && !string.IsNullOrEmpty(testResult.TESTSCRE.Reading))
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.TESTSCRE.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Testosterone, "testosteroneUnableToScreen", null);
            }
        }

        public void LoadVitaminDResult(VitaminDTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null)
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='VitaminDNewLab-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                        && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='VitaminD-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }


                _resultPdfHelper.SetInputBox(doc, "VitaminDtextbox", testResult.VitD);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.VitaminD, "VitaminDUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpVitaminD", "criticalVitaminD", "physicianRemarksVitaminD");
                _resultPdfHelper.SetTechnician(doc, testResult, "techVitaminD", "technotesVitaminD", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='VitaminD-rpp-resultspan']");
                if (selectedNodes != null && testResult.VitD != null && !string.IsNullOrEmpty(testResult.VitD.Reading))
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.VitD.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.VitaminD, "VitaminDUnableToScreen", null);
            }
        }

        public void LoadMenBloodPanelResult(MenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null)
            {
                if (isFromNewBloodLab)
                {
                    var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MenBloodPanelNewLab-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                        && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MenBloodPanel-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }

                MenBloodPanelPsaResult(testResult, doc, technicianIdNamePairs, isFromNewBloodLab);
                MenBloodPanelCrpResult(testResult, doc, technicianIdNamePairs, isFromNewBloodLab);
                MenBloodPanelTestosteroneResult(testResult, doc, technicianIdNamePairs, isFromNewBloodLab);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.MenBloodPanel, "MenBloodPanelUnableToScreen", null);
            }

        }

        private void MenBloodPanelPsaResult(MenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null && testResult.PSASCR != null && !string.IsNullOrEmpty(testResult.PSASCR.Reading))
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MenBloodPanelNewLabPSA-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MenBloodPanelPSA-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetInputBox(doc, "MenBloodPanelPsatextbox", testResult.PSASCR);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.MenBloodPanel, "MenBloodPanelPsaUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpMenBloodPanelPsa", "criticalMenBloodPanelPsa", "physicianRemarksMenBloodPanelPsa");
                _resultPdfHelper.SetTechnician(doc, testResult, "techMenBloodPanelPsa", "technotesMenBloodPanelPsa", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='MenBloodPanelPsa-rpp-resultspan']");
                if (selectedNodes != null)
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.PSASCR.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
        }

        private void MenBloodPanelCrpResult(MenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null && testResult.LCRP != null && !string.IsNullOrEmpty(testResult.LCRP.Reading))
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MenBloodPanelNewLabCRP-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MenBloodPanelCRP-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetInputBox(doc, "MenBloodPanelCrptextbox", testResult.LCRP);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.MenBloodPanel, "MenBloodPanelCrpUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpMenBloodPanelCrp", "criticalMenBloodPanelCrp", "physicianRemarksMenBloodPanelCrp");
                _resultPdfHelper.SetTechnician(doc, testResult, "techMenBloodPanelCrp", "technotesMenBloodPanelCrp", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='MenBloodPanelCrp-rpp-resultspan']");
                if (selectedNodes != null)
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.LCRP.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
        }

        private void MenBloodPanelTestosteroneResult(MenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null && testResult.TESTSCRE != null && !string.IsNullOrEmpty(testResult.TESTSCRE.Reading))
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MenBloodPanelNewLabTestosterone-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MenBloodPanelTestosterone-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetInputBox(doc, "MenBloodPanelTestosteronetextbox", testResult.TESTSCRE);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.MenBloodPanel, "MenBloodPanelTestosteroneUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpMenBloodPanelTestosterone", "criticalMenBloodPanelTestosterone", "physicianRemarksMenBloodPanelTestosterone");
                _resultPdfHelper.SetTechnician(doc, testResult, "techMenBloodPanelTestosterone", "technotesMenBloodPanelTestosterone", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='MenBloodPanelTestosterone-rpp-resultspan']");
                if (selectedNodes != null)
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.TESTSCRE.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
        }

        public void LoadWomenBloodPanelResult(WomenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null)
            {
                if (isFromNewBloodLab)
                {
                    var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='WomenBloodPanelNewLab-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                        && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='WomenBloodPanel-rpp-section']");
                    if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                        selectedNode.SetAttributeValue("style", "display:block;");
                }


                WomenBloodPanelCrpResult(testResult, doc, technicianIdNamePairs, isFromNewBloodLab);
                WomenBloodPanelThyroidResult(testResult, doc, technicianIdNamePairs, isFromNewBloodLab);
                WomenBloodPanelVitaminDResult(testResult, doc, technicianIdNamePairs, isFromNewBloodLab);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.WomenBloodPanel, "WomenBloodPanelUnableToScreen", null);
            }
        }

        private void WomenBloodPanelCrpResult(WomenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null && testResult.LCRP != null && !string.IsNullOrEmpty(testResult.LCRP.Reading))
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='WomenBloodPanelNewLabCRP-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='WomenBloodPanelCRP-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetInputBox(doc, "WomenBloodPanelCrptextbox", testResult.LCRP);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.WomenBloodPanel, "WomenBloodPanelCrpUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpWomenBloodPanelCrp", "criticalWomenBloodPanelCrp", "physicianRemarksWomenBloodPanelCrp");
                _resultPdfHelper.SetTechnician(doc, testResult, "techWomenBloodPanelCrp", "technotesWomenBloodPanelCrp", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='WomenBloodPanelCrp-rpp-resultspan']");
                if (selectedNodes != null)
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.LCRP.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
        }

        private void WomenBloodPanelThyroidResult(WomenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null && testResult.TSHSCR != null && !string.IsNullOrEmpty(testResult.TSHSCR.Reading))
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='WomenBloodPanelNewLabTSH-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='WomenBloodPanelTSH-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetInputBox(doc, "WomenBloodPanelThyroidtextbox", testResult.TSHSCR);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.WomenBloodPanel, "WomenBloodPanelThyroidUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpWomenBloodPanelThyroid", "criticalWomenBloodPanelThyroid", "physicianRemarksWomenBloodPanelThyroid");
                _resultPdfHelper.SetTechnician(doc, testResult, "techWomenBloodPanelThyroid", "technotesWomenBloodPanelThyroid", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='WomenBloodPanelThyroid-rpp-resultspan']");
                if (selectedNodes != null)
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.TSHSCR.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
        }

        private void WomenBloodPanelVitaminDResult(WomenBloodPanelTestResult testResult, HtmlDocument doc, List<OrderedPair<long, string>> technicianIdNamePairs, bool isFromNewBloodLab)
        {
            if (testResult != null && testResult.VitD != null && !string.IsNullOrEmpty(testResult.VitD.Reading))
            {
                HtmlNode selectedNode;
                if (isFromNewBloodLab)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='WomenBloodPanelNewLabVitaminD-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='WomenBloodPanelVitaminD-rpp-section']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetInputBox(doc, "WomenBloodPanelVitaminDtextbox", testResult.VitD);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.WomenBloodPanel, "WomenBloodPanelVitaminDUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpWomenBloodPanelVitaminD", "criticalWomenBloodPanelVitaminD", "physicianRemarksWomenBloodPanelVitaminD");
                _resultPdfHelper.SetTechnician(doc, testResult, "techWomenBloodPanelVitaminD", "technotesWomenBloodPanelVitaminD", technicianIdNamePairs);

                var selectedNodes = doc.DocumentNode.SelectNodes("//span[@id='WomenBloodPanelVitaminD-rpp-resultspan']");
                if (selectedNodes != null)
                {
                    foreach (var node in selectedNodes)
                    {
                        node.InnerHtml = testResult.VitD.Reading.Replace("<", "&lt;").Replace(">", "&gt;");
                    }
                }
            }
        }

    }
}
