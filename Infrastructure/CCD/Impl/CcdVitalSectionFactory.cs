using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.CCD.ValueType;
using Falcon.App.Core.CCD.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using HtmlAgilityPack;

namespace Falcon.App.Infrastructure.CCD.impl
{
    public class CcdVitalSectionFactory
    {
        public Section GetVitalSection(Customer customer, Event eventData, IEnumerable<Test> tests, ISettings settings)
        {
            var observations = new List<Observation>();
            var isHypertenstionTestPurchased = false;
            if (!tests.IsNullOrEmpty())
            {
                isHypertenstionTestPurchased = tests.Any(x => x.Id == (long)TestType.Hypertension && x.IsRecordable);
            }

            return new Section
            {
                TemplateId = new ClinicalRoot(DateTime.Today.ToString("yyyy-MM-dd"), ClinicalDocumentRoots.VitalSectionTemplateRootId),
                Title = "Vital Signs (Last Filed)",
                Code = ClinicalDocumentHelper.LoincCodes.Single(x => x.FirstValue == LoincCode.VitalSigns).SecondValue,
                HtmlText = GetVitalSignsHtml(customer, eventData, observations, isHypertenstionTestPurchased, settings),
                Entery = new [] { CreateVitalEntery(observations) }
            };
        }

        private static decimal BmiCalculator(double weightInPounds, double heightInInches)
        {
            var bmiIndex = (weightInPounds < 1 || heightInInches < 1) ? 0 : (weightInPounds / Math.Pow(heightInInches, 2)) * 703;
            return decimal.Parse(bmiIndex.ToString("##.##"));
        }

        private string GetVitalSignsHtml(Customer customer, Event eventData, List<Observation> observations, bool isHypertenstionTestPurchased, ISettings settings)
        {
            var weight = customer.Weight;
            var height = customer.Height;
            var headerRow = HtmlNode.CreateNode("<tr></tr>");
            var dataRow = HtmlNode.CreateNode("<tr></tr>");

            observations = observations ?? new List<Observation>();
            bool isCellAdded = false;
            if (weight != null && weight.Pounds > 1 && height != null && height.TotalInches > 1)
            {
                var bmiIndex = BmiCalculator(weight.Pounds, height.TotalInches);
                headerRow.AppendChild(HtmlNode.CreateNode("<th>BMI</th>"));
                dataRow.AppendChild(HtmlNode.CreateNode("<td id='BMI_1'>" + bmiIndex + "</td>"));

                headerRow.AppendChild(HtmlNode.CreateNode("<th >Height</th>"));
                dataRow.AppendChild(HtmlNode.CreateNode("<td Id='Height_1'>" + height.TotalInches + "</td>"));

                headerRow.AppendChild(HtmlNode.CreateNode("<th>Height Units</th>"));
                dataRow.AppendChild(HtmlNode.CreateNode("<td>inches</td>"));

                headerRow.AppendChild(HtmlNode.CreateNode("<th>Weight</th>"));
                dataRow.AppendChild(HtmlNode.CreateNode("<td Id='Weight_1'>" + weight.Pounds + "</td>"));

                headerRow.AppendChild(HtmlNode.CreateNode("<th>Weight Units</th>"));
                dataRow.AppendChild(HtmlNode.CreateNode("<td>lbs</td>"));

                //Height Observatoin
                var observartion = new Observation
                {
                    TemplateId = new ClinicalRoot[]{ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.BloodPressures).SecondValue},
                    Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.Height).SecondValue,
                    Reference = " <reference value='#Height_1'/>",
                    StatusCode = new StatusCode { Code = "completed" },
                    ObservationValue = new ObservationValue { Value = height.TotalInches.ToString(), Unit = "inches" }
                };

                observations.Add(observartion);

                //Weight Observatoin
                observartion = new Observation
                {
                    TemplateId = new ClinicalRoot[]{ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.BloodPressures).SecondValue},
                    Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.Weight).SecondValue,
                    Reference = " <reference value='#Weight_1'/>",
                    StatusCode = new StatusCode { Code = "completed" },
                    ObservationValue = new ObservationValue { Value = weight.Pounds.ToString(), Unit = "lbs" }
                };
                observations.Add(observartion);

                //BMI Observatoin
                observartion = new Observation
                {
                    TemplateId = new ClinicalRoot[]{ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.BloodPressures).SecondValue},
                    Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.Bmi).SecondValue,
                    Reference = " <reference value='#BMI_1'/>",
                    StatusCode = new StatusCode { Code = "completed" },
                    ObservationValue = new ObservationValue { Value = bmiIndex.ToString() }
                };

                observations.Add(observartion);

                isCellAdded = true;
            }


            if (isHypertenstionTestPurchased)
            {
                ITestResultRepository testResultRepository = new HypertensionTestRepository();

                var isNewResultFlow = eventData.EventDate >= settings.ResultFlowChangeDate;

                var hyperTenstionTestResult = (HypertensionTestResult)testResultRepository.GetTestResults(customer.CustomerId, eventData.Id, isNewResultFlow);

                if (hyperTenstionTestResult != null && (hyperTenstionTestResult.TestNotPerformed == null || hyperTenstionTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0) && (hyperTenstionTestResult.UnableScreenReason == null || hyperTenstionTestResult.UnableScreenReason.Count == 0))
                {
                    var systolic = Reading(hyperTenstionTestResult.Systolic);
                    var diastolic = Reading(hyperTenstionTestResult.Diastolic);

                    var pulse = Reading(hyperTenstionTestResult.Pulse);
                    if (!string.IsNullOrEmpty(systolic) || !string.IsNullOrEmpty(diastolic))
                    {
                        isCellAdded = true;
                        headerRow.AppendChild(HtmlNode.CreateNode("<th>Blood Pressure</th>"));
                        dataRow.AppendChild(HtmlNode.CreateNode("<td><content ID='SystolicBP_1'>" + systolic + "</content>/<content ID='DiastolicBP_1'>" + diastolic + "</content>mm[Hg] </td></td>"));

                        if (!string.IsNullOrEmpty(systolic))
                        {
                            var observartion = new Observation
                            {
                                TemplateId = new ClinicalRoot[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.BloodPressures).SecondValue},
                                Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.SystolicBloodPressures).SecondValue,
                                Reference = " <reference value='#SystolicBP_1'/>",
                                StatusCode = new StatusCode { Code = "completed" },
                                ObservationValue = new ObservationValue { Value = systolic, Unit = "mm[Hg]" }
                            };
                            observations.Add(observartion);
                        }

                        if (!string.IsNullOrEmpty(diastolic))
                        {
                            var observartion = new Observation
                            {
                                TemplateId = new ClinicalRoot[]{  ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.BloodPressures).SecondValue},
                                Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.DiastolicBloodPressures).SecondValue,
                                Reference = " <reference value='#DiastolicBP_1'/>",
                                StatusCode = new StatusCode { Code = "completed" },
                                ObservationValue = new ObservationValue { Value = diastolic, Unit = "mm[Hg]" }
                            };
                            observations.Add(observartion);
                        }

                    }

                    if (!string.IsNullOrEmpty(pulse))
                    {
                        isCellAdded = true;
                        headerRow.AppendChild(HtmlNode.CreateNode("<th>pulse</th>"));
                        dataRow.AppendChild(HtmlNode.CreateNode("<td ID='Pulse_1'>" + pulse + " /min</td>"));

                        var observartion = new Observation
                        {
                            TemplateId = new ClinicalRoot[]{ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.BloodPressures).SecondValue},
                            Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.HeartRate).SecondValue,
                            Reference = " <reference value='#Pulse_1'/>",
                            StatusCode = new StatusCode { Code = "completed" },
                            ObservationValue = new ObservationValue { Value = pulse, Unit = "/min" }
                        };

                        observations.Add(observartion);

                    }
                }
            }

            if (isCellAdded)
            {
                var htmlDoc = new HtmlDocument();
                var tableNode = htmlDoc.CreateElement("table");
                var thead = HtmlNode.CreateNode("<thead></thead>");
                var tbody = HtmlNode.CreateNode("<tbody></tbody>");
                thead.AppendChild(headerRow);
                tbody.AppendChild(dataRow);

                tableNode.AppendChild(thead);
                tableNode.AppendChild(tbody);

                return tableNode.OuterHtml;
            }

            return string.Empty;

        }

        private Entry CreateVitalEntery(List<Observation> observation)
        {
            var templateValue = ClinicalDocumentHelper.ClinicalRoots.First(c => c.FirstValue == ClinicalRootType.VitalSigns).SecondValue;
            var code = ClinicalDocumentHelper.LoincCodes.First(cc => cc.FirstValue == LoincCode.VitalSignsCode).SecondValue;

            return new Entry
            {
                TypeCode = ClinicalDocumentFactory.VitalSignEntery,
                Organizer = new Organizer
                {
                    ClassCode = ClinicalDocumentFactory.OrganizerClassCode,
                    MoodCode = ClinicalDocumentFactory.OrganizerMoodCode,
                    TemplateId = templateValue,
                    // Id = new ClinicalRoot(Guid.NewGuid().ToString()),
                    Code = code,
                    StatusCode = new StatusCode { Code = "completed" },
                    Component = SetComponents(observation)

                }
            };
        }
        private Component[] SetComponents(List<Observation> observation)
        {
            if (observation.IsNullOrEmpty()) return null;

            return observation.Select(obesrvation => new Component { Obesrvation = obesrvation }).ToArray();
        }
        private string Reading<T>(ResultReading<T> resultReading)
        {
            return (resultReading != null && resultReading.Reading != null) ? resultReading.Reading.ToString() : string.Empty;
        }
    }
}