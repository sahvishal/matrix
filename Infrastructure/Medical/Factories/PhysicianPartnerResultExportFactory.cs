using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core;
using Falcon.App.Core.Application;
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
    public class PhysicianPartnerResultExportFactory : IPhysicianPartnerResultExportFactory
    {
        private readonly TestResultService _testResultService;
        private readonly CryptographyService _cryptographyService = new PasswordCryptographyService();
        private readonly ILogger _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IOrganizationRepository _organizationRepository;

        private readonly IPhysicianPartnerResultExportEchoFactory _echoFactory;
        private readonly IPhysicianPartnerResultExportAaaFactory _aaaFactory;
        private readonly IPhysicianPartnerResultExportLeadFactory _leadFactory;
        private readonly IPhysicianPartnerResultExportSpiroFactory _spiroFactory;
        private readonly ISettings _settings;

        private readonly string _destinationDirectory;

        public PhysicianPartnerResultExportFactory(ILogger logger, string destinationDirectory, ISettings settings)
        {
            _logger = logger;
            _destinationDirectory = destinationDirectory;
            _settings = settings;

            _testResultService = new TestResultService();
            _eventRepository = new EventRepository();
            _hostRepository = new HostRepository();
            _organizationRepository = new OrganizationRepository();

            _echoFactory = new PhysicianPartnerResultExportEchoFactory();
            _aaaFactory = new PhysicianPartnerResultExportAaaFactory();
            _leadFactory = new PhysicianPartnerResultExportLeadFactory();
            _spiroFactory = new PhysicianPartnerResultExportSpiroFactory();
        }

        public void Create(IEnumerable<EventCustomerResultEntity> eventCustomerResultEntities, IEnumerable<OrderedPair<long, long>> orgRoleUserIdUserIdPairs, IEnumerable<UserEntity> userEntities,
            IEnumerable<Address> addresses, IEnumerable<CustomerProfileEntity> customerProfileEntities, IEnumerable<EventsEntity> eventsEntities, IEnumerable<CustomerHealthInfoEntity> customerHealthInfoEntities,
            IEnumerable<OrderedPair<long, long>> eventIdPodIdPairs, IEnumerable<PodDetailsEntity> podDetailsEntities, IEnumerable<OrderedPair<long, long>> eventIdHospitalPartnerIdPairs, IEnumerable<OrderedPair<long, string>> hospitalPartnerIdNamePairs,
            IEnumerable<EventCustomerBasicBioMetricEntity> basicBioMetricEntities, IEnumerable<EventCustomersEntity> eventCustomersEntities, IEnumerable<EventAppointmentEntity> eventAppointmentEntities,
            IEnumerable<HospitalPartnerCustomerEntity> hospitalPartnerCustomerEntities, IEnumerable<OrderedPair<long, string>> careCoordinatorIdNamePair, IEnumerable<CustomerPrimaryCarePhysicianEntity> primaryCarePhysicianEntities)
        {
            long totalRecords = eventCustomerResultEntities.Count();
            long counter = 1;

            _logger.Info("Total Records : " + totalRecords);

            var fileName = _destinationDirectory + string.Format(@"\ResultExport_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd")); ;

            WriteCsvHeader(fileName);

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

                    var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;

                    var answers = new List<OrderedPair<long, string>>();

                    foreach (var question in PhysicianPartnerResultExportHelper.Questions)
                    {
                        var hafAnswer = hafAnswers.Where(ha => ha.CustomerHealthQuestionId == question.FirstValue).Select(ha => ha).FirstOrDefault();

                        if (hafAnswer != null)
                        {
                            answers.Add(new OrderedPair<long, string>(question.FirstValue, hafAnswer.HealthQuestionAnswer));
                        }
                        else
                        {
                            if (question.FirstValue == 47)
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, "NA"));
                            else
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, "No"));
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

                    var model = new PhysicianPartnerResultExportModel
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
                        model.IsAbnormalBloodPressure = basicBimetric.IsBloodPressureElevated.HasValue && basicBimetric.IsBloodPressureElevated.Value ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
                    }
                    ITestResultRepository testResultRepository;

                    var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.PPEcho);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Echo data.");

                        testResultRepository = new PpEchocardiogramTestRepository();
                        var echoTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (echoTestResult != null)
                        {
                            model = _echoFactory.SetEchoData(model, echoTestResult as PpEchocardiogramTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.PPAAA);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting AAA data.");

                        testResultRepository = new PpAaaTestRepository();
                        var aaaTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (aaaTestResult != null)
                        {
                            model = _aaaFactory.SetAaaData(model, aaaTestResult as PpAaaTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.Lead);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Lead data.");

                        testResultRepository = new LeadTestRepository();
                        var leadTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (leadTestResult != null)
                        {
                            model = _leadFactory.SetLeadData(model, leadTestResult as LeadTestResult);
                        }
                    }

                    isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventData.EventId, customer.CustomerId, (long)TestType.Spiro);
                    if (isTestPurchased)
                    {
                        _logger.Info("Setting Spiro data.");

                        testResultRepository = new SpiroTestRepository();
                        var spiroTestResult = testResultRepository.GetTestResults(customer.CustomerId, eventData.EventId, isNewResultFlow);
                        if (spiroTestResult != null)
                        {
                            model = _spiroFactory.SetSpiroData(model, spiroTestResult as SpiroTestResult);
                        }
                    }

                    WriteCsv(model, fileName);
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
                var members = (typeof(PhysicianPartnerResultExportModel)).GetMembers();

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
                            header.AddRange(PhysicianPartnerResultExportHelper.Questions.Select(q => EscapeString(q.SecondValue)).ToArray());
                            continue;
                        }
                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                        {
                            if (memberInfo.Name == "EchoDiagnosisCodes")
                                header.AddRange(PhysicianPartnerResultExportHelper.EchoDiagnosisCodes.Select(EscapeString).ToArray());
                            else if (memberInfo.Name == "AaaDiagnosisCodes")
                                header.AddRange(PhysicianPartnerResultExportHelper.AaaDiagnosisCodes.Select(EscapeString).ToArray());
                            else if (memberInfo.Name == "LeadDiagnosisCodes")
                                header.AddRange(PhysicianPartnerResultExportHelper.LeadDiagnosisCodes.Select(EscapeString).ToArray());
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

                streamWriter.Write(string.Join(PhysicianPartnerResultExportHelper.Delimiter, header.ToArray()) + Environment.NewLine);
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

        private void WriteCsv(PhysicianPartnerResultExportModel model, string fileName)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(PhysicianPartnerResultExportModel)).GetMembers();
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
                            foreach (var question in PhysicianPartnerResultExportHelper.Questions)
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

                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                        {
                            if (memberInfo.Name == "EchoDiagnosisCodes")
                            {
                                if (model.EchoDiagnosisCodes != null)
                                    values.AddRange(model.EchoDiagnosisCodes.Select(code => EscapeString(code.SecondValue)));
                                else
                                    values.AddRange(PhysicianPartnerResultExportHelper.EchoDiagnosisCodes.Select(code => string.Empty));
                            }
                            else if (memberInfo.Name == "AaaDiagnosisCodes")
                            {
                                if (model.AaaDiagnosisCodes != null)
                                    values.AddRange(model.AaaDiagnosisCodes.Select(code => EscapeString(code.SecondValue)));
                                else
                                    values.AddRange(PhysicianPartnerResultExportHelper.AaaDiagnosisCodes.Select(code => string.Empty));
                            }
                            else if (memberInfo.Name == "LeadDiagnosisCodes")
                            {
                                if (model.LeadDiagnosisCodes != null)
                                    values.AddRange(model.LeadDiagnosisCodes.Select(code => EscapeString(code.SecondValue)));
                                else
                                    values.AddRange(PhysicianPartnerResultExportHelper.LeadDiagnosisCodes.Select(code => string.Empty));
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

                streamWriter.Write(string.Join(PhysicianPartnerResultExportHelper.Delimiter, values.ToArray()) + Environment.NewLine);


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
