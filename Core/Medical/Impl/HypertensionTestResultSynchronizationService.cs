using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class HypertensionTestResultSynchronizationService : TestResultSynchronizationService
    {
        public HypertensionTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newHypertensionTestResult = newTestResult as HypertensionTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newHypertensionTestResult.Systolic != null && newHypertensionTestResult.Systolic.Reading == null) newHypertensionTestResult.Systolic = null;
                if (newHypertensionTestResult.Diastolic != null && newHypertensionTestResult.Diastolic.Reading == null) newHypertensionTestResult.Diastolic = null;
                if (newHypertensionTestResult.Pulse != null && newHypertensionTestResult.Pulse.Reading == null) newHypertensionTestResult.Pulse = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newHypertensionTestResult;
            }

            var currentHypertensionTestResult = (HypertensionTestResult)currentTestResult;
            newHypertensionTestResult.Id = currentHypertensionTestResult.Id;
            newHypertensionTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newHypertensionTestResult.Systolic = SynchronizeResultReading(currentHypertensionTestResult.Systolic, newHypertensionTestResult.Systolic, newTestResult.DataRecorderMetaData);
            newHypertensionTestResult.Diastolic = SynchronizeResultReading(currentHypertensionTestResult.Diastolic, newHypertensionTestResult.Diastolic, newTestResult.DataRecorderMetaData);

            newHypertensionTestResult.Pulse = SynchronizeResultReading(currentHypertensionTestResult.Pulse, newHypertensionTestResult.Pulse, newTestResult.DataRecorderMetaData);

            newHypertensionTestResult.RightArmBpMeasurement = SynchronizeResultReading(currentHypertensionTestResult.RightArmBpMeasurement, newHypertensionTestResult.RightArmBpMeasurement, newTestResult.DataRecorderMetaData);
            newHypertensionTestResult.BloodPressureElevated = SynchronizeResultReading(currentHypertensionTestResult.BloodPressureElevated, newHypertensionTestResult.BloodPressureElevated, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                newHypertensionTestResult = (HypertensionTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentHypertensionTestResult, newHypertensionTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newHypertensionTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newHypertensionTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newHypertensionTestResult.ResultStatus.Status == TestResultStatus.Complete && newHypertensionTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newHypertensionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;

                return newHypertensionTestResult;
            }

            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var hypertensionPanelTestResult = newTestResult as HypertensionTestResult;
            if (hypertensionPanelTestResult == null) return null;

            if (hypertensionPanelTestResult.TestPerformedExternally != null)
            {
                if (hypertensionPanelTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && hypertensionPanelTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return hypertensionPanelTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {

                    case ReadingLabels.SystolicRight:
                        if (hypertensionPanelTestResult.Systolic == null)
                        {
                            hypertensionPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return hypertensionPanelTestResult;
                        }
                        break;
                    case ReadingLabels.DiastolicRight:
                        if (hypertensionPanelTestResult.Diastolic == null)
                        {
                            hypertensionPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return hypertensionPanelTestResult;
                        }
                        break;

                    case ReadingLabels.Pulse:
                        if (hypertensionPanelTestResult.Pulse == null)
                        {
                            hypertensionPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return hypertensionPanelTestResult;
                        }
                        break;
                    case ReadingLabels.BloodPressureElevated:
                        if (hypertensionPanelTestResult.BloodPressureElevated == null)
                        {
                            hypertensionPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return hypertensionPanelTestResult;
                        }
                        break;
                    case ReadingLabels.RightArmBpMeasurement:
                        if (hypertensionPanelTestResult.RightArmBpMeasurement == null)
                        {
                            hypertensionPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return hypertensionPanelTestResult;
                        }
                        break;
                }
            }

            hypertensionPanelTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return hypertensionPanelTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newHypertensionTestResult = newTestResult as HypertensionTestResult;

            //var returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.VitD).ReadingSource, newHypertensionTestResult.VitD);
            //if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = TestResultStateNumber.ManualEntry; return newHypertensionTestResult; }


            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.SystolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.SystolicRight).ReadingSource, newHypertensionTestResult.Systolic);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newHypertensionTestResult; }
                        break;

                    case ReadingLabels.DiastolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.DiastolicRight).ReadingSource, newHypertensionTestResult.Diastolic);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newHypertensionTestResult; }
                        break;

                    case ReadingLabels.Pulse:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.Pulse).ReadingSource, newHypertensionTestResult.Pulse);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newHypertensionTestResult; }
                        break;

                    case ReadingLabels.RightArmBpMeasurement:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.RightArmBpMeasurement).ReadingSource, newHypertensionTestResult.RightArmBpMeasurement);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newHypertensionTestResult; }
                        break;

                    case ReadingLabels.BloodPressureElevated:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.BloodPressureElevated).ReadingSource, newHypertensionTestResult.BloodPressureElevated);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newHypertensionTestResult; }
                        break;
                }
            }

            if (newHypertensionTestResult.UnableScreenReason != null && newHypertensionTestResult.UnableScreenReason.Count > 0)
            {
                newHypertensionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newHypertensionTestResult;
            }

            newHypertensionTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newHypertensionTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newHypertensionTestResult = newTestResult as HypertensionTestResult;

            //var returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.VitD).ReadingSource, newHypertensionTestResult.VitD);
            //if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = TestResultStateNumber.ManualEntry; return newHypertensionTestResult; }


            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.SystolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.SystolicRight).ReadingSource, newHypertensionTestResult.Systolic);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newHypertensionTestResult; }
                        break;

                    case ReadingLabels.DiastolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.DiastolicRight).ReadingSource, newHypertensionTestResult.Diastolic);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newHypertensionTestResult; }
                        break;

                    case ReadingLabels.Pulse:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.Pulse).ReadingSource, newHypertensionTestResult.Pulse);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newHypertensionTestResult; }
                        break;

                    case ReadingLabels.RightArmBpMeasurement:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.RightArmBpMeasurement).ReadingSource, newHypertensionTestResult.RightArmBpMeasurement);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newHypertensionTestResult; }
                        break;

                    case ReadingLabels.BloodPressureElevated:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.BloodPressureElevated).ReadingSource, newHypertensionTestResult.BloodPressureElevated);
                        if (returnStatus) { newHypertensionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newHypertensionTestResult; }
                        break;
                }
            }

            if (newHypertensionTestResult.UnableScreenReason != null && newHypertensionTestResult.UnableScreenReason.Count > 0)
            {
                newHypertensionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newHypertensionTestResult;
            }

            newHypertensionTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newHypertensionTestResult;
        }
    }
}