using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using HtmlAgilityPack;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ResultPdfHelper : IResultPdfHelper
    {
        private readonly IPhysicianEvaluationRepository _physicianEvaluationRepository;

        private readonly ISettings _settings;

        private const string StringforMediaDirectory = "media";
        private const string StringforContentDirectory = "content";
        private const string LongDescriptionFortestnotPurchased = "You have not purchased this test.";
        private const string LongDescriptionFortestnotScreened = "You have purchased the test, however due to technical reasons we could not perform this test on you. If you have any questions please feel free to call us.";
        private const string LongDescriptionAdditionalImagesNeeded = "In order to finalize the results of this study, our physician has requested additional images be gathered.  This does not mean your results are normal nor abnormal, simply that additional images are needed in order to properly evaluate the study.  Please contact Matrix Medical Network at 1-877-590-3247 to have this test repeated.";
        private const string LongDescriptionConsiderOtherModalities = "While ultrasound is an effective imaging method, it is not suited for all body types.  Due to these limitations, proper images could not be obtained for this study.  This does not mean your results were normal nor abnormal.  We encourage you to speak with your physician and determine what other testing modalities may be appropriate for you.  If you have any questions, you may contact Matrix Medical Network at 1-877-590-3247.";

        public ResultPdfHelper(IPhysicianEvaluationRepository physicianEvaluationRepository, ISettings settings)
        {
            _physicianEvaluationRepository = physicianEvaluationRepository;
            _settings = settings;
        }

        public void SetCheckBox(HtmlDocument doc, string nodeName, ResultReading<bool> resultReading)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='" + nodeName + "']");
            if (selectedNode != null && resultReading != null)
            {
                var isSelected = resultReading.Reading;
                if (isSelected)
                    selectedNode.SetAttributeValue("checked", "checked");
            }
        }

        public void SetCheckBox(HtmlDocument doc, string nodeName, ResultReading<bool?> resultReading)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='" + nodeName + "']");
            if (selectedNode != null && resultReading != null && resultReading.Reading != null)
            {
                var isSelected = resultReading.Reading.Value;
                if (isSelected)
                    selectedNode.SetAttributeValue("checked", "checked");
            }
        }
        public void SetInputBox<T>(HtmlDocument doc, string nodeName, ResultReading<T> resultReading)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='" + nodeName + "']");
            if (selectedNode != null)
                selectedNode.SetAttributeValue("value", (resultReading != null && resultReading.Reading != null) ? resultReading.Reading.ToString() : string.Empty);
        }

        public void SetSummaryFindings<T>(HtmlDocument doc, StandardFinding<T> findingInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId, string descriptionboxid = "", StandardFinding<T> findingForLongDescription = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null, bool showAdditionalImagesNeeded = false, bool showConsiderOtherModalities = false)
        {
            string htmlRows = "";
            string longdescription = "";
            foreach (var standardFinding in findingsCollection)
            {
                string rowString = "<input type='checkbox' /> " + standardFinding.Label;
                if (findingInDb != null && findingInDb.Id == standardFinding.Id)
                {
                    rowString = "<input type='checkbox' checked='checked' /> " + standardFinding.Label;
                    longdescription = standardFinding.LongDescription;
                }
                htmlRows = htmlRows + rowString;
            }

            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='" + containerId + "']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = htmlRows;
            }

            if (showAdditionalImagesNeeded)
            {
                longdescription = "<i>" + LongDescriptionAdditionalImagesNeeded + "</i>";
            }
            else if (showConsiderOtherModalities)
            {
                longdescription = "<i>" + LongDescriptionConsiderOtherModalities + "</i>";
            }
            else if (unableScreenReason != null)
            {
                longdescription = string.IsNullOrEmpty(unableScreenReason.Description) ? "<i>" + LongDescriptionFortestnotScreened + "</i>" : unableScreenReason.Description;
            }
            else if (findingForLongDescription != null && !string.IsNullOrEmpty(findingForLongDescription.LongDescription))
            {
                longdescription = findingForLongDescription.LongDescription;
            }
            else if (!isTestPurchased)
            {
                longdescription = "<i>" + LongDescriptionFortestnotPurchased + "</i>";
            }

            if (!string.IsNullOrEmpty(descriptionboxid) && !string.IsNullOrEmpty(longdescription))
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='" + descriptionboxid + "']");
                if (selectedNode != null)
                {
                    selectedNode.InnerHtml = longdescription;
                }
            }
        }

        public void LoadTestMedia(HtmlDocument doc, IEnumerable<ResultMedia> media, string containerId, bool loadImages)
        {
            if (!loadImages) return;

            if (media == null || !media.Any()) return;
            string html = "";
            int counter = 0;

            foreach (var mediaItem in media)
            {
                string tempHtml = "";
                if (counter % 8 == 0)
                    tempHtml = "<tr>";

                if (mediaItem.File.Type == FileType.Image)
                {
                    tempHtml += "<td style='text-align:center;'> <img src='" + StringforMediaDirectory + "/" + mediaItem.File.Path + "' alt='' style='width:64px;height:64px' class='media-img' /> <input type='hidden' value='" + StringforMediaDirectory + "/" + mediaItem.File.Path + "' /> " + "</td>";
                }
                else if (mediaItem.File.Type == FileType.Video)
                {
                    tempHtml += "<td style='text-align:center;'> <img src='" + StringforContentDirectory + "/MovieThumb.gif' alt='' class='media-video' /> <input type='hidden' value='" + StringforMediaDirectory + "/" + Path.GetFileNameWithoutExtension(mediaItem.File.Path) + ".mp4" + "' /> " + "</td>";
                }
                counter++;

                if (counter % 8 == 0)
                {
                    html += tempHtml + "</tr>";
                }
                else
                {
                    html += tempHtml;
                }
            }

            if (counter > 0 && counter % 8 > 0)
                html += "</tr>";

            if (string.IsNullOrEmpty(html)) return;

            var selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='" + containerId + "']");
            if (selectedNode != null) selectedNode.InnerHtml = html;
        }

        public void SetPhysicianRemarks(HtmlDocument doc, TestResult testResult, string followUpCheckBoxId, string criticalCheckBoxId, string physicianRemarksTextboxId)
        {
            if (testResult.PhysicianInterpretation == null) return;

            var selectedNode = doc.DocumentNode.SelectSingleNode(string.Concat("//span[@id='", physicianRemarksTextboxId, "']"));
            var criticalNode = doc.DocumentNode.SelectSingleNode(string.Concat("//input[@id='", criticalCheckBoxId, "']"));

            if (selectedNode != null)
            {
                selectedNode.InnerHtml = testResult.PhysicianInterpretation.Remarks;
                //if (testResult.PhysicianInterpretation.IsCritical && criticalNode == null)
                //    selectedNode.InnerHtml = "(<b>CRITICAL</b>) " + testResult.PhysicianInterpretation.Remarks;
                //else
                //    selectedNode.InnerHtml = testResult.PhysicianInterpretation.Remarks;
            }

            if (testResult.PhysicianInterpretation.IsCritical)
            {
                if (criticalNode != null)
                    criticalNode.SetAttributeValue("checked", "checked");
            }
            else if (testResult.PhysicianInterpretation.FollowUp)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode(string.Concat("//input[@id='", followUpCheckBoxId, "']"));
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("checked", "checked");
            }
        }

        public void SetTechnician(HtmlDocument doc, TestResult testResult, string technicianTextBoxId, string technicianNotesTextboxId, List<OrderedPair<long, string>> technicianIdNamePairs)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode(string.Concat("//span[@id='", technicianNotesTextboxId, "']"));
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = testResult.TechnicianNotes;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode(string.Concat("//input[@id='", technicianNotesTextboxId, "']"));
            if (selectedNode != null)
            {
                selectedNode.SetAttributeValue("value", testResult.TechnicianNotes);
            }

            selectedNode = doc.DocumentNode.SelectSingleNode(string.Concat("//input[@id='", technicianTextBoxId, "']"));
            if (selectedNode != null)
            {
                var technicianName =
                     technicianIdNamePairs.Where(t => t.FirstValue == testResult.ConductedByOrgRoleUserId).Select(
                         t => t.SecondValue).SingleOrDefault();
                selectedNode.SetAttributeValue("value", technicianName);
            }
        }

        public void SetUnableToScreenReasons(HtmlDocument doc, TestType testType, string containerId, IEnumerable<UnableScreenReason> unableScreenReasons)
        {
            IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)testType) ??
                                             new List<UnableScreenReason>();
            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason(0)
                {
                    DisplayName = "Unable to Screen",
                    Reason = UnableToScreenReason.Other
                });

            var selectedNode = doc.DocumentNode.SelectSingleNode(string.Concat("//table[@id='", containerId, "']"));
            string html = "";
            foreach (var unableScreenReason in listUnableScreenReasonData)
            {
                string itemHtml = string.Concat("<input type='checkbox' /> ", unableScreenReason.DisplayName);

                if (unableScreenReasons != null)
                {
                    foreach (var screenReason in unableScreenReasons)
                    {
                        if (unableScreenReason.Reason == screenReason.Reason)
                            itemHtml = string.Concat("<input type='checkbox' checked='checked' /> ",
                                                     unableScreenReason.DisplayName);
                    }
                }
                html += "<td>" + itemHtml + "</td>";
            }

            if (selectedNode != null)
            {
                selectedNode.InnerHtml = "<tr>" + html + "</tr>";
            }
        }

        public void SetFindingsHorizontal<T>(HtmlDocument doc, IEnumerable<StandardFinding<T>> findingsInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId, int colSpecified = 0)
        {
            if (findingsCollection == null || !findingsCollection.Any()) return;

            string htmlRows = "";
            int counter = 0;
            foreach (var standardFinding in findingsCollection)
            {
                string rowString = "<td>";
                if (colSpecified != 0 && counter % colSpecified == 0)
                    rowString = "<tr><td>";

                if (findingsInDb != null && findingsInDb.Any() && findingsInDb.Count(fd => fd.Id == standardFinding.Id) > 0)
                    rowString += "<input type='checkbox' checked='checked' /> " + standardFinding.Label;
                else
                    rowString += "<input type='checkbox' /> " + standardFinding.Label;

                if (colSpecified != 0 && counter % colSpecified == (colSpecified - 1))
                    rowString += "</td></tr>";
                else
                    rowString += "</td>";

                htmlRows = htmlRows + rowString;
                counter++;
            }

            if (colSpecified == 0)
                htmlRows = "<tr>" + htmlRows + "</tr>";
            else if (colSpecified != 0 && counter % colSpecified == (colSpecified - 1))
                htmlRows += "</td></tr>";

            var selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='" + containerId + "']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = htmlRows;
            }
        }

        public void SetFindingsHorizontal<T>(HtmlDocument doc, StandardFinding<T> findingInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId, int colSpecified = 0)
        {
            if (findingsCollection == null || !findingsCollection.Any()) return;

            string htmlRows = "";
            int counter = 0;
            foreach (var standardFinding in findingsCollection)
            {
                string rowString = "<td>";
                if (colSpecified != 0 && counter % colSpecified == 0)
                    rowString = "<tr><td>";

                if (findingInDb != null && findingInDb.Id == standardFinding.Id)
                    rowString += "<input type='checkbox' checked='checked' /> " + standardFinding.Label;
                else
                    rowString += "<input type='checkbox' /> " + standardFinding.Label;

                if (colSpecified != 0 && counter % colSpecified == (colSpecified - 1))
                    rowString += "</td></tr>";
                else
                    rowString += "</td>";

                htmlRows = htmlRows + rowString;
                counter++;
            }

            if (colSpecified == 0)
                htmlRows = "<tr>" + htmlRows + "</tr>";
            else if (colSpecified != 0 && counter % colSpecified == (colSpecified - 1))
                htmlRows += "</td></tr>";

            var selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='" + containerId + "']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = htmlRows;
            }
        }

        public void SetFindingsVertical<T>(HtmlDocument doc, StandardFinding<T> findingInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId)
        {
            if (findingsCollection == null || !findingsCollection.Any()) return;

            string htmlRows = "";
            foreach (var standardFinding in findingsCollection)
            {
                string rowString = "<tr><td> <input type='checkbox' /> </td>";
                if (findingInDb != null && findingInDb.Id == standardFinding.Id)
                {
                    rowString = "<tr><td> <input type='checkbox' checked='checked' /> </td>";
                }
                rowString += "<td> " + standardFinding.Label + " " + standardFinding.Description.Replace("<", "&lt;").Replace(">", "&gt;") + "</td></tr>";
                htmlRows = htmlRows + rowString;
            }

            var selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='" + containerId + "']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = htmlRows;
            }
        }

        public void SetIncidentalFindings(HtmlDocument doc, IEnumerable<IncidentalFinding> allFortheTest, IEnumerable<IncidentalFinding> recordedForthecurrentRecord, string containerId)
        {
            if (allFortheTest == null || allFortheTest.Count() < 1) return;

            string html = string.Empty;
            if (recordedForthecurrentRecord == null) recordedForthecurrentRecord = new List<IncidentalFinding>();

            foreach (var finding in allFortheTest)
            {
                var selectedFinding = (from item in recordedForthecurrentRecord where item.Id == finding.Id select item).FirstOrDefault();

                if (selectedFinding != null)
                {
                    string tempHtml = " ";

                    tempHtml = "<td> <input type='checkbox' checked='checked' /> " + finding.Label + " </td>";
                    if (selectedFinding.IncidentalFindingGroups != null && selectedFinding.IncidentalFindingGroups.Count() > 0)
                    {
                        foreach (var group in selectedFinding.IncidentalFindingGroups.Where(ifg => ifg.GroupItems != null && ifg.GroupItems.Count > 0).ToArray())
                        {
                            if (!string.IsNullOrEmpty(group.GroupItems.First().Value))
                            {
                                Int32 tempwidth = 0;
                                tempwidth = group.GroupItems.First().Value.Length * 8;
                                if (tempwidth < 40) tempwidth = 40;
                                else if (tempwidth > 100) tempwidth = 100;
                                tempHtml = "<td> <input type='checkbox' checked='checked' /> " + finding.Label + " <input type='text' style='width:" + tempwidth + "px;' value='" + group.GroupItems.First().Value + "' /> </td>";
                            }
                        }
                    }

                    html += tempHtml;
                }
                else
                {
                    html += "<td> <input type='checkbox' /> " + finding.Label + " </td>";
                }
            }

            if (string.IsNullOrEmpty(html)) return;

            var selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='" + containerId + "']");
            if (selectedNode != null)
                selectedNode.InnerHtml = "<tr>" + html + "</tr>";
        }

        public bool ShowHideRepeatStudyCheckbox(DateTime eventDate, long eventId, long customerId)
        {
            var showRepeatStudyCheckbox = false;

            var showHideRepeatStudyDate = _settings.ShowHideRepeatStudyDate;

            if (eventDate <= showHideRepeatStudyDate.Date)
            {
                var physicianEvaluation = _physicianEvaluationRepository.GetPhysicianEvaluationbyEventIdCustomerId(eventId, customerId);

                showRepeatStudyCheckbox = physicianEvaluation != null && physicianEvaluation.EvaluationStartTime < showHideRepeatStudyDate.Date;
            }

            return showRepeatStudyCheckbox;
        }

        public void ShowHideRepeatStudy(HtmlDocument doc, string containerDivId, bool showRepeatStudyCheckbox)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='" + containerDivId + "']");
            if (selectedNode != null)
            {
                selectedNode.SetAttributeValue("style", showRepeatStudyCheckbox ? "display:block" : "display:none");
            }
        }

        public void ShowHideOtherModalitiesAdditionalImages(HtmlDocument doc, string containerDivId, bool showOtherModalitiesAdditionalImages)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='" + containerDivId + "']");
            if (selectedNode != null)
            {
                selectedNode.SetAttributeValue("style", showOtherModalitiesAdditionalImages ? "display:block" : "display:none");
            }
        }

        public void SetPhysicianSignature(HtmlDocument doc, string priamryPhysicianContainerId, string overReadPhysicianControlId, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            if (physicians == null || physicians.Count() < 1) return;

            var physicianUrl = StringforContentDirectory + "/";

            if (eventPhysicianTests != null && eventPhysicianTests.Any())
            {
                try
                {
                    var eventPhysicianTest = eventPhysicianTests.First();

                    var physician = physicians.First(p => p.PhysicianId == eventPhysicianTest.PhysicianId);
                    var selectedNode = doc.DocumentNode.SelectSingleNode("//td[@id='" + priamryPhysicianContainerId + "']");

                    if (selectedNode != null)
                    {
                        var htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + "</span>";

                        if (customerSkipReview != null)
                        {
                            htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " On " + customerSkipReview.DateCreated.ToString("MM/dd/yyyy") + " at " + customerSkipReview.DateCreated.ToString("hh:mm tt") + "  </span>";
                        }
                        else
                        {
                            var evaluationTime = GetPhysicianEvaluationTime(eventCustomerPhysicianEvaluations, physician.PhysicianId);
                            if (evaluationTime != null)
                            {
                                htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " On " + evaluationTime.Value.ToString("MM/dd/yyyy") + " at " + evaluationTime.Value.ToString("hh:mm tt") + "  </span>";
                            }
                        }


                        selectedNode.InnerHtml = htmlString;
                    }

                    eventPhysicianTest = eventPhysicianTests.ElementAtOrDefault(1);
                    if (eventPhysicianTest != null)
                    {
                        physician = physicians.First(p => p.PhysicianId == eventPhysicianTest.PhysicianId); ;
                        selectedNode = doc.DocumentNode.SelectSingleNode("//td[@id='" + overReadPhysicianControlId + "']");

                        if (selectedNode != null && physician != null)
                        {
                            var htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " </span>";

                            if (customerSkipReview != null)
                            {
                                htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " On " + customerSkipReview.DateCreated.ToString("MM/dd/yyyy") + " at " + customerSkipReview.DateCreated.ToString("hh:mm tt") + "</span>";
                            }
                            else
                            {
                                var evaluationTime = GetPhysicianEvaluationTime(eventCustomerPhysicianEvaluations, physician.PhysicianId);
                                if (evaluationTime != null)
                                {
                                    htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " On " + evaluationTime.Value.ToString("MM/dd/yyyy") + " at " + evaluationTime.Value.ToString("hh:mm tt") + "</span>";
                                }
                            }

                            selectedNode.InnerHtml = htmlString;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                var physician = physicians.First();
                var selectedNode = doc.DocumentNode.SelectSingleNode("//td[@id='" + priamryPhysicianContainerId + "']");

                if (selectedNode != null)
                {
                    var htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " </span>"; ;

                    if (customerSkipReview != null)
                    {
                        htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " On " + customerSkipReview.DateCreated.ToString("MM/dd/yyyy") + " at " + customerSkipReview.DateCreated.ToString("hh:mm tt") + "</span>";
                    }
                    else
                    {
                        var evaluationTime = GetPhysicianEvaluationTime(eventCustomerPhysicianEvaluations, physician.PhysicianId);
                        if (evaluationTime != null)
                        {
                            htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " On " + evaluationTime.Value.ToString("MM/dd/yyyy") + " at " + evaluationTime.Value.ToString("hh:mm tt") + "</span>";
                        }
                    }

                    selectedNode.InnerHtml = htmlString;
                }

                physician = physicians.ElementAtOrDefault(1);
                selectedNode = doc.DocumentNode.SelectSingleNode("//td[@id='" + overReadPhysicianControlId + "']");
                if (selectedNode != null && physician != null)
                {
                    var htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " </span>";

                    if (customerSkipReview != null)
                    {
                        htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " On " + customerSkipReview.DateCreated.ToString("MM/dd/yyyy") + " at " + customerSkipReview.DateCreated.ToString("hh:mm tt") + "</span>";
                    }
                    else
                    {
                        var evaluationTime = GetPhysicianEvaluationTime(eventCustomerPhysicianEvaluations, physician.PhysicianId);
                        if (evaluationTime != null)
                        {
                            htmlString = "<img src='" + physicianUrl + physician.PhysicianSignatureFilePath + "' style='width:200px; height:60px;' alt='' /> <span style='display:block;'> By: " + physician.PhysicianName + " On " + evaluationTime.Value.ToString("MM/dd/yyyy") + " at " + evaluationTime.Value.ToString("hh:mm tt") + "</span>";
                        }
                    }


                    selectedNode.InnerHtml = htmlString;
                }
            }
        }

        private DateTime? GetPhysicianEvaluationTime(IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, long physicianId)
        {

            if (eventCustomerPhysicianEvaluations.IsNullOrEmpty()) return null;

            var evaluationTimeStamp = eventCustomerPhysicianEvaluations.FirstOrDefault(x => x.PhysicianId == physicianId);

            if (evaluationTimeStamp == null) return null;

            var evaluationTime = evaluationTimeStamp.EvaluationEndTime.HasValue ? evaluationTimeStamp.EvaluationEndTime.Value : evaluationTimeStamp.EvaluationStartTime;

            return evaluationTime;
        }


        public void SetFindingsDropdown<T>(HtmlDocument doc, StandardFinding<T> findingInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId)
        {
            if (findingsCollection == null || !findingsCollection.Any()) return;

            var selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='" + containerId + "']");

            if (selectedNode != null)
            {
                foreach (var standardFinding in findingsCollection)
                {
                    if (findingInDb != null && findingInDb.Id == standardFinding.Id)
                    {
                        selectedNode.SetAttributeValue("value", standardFinding.Label);
                    }
                }
            }
        }
    }
}
