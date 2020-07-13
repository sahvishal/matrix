using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class GlaucomaTestResultSynchronizationService : TestResultSynchronizationService
    {
        public GlaucomaTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var glaucomaTestResult = newTestResult as GlaucomaTestResult;
            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (glaucomaTestResult.AmslerRightEye != null && glaucomaTestResult.AmslerRightEye.Reading == null) glaucomaTestResult.AmslerRightEye = null;
                if (glaucomaTestResult.AmslerLeftEye != null && glaucomaTestResult.AmslerLeftEye.Reading == null) glaucomaTestResult.AmslerLeftEye = null;

                if (glaucomaTestResult.RightEyePressure != null && glaucomaTestResult.RightEyePressure.Reading == null) glaucomaTestResult.RightEyePressure = null;
                if (glaucomaTestResult.LeftEyePressure != null && glaucomaTestResult.LeftEyePressure.Reading == null) glaucomaTestResult.LeftEyePressure = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return glaucomaTestResult;
            }

            var currentGlaucomaTestResult = (GlaucomaTestResult)currentTestResult;

            glaucomaTestResult.Id = currentGlaucomaTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            glaucomaTestResult.AmslerRightEye = SynchronizeResultReading(currentGlaucomaTestResult.AmslerRightEye, glaucomaTestResult.AmslerRightEye, newTestResult.DataRecorderMetaData);
            glaucomaTestResult.AmslerLeftEye = SynchronizeResultReading(currentGlaucomaTestResult.AmslerLeftEye, glaucomaTestResult.AmslerLeftEye, newTestResult.DataRecorderMetaData);

            glaucomaTestResult.RightEyePressure = SynchronizeResultReading(currentGlaucomaTestResult.RightEyePressure, glaucomaTestResult.RightEyePressure, newTestResult.DataRecorderMetaData);
            glaucomaTestResult.LeftEyePressure = SynchronizeResultReading(currentGlaucomaTestResult.LeftEyePressure, glaucomaTestResult.LeftEyePressure, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                glaucomaTestResult = (GlaucomaTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentGlaucomaTestResult, glaucomaTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return glaucomaTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var glaucomaTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (glaucomaTestResult.ResultStatus.Status == TestResultStatus.Complete && glaucomaTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    glaucomaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return glaucomaTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var hearingTestResult = newTestResult as GlaucomaTestResult;
            if (hearingTestResult == null) return null;

            if (hearingTestResult.TestPerformedExternally != null)
            {
                if (hearingTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && hearingTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return hearingTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.AmslerRightEye:
                        if (hearingTestResult.AmslerRightEye == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.AmslerLeftEye:
                        if (hearingTestResult.AmslerLeftEye == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyePressure:
                        if (hearingTestResult.RightEyePressure == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyePressure:
                        if (hearingTestResult.LeftEyePressure == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }
            hearingTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return hearingTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var glaucomaTestResult = (GlaucomaTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.AmslerRightEye:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, glaucomaTestResult.AmslerRightEye);
                        if (returnStatus)
                        {
                            glaucomaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return glaucomaTestResult;
                        }
                        break;

                    case ReadingLabels.AmslerLeftEye:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, glaucomaTestResult.AmslerLeftEye);
                        if (returnStatus)
                        {
                            glaucomaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return glaucomaTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyePressure:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, glaucomaTestResult.RightEyePressure);
                        if (returnStatus)
                        {
                            glaucomaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return glaucomaTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyePressure:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, glaucomaTestResult.LeftEyePressure);
                        if (returnStatus)
                        {
                            glaucomaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return glaucomaTestResult;
                        }
                        break;
                }
            }

            if (glaucomaTestResult.UnableScreenReason != null && glaucomaTestResult.UnableScreenReason.Count > 0)
            {
                glaucomaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return glaucomaTestResult;
            }

            glaucomaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return glaucomaTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var glaucomaTestResult = (GlaucomaTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.AmslerRightEye:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, glaucomaTestResult.AmslerRightEye);
                        if (returnStatus)
                        {
                            glaucomaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return glaucomaTestResult;
                        }
                        break;

                    case ReadingLabels.AmslerLeftEye:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, glaucomaTestResult.AmslerLeftEye);
                        if (returnStatus)
                        {
                            glaucomaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return glaucomaTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyePressure:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, glaucomaTestResult.RightEyePressure);
                        if (returnStatus)
                        {
                            glaucomaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return glaucomaTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyePressure:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, glaucomaTestResult.LeftEyePressure);
                        if (returnStatus)
                        {
                            glaucomaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return glaucomaTestResult;
                        }
                        break;
                }
            }

            if (glaucomaTestResult.UnableScreenReason != null && glaucomaTestResult.UnableScreenReason.Count > 0)
            {
                glaucomaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return glaucomaTestResult;
            }

            glaucomaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return glaucomaTestResult;
        }
    }
}
