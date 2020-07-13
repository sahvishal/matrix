using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class EAwvTestResultSynchronizationService : TestResultSynchronizationService
    {
        public EAwvTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newEAwvTestResult = (EAwvTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (!newEAwvTestResult.ResultImages.IsNullOrEmpty())
                {
                    newEAwvTestResult.ResultImages = newEAwvTestResult.ResultImages.FindAll(resultImage => resultImage.File != null);

                    if (newEAwvTestResult.ResultImages.IsNullOrEmpty()) newEAwvTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newEAwvTestResult;
            }

            var currentEAwvTestResult = (EAwvTestResult)currentTestResult;
            newEAwvTestResult.Id = currentEAwvTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentEAwvTestResult.ResultImages.IsNullOrEmpty() && !newEAwvTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentEAwvTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newEAwvTestResult.ResultImages;
                    else// resultImages.AddRange(newEAwvTestResult.ResultImages);
                    {
                        if (!CheckMediaExist(resultImages, TestType.eAWV + "_" + AwvFileTypes.SnapShot) && CheckMediaExist(newEAwvTestResult.ResultImages, TestType.eAWV + "_" + AwvFileTypes.SnapShot))
                        {
                            resultImages.Add(GetResultMedia(newEAwvTestResult.ResultImages, TestType.eAWV + "_" + AwvFileTypes.SnapShot));
                        }

                        if (!CheckMediaExist(resultImages, TestType.eAWV + "_" + AwvFileTypes.PreventionPlan) && CheckMediaExist(newEAwvTestResult.ResultImages, TestType.eAWV + "_" + AwvFileTypes.PreventionPlan))
                        {
                            resultImages.Add(GetResultMedia(newEAwvTestResult.ResultImages, TestType.eAWV + "_" + AwvFileTypes.PreventionPlan));
                        }

                        if (!CheckMediaExist(resultImages, TestType.eAWV + "_" + AwvFileTypes.ResultExport) && CheckMediaExist(newEAwvTestResult.ResultImages, TestType.eAWV + "_" + AwvFileTypes.ResultExport))
                        {
                            resultImages.Add(GetResultMedia(newEAwvTestResult.ResultImages, TestType.eAWV + "_" + AwvFileTypes.ResultExport));
                        }
                    }

                    newEAwvTestResult.ResultImages = resultImages;
                }
                else if (!currentEAwvTestResult.ResultImages.IsNullOrEmpty())
                {
                    newEAwvTestResult.ResultImages = currentEAwvTestResult.ResultImages;
                }

                newEAwvTestResult.TestNotPerformed = currentEAwvTestResult.TestNotPerformed;
            }
            else
            {
                if (!currentEAwvTestResult.ResultImages.IsNullOrEmpty() && !newEAwvTestResult.ResultImages.IsNullOrEmpty())
                {
                    newEAwvTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentEAwvTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newEAwvTestResult.Finding = currentEAwvTestResult.Finding;
                newEAwvTestResult = (EAwvTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentEAwvTestResult, newEAwvTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newEAwvTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newEAwvTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newEAwvTestResult.ResultStatus.Status == TestResultStatus.Complete && newEAwvTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newEAwvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newEAwvTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var eawvTestResult = newTestResult as EAwvTestResult;
            if (eawvTestResult == null) return null;

            if (eawvTestResult.TestPerformedExternally != null)
            {
                if (eawvTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && eawvTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return eawvTestResult;
            }


            if (eawvTestResult.TestPerformedExternally != null && eawvTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat)
            {

                if (eawvTestResult.TestPerformedExternally.EntryCompleted)
                    eawvTestResult.ResultStatus.Status = TestResultStatus.Complete;
                else
                    eawvTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return eawvTestResult;

            }

            if (eawvTestResult.ResultImages != null && eawvTestResult.ResultImages.Count < 1)
                eawvTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                eawvTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return eawvTestResult;
        }

        private bool CheckMediaExist(IEnumerable<ResultMedia> resultImages, string prefix)
        {
            return resultImages.Any(item => item.File.Path.StartsWith(prefix));
        }

        private ResultMedia GetResultMedia(IEnumerable<ResultMedia> resultImages, string prefix)
        {
            return resultImages.First(item => item.File.Path.StartsWith(prefix));
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newEAwvTestResult = (EAwvTestResult)newTestResult;

            if (newEAwvTestResult.UnableScreenReason != null && newEAwvTestResult.UnableScreenReason.Count > 0)
            {
                newEAwvTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newEAwvTestResult;
            }

            newEAwvTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newEAwvTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newEAwvTestResult = (EAwvTestResult)newTestResult;

            if (newEAwvTestResult.UnableScreenReason != null && newEAwvTestResult.UnableScreenReason.Count > 0)
            {
                newEAwvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newEAwvTestResult;
            }

            newEAwvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newEAwvTestResult;
        }
    }
}
