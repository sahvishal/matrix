using System;
using System.Collections.Generic;
using System.Data;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BloodPressureSynchronizer : IBloodPressureSynchronizer
    {
        private ILogger _logger;
        private string _errorSummary;

        private readonly long _eventId;
        private readonly long _customerId;
        private readonly long _updatedBy;
        private readonly ASITestRepository _asiTestRepository;
        private readonly IRepository<BasicBiometric> _basicBiometricRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly Service.TestResultService _testResultService;

        private const string ColumnForSystolicLeft = "SYSTOLICLEFT";
        private const string ColumnForSystolicRight = "SYSTOLICRIGHT";
        private const string ColumnForDiastolicLeft = "DIASTOLICLEFT";
        private const string ColumnForDiastolicRight = "DIASTOLICRIGHT";
        private const string ColumnForPulseRateLeft = "PULSERATELEFT";
        private const string ColumnForPulseRateRight = "PULSERATERIGHT";

        private readonly bool _isNewResultFlow;

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        public BloodPressureSynchronizer(ILogger logger, long customerId, long eventId, long updateBy, bool isNewResultFlow)
        {
            _errorSummary = "";
            _logger = logger;
            _customerId = customerId;
            _eventId = eventId;
            _updatedBy = updateBy;
            _asiTestRepository = new ASITestRepository(ReadingSource.Manual);
            _basicBiometricRepository = new BasicBiometricRepository();
            _eventCustomerRepository = new EventCustomerRepository();
            _testResultService = new Service.TestResultService();
            _isNewResultFlow = isNewResultFlow;
        }

        public IEnumerable<TestResult> Parse(DataRow dr)
        {
            SaveBasicBiometric(dr);
            var asiTestResult = (ASITestResult)_asiTestRepository.GetTestResults(_customerId, _eventId, _isNewResultFlow);

            if (asiTestResult == null && _testResultService.IsTestPurchasedByCustomer(_eventId, _customerId, (long)TestType.ASI))
            {
                asiTestResult = new ASITestResult();
            }

            if (asiTestResult == null) return null;

            var pressureReadings = GetBpValues(dr);
            if (pressureReadings == null) return null;

            var testResults = new List<TestResult>();
            asiTestResult.PressureReadings = SynchronizeBpValues(pressureReadings, asiTestResult.PressureReadings);
            testResults.Add(asiTestResult);

            return testResults;
        }

        public bool CheckIfDatatableIsValidforBpValues(DataTable dt)
        {
            if (dt.Columns.Contains(ColumnForSystolicRight) && dt.Columns.Contains(ColumnForSystolicLeft) && dt.Columns.Contains(ColumnForPulseRateRight) &&
                dt.Columns.Contains(ColumnForPulseRateLeft) && dt.Columns.Contains(ColumnForDiastolicRight) && dt.Columns.Contains(ColumnForDiastolicLeft))
                return true;
            return false;
        }

        private void SaveBasicBiometric(DataRow dr)
        {
            var systolicRight = GetDataReading(ColumnForSystolicRight, dr);
            var systolicLeft = GetDataReading(ColumnForSystolicLeft, dr);
            var diastolicRight = GetDataReading(ColumnForDiastolicRight, dr);
            var diastolicLeft = GetDataReading(ColumnForDiastolicLeft, dr);

            if (systolicLeft == null && systolicRight == null && diastolicLeft == null && diastolicRight == null)
                return;

            var funcIscomplete = new Func<int?, int?, bool>((a, b) => a != null && b != null);
            var funcIsPartial = new Func<int?, int?, bool>((a, b) => a != null || b != null);

            var isLeftComplete = funcIscomplete(systolicLeft, diastolicLeft);
            var isRightComplete = funcIscomplete(systolicRight, diastolicRight);
            var isLeftPartial = funcIsPartial(systolicLeft, diastolicLeft);
            var isRightPartial = funcIsPartial(systolicRight, diastolicRight);

            if (!isLeftPartial && !isLeftComplete && !isRightPartial && !isRightComplete) return;

            var eventCustomer = _eventCustomerRepository.Get(_eventId, _customerId);
            var biometric = new BasicBiometric
                                {
                                    Id = eventCustomer.Id,
                                    SystolicPressure = systolicRight,
                                    DiastolicPressure = diastolicRight,
                                    IsRightArmBpMeasurement = true,
                                    CreatedByOrgRoleUserId = _updatedBy,
                                    CreatedOn = DateTime.Now
                                };

            if (!isRightComplete && isLeftComplete)
            {
                biometric.SystolicPressure = systolicLeft;
                biometric.DiastolicPressure = diastolicLeft;
            }
            _basicBiometricRepository.Save(biometric);
        }

        private CardiovisionPressureReadings GetBpValues(DataRow dr)
        {
            var cardiovisionPressureReadings = new CardiovisionPressureReadings
                                                   {
                                                       Pulse = GetDataReading(ColumnForPulseRateLeft, ReadingLabels.Pulse, dr) ?? GetDataReading(ColumnForPulseRateRight, ReadingLabels.Pulse, dr)
                                                   };

            if (cardiovisionPressureReadings.Pulse == null)
                return null;

            return cardiovisionPressureReadings;
        }

        private static CardiovisionPressureReadings SynchronizeBpValues(CardiovisionPressureReadings pressureReadings, CardiovisionPressureReadings pressureReadingsinDb)
        {
            if (pressureReadingsinDb == null) return pressureReadings;

            if (pressureReadingsinDb.Pulse != null && pressureReadingsinDb.Pulse.ReadingSource == ReadingSource.Manual)
                pressureReadings.Pulse = pressureReadingsinDb.Pulse;

            pressureReadings.PulsePressure = pressureReadingsinDb.PulsePressure;

            return pressureReadings;
        }

        private ResultReading<int?> GetDataReading(string columnName, ReadingLabels readingLabel, DataRow dr)
        {
            try
            {
                if (!IsDataRowItemEmpty(dr[columnName]))
                {
                    int s;
                    if (int.TryParse(dr[columnName].ToString(), out s))
                    {
                        return new ResultReading<int?>(readingLabel)
                                   {
                                       Reading = s,
                                       ReadingSource = ReadingSource.Automatic
                                   };
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Exception caused while recording data for " + columnName;
                _logger.Error("\nException caused while recording data for " + columnName + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
            }
            return null;
        }

        private int? GetDataReading(string columnName, DataRow dr)
        {
            try
            {
                if (!IsDataRowItemEmpty(dr[columnName]))
                {
                    int s;
                    if (int.TryParse(dr[columnName].ToString(), out s))
                    {
                        return s;
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Exception caused while recording data for " + columnName;
                _logger.Error("\nException caused while recording data for " + columnName + ". Message: " + ex.Message + "\n\t" + ex.StackTrace);
            }
            return null;
        }

        private static bool IsDataRowItemEmpty(Object obj)
        {
            if (obj != null && obj != DBNull.Value && !string.IsNullOrEmpty(obj.ToString()))
                return false;

            return true;
        }

        public CardiovisionPressureReadings GetReadingsinDb()
        {
            var asiTestResult = (ASITestResult)_asiTestRepository.GetTestResults(_customerId, _eventId, _isNewResultFlow);
            if (asiTestResult == null) return null;
            CardiovisionPressureReadings pressureReadings = asiTestResult.PressureReadings;

            if (pressureReadings != null)
            {
                var func = new Func<ResultReading<int?>, ResultReading<int?>>(a =>
                                                                               {
                                                                                   if (a != null)
                                                                                   {
                                                                                       a.Id = 0;
                                                                                       a.ReadingSource = ReadingSource.Automatic;
                                                                                   }
                                                                                   return a;
                                                                               });

                pressureReadings.Pulse = func(pressureReadings.Pulse);
            }

            return pressureReadings;
        }

    }
}
