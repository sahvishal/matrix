using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class ImtTestResultSynchronizationService : TestResultSynchronizationService
    {
        public ImtTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var imtTestResult = (ImtTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (!imtTestResult.ResultMedia.IsNullOrEmpty())
                {
                    imtTestResult.ResultMedia = imtTestResult.ResultMedia.Where(resultImage => resultImage.File != null);

                    if (imtTestResult.ResultMedia.IsNullOrEmpty()) imtTestResult.ResultMedia = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return imtTestResult;
            }

            var currentImtTestResult = (ImtTestResult)currentTestResult;
            imtTestResult.Id = currentImtTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            imtTestResult.QimtLeft = SynchronizeResultReading(currentImtTestResult.QimtLeft, imtTestResult.QimtLeft, newTestResult.DataRecorderMetaData);
            imtTestResult.QimtRight = SynchronizeResultReading(currentImtTestResult.QimtRight, imtTestResult.QimtRight, newTestResult.DataRecorderMetaData);
            imtTestResult.ExpectedQimt = SynchronizeResultReading(currentImtTestResult.ExpectedQimt, imtTestResult.ExpectedQimt, newTestResult.DataRecorderMetaData);
            imtTestResult.VascularAge = SynchronizeResultReading(currentImtTestResult.VascularAge, imtTestResult.VascularAge, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                //imtTestResult.Finding = currentImtTestResult.Finding;
                imtTestResult = (ImtTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentImtTestResult, imtTestResult);
            }


            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentImtTestResult.ResultMedia.IsNullOrEmpty() && !imtTestResult.ResultMedia.IsNullOrEmpty())
                {
                    var resultImages = currentImtTestResult.ResultMedia.Where(image => image.ReadingSource == ReadingSource.Manual).ToList();

                    if (resultImages.IsNullOrEmpty()) resultImages = imtTestResult.ResultMedia.ToList();
                    else resultImages.AddRange(imtTestResult.ResultMedia);

                    imtTestResult.ResultMedia = resultImages;
                }
                else if (!currentImtTestResult.ResultMedia.IsNullOrEmpty())
                {
                    imtTestResult.ResultMedia = currentImtTestResult.ResultMedia;
                }
            }
            else
            {
                if (!currentImtTestResult.ResultMedia.IsNullOrEmpty() && !imtTestResult.ResultMedia.IsNullOrEmpty())
                {
                    imtTestResult.ResultMedia.ForEach(resultImage =>
                    {
                        var selectedImage = currentImtTestResult.ResultMedia.Where(currentImage => currentImage.File.Path == resultImage.File.Path).FirstOrDefault();
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return imtTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var imtTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (imtTestResult.ResultStatus.Status == TestResultStatus.Complete && imtTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    imtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return imtTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var imtTestResult = newTestResult as ImtTestResult;

            if (imtTestResult != null)
            {
                if (imtTestResult.TestPerformedExternally != null)
                {
                    if (imtTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && imtTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return imtTestResult;
                }
            }


            var isIncomplete = false;

            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.ExpectedQimt:
                        if (imtTestResult.ExpectedQimt == null)
                            isIncomplete = true;
                        break;

                    case ReadingLabels.QimtRight:
                        if (imtTestResult.QimtRight == null)
                            isIncomplete = true;
                        break;

                    case ReadingLabels.QimtLeft:
                        if (imtTestResult.QimtLeft == null)
                            isIncomplete = true;
                        break;

                    case ReadingLabels.VascularAge:
                        if (imtTestResult.VascularAge == null)
                            isIncomplete = true;
                        break;
                }
            }


            if (isIncomplete || imtTestResult.Finding == null || imtTestResult.ResultMedia == null || !imtTestResult.ResultMedia.Any())
            {
                imtTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            }
            else
                imtTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return imtTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var imtTestResult = newTestResult as ImtTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.QimtLeft:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, imtTestResult.QimtLeft);
                        if (returnStatus)
                        {
                            imtTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return imtTestResult;
                        }
                        break;

                    case ReadingLabels.QimtRight:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, imtTestResult.QimtRight);
                        if (returnStatus)
                        {
                            imtTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return imtTestResult;
                        }
                        break;

                    case ReadingLabels.ExpectedQimt:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, imtTestResult.ExpectedQimt);
                        if (returnStatus)
                        {
                            imtTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return imtTestResult;
                        }
                        break;

                    case ReadingLabels.VascularAge:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, imtTestResult.VascularAge);
                        if (returnStatus)
                        {
                            imtTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return imtTestResult;
                        }
                        break;

                }
            }

            if (!imtTestResult.ResultMedia.IsNullOrEmpty() && imtTestResult.ResultMedia.Any(resultImage => resultImage.ReadingSource == ReadingSource.Manual))
            {
                imtTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return imtTestResult;
            }

            if (imtTestResult.UnableScreenReason != null && imtTestResult.UnableScreenReason.Count > 0)
            {
                imtTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return imtTestResult;
            }

            imtTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return imtTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var imtTestResult = newTestResult as ImtTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.QimtLeft:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, imtTestResult.QimtLeft);
                        if (returnStatus)
                        {
                            imtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return imtTestResult;
                        }
                        break;

                    case ReadingLabels.QimtRight:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, imtTestResult.QimtRight);
                        if (returnStatus)
                        {
                            imtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return imtTestResult;
                        }
                        break;

                    case ReadingLabels.ExpectedQimt:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, imtTestResult.ExpectedQimt);
                        if (returnStatus)
                        {
                            imtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return imtTestResult;
                        }
                        break;

                    case ReadingLabels.VascularAge:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, imtTestResult.VascularAge);
                        if (returnStatus)
                        {
                            imtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return imtTestResult;
                        }
                        break;

                }
            }

            if (!imtTestResult.ResultMedia.IsNullOrEmpty() && imtTestResult.ResultMedia.Any(resultImage => resultImage.ReadingSource == ReadingSource.Manual))
            {
                imtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return imtTestResult;
            }

            if (imtTestResult.UnableScreenReason != null && imtTestResult.UnableScreenReason.Count > 0)
            {
                imtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return imtTestResult;
            }

            imtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return imtTestResult;
        }
    }
}
