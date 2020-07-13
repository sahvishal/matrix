using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using HtmlAgilityPack;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class TestNotPerformedHelper : ITestNotPerformedHelper
    {
        private readonly ITestRepository _testRepository;
        private readonly string _htmlFilePathTestNotPerformed;
        private const int MaxTestPerSection = 5;

        public TestNotPerformedHelper(ISettings settings, ITestRepository testRepository)
        {
            _testRepository = testRepository;
            _htmlFilePathTestNotPerformed = settings.TemplateTestNotPerformedLocation;
        }

        public void CreateTestNotPerformedPage(HtmlDocument resultDocument, IEnumerable<TestResult> testResults)
        {
            if (testResults == null || !testResults.Any()) return;

            var testNotPerformedResults = testResults.Where(x => x.TestNotPerformed != null);

            if (testNotPerformedResults == null || !testNotPerformedResults.Any()) return;

            var testInCurrentSection = 1;

            var sb = new StringBuilder();

            foreach (var testNotPerformedResult in testNotPerformedResults)
            {
                var testnotPerformed = testNotPerformedResult.TestNotPerformed;
                var testName = GetTestName((long)testNotPerformedResult.TestType);

                var testNotPerformedReason = (TestNotPerformedReasonType)testnotPerformed.TestNotPerformedReasonId;

                sb.Append("<div class='section'><div class='testnotperformed-name testsection-header'>");
                sb.Append(testName);
                sb.Append("</div><div class='testnotperformed-reason'><b>Reason: </b>");
                sb.Append(testNotPerformedReason.GetDescription());
                sb.Append("</div>");

                if (!string.IsNullOrEmpty(testnotPerformed.Notes))
                {
                    sb.Append("<div class='testnotperformed-notes'><b>Notes: </b>");
                    sb.Append(testnotPerformed.Notes);
                    sb.Append("</div>");
                }

                sb.Append("</div>");


                if (MaxTestPerSection == testInCurrentSection)
                {
                    SetTestNotPerformedSectionToResultPdf(resultDocument, sb);

                    sb = new StringBuilder();

                    testInCurrentSection = 1;
                }
                else
                {
                    testInCurrentSection++;
                }
            }

            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                SetTestNotPerformedSectionToResultPdf(resultDocument, sb);
            }
        }

        private void SetTestNotPerformedSectionToResultPdf(HtmlDocument resultDocument, StringBuilder sb)
        {
            var doc = new HtmlDocument();
            doc.Load(_htmlFilePathTestNotPerformed);

            var section = doc.DocumentNode.SelectSingleNode("//div[@id='testNotPerformedTemplate']/div");
            if (section == null) return;

            var testNotPerformed = doc.DocumentNode.SelectSingleNode("//div[@class='testNotPerformed-section']");

            testNotPerformed.InnerHtml = sb.ToString();

            var testNotPerformedSection = resultDocument.DocumentNode.SelectSingleNode("//div[@id='TestNotPerformed']");

            if (testNotPerformedSection == null) return;

            testNotPerformedSection.AppendChild(section);

            testNotPerformedSection.SetAttributeValue("style", "display:block;");

        }

        private string GetTestName(long testId)
        {
            var testOrderPair = TestNamesOrderedPairs.FirstOrDefault(x => x.FirstValue == testId);
            if (testOrderPair == null)
                return string.Empty;

            return testOrderPair.SecondValue.ToUpper();
        }

        public static IEnumerable<OrderedPair<long, string>> TestNamesOrderedPairs
        {
            get
            {
                return new[]
                {
                    new OrderedPair<long, string>(9,"BONE DENSITY"),
                    new OrderedPair<long, string>(29,"Mammogram "),
                    new OrderedPair<long, string>(31,"FluShot"),
                    new OrderedPair<long, string>(35,"LOWER EXTREMITY ARTERIAL DUPLEX (LEAD)"),
                    new OrderedPair<long, string>(43,"Depression Assessment Score(PHQ-9)"),
                    new OrderedPair<long, string>(44,"VISION "),
                    new OrderedPair<long, string>(45,"Hearing "),
                    new OrderedPair<long, string>(47,"ECHOCARDIOGRAM "),
                    new OrderedPair<long, string>(48,"STROKE/CAROTID ARTERY "),
                    new OrderedPair<long, string>(49,"ABDOMINAL AORTA ANEURYSM (AAA) "),
                    new OrderedPair<long, string>(50,"ELECTROCARDIOGRAM (EKG) "),
                    new OrderedPair<long, string>(51,"ELECTROCARDIOGRAM (EKG) "),
                    new OrderedPair<long, string>(52,"SPIROMETRY/PFT "),
                    new OrderedPair<long, string>(53,"PERIPHERAL ARTERIAL DISEASE (PAD/ABI) "),
                    new OrderedPair<long, string>(54,"ECHOCARDIOGRAM "),
                    new OrderedPair<long, string>(55,"ABDOMINAL AORTA ANEURYSM (AAA) "),
                    new OrderedPair<long, string>(56,"STROKE/CAROTID ARTERY "),
                    new OrderedPair<long, string>(57,"Lipid Panel"),
                    new OrderedPair<long, string>(58,"GLUCOSE "),
                    new OrderedPair<long, string>(59,"HBA1-C"),
                    new OrderedPair<long, string>(60,"BONE DENSITY "),
                    new OrderedPair<long, string>(61,"CHOLESTEROL "),
                    new OrderedPair<long, string>(62,"DIABETES "),
                    new OrderedPair<long, string>(63,"HELICOBACTER PYLORI "),
                    new OrderedPair<long, string>(67,"Blood Pressure Evaluation Test"),
                    new OrderedPair<long, string>(70,"Diabetic Neuropathy"),
                    new OrderedPair<long, string>(71,"Diabetes Foot Exam "),
                    new OrderedPair<long, string>(73,"Diabetic Retinopathy "),
                    new OrderedPair<long, string>(74,"Pneumococcal"),
                    new OrderedPair<long, string>(75,"IFOBT "),
                    new OrderedPair<long, string>(81,"e-AWV"),
                    new OrderedPair<long, string>(83,"FluShot"),
                    new OrderedPair<long, string>(84,"Quality Measures"),
                    new OrderedPair<long, string>(85,"RINNE AND WEBER HEARING"),
                    new OrderedPair<long, string>(88,"FLO CHEC "),
                    new OrderedPair<long, string>(89,"URINE MICROALBUMIN "),
                    new OrderedPair<long, string>(91,"MONOFILAMENT "),
                    new OrderedPair<long, string>(92,"FOC/Attestation"),
                    new OrderedPair<long, string>(93,"Chlamydia Screening")
                    
                };
            }
        }
    }
}