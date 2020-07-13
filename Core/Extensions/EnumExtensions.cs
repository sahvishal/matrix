using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this System.Enum enumToUse)
        {
            var memberInfo = enumToUse.GetType().GetMember(enumToUse.ToString());
            if (memberInfo.Length < 1) return enumToUse.ToString();

            var descriptionAttribute = (DescriptionAttribute)memberInfo.FirstOrDefault().GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            if (descriptionAttribute == null) return enumToUse.ToString();
            return descriptionAttribute.Description;
        }

        public static List<OrderedPair<int, string>> GetNameValuePairs(this System.Enum enumToUse)
        {
            var typeOfEnum = enumToUse.GetType();
            var orderedNameValuePairs = new List<OrderedPair<int, string>>();
            foreach (var value in System.Enum.GetValues(typeOfEnum))
            {
                orderedNameValuePairs.Add(new OrderedPair<int, string>(Convert.ToInt32(value),
                                                                       ((System.Enum)value).GetDescription()));
            }
            return orderedNameValuePairs;
        }

        public static TestResultStateNumber GetResultStatefromPresentation(this TestResultStateLabel enumToUse, out bool isPartial)
        {
            TestResultStateNumber number = 0;
            isPartial = false;

            switch (enumToUse)
            {
                case TestResultStateLabel.NoResults:
                    number = TestResultStateNumber.NoResults;
                    break;
                case TestResultStateLabel.Evaluated:
                    number = TestResultStateNumber.Evaluated;
                    break;
                case TestResultStateLabel.ManualEntry:
                    number = TestResultStateNumber.ManualEntry;
                    break;
                case TestResultStateLabel.ManualEntryPartial:
                    number = TestResultStateNumber.ManualEntry;
                    isPartial = true;
                    break;
                case TestResultStateLabel.OverreadPending:
                    number = TestResultStateNumber.Evaluated;
                    isPartial = true;
                    break;

                case TestResultStateLabel.ParsingFailure:
                    number = TestResultStateNumber.NoResults;
                    break;

                case TestResultStateLabel.PostAudit:
                    number = TestResultStateNumber.PostAudit;
                    isPartial = true;
                    break;

                case TestResultStateLabel.PostAuditWithPdf:
                    number = TestResultStateNumber.PostAudit;
                    break;

                case TestResultStateLabel.PreAudit:
                    number = TestResultStateNumber.PreAudit;
                    break;

                case TestResultStateLabel.ResultDelivered:
                    number = TestResultStateNumber.ResultDelivered;
                    break;

                case TestResultStateLabel.ResultUploaded:
                    number = TestResultStateNumber.ResultsUploaded;
                    break;

                case TestResultStateLabel.ResultUploadedPartial:
                    number = TestResultStateNumber.ResultsUploaded;
                    isPartial = true;
                    break;

                case TestResultStateLabel.SentBackForCorrection:
                    number = TestResultStateNumber.PreAudit;
                    isPartial = true;
                    break;
            }

            return number;
        }

        public static TestResultStateLabel GetPresentationfromResultState(this TestResultStateNumber enumToUse, bool isPartial)
        {
            TestResultStateLabel label = 0;

            switch (enumToUse)
            {
                case TestResultStateNumber.Evaluated:
                    label = isPartial ? TestResultStateLabel.OverreadPending : TestResultStateLabel.Evaluated;
                    break;

                case TestResultStateNumber.ManualEntry:
                    label = isPartial ? TestResultStateLabel.ManualEntryPartial : TestResultStateLabel.ManualEntry;
                    break;

                case TestResultStateNumber.NoResults:
                    label = TestResultStateLabel.NoResults;
                    break;

                case TestResultStateNumber.PostAudit:
                    label = isPartial ? TestResultStateLabel.PostAudit : TestResultStateLabel.PostAuditWithPdf;
                    break;

                case TestResultStateNumber.PreAudit:
                    label = isPartial ? TestResultStateLabel.SentBackForCorrection : TestResultStateLabel.PreAudit;
                    break;

                case TestResultStateNumber.ResultDelivered:
                    label = TestResultStateLabel.ResultDelivered;
                    break;

                case TestResultStateNumber.ResultsUploaded:
                    label = isPartial ? TestResultStateLabel.ResultUploadedPartial : TestResultStateLabel.ResultUploaded;
                    break;
            }

            return label;
        }

        public static NewTestResultStateNumber GetNewResultStatefromPresentation(this TestResultStateLabel enumToUse, out bool isPartial, out bool isChartSignedOff)
        {

            NewTestResultStateNumber number = 0;
            isPartial = false;
            isChartSignedOff = false;

            switch (enumToUse)
            {

                case TestResultStateLabel.NoResults:
                    number = NewTestResultStateNumber.NoResults;
                    break;

                case TestResultStateLabel.NoResultsChartSigned:
                    number = NewTestResultStateNumber.NoResults;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.ResultEntryPartialChartNotSigned:
                    number = NewTestResultStateNumber.ResultEntryPartial;
                    break;

                case TestResultStateLabel.ResultEntryPartialChartSigned:
                    number = NewTestResultStateNumber.ResultEntryPartial;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.ResultEntryCompletedChartNotSigned:
                    number = NewTestResultStateNumber.ResultEntryCompleted;
                    break;

                case TestResultStateLabel.ResultEntryCompletedChartSigned:
                    number = NewTestResultStateNumber.ResultEntryCompleted;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.PreAudit: // Undo Pre-Audit
                    number = NewTestResultStateNumber.PreAudit;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.SentBackForCorrection:
                    number = NewTestResultStateNumber.PreAudit;
                    isPartial = true;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.Evaluated:
                    number = NewTestResultStateNumber.Evaluated;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.OverreadPending:
                    number = NewTestResultStateNumber.Evaluated;
                    isPartial = true;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.NpNotificationSent:
                    number = NewTestResultStateNumber.NpNotificationSent;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.NpSigned://Undo Coding
                    number = NewTestResultStateNumber.NpSigned;
                    isChartSignedOff = true;
                    isPartial = true;
                    break;

                case TestResultStateLabel.ReadyForCoding://Undo Coding
                    number = NewTestResultStateNumber.NpSigned;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.CodingCompleted:
                    number = NewTestResultStateNumber.CodingCompleted;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.ArtifactSynced:
                    number = NewTestResultStateNumber.ArtifactSynced;
                    isChartSignedOff = true;
                    break;


                case TestResultStateLabel.PostAudit: //Undo Post Audit
                    number = NewTestResultStateNumber.PostAuditNew;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.PdfGeneratedWaitingForAces:
                    number = NewTestResultStateNumber.PdfGenerated;
                    isChartSignedOff = true;
                    break;

                case TestResultStateLabel.ResultDelivered:
                    number = NewTestResultStateNumber.ResultDelivered;
                    isChartSignedOff = true;
                    break;
            }

            return number;
        }

        public static TestResultStateLabel GetNewPresentationfromResultState(this NewTestResultStateNumber enumToUse, bool isPartial, bool isChartSignedOff)
        {
            TestResultStateLabel label = 0;
            switch (enumToUse)
            {
                case NewTestResultStateNumber.NoResults:
                    label = isChartSignedOff ? TestResultStateLabel.NoResultsChartSigned : TestResultStateLabel.NoResults;
                    break;
                case NewTestResultStateNumber.ResultEntryPartial:
                    label = isChartSignedOff ? TestResultStateLabel.ResultEntryPartialChartSigned : TestResultStateLabel.ResultEntryPartialChartNotSigned;
                    break;
                case NewTestResultStateNumber.ResultEntryCompleted:
                    label = isChartSignedOff ? TestResultStateLabel.ResultEntryCompletedChartSigned : TestResultStateLabel.ResultEntryCompletedChartNotSigned;
                    break;
                case NewTestResultStateNumber.PreAudit:
                    label = isPartial ? TestResultStateLabel.SentBackForCorrection : TestResultStateLabel.PreAudit;
                    break;
                case NewTestResultStateNumber.Evaluated:
                    label = isPartial ? TestResultStateLabel.OverreadPending : TestResultStateLabel.Evaluated;
                    break;
                case NewTestResultStateNumber.NpNotificationSent:
                    label = TestResultStateLabel.NpNotificationSent;
                    break;
                case NewTestResultStateNumber.NpSigned:
                    label = isPartial ? TestResultStateLabel.NpSigned : TestResultStateLabel.ReadyForCoding;
                    break;
                case NewTestResultStateNumber.CodingCompleted:
                    label = TestResultStateLabel.CodingCompleted;
                    break;
                case NewTestResultStateNumber.ArtifactSynced:
                    label = TestResultStateLabel.ArtifactSynced;
                    break;
                case NewTestResultStateNumber.PostAuditNew:
                    label = TestResultStateLabel.PostAudit;
                    break;
                case NewTestResultStateNumber.PdfGenerated:
                    label = TestResultStateLabel.PdfGeneratedWaitingForAces;
                    break;
                case NewTestResultStateNumber.ResultDelivered:
                    label = TestResultStateLabel.ResultDelivered;
                    break;
            }

            return label;
        }

        public static string GetRegExpression(this ChargeCardType element)
        {
            switch (element)
            {
                case ChargeCardType.Visa:
                    return "^4[0-9]{12}(?:[0-9]{3})?$";
                case ChargeCardType.MasterCard:
                    return "^5[1-5][0-9]{14}$";
                case ChargeCardType.Discover:
                    return "^6(?:011|5[0-9]{2})[0-9]{12}$";
                case ChargeCardType.AmericanExpress:
                    return "^3[47][0-9]{13}$";
                default:
                    throw new InvalidOperationException("Can't validate Card type '" + element.GetDescription() + "', as there is no regular expression provided!");
            }
        }

        public static long? GetMax(this ResultInterpretation resultInterpretation, IEnumerable<long> resultInterpretations)
        {
            if (resultInterpretations == null || resultInterpretations.Count() < 1) return null;

            if (resultInterpretations.Any(i => i == (long)ResultInterpretation.Critical))
                return (long)ResultInterpretation.Critical;

            if (resultInterpretations.Any(i => i == (long)ResultInterpretation.Urgent))
                return (long)ResultInterpretation.Urgent;

            if (resultInterpretations.Any(i => i == (long)ResultInterpretation.Abnormal))
                return (long)ResultInterpretation.Abnormal;

            return (long)ResultInterpretation.Normal;
        }

        public static long? GetMax(this PathwayRecommendation recommendation, IEnumerable<long> pathwayRecommendations)
        {
            if (pathwayRecommendations == null || pathwayRecommendations.Count() < 1) return null;

            if (pathwayRecommendations.Any(i => i == (long)PathwayRecommendation.Specialist))
                return (long)PathwayRecommendation.Specialist;

            if (pathwayRecommendations.Any(i => i == (long)PathwayRecommendation.Pcp))
                return (long)PathwayRecommendation.Pcp;

            return (long)PathwayRecommendation.None;
        }
    }
}
