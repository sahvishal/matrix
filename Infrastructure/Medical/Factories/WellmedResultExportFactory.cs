using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class WellmedResultExportFactory : IWellmedResultExportFactory
    {
        private readonly TestResultService _testResultService;
        private readonly CryptographyService _cryptographyService = new PasswordCryptographyService();
        private readonly ILogger _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IOrganizationRepository _organizationRepository;

        private readonly IPcpResultExportAwvAaaFactory _awvAaaFactory;
        private readonly IPcpResultExportAwvEchoFactory _awvEchoFactory;
        private readonly IPcpResultExportAwvCarotidFactory _awvCarotidFactory;
        private readonly IPcpResultExportAwvSpiroFactory _awvSpiroFactory;
        private readonly IPcpResultExportAwvAbiFactory _awvAbiFactory;
        private readonly IPcpResultExportAwvEkgFactory _awvEkgFactory;
        private readonly IPcpResultExportVisionFactory _visionFactory;
        private readonly IPcpResultExportHypertensionFactory _hypertensionFactory;



        // private readonly string _destinationDirectory;

        public WellmedResultExportFactory(ILogger logger)
        {
            _logger = logger;
            _testResultService = new TestResultService();
            _eventRepository = new EventRepository();
            _hostRepository = new HostRepository();
            _organizationRepository = new OrganizationRepository();

            _awvAaaFactory = new PcpResultExportAwvAaaFactory();
            _awvEchoFactory = new PcpResultExportAwvEchoFactory();
            _awvCarotidFactory = new PcpResultExportAwvCarotidFactory();
            _awvSpiroFactory = new PcpResultExportAwvSpiroFactory();
            _awvAbiFactory = new PcpResultExportAwvAbiFactory();
            _awvEkgFactory = new PcpResultExportAwvEkgFactory();
            _visionFactory = new PcpResultExportVisionFactory();
            _hypertensionFactory = new PcpResultExportHypertensionFactory();

        }

        public void Create(IEnumerable<EventCustomerResultEntity> eventCustomerResultEntities, IEnumerable<OrderedPair<long, long>> orgRoleUserIdUserIdPairs, IEnumerable<UserEntity> userEntities,
            IEnumerable<Address> addresses, IEnumerable<CustomerProfileEntity> customerProfileEntities, IEnumerable<EventsEntity> eventsEntities, IEnumerable<CustomerHealthInfoEntity> customerHealthInfoEntities,
            IEnumerable<OrderedPair<long, long>> eventIdPodIdPairs, IEnumerable<PodDetailsEntity> podDetailsEntities, IEnumerable<OrderedPair<long, long>> eventIdHospitalPartnerIdPairs,
            IEnumerable<OrderedPair<long, string>> hospitalPartnerIdNamePairs, IEnumerable<EventCustomerBasicBioMetricEntity> basicBioMetricEntities, IEnumerable<EventCustomersEntity> eventCustomersEntities,
            IEnumerable<EventAppointmentEntity> eventAppointmentEntities, IEnumerable<HospitalPartnerCustomerEntity> hospitalPartnerCustomerEntities, IEnumerable<OrderedPair<long, string>> careCoordinatorIdNamePair,
            IEnumerable<CustomerPrimaryCarePhysicianEntity> primaryCarePhysicianEntities, string destinationPath, IEnumerable<long> hafQuestionIds)
        {
            long totalRecords = eventCustomerResultEntities.Count();
            long counter = 1;

            PcpResultExportHelper.Questions = PcpResultExportHelper.AllQuestions.Where(aq => hafQuestionIds.Contains(aq.FirstValue)).Select(aq => aq).ToArray();

            _logger.Info("Total Records : " + totalRecords);
           
            WriteCsvHeader(destinationPath);

            foreach (var eventCustomerResultEntity in eventCustomerResultEntities)
            {
                try
                {
                    _logger.Info(string.Format("Creating Model for event {0} and customer {1}", eventCustomerResultEntity.EventId, eventCustomerResultEntity.CustomerId));

                    var userId = orgRoleUserIdUserIdPairs.Where(oru => oru.FirstValue == eventCustomerResultEntity.CustomerId).Select(oru => oru.SecondValue).Single();

                    var user = userEntities.Where(u => u.UserId == userId).Select(u => u).Single();

                    var address = addresses.Where(a => a.Id == user.HomeAddressId).Select(a => a).Single();

                    var customer = customerProfileEntities.Where(cp => cp.CustomerId == eventCustomerResultEntity.CustomerId).Select(cp => cp).Single();

                    var eventData = eventsEntities.Where(e => e.EventId == eventCustomerResultEntity.EventId).Select(e => e).Single();

                    var podIds = eventIdPodIdPairs.Where(ep => ep.FirstValue == eventData.EventId).Select(ep => ep.SecondValue).ToArray();

                    var podName = string.Join(",", podDetailsEntities.Where(pd => podIds.Contains(pd.PodId)).Select(pd => pd.Name).ToArray());

                    var hospitalPartnerId = eventIdHospitalPartnerIdPairs.Where(ehp => ehp.FirstValue == eventData.EventId).Select(ehp => ehp.SecondValue).SingleOrDefault();

                    var hopitalPartnerName = hospitalPartnerIdNamePairs.Where(hp => hp.FirstValue == hospitalPartnerId).Select(hp => hp.SecondValue).SingleOrDefault();

                    var eventCustomer = eventCustomersEntities.Where(ec => ec.EventCustomerId == eventCustomerResultEntity.EventCustomerResultId).Select(ec => ec).Single();

                    var eventAppointment = eventAppointmentEntities.Where(ea => ea.AppointmentId == eventCustomer.AppointmentId).Select(ea => ea).Single();

                    var primaryCarePhysician = primaryCarePhysicianEntities.Where(pcp => pcp.CustomerId == eventCustomerResultEntity.CustomerId).Select(pcp => pcp).FirstOrDefault();

                    var basicBimetric = basicBioMetricEntities.Where(bb => bb.EventCustomerId == eventCustomerResultEntity.EventCustomerResultId).Select(bb => bb).FirstOrDefault();

                    var hafAnswers = customerHealthInfoEntities.Where(chi => chi.EventCustomerId == eventCustomerResultEntity.EventCustomerResultId).Select(chi => chi).ToArray();

                    var answers = new List<OrderedPair<long, string>>();

                    foreach (var question in PcpResultExportHelper.Questions)
                    {
                        var hafAnswer = hafAnswers.Where(ha => ha.CustomerHealthQuestionId == question.FirstValue).Select(ha => ha).FirstOrDefault();

                        if (hafAnswer != null)
                        {
                            answers.Add(new OrderedPair<long, string>(question.FirstValue, hafAnswer.HealthQuestionAnswer));
                        }
                        else
                        {
                            answers.Add(new OrderedPair<long, string>(question.FirstValue, ""));
                        }
                    }

                    var age = string.Empty;
                    if (user.Dob.HasValue)
                    {
                        var now = DateTime.Now;
                        var checkCurrentLeapYear = new DateTime(now.Year, 3, 1);
                        var birth = user.Dob.Value;
                        var checkBirthLeapYear = new DateTime(birth.Year, 3, 1);

                        var currentDayOfYear = now.DayOfYear;
                        if (checkCurrentLeapYear.DayOfYear == 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear != 61)
                            currentDayOfYear = now.DayOfYear - 1;
                        else if (checkCurrentLeapYear.DayOfYear != 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear == 61)
                            currentDayOfYear = now.DayOfYear + 1;

                        var years = now.Year - birth.Year - ((currentDayOfYear < birth.DayOfYear) ? 1 : 0);
                        var months = (12 + now.Month - birth.Month - ((now.Day < birth.Day) ? 1 : 0)) % 12;
                        var days = now.Day - birth.Day;
                        if (days < 0)
                            days = new DateTime(now.Year, now.Month, 1).AddDays(-1).AddDays(days).Day;

                        age = years.ToString();
                    }
                    var ssn = "N/A";
                    if (!string.IsNullOrEmpty(user.Ssn))
                    {
                        ssn = _cryptographyService.Decrypt(user.Ssn);
                        if (ssn.Length >= 9)
                        {
                            ssn = ssn.Substring(0, 3) + "-" + ssn.Substring(3, 2) + "-" + ssn.Substring(ssn.Length - 4);
                        }
                    }

                    var model = new PcpResultExportModel
                    {
                        CustomerId = customer.CustomerId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address1 = address.StreetAddressLine1,
                        City = address.City,
                        State = address.State,
                        Zip = address.ZipCode.Zip,
                        Dob = user.Dob,
                        Age = age,
                        Height = customer.Height,
                        Weight = customer.Weight > 0 ? customer.Weight.ToString() : "",
                        Gender = customer.Gender,
                        Race = customer.Race != "-1" ? customer.Race : "",
                        Email = user.Email1,
                        Phone = user.PhoneHome,
                        Ssn = ssn,
                        MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "" : customer.InsuranceId,
                        Hicn = string.IsNullOrEmpty(customer.Hicn) ? "" : customer.Hicn,
                        EventId = eventData.EventId,
                        EventDate = eventData.EventDate,
                        Pod = podName,
                        HospitalPartner = hopitalPartnerName,
                        Hipaa = ((RegulatoryState)eventCustomer.Hipaastatus).GetDescription(),
                        CheckinTime = eventAppointment.CheckinTime.HasValue ? eventAppointment.CheckinTime.Value.ToShortTimeString() : "",
                        CheckoutTime = eventAppointment.CheckoutTime.HasValue ? eventAppointment.CheckoutTime.Value.ToShortTimeString() : "",
                        HealthAssesmentAnswer = answers,
                        ResultSummary = eventCustomerResultEntity.ResultSummary.HasValue ? ((ResultInterpretation)eventCustomerResultEntity.ResultSummary).GetDescription() : ""
                    };
                    if (primaryCarePhysician != null)
                    {
                        model.PrimaryPhysicianName = new Name(primaryCarePhysician.FirstName, primaryCarePhysician.MiddleName, primaryCarePhysician.LastName).FullName;
                    }
                    if (hospitalPartnerId > 0)
                    {
                        model.PartnerRelease = eventCustomer.PartnerRelease > 0 ? ((RegulatoryState)eventCustomer.PartnerRelease).GetDescription() : "";
                        var hospitalPartnerCustomer = hospitalPartnerCustomerEntities.LastOrDefault(hpc => hpc.EventId == eventCustomerResultEntity.EventId && hpc.CustomerId == eventCustomerResultEntity.CustomerId);
                        model.CareCoordinatorStatus = hospitalPartnerCustomer != null
                            ? ((HospitalPartnerCustomerStatus)hospitalPartnerCustomer.Status).GetDescription()
                            : HospitalPartnerCustomerStatus.NotCalled.GetDescription();
                        model.CareCoordinatorOutcome = hospitalPartnerCustomer != null
                            ? ((HospitalPartnerCustomerOutcome)hospitalPartnerCustomer.Outcome).GetDescription()
                            : HospitalPartnerCustomerOutcome.NotScheduledNotInterested.GetDescription();
                        model.CareCoordinator = hospitalPartnerCustomer != null
                            ? careCoordinatorIdNamePair.First(cc => cc.FirstValue == hospitalPartnerCustomer.CareCoordinatorOrgRoleUserId).SecondValue
                            : "N/A";
                        model.CareCoordinatorNotes = hospitalPartnerCustomer != null
                            ? hospitalPartnerCustomer.Notes
                            : "";
                    }
                    else
                    {
                        model.PartnerRelease = "N/A";
                        model.CareCoordinatorStatus = "N/A";
                        model.CareCoordinatorOutcome = "N/A";
                        model.CareCoordinator = "N/A";
                        model.CareCoordinatorNotes = "N/A";
                    }

                    if (model.EventId > 0)
                    {
                        var theEvent = _eventRepository.GetById(model.EventId);
                        if (theEvent.AccountId.HasValue && theEvent.AccountId > 0)
                        {
                            var organization = _organizationRepository.GetOrganizationbyId(theEvent.AccountId.Value);
                            model.CorporateAccount = organization.Name;
                        }

                        if (theEvent.HostId > 0)
                        {
                            var host = _hostRepository.GetHostForEvent(theEvent.Id);
                            model.EventLocation = host.OrganizationName + " @ " + host.Address;
                        }
                    }

                    if (basicBimetric != null)
                    {
                        model.BloodPressure = (basicBimetric.SystolicPressure.HasValue ? basicBimetric.SystolicPressure.Value.ToString() : "0") + "/" + (basicBimetric.DiastolicPressure.HasValue ? basicBimetric.DiastolicPressure.Value.ToString() : "0");

                        model.PulseRate = basicBimetric.PulseRate.HasValue ? basicBimetric.PulseRate.Value.ToString() : "";

                        model.IsAbnormalBloodPressure = basicBimetric.IsBloodPressureElevated.HasValue && basicBimetric.IsBloodPressureElevated.Value ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
                    }
                    ITestResultRepository testResultRepository;

                    var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvAAA);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv Aaa  data.");

                        testResultRepository = new AwvAaaTestRepository();
                        var awvAaaTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId);
                        if (awvAaaTestResult != null)
                        {
                            model = _awvAaaFactory.SetAwvAaaData(model, awvAaaTestResult as AwvAaaTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvEcho);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv Echo  data.");

                        testResultRepository = new AwvEchocardiogramTestRepository();
                        var awvEchoTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId);
                        if (awvEchoTestResult != null)
                        {
                            model = _awvEchoFactory.SetAwvEchoData(model, awvEchoTestResult as AwvEchocardiogramTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvCarotid);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv Carotid data.");

                        testResultRepository = new AwvCarotidTestRepository();
                        var awvCarotidTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId);
                        if (awvCarotidTestResult != null)
                        {
                            model = _awvCarotidFactory.SetAwvCarotidData(model, awvCarotidTestResult as AwvCarotidTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvSpiro);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting AWV Spiro data.");

                        testResultRepository = new AwvSpiroTestRepository();
                        var awvSpiroTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId);
                        if (awvSpiroTestResult != null)
                        {
                            model = _awvSpiroFactory.SetAwvSpiroData(model, awvSpiroTestResult as AwvSpiroTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvABI);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv ABI data.");

                        testResultRepository = new AwvAbiTestRepository();
                        var awvAbiTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId);
                        if (awvAbiTestResult != null)
                        {
                            model = _awvAbiFactory.SetAwvAbiData(model, awvAbiTestResult as AwvAbiTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.AwvEkg);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Awv EKG data.");

                        testResultRepository = new AwvEkgTestRepository();
                        var awvEkgTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId);
                        if (awvEkgTestResult != null)
                        {
                            model = _awvEkgFactory.SetAwvEkgData(model, awvEkgTestResult as AwvEkgTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.Vision);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Vision data.");

                        testResultRepository = new VisionTestRepository();
                        var visionTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId);
                        if (visionTestResult != null)
                        {
                            model = _visionFactory.SetVisionData(model, visionTestResult as VisionTestResult);
                        }
                    }

                    WriteCsv(model, destinationPath);
                    _logger.Info(counter + " completed out of " + totalRecords);

                    //if (counter > 10)
                    //    break;
                    counter++;

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("\n\nFor Event {0} and Customer {1} \n Error:{2}", eventCustomerResultEntity.EventId, eventCustomerResultEntity.CustomerId, ex.Message));
                }
            }
        }


        private void WriteCsvHeader(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            var streamWriter = new StreamWriter(fs);

            try
            {
                var members = (typeof(PcpResultExportModel)).GetMembers();

                var header = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, string>>))
                        {
                            header.AddRange(PcpResultExportHelper.Questions.Select(q => EscapeString(q.SecondValue)).ToArray());
                            continue;
                        }
                    }
                    else
                        continue;

                    string propertyName = memberInfo.Name;
                    bool isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(EscapeString(propertyName));
                }

                streamWriter.Write(string.Join(PcpResultExportHelper.Delimiter, header.ToArray()) + Environment.NewLine);
            }
            catch (Exception ex)
            {
                _logger.Error("While creating CSV File header: " + ex.Message + "\n\t" + ex.StackTrace + "\n\n");
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }

        private void WriteCsv(PcpResultExportModel model, string fileName)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(PcpResultExportModel)).GetMembers();
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, string>>))
                        {
                            foreach (var question in PcpResultExportHelper.Questions)
                            {
                                if (model.HealthAssesmentAnswer != null && model.HealthAssesmentAnswer.Any())
                                {
                                    var answer = model.HealthAssesmentAnswer.Where(a => a.FirstValue == question.FirstValue).FirstOrDefault();

                                    values.Add(EscapeString(answer.SecondValue));
                                }
                                else
                                    values.Add(string.Empty);
                            }
                            continue;
                        }
                    }
                    else
                        continue;


                    bool isHidden = false;
                    FormatAttribute formatter = null;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is FormatAttribute)
                            {
                                formatter = (FormatAttribute)attribute;
                            }
                        }
                    }

                    if (isHidden) continue;
                    var obj = propInfo.GetValue(model, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(EscapeString(formatter.ToString(obj)));
                    else
                        values.Add(EscapeString(obj.ToString()));

                }

                streamWriter.Write(string.Join(PcpResultExportHelper.Delimiter, values.ToArray()) + Environment.NewLine);


            }
            catch (Exception ex)
            {
                _logger.Error("While creating CSV File : " + ex.Message + "\n\t" + ex.StackTrace + "\n\n");
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }

        private static string EscapeString(string toEscape)
        {
            if (toEscape == null)
            {
                return "";
            }
            return '"' + toEscape.Replace("\"", @"""""") + '"';
        }

    }
}