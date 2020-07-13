using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class VisionTestResultSynchronizationService : TestResultSynchronizationService
    {
        public VisionTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var visionTestResult = newTestResult as VisionTestResult;
            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (visionTestResult.BothEyesLeftUpperQuadrant != null && visionTestResult.BothEyesLeftUpperQuadrant.Reading == null) visionTestResult.BothEyesLeftUpperQuadrant = null;
                if (visionTestResult.BothEyesLeftLowerQuadrant != null && visionTestResult.BothEyesLeftLowerQuadrant.Reading == null) visionTestResult.BothEyesLeftLowerQuadrant = null;
                if (visionTestResult.BothEyesRightUpperQuadrant != null && visionTestResult.BothEyesRightUpperQuadrant.Reading == null) visionTestResult.BothEyesRightUpperQuadrant = null;
                if (visionTestResult.BothEyesRightLowerQuadrant != null && visionTestResult.BothEyesRightLowerQuadrant.Reading == null) visionTestResult.BothEyesRightLowerQuadrant = null;

                if (visionTestResult.RightEyeLeftUpperQuadrant != null && visionTestResult.RightEyeLeftUpperQuadrant.Reading == null) visionTestResult.RightEyeLeftUpperQuadrant = null;
                if (visionTestResult.RightEyeLeftLowerQuadrant != null && visionTestResult.RightEyeLeftLowerQuadrant.Reading == null) visionTestResult.RightEyeLeftLowerQuadrant = null;
                if (visionTestResult.RightEyeRightUpperQuadrant != null && visionTestResult.RightEyeRightUpperQuadrant.Reading == null) visionTestResult.RightEyeRightUpperQuadrant = null;
                if (visionTestResult.RightEyeRightLowerQuadrant != null && visionTestResult.RightEyeRightLowerQuadrant.Reading == null) visionTestResult.RightEyeRightLowerQuadrant = null;

                if (visionTestResult.LeftEyeLeftUpperQuadrant != null && visionTestResult.LeftEyeLeftUpperQuadrant.Reading == null) visionTestResult.LeftEyeLeftUpperQuadrant = null;
                if (visionTestResult.LeftEyeLeftLowerQuadrant != null && visionTestResult.LeftEyeLeftLowerQuadrant.Reading == null) visionTestResult.LeftEyeLeftLowerQuadrant = null;
                if (visionTestResult.LeftEyeRightUpperQuadrant != null && visionTestResult.LeftEyeRightUpperQuadrant.Reading == null) visionTestResult.LeftEyeRightUpperQuadrant = null;
                if (visionTestResult.LeftEyeRightLowerQuadrant != null && visionTestResult.LeftEyeRightLowerQuadrant.Reading == null) visionTestResult.LeftEyeRightLowerQuadrant = null;

                if (visionTestResult.RightEyeCylindrical != null && visionTestResult.RightEyeCylindrical.Reading == null) visionTestResult.RightEyeCylindrical = null;
                if (visionTestResult.RightEyeSpherical != null && visionTestResult.RightEyeSpherical.Reading == null) visionTestResult.RightEyeSpherical = null;

                if (visionTestResult.LeftEyeCylindrical != null && visionTestResult.LeftEyeCylindrical.Reading == null) visionTestResult.LeftEyeCylindrical = null;
                if (visionTestResult.LeftEyeSpherical != null && visionTestResult.LeftEyeSpherical.Reading == null) visionTestResult.LeftEyeSpherical = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return visionTestResult;
            }

            var currentVisionTestResult = (VisionTestResult)currentTestResult;

            visionTestResult.Id = currentVisionTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            visionTestResult.BothEyesLeftUpperQuadrant = SynchronizeResultReading(currentVisionTestResult.BothEyesLeftUpperQuadrant, visionTestResult.BothEyesLeftUpperQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.BothEyesLeftLowerQuadrant = SynchronizeResultReading(currentVisionTestResult.BothEyesLeftLowerQuadrant, visionTestResult.BothEyesLeftLowerQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.BothEyesRightUpperQuadrant = SynchronizeResultReading(currentVisionTestResult.BothEyesRightUpperQuadrant, visionTestResult.BothEyesRightUpperQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.BothEyesRightLowerQuadrant = SynchronizeResultReading(currentVisionTestResult.BothEyesRightLowerQuadrant, visionTestResult.BothEyesRightLowerQuadrant, newTestResult.DataRecorderMetaData);

            visionTestResult.RightEyeLeftUpperQuadrant = SynchronizeResultReading(currentVisionTestResult.RightEyeLeftUpperQuadrant, visionTestResult.RightEyeLeftUpperQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.RightEyeLeftLowerQuadrant = SynchronizeResultReading(currentVisionTestResult.RightEyeLeftLowerQuadrant, visionTestResult.RightEyeLeftLowerQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.RightEyeRightUpperQuadrant = SynchronizeResultReading(currentVisionTestResult.RightEyeRightUpperQuadrant, visionTestResult.RightEyeRightUpperQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.RightEyeRightLowerQuadrant = SynchronizeResultReading(currentVisionTestResult.RightEyeRightLowerQuadrant, visionTestResult.RightEyeRightLowerQuadrant, newTestResult.DataRecorderMetaData);

            visionTestResult.LeftEyeLeftUpperQuadrant = SynchronizeResultReading(currentVisionTestResult.LeftEyeLeftUpperQuadrant, visionTestResult.LeftEyeLeftUpperQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.LeftEyeLeftLowerQuadrant = SynchronizeResultReading(currentVisionTestResult.LeftEyeLeftLowerQuadrant, visionTestResult.LeftEyeLeftLowerQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.LeftEyeRightUpperQuadrant = SynchronizeResultReading(currentVisionTestResult.LeftEyeRightUpperQuadrant, visionTestResult.LeftEyeRightUpperQuadrant, newTestResult.DataRecorderMetaData);
            visionTestResult.LeftEyeRightLowerQuadrant = SynchronizeResultReading(currentVisionTestResult.LeftEyeRightLowerQuadrant, visionTestResult.LeftEyeRightLowerQuadrant, newTestResult.DataRecorderMetaData);

            visionTestResult.RightEyeCylindrical = SynchronizeResultReading(currentVisionTestResult.RightEyeCylindrical, visionTestResult.RightEyeCylindrical, newTestResult.DataRecorderMetaData);
            visionTestResult.RightEyeSpherical = SynchronizeResultReading(currentVisionTestResult.RightEyeSpherical, visionTestResult.RightEyeSpherical, newTestResult.DataRecorderMetaData);

            visionTestResult.LeftEyeCylindrical = SynchronizeResultReading(currentVisionTestResult.LeftEyeCylindrical, visionTestResult.LeftEyeCylindrical, newTestResult.DataRecorderMetaData);
            visionTestResult.LeftEyeSpherical = SynchronizeResultReading(currentVisionTestResult.LeftEyeSpherical, visionTestResult.LeftEyeSpherical, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                visionTestResult = (VisionTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentVisionTestResult, visionTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return visionTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var visionTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (visionTestResult.ResultStatus.Status == TestResultStatus.Complete && visionTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return visionTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var visionTestResult = newTestResult as VisionTestResult;
            if (visionTestResult == null) return null;

            if (visionTestResult.TestPerformedExternally != null)
            {
                if (visionTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && visionTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return visionTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.BothEyesLeftUpperQuadrant:
                        if (visionTestResult.BothEyesLeftUpperQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesLeftLowerQuadrant:
                        if (visionTestResult.BothEyesLeftLowerQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesRightUpperQuadrant:
                        if (visionTestResult.BothEyesRightUpperQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesRightLowerQuadrant:
                        if (visionTestResult.BothEyesRightLowerQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeLeftUpperQuadrant:
                        if (visionTestResult.RightEyeLeftUpperQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeLeftLowerQuadrant:
                        if (visionTestResult.RightEyeLeftLowerQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeRightUpperQuadrant:
                        if (visionTestResult.RightEyeRightUpperQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeRightLowerQuadrant:
                        if (visionTestResult.RightEyeRightLowerQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeLeftUpperQuadrant:
                        if (visionTestResult.LeftEyeLeftUpperQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeLeftLowerQuadrant:
                        if (visionTestResult.LeftEyeLeftLowerQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeRightUpperQuadrant:
                        if (visionTestResult.LeftEyeRightUpperQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeRightLowerQuadrant:
                        if (visionTestResult.LeftEyeRightLowerQuadrant == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeCylindrical:
                        if (visionTestResult.RightEyeCylindrical == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeSpherical:
                        if (visionTestResult.RightEyeSpherical == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeCylindrical:
                        if (visionTestResult.LeftEyeCylindrical == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeSpherical:
                        if (visionTestResult.LeftEyeSpherical == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }
            visionTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return visionTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var visionTestResult = (VisionTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.BothEyesLeftUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.BothEyesLeftUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesLeftLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.BothEyesLeftLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesRightUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.BothEyesRightUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesRightLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.BothEyesRightLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeLeftUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeLeftUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeLeftLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeLeftLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeRightUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeRightUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeRightLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeRightLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeLeftUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeLeftUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeLeftLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeLeftLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeRightUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeRightUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeRightLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeRightLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeCylindrical:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeCylindrical);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeSpherical:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeSpherical);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeCylindrical:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeCylindrical);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeSpherical:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeSpherical);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return visionTestResult;
                        }
                        break;
                }
            }

            if (visionTestResult.UnableScreenReason != null && visionTestResult.UnableScreenReason.Count > 0)
            {
                visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return visionTestResult;
            }

            visionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return visionTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var visionTestResult = (VisionTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.BothEyesLeftUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.BothEyesLeftUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesLeftLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.BothEyesLeftLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesRightUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.BothEyesRightUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.BothEyesRightLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.BothEyesRightLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeLeftUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeLeftUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeLeftLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeLeftLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeRightUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeRightUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeRightLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeRightLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeLeftUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeLeftUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeLeftLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeLeftLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeRightUpperQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeRightUpperQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeRightLowerQuadrant:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeRightLowerQuadrant);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeCylindrical:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeCylindrical);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.RightEyeSpherical:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.RightEyeSpherical);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeCylindrical:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeCylindrical);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEyeSpherical:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, visionTestResult.LeftEyeSpherical);
                        if (returnStatus)
                        {
                            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return visionTestResult;
                        }
                        break;
                }
            }

            if (visionTestResult.UnableScreenReason != null && visionTestResult.UnableScreenReason.Count > 0)
            {
                visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return visionTestResult;
            }

            visionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return visionTestResult;
        }
    }
}
