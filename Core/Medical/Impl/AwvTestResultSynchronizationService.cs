using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvTestResult = (AwvTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (!newAwvTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvTestResult.ResultImages = newAwvTestResult.ResultImages.FindAll(resultImage => resultImage.File != null);

                    if (newAwvTestResult.ResultImages.IsNullOrEmpty()) newAwvTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvTestResult;
            }

            var currentAwvTestResult = (AwvTestResult)currentTestResult;
            newAwvTestResult.Id = currentAwvTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentAwvTestResult.ResultImages.IsNullOrEmpty() && !newAwvTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentAwvTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newAwvTestResult.ResultImages;
                    else resultImages.AddRange(newAwvTestResult.ResultImages);

                    newAwvTestResult.ResultImages = resultImages;
                }
                else if (!currentAwvTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvTestResult.ResultImages = currentAwvTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentAwvTestResult.ResultImages.IsNullOrEmpty() && !newAwvTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentAwvTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvTestResult.Finding = currentAwvTestResult.Finding;
                newAwvTestResult = (AwvTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvTestResult, newAwvTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvTestResult = newTestResult as AwvTestResult;
            if (awvTestResult == null) return null;

            if (awvTestResult.TestPerformedExternally != null)
            {
                if (awvTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvTestResult;
            }

            if (awvTestResult.TestPerformedExternally != null && awvTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat)
            {

                if (awvTestResult.TestPerformedExternally.EntryCompleted)
                    awvTestResult.ResultStatus.Status = TestResultStatus.Complete;
                else
                    awvTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return awvTestResult;

            }

            if (awvTestResult.ResultImages != null && awvTestResult.ResultImages.Count < 1)
                awvTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                awvTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newAwvTestResult = (AwvTestResult)newTestResult;

            if (newAwvTestResult.UnableScreenReason != null && newAwvTestResult.UnableScreenReason.Count > 0)
            {
                newAwvTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvTestResult;
            }

            newAwvTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newAwvTestResult = (AwvTestResult)newTestResult;

            if (newAwvTestResult.UnableScreenReason != null && newAwvTestResult.UnableScreenReason.Count > 0)
            {
                newAwvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvTestResult;
            }

            newAwvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvTestResult;
        }
    }
}
