using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvCarotidTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvCarotidTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvCarotidTestResult = (AwvCarotidTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvCarotidTestResult.LeftResultReadings != null)
                {
                    if (newAwvCarotidTestResult.LeftResultReadings.CCAProximalPSV != null && newAwvCarotidTestResult.LeftResultReadings.CCAProximalPSV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.CCAProximalPSV = null;
                    if (newAwvCarotidTestResult.LeftResultReadings.CCAProximalEDV != null && newAwvCarotidTestResult.LeftResultReadings.CCAProximalEDV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.CCAProximalEDV = null;

                    if (newAwvCarotidTestResult.LeftResultReadings.CCADistalPSV != null && newAwvCarotidTestResult.LeftResultReadings.CCADistalPSV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.CCADistalPSV = null;
                    if (newAwvCarotidTestResult.LeftResultReadings.CCADistalEDV != null && newAwvCarotidTestResult.LeftResultReadings.CCADistalEDV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.CCADistalEDV = null;

                    if (newAwvCarotidTestResult.LeftResultReadings.BulbPSV != null && newAwvCarotidTestResult.LeftResultReadings.BulbPSV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.BulbPSV = null;
                    if (newAwvCarotidTestResult.LeftResultReadings.BulbEDV != null && newAwvCarotidTestResult.LeftResultReadings.BulbEDV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.BulbEDV = null;

                    if (newAwvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV != null && newAwvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV = null;

                    if (newAwvCarotidTestResult.LeftResultReadings.ICAProximalPSV != null && newAwvCarotidTestResult.LeftResultReadings.ICAProximalPSV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.ICAProximalPSV = null;
                    if (newAwvCarotidTestResult.LeftResultReadings.ICAProximalEDV != null && newAwvCarotidTestResult.LeftResultReadings.ICAProximalEDV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.ICAProximalEDV = null;

                    if (newAwvCarotidTestResult.LeftResultReadings.ICADistalPSV != null && newAwvCarotidTestResult.LeftResultReadings.ICADistalPSV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.ICADistalPSV = null;
                    if (newAwvCarotidTestResult.LeftResultReadings.ICADistalEDV != null && newAwvCarotidTestResult.LeftResultReadings.ICADistalEDV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.ICADistalEDV = null;

                    if (newAwvCarotidTestResult.LeftResultReadings.VertebralArtPSV != null && newAwvCarotidTestResult.LeftResultReadings.VertebralArtPSV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.VertebralArtPSV = null;
                    if (newAwvCarotidTestResult.LeftResultReadings.VertebralArtEDV != null && newAwvCarotidTestResult.LeftResultReadings.VertebralArtEDV.Reading == null) newAwvCarotidTestResult.LeftResultReadings.VertebralArtEDV = null;
                }

                if (newAwvCarotidTestResult.RightResultReadings != null)
                {
                    if (newAwvCarotidTestResult.RightResultReadings.CCAProximalPSV != null && newAwvCarotidTestResult.RightResultReadings.CCAProximalPSV.Reading == null) newAwvCarotidTestResult.RightResultReadings.CCAProximalPSV = null;
                    if (newAwvCarotidTestResult.RightResultReadings.CCAProximalEDV != null && newAwvCarotidTestResult.RightResultReadings.CCAProximalEDV.Reading == null) newAwvCarotidTestResult.RightResultReadings.CCAProximalEDV = null;

                    if (newAwvCarotidTestResult.RightResultReadings.CCADistalPSV != null && newAwvCarotidTestResult.RightResultReadings.CCADistalPSV.Reading == null) newAwvCarotidTestResult.RightResultReadings.CCADistalPSV = null;
                    if (newAwvCarotidTestResult.RightResultReadings.CCADistalEDV != null && newAwvCarotidTestResult.RightResultReadings.CCADistalEDV.Reading == null) newAwvCarotidTestResult.RightResultReadings.CCADistalEDV = null;

                    if (newAwvCarotidTestResult.RightResultReadings.BulbPSV != null && newAwvCarotidTestResult.RightResultReadings.BulbPSV.Reading == null) newAwvCarotidTestResult.RightResultReadings.BulbPSV = null;
                    if (newAwvCarotidTestResult.RightResultReadings.BulbEDV != null && newAwvCarotidTestResult.RightResultReadings.BulbEDV.Reading == null) newAwvCarotidTestResult.RightResultReadings.BulbEDV = null;

                    if (newAwvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV != null && newAwvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV.Reading == null) newAwvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV = null;

                    if (newAwvCarotidTestResult.RightResultReadings.ICAProximalPSV != null && newAwvCarotidTestResult.RightResultReadings.ICAProximalPSV.Reading == null) newAwvCarotidTestResult.RightResultReadings.ICAProximalPSV = null;
                    if (newAwvCarotidTestResult.RightResultReadings.ICAProximalEDV != null && newAwvCarotidTestResult.RightResultReadings.ICAProximalEDV.Reading == null) newAwvCarotidTestResult.RightResultReadings.ICAProximalEDV = null;

                    if (newAwvCarotidTestResult.RightResultReadings.ICADistalPSV != null && newAwvCarotidTestResult.RightResultReadings.ICADistalPSV.Reading == null) newAwvCarotidTestResult.RightResultReadings.ICADistalPSV = null;
                    if (newAwvCarotidTestResult.RightResultReadings.ICADistalEDV != null && newAwvCarotidTestResult.RightResultReadings.ICADistalEDV.Reading == null) newAwvCarotidTestResult.RightResultReadings.ICADistalEDV = null;

                    if (newAwvCarotidTestResult.RightResultReadings.VertebralArtPSV != null && newAwvCarotidTestResult.RightResultReadings.VertebralArtPSV.Reading == null) newAwvCarotidTestResult.RightResultReadings.VertebralArtPSV = null;
                    if (newAwvCarotidTestResult.RightResultReadings.VertebralArtEDV != null && newAwvCarotidTestResult.RightResultReadings.VertebralArtEDV.Reading == null) newAwvCarotidTestResult.RightResultReadings.VertebralArtEDV = null;
                }

                if (!newAwvCarotidTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvCarotidTestResult.ResultImages = newAwvCarotidTestResult.ResultImages.FindAll(resultImage =>
                        resultImage.File != null);

                    if (newAwvCarotidTestResult.ResultImages.IsNullOrEmpty()) newAwvCarotidTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvCarotidTestResult;
            }

            var currentAwvCarotidTestResult = (AwvCarotidTestResult)currentTestResult;
            newAwvCarotidTestResult.Id = currentAwvCarotidTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (newAwvCarotidTestResult.LeftResultReadings == null && currentAwvCarotidTestResult.LeftResultReadings != null) newAwvCarotidTestResult.LeftResultReadings = new AwvCarotidTestReadings();

            if (newAwvCarotidTestResult.LeftResultReadings != null)
            {
                newAwvCarotidTestResult.LeftResultReadings.CCAProximalPSV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.CCAProximalPSV, newAwvCarotidTestResult.LeftResultReadings.CCAProximalPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.LeftResultReadings.CCAProximalEDV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.CCAProximalEDV, newAwvCarotidTestResult.LeftResultReadings.CCAProximalEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.LeftResultReadings.CCADistalPSV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.CCADistalPSV, newAwvCarotidTestResult.LeftResultReadings.CCADistalPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.LeftResultReadings.CCADistalEDV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.CCADistalEDV, newAwvCarotidTestResult.LeftResultReadings.CCADistalEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.LeftResultReadings.BulbPSV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.BulbPSV, newAwvCarotidTestResult.LeftResultReadings.BulbPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.LeftResultReadings.BulbEDV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.BulbEDV, newAwvCarotidTestResult.LeftResultReadings.BulbEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV, newAwvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.LeftResultReadings.ICAProximalPSV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.ICAProximalPSV, newAwvCarotidTestResult.LeftResultReadings.ICAProximalPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.LeftResultReadings.ICAProximalEDV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.ICAProximalEDV, newAwvCarotidTestResult.LeftResultReadings.ICAProximalEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.LeftResultReadings.ICADistalPSV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.ICADistalPSV, newAwvCarotidTestResult.LeftResultReadings.ICADistalPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.LeftResultReadings.ICADistalEDV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.ICADistalEDV, newAwvCarotidTestResult.LeftResultReadings.ICADistalEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.LeftResultReadings.VertebralArtPSV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.VertebralArtPSV, newAwvCarotidTestResult.LeftResultReadings.VertebralArtPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.LeftResultReadings.VertebralArtEDV = SynchronizeResultReading(currentAwvCarotidTestResult.LeftResultReadings.VertebralArtEDV, newAwvCarotidTestResult.LeftResultReadings.VertebralArtEDV, newTestResult.DataRecorderMetaData);
            }

            if (newAwvCarotidTestResult.RightResultReadings == null && currentAwvCarotidTestResult.RightResultReadings != null) newAwvCarotidTestResult.RightResultReadings = new AwvCarotidTestReadings();

            if (newAwvCarotidTestResult.RightResultReadings != null)
            {
                newAwvCarotidTestResult.RightResultReadings.CCAProximalPSV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.CCAProximalPSV, newAwvCarotidTestResult.RightResultReadings.CCAProximalPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.RightResultReadings.CCAProximalEDV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.CCAProximalEDV, newAwvCarotidTestResult.RightResultReadings.CCAProximalEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.RightResultReadings.CCADistalPSV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.CCADistalPSV, newAwvCarotidTestResult.RightResultReadings.CCADistalPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.RightResultReadings.CCADistalEDV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.CCADistalEDV, newAwvCarotidTestResult.RightResultReadings.CCADistalEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.RightResultReadings.BulbPSV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.BulbPSV, newAwvCarotidTestResult.RightResultReadings.BulbPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.RightResultReadings.BulbEDV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.BulbEDV, newAwvCarotidTestResult.RightResultReadings.BulbEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV, newAwvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.RightResultReadings.ICAProximalPSV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.ICAProximalPSV, newAwvCarotidTestResult.RightResultReadings.ICAProximalPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.RightResultReadings.ICAProximalEDV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.ICAProximalEDV, newAwvCarotidTestResult.RightResultReadings.ICAProximalEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.RightResultReadings.ICADistalPSV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.ICADistalPSV, newAwvCarotidTestResult.RightResultReadings.ICADistalPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.RightResultReadings.ICADistalEDV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.ICADistalEDV, newAwvCarotidTestResult.RightResultReadings.ICADistalEDV, newTestResult.DataRecorderMetaData);

                newAwvCarotidTestResult.RightResultReadings.VertebralArtPSV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.VertebralArtPSV, newAwvCarotidTestResult.RightResultReadings.VertebralArtPSV, newTestResult.DataRecorderMetaData);
                newAwvCarotidTestResult.RightResultReadings.VertebralArtEDV = SynchronizeResultReading(currentAwvCarotidTestResult.RightResultReadings.VertebralArtEDV, newAwvCarotidTestResult.RightResultReadings.VertebralArtEDV, newTestResult.DataRecorderMetaData);
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentAwvCarotidTestResult.ResultImages.IsNullOrEmpty() && !newAwvCarotidTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentAwvCarotidTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newAwvCarotidTestResult.ResultImages;
                    else resultImages.AddRange(newAwvCarotidTestResult.ResultImages);

                    newAwvCarotidTestResult.ResultImages = resultImages;
                }
                else if (!currentAwvCarotidTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvCarotidTestResult.ResultImages = currentAwvCarotidTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentAwvCarotidTestResult.ResultImages.IsNullOrEmpty() && !newAwvCarotidTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvCarotidTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentAwvCarotidTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                if (newAwvCarotidTestResult.RightResultReadings != null)
                {
                    newAwvCarotidTestResult.RightResultReadings.Finding = currentAwvCarotidTestResult.RightResultReadings.Finding;
                }
                else if (currentAwvCarotidTestResult.RightResultReadings.Finding != null)
                {
                    newAwvCarotidTestResult.RightResultReadings = new AwvCarotidTestReadings { Finding = currentAwvCarotidTestResult.RightResultReadings.Finding };
                }

                if (newAwvCarotidTestResult.LeftResultReadings != null) newAwvCarotidTestResult.LeftResultReadings.Finding = currentAwvCarotidTestResult.LeftResultReadings.Finding;
                else if (currentAwvCarotidTestResult.LeftResultReadings.Finding != null)
                {
                    newAwvCarotidTestResult.LeftResultReadings = new AwvCarotidTestReadings { Finding = currentAwvCarotidTestResult.LeftResultReadings.Finding };
                }

                newAwvCarotidTestResult = (AwvCarotidTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvCarotidTestResult, newAwvCarotidTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvCarotidTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvCarotidTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvCarotidTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvCarotidTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvCarotidTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvCarotidTestResult = newTestResult as AwvCarotidTestResult;
            if (awvCarotidTestResult == null) return null;

            if (awvCarotidTestResult.TestPerformedExternally != null)
            {
                if (awvCarotidTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvCarotidTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvCarotidTestResult;
            }

            if (NewReadingSource != ReadingSource.Automatic)
            {
                foreach (var reading in compareToResultReadings)
                {
                    switch (reading.Label)
                    {
                        case ReadingLabels.RCCAProximalPSV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.CCAProximalPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RCCAProximalEDV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.CCAProximalEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RCCADistalPSV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.CCADistalPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RCCADistalEDV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.CCADistalEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RBulbPSV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.BulbPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RBulbEDV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.BulbEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RExtCarotidArtPSV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RICAPSV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.ICAProximalPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RICAEDV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.ICAProximalEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RICADistalPSV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.ICADistalPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RICADistalEDV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.ICADistalEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RVertebralArtPSV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.VertebralArtPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RVertebralArtEDV:
                            if (awvCarotidTestResult.RightResultReadings == null ||
                                awvCarotidTestResult.RightResultReadings.VertebralArtEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;


                        case ReadingLabels.LCCAProximalPSV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.CCAProximalPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LCCAProximalEDV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.CCAProximalEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LCCADistalPSV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.CCADistalPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LCCADistalEDV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.CCADistalEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LBulbPSV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.BulbPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LBulbEDV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.BulbEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LExtCarotidArtPSV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LICAPSV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.ICAProximalPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LICAEDV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.ICAProximalEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LICADistalPSV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.ICADistalPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LICADistalEDV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.ICADistalEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LVertebralArtPSV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.VertebralArtPSV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LVertebralArtEDV:
                            if (awvCarotidTestResult.LeftResultReadings == null ||
                                awvCarotidTestResult.LeftResultReadings.VertebralArtEDV == null)
                            {
                                awvCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return awvCarotidTestResult;
                            }
                            break;

                    }
                }
            }

            if (/*strokeTestResult.LeftResultReadings.Finding == null || strokeTestResult.RightResultReadings.Finding == null ||*/ awvCarotidTestResult.ResultImages == null || awvCarotidTestResult.ResultImages.Count < 1)
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvCarotidTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newAwvCarotidTestResult = (AwvCarotidTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.RCCAProximalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.CCAProximalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RCCAProximalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.CCAProximalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RCCADistalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.CCADistalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RCCADistalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.CCADistalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RBulbPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.BulbPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RBulbEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.BulbEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RExtCarotidArtPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ICAProximalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ICAProximalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;
                    case ReadingLabels.RICADistalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ICADistalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RICADistalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ICADistalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;
                    case ReadingLabels.RVertebralArtPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.VertebralArtPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RVertebralArtEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.VertebralArtEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;



                    case ReadingLabels.LCCAProximalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.CCAProximalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LCCAProximalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.CCAProximalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LCCADistalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.CCADistalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LCCADistalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.CCADistalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LBulbPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.BulbPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LBulbEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.BulbEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LExtCarotidArtPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;


                    case ReadingLabels.LICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ICAProximalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ICAProximalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICADistalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ICADistalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICADistalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ICADistalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LVertebralArtPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.VertebralArtPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LVertebralArtEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.VertebralArtEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvCarotidTestResult;
                        }
                        break;
                }
            }

            if (!newAwvCarotidTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newAwvCarotidTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                    return newAwvCarotidTestResult;
                }
            }

            if ((newAwvCarotidTestResult.UnableScreenReason != null && newAwvCarotidTestResult.UnableScreenReason.Count > 0) || (newAwvCarotidTestResult.IncidentalFindings != null && newAwvCarotidTestResult.IncidentalFindings.Count > 0))
            {
                newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvCarotidTestResult;
            }

            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvCarotidTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newAwvCarotidTestResult = (AwvCarotidTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.RCCAProximalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.CCAProximalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RCCAProximalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.CCAProximalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RCCADistalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.CCADistalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RCCADistalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.CCADistalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RBulbPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.BulbPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RBulbEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.BulbEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RExtCarotidArtPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ICAProximalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ICAProximalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;
                    case ReadingLabels.RICADistalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ICADistalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RICADistalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.ICADistalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;
                    case ReadingLabels.RVertebralArtPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.VertebralArtPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RVertebralArtEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.RightResultReadings != null ? newAwvCarotidTestResult.RightResultReadings.VertebralArtEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;



                    case ReadingLabels.LCCAProximalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.CCAProximalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LCCAProximalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.CCAProximalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LCCADistalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.CCADistalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LCCADistalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.CCADistalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LBulbPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.BulbPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LBulbEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.BulbEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LExtCarotidArtPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;


                    case ReadingLabels.LICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ICAProximalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ICAProximalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICADistalPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ICADistalPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICADistalEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.ICADistalEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LVertebralArtPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.VertebralArtPSV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LVertebralArtEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvCarotidTestResult.LeftResultReadings != null ? newAwvCarotidTestResult.LeftResultReadings.VertebralArtEDV : null);
                        if (returnStatus)
                        {
                            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvCarotidTestResult;
                        }
                        break;
                }
            }

            if (!newAwvCarotidTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newAwvCarotidTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                    return newAwvCarotidTestResult;
                }
            }

            if ((newAwvCarotidTestResult.UnableScreenReason != null && newAwvCarotidTestResult.UnableScreenReason.Count > 0) || (newAwvCarotidTestResult.IncidentalFindings != null && newAwvCarotidTestResult.IncidentalFindings.Count > 0))
            {
                newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvCarotidTestResult;
            }

            newAwvCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvCarotidTestResult;
        }
    }
}
