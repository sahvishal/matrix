using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class MyBioAssessmentTestResultSynchronizationService : TestResultSynchronizationService
    {
        public MyBioAssessmentTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newMyBioCheckAssessmentTestResult = (MyBioAssessmentTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newMyBioCheckAssessmentTestResult.Glucose != null && newMyBioCheckAssessmentTestResult.Glucose.Reading == null && newMyBioCheckAssessmentTestResult.Glucose.Finding == null) newMyBioCheckAssessmentTestResult.Glucose = null;
                if (newMyBioCheckAssessmentTestResult.TotalCholestrol != null && newMyBioCheckAssessmentTestResult.TotalCholestrol.Reading == null && newMyBioCheckAssessmentTestResult.TotalCholestrol.Finding == null) newMyBioCheckAssessmentTestResult.TotalCholestrol = null;
                if (newMyBioCheckAssessmentTestResult.Hdl != null && newMyBioCheckAssessmentTestResult.Hdl.Reading == null && newMyBioCheckAssessmentTestResult.Hdl.Finding == null) newMyBioCheckAssessmentTestResult.Hdl = null;
                if (newMyBioCheckAssessmentTestResult.Ldl != null && newMyBioCheckAssessmentTestResult.Ldl.Reading == null && newMyBioCheckAssessmentTestResult.Ldl.Finding == null) newMyBioCheckAssessmentTestResult.Ldl = null;
                if (newMyBioCheckAssessmentTestResult.TriGlycerides != null && newMyBioCheckAssessmentTestResult.TriGlycerides.Reading == null && newMyBioCheckAssessmentTestResult.TriGlycerides.Finding == null) newMyBioCheckAssessmentTestResult.TriGlycerides = null;
                if (newMyBioCheckAssessmentTestResult.TcHdlRatio != null && newMyBioCheckAssessmentTestResult.TcHdlRatio.Reading == null && newMyBioCheckAssessmentTestResult.TcHdlRatio.Finding == null) newMyBioCheckAssessmentTestResult.TcHdlRatio = null;

                if (newMyBioCheckAssessmentTestResult.ResultImage != null)
                {
                    if (newMyBioCheckAssessmentTestResult.ResultImage.File == null) newMyBioCheckAssessmentTestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newMyBioCheckAssessmentTestResult;
            }

            var currentMyBioCheckAssessmentTestResult = (MyBioAssessmentTestResult)currentTestResult;
            newMyBioCheckAssessmentTestResult.Id = currentMyBioCheckAssessmentTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentMyBioCheckAssessmentTestResult.ResultImage != null && newMyBioCheckAssessmentTestResult.ResultImage != null)
            {
                if (newMyBioCheckAssessmentTestResult.ResultImage.File != null && currentMyBioCheckAssessmentTestResult.ResultImage.File != null && currentMyBioCheckAssessmentTestResult.ResultImage.File.Path == newMyBioCheckAssessmentTestResult.ResultImage.File.Path)
                    newMyBioCheckAssessmentTestResult.ResultImage = currentMyBioCheckAssessmentTestResult.ResultImage;

                if (currentMyBioCheckAssessmentTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newMyBioCheckAssessmentTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newMyBioCheckAssessmentTestResult.ResultImage = currentMyBioCheckAssessmentTestResult.ResultImage;
            }

            if (newMyBioCheckAssessmentTestResult.ResultImage != null)
            {
                if (newMyBioCheckAssessmentTestResult.ResultImage.File == null) newMyBioCheckAssessmentTestResult.ResultImage = null;
            }

            newMyBioCheckAssessmentTestResult.Glucose = SynchronizeResultReading(currentMyBioCheckAssessmentTestResult.Glucose, newMyBioCheckAssessmentTestResult.Glucose, newTestResult.DataRecorderMetaData);
            newMyBioCheckAssessmentTestResult.TotalCholestrol = SynchronizeResultReading(currentMyBioCheckAssessmentTestResult.TotalCholestrol, newMyBioCheckAssessmentTestResult.TotalCholestrol, newTestResult.DataRecorderMetaData);
            newMyBioCheckAssessmentTestResult.Hdl = SynchronizeResultReading(currentMyBioCheckAssessmentTestResult.Hdl, newMyBioCheckAssessmentTestResult.Hdl, newTestResult.DataRecorderMetaData);
            newMyBioCheckAssessmentTestResult.Ldl = SynchronizeResultReading(currentMyBioCheckAssessmentTestResult.Ldl, newMyBioCheckAssessmentTestResult.Ldl, newTestResult.DataRecorderMetaData);
            newMyBioCheckAssessmentTestResult.TriGlycerides = SynchronizeResultReading(currentMyBioCheckAssessmentTestResult.TriGlycerides, newMyBioCheckAssessmentTestResult.TriGlycerides, newTestResult.DataRecorderMetaData);
            newMyBioCheckAssessmentTestResult.TcHdlRatio = SynchronizeResultReading(currentMyBioCheckAssessmentTestResult.TcHdlRatio, newMyBioCheckAssessmentTestResult.TcHdlRatio, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newMyBioCheckAssessmentTestResult = (MyBioAssessmentTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentMyBioCheckAssessmentTestResult, newMyBioCheckAssessmentTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newMyBioCheckAssessmentTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newMyBioCheckAssessmentTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newMyBioCheckAssessmentTestResult.ResultStatus.Status == TestResultStatus.Complete && newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newMyBioCheckAssessmentTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var myBioAssessmentTestResult = newTestResult as MyBioAssessmentTestResult;
            if (myBioAssessmentTestResult == null) return null;

            if (myBioAssessmentTestResult.TestPerformedExternally != null )
            {
                if (myBioAssessmentTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && myBioAssessmentTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return myBioAssessmentTestResult;
            }
            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        if (IsIncompleteReading(myBioAssessmentTestResult.Glucose))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TCHDLRatio:
                        if (IsIncompleteReading(myBioAssessmentTestResult.TcHdlRatio))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        if (IsIncompleteReading(myBioAssessmentTestResult.TotalCholestrol))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TriGlycerides:
                        if (IsIncompleteReading(myBioAssessmentTestResult.TriGlycerides))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.HDL:
                        if (IsIncompleteReading(myBioAssessmentTestResult.Hdl))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LDL:
                        if (IsIncompleteReading(myBioAssessmentTestResult.Ldl))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                }
            }

            if (myBioAssessmentTestResult.ResultImage == null || myBioAssessmentTestResult.ResultImage.File == null)
            {
                myBioAssessmentTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return myBioAssessmentTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return myBioAssessmentTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newMyBioCheckAssessmentTestResult = (MyBioAssessmentTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.Glucose);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.TCHDLRatio:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.TcHdlRatio);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.TotalCholestrol);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.TriGlycerides:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.TriGlycerides);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.HDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.Hdl);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.LDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.Ldl);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMyBioCheckAssessmentTestResult; }
                        break;
                }
            }

            if (newMyBioCheckAssessmentTestResult.ResultImage != null && newMyBioCheckAssessmentTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newMyBioCheckAssessmentTestResult;
            }


            if (newMyBioCheckAssessmentTestResult.UnableScreenReason != null && newMyBioCheckAssessmentTestResult.UnableScreenReason.Count > 0)
            {
                newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newMyBioCheckAssessmentTestResult;
            }

            newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newMyBioCheckAssessmentTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {

            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newMyBioCheckAssessmentTestResult = (MyBioAssessmentTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.Glucose);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.TCHDLRatio:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.TcHdlRatio);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.TotalCholestrol);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.TriGlycerides:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.TriGlycerides);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.HDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.Hdl);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMyBioCheckAssessmentTestResult; }
                        break;

                    case ReadingLabels.LDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newMyBioCheckAssessmentTestResult.Ldl);
                        if (returnStatus) { newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMyBioCheckAssessmentTestResult; }
                        break;
                }
            }

            if (newMyBioCheckAssessmentTestResult.ResultImage != null && newMyBioCheckAssessmentTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newMyBioCheckAssessmentTestResult;
            }


            if (newMyBioCheckAssessmentTestResult.UnableScreenReason != null && newMyBioCheckAssessmentTestResult.UnableScreenReason.Count > 0)
            {
                newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newMyBioCheckAssessmentTestResult;
            }

            newMyBioCheckAssessmentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newMyBioCheckAssessmentTestResult;
        }
    }
}