using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CCD;
using Falcon.App.Core.CCD.ValueType;
using Falcon.App.Core.CCD.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.CCD.impl
{
    [DefaultImplementation]
    public class ClinicalDocumentFactory : IClinicalDocumentFactory
    {
        private readonly ISettings _settings;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;

        private readonly CcdVitalSectionFactory _ccdVitalSectionFactory;
        public const string VitalSignEntery = "DRIV";
        public const string OrganizerClassCode = "CLUSTER";
        public const string OrganizerMoodCode = "EVN";

        public ClinicalDocumentFactory(ISettings settings, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository,
            IEventTestRepository eventTestRepository)
        {
            _settings = settings;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;

            _ccdVitalSectionFactory = new CcdVitalSectionFactory();
        }

        public ClinicalDocument Create(EventCustomerResult eventCustomerResult, Customer customer, PrimaryCarePhysician pcp, Event theEventData)
        {

            var patientIds = GetClinicalRoots(null, customer.CustomerId.ToString(), ClinicalDocumentRoots.PatinetMedicalRecordNumber);

            if (!string.IsNullOrWhiteSpace(customer.Hicn))
            {
                patientIds = GetClinicalRoots(patientIds, customer.Hicn.Trim(), ClinicalDocumentRoots.PatientAdditionalIds);
            }

            if (!string.IsNullOrWhiteSpace(customer.InsuranceId))
            {
                patientIds = GetClinicalRoots(patientIds, customer.InsuranceId.Trim(), ClinicalDocumentRoots.PatientAdditionalIds);
            }
            var telecom = new List<ClinicalTeleCom>();
            if (customer.HomePhoneNumber != null && !customer.HomePhoneNumber.IsEmpty())
                telecom.Add(new ClinicalTeleCom(TelecomType.PrimaryHome, customer.HomePhoneNumber.GlobalPhoneNumberFormat));

            if (customer.MobilePhoneNumber != null && !customer.MobilePhoneNumber.IsEmpty())
                telecom.Add(new ClinicalTeleCom(TelecomType.MobileContact, customer.MobilePhoneNumber.GlobalPhoneNumberFormat));


            if (customer.OfficePhoneNumber != null && !customer.OfficePhoneNumber.IsEmpty())
                telecom.Add(new ClinicalTeleCom(TelecomType.Workplace, customer.OfficePhoneNumber.GlobalPhoneNumberFormat));

            var orderId = _orderRepository.GetOrderIdByEventIdCustomerId(theEventData.Id, customer.CustomerId);
            var package = _eventPackageRepository.GetPackageForOrder(orderId);
            var eventTests = _eventTestRepository.GetTestsForOrder(orderId);

            if (package != null)
                eventTests = eventTests.Concat(package.Tests.ToArray());

            var tests = eventTests.Select(et => et.Test).ToArray();


            var structureBodySection = new List<StructuredBodyComponent>()
            {
                new StructuredBodyComponent() {Section = _ccdVitalSectionFactory.GetVitalSection(customer, theEventData,tests,_settings)},
                GetResultSection(customer,theEventData,tests),
            };

            return new ClinicalDocument
            {
                Realm = new RealmCode("US"),
                Title = "Summary of Patient Chart",
                EffectiveTime = new DocumentGenerationtime(DateTime.Now),
                // LanguageCode = new LanguageCode("en-US"),
                RecordTarget = new RecordTarget
                {
                    PatientRole = new PatientRole
                    {
                        PatientIds = patientIds,
                        PatinetAddress = GetClinicalAddress(customer.BillingAddress, AddressType.HomeAddress),
                        Patient = GetPatient(customer),
                        TeleCom = telecom.IsNullOrEmpty() ? null : telecom.ToArray(),
                        ProviderOrganization = GetProviderOrganization()
                    }
                },
                DocumentationOfCcd = GetDocumentationOf(pcp, theEventData),
                CdaBodyComponent = new CdaBodyComponent() { StructuredBody = new StructuredBody { VitalSigns = structureBodySection.ToArray() } }

            };

        }

        private ProviderOrganization GetProviderOrganization()
        {
            return new ProviderOrganization
            {
                Name = _settings.FullBusinessName,
                TeleCom = new ClinicalTeleCom(TelecomType.Workplace, PhoneNumber.Create(_settings.PhoneTollFree, PhoneNumberType.Office).GlobalPhoneNumberFormat),
                Address = new ClinicalAddress
                {
                    StreetAddressLine = _settings.Address1,
                    AdditionalLocator = _settings.Address2,
                    AddressUse = AddressType.Workplace,
                    City = _settings.City,
                    Countery = "US",
                    PostalCode = _settings.ZipCode,
                    State = _settings.State
                }
            };
        }

        private ClinicalRoot GetClinicalRoot(string ext, string root)
        {
            return new ClinicalRoot(ext, root);
        }

        private ClinicalRoot[] GetClinicalRoots(IEnumerable<ClinicalRoot> clinicalRoots, string ext, string root)
        {
            if (clinicalRoots == null)
            {
                return new ClinicalRoot[] { GetClinicalRoot(ext, root) };
            }
            var roots = clinicalRoots.ToList();
            roots.Add(new ClinicalRoot(ext, root));

            return roots.ToArray();
        }

        private ClinicalAddress GetClinicalAddress(Address address, string addressUse)
        {
            if (address == null) return null;
            return new ClinicalAddress
            {
                AddressUse = addressUse,
                City = address.City,
                State = address.StateCode,
                Countery = address.Country,
                StreetAddressLine = address.StreetAddressLine1,
                AdditionalLocator = string.IsNullOrWhiteSpace(address.StreetAddressLine2) ? string.Empty : address.StreetAddressLine2,
                PostalCode = address.ZipCode.Zip
            };
        }

        private Patient GetPatient(Customer customer)
        {
            return new Patient
             {
                 ClinicalName = GetName(customer.Name),
                 BirthTime = new ValueNode { Value = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value.ToString("yyyyMMdd") : string.Empty },
                 GenderCode = Gender(customer),

             };
        }

        private ClinicalName GetName(Name name)
        {
            var givenName = new List<string> { name.FirstName };
            if (!string.IsNullOrWhiteSpace(name.MiddleName))
                givenName.Add(name.MiddleName);

            return new ClinicalName
            {
                GivenName = givenName.ToArray(),
                LastName = name.LastName,
                Use = NameType.LegalName
            };
        }

        private ClinicalCode Gender(Customer customer)
        {
            var clinicalCodes = ClinicalDocumentHelper.ClinicalCodes.Where(x => x.FirstValue == ClinicalCodeType.Gender);
            if (customer.Gender == Core.Users.Enum.Gender.Female)
            {
                return clinicalCodes.Single(x => x.SecondValue.DisplayName == customer.Gender.ToString()).SecondValue;
            }

            if (customer.Gender == Core.Users.Enum.Gender.Male)
            {
                return clinicalCodes.Single(x => x.SecondValue.DisplayName == customer.Gender.ToString()).SecondValue;
            }

            if (customer.Gender == Core.Users.Enum.Gender.Unspecified)
            {
                return clinicalCodes.Single(x => x.SecondValue.DisplayName != Core.Users.Enum.Gender.Female.ToString() &&
                            x.SecondValue.DisplayName != Core.Users.Enum.Gender.Male.ToString()).SecondValue;
            }

            return null;
        }

        private DocumentationOfCcd GetDocumentationOf(PrimaryCarePhysician pcp, Event theEventData)
        {
            if (pcp == null) return null;
            AssignedPerson assingedPerson = null;
            if (pcp.Name != null)
            {
                assingedPerson = new AssignedPerson
                {
                    Name = GetName(pcp.Name)
                };
            }
            return new DocumentationOfCcd
            {
                ServiceEvent = new ServiceEvent
                {
                    EffectiveTime = new EffectiveTime
                    {
                        Low = new DocumentGenerationDate(theEventData.EventDate),
                        High = new DocumentGenerationtime(DateTime.Now)
                    },
                    ClassCode = PerformerTypeCode.Perfromer,
                    Performer = new Performer
                    {
                        AssingnedEntity = new AssingnedEntity
                        {
                            Address = GetClinicalAddress(pcp.Address, AddressType.Workplace),

                            AssignedPerson = assingedPerson,
                            ClinicalTeleCom = (pcp.Fax != null && !pcp.Fax.IsEmpty()) ? new ClinicalTeleCom(TelecomType.Workplace, pcp.Fax.FaxNumberFormat) : null
                        },
                        TypeCode = PerformerTypeCode.Perfromer
                    }

                }
            };
        }

        private Entry[] GetResultEntery(Customer customer, Event eventData, IEnumerable<Test> tests)
        {
            var sbodyComponent = new List<Entry>();

            if (!tests.IsNullOrEmpty())
                tests = tests.Where(x => x.Id != (long)TestType.Hypertension && x.IsRecordable).ToArray();

            foreach (var test in tests)
            {
                switch ((TestType)test.Id)
                {
                    case TestType.AwvLipid:
                        sbodyComponent.Add(CreateLipidEntery(customer, eventData));
                        break;
                    case TestType.AwvAAA:
                        sbodyComponent.Add(CreateAwvAaaEntery(customer, eventData));
                        break;

                    case TestType.UrineMicroalbumin:
                        sbodyComponent.Add(CreateMicoralbumineEntery(customer, eventData));
                        break;
                    case TestType.AwvGlucose:
                        sbodyComponent.Add(CreateAwvGlucoseEntery(customer, eventData));
                        break;

                }
            }
            return sbodyComponent.ToArray();
        }

        private StructuredBodyComponent GetResultSection(Customer customer, Event eventData, IEnumerable<Test> tests)
        {
            return new StructuredBodyComponent
            {
                Section = new Section
                {
                    TemplateId = new ClinicalRoot(DateTime.Today.ToString("yyyy-MM-dd"), ClinicalDocumentRoots.ResultSectionTemplateRootId),
                    Title = "Result",
                    Code = ClinicalDocumentHelper.LoincCodes.Single(x => x.FirstValue == LoincCode.ResultSection).SecondValue,
                    Entery = GetResultEntery(customer, eventData, tests)
                }
            };
        }


        private Component[] SetComponents(List<Observation> observation)
        {
            if (observation.IsNullOrEmpty()) return null;

            return observation.Select(obesrvation => new Component { Obesrvation = obesrvation }).ToArray();
        }

        private string Reading<T>(ResultReading<T> resultReading)
        {
            return (resultReading != null && resultReading.Reading != null) ? resultReading.Reading.ToString() : string.Empty;
        }


        private Entry CreateLipidEntery(Customer customer, Event theEventData)
        {
            var templateValue = ClinicalDocumentHelper.ClinicalRoots.First(c => c.FirstValue == ClinicalRootType.LipidProfile).SecondValue;
            var code = ClinicalDocumentHelper.LoincCodes.First(cc => cc.FirstValue == LoincCode.LipidProfile).SecondValue;


            return new Entry
            {
                TypeCode = VitalSignEntery,
                Organizer = new Organizer
                {
                    ClassCode = OrganizerClassCode,
                    MoodCode = OrganizerMoodCode,
                    TemplateId = templateValue,
                    // Id = new ClinicalRoot(Guid.NewGuid().ToString()),
                    Code = code,
                    StatusCode = new StatusCode { Code = "completed" },
                    Component = SetComponents(LipidObservations(customer, theEventData))
                }
            };
        }
        public ClinicalRoot[] GetLipidObseravationTemplates()
        {
            return new ClinicalRoot[]
            {
                ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.LipidGlucose).SecondValue,
                ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.LipidHdlcholesterol).SecondValue,
                ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.LipidLdlcholesterol).SecondValue,
                ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.LipidTriglycerides).SecondValue,
            };
        }
        private List<Observation> LipidObservations(Customer customer, Event theEventData)
        {
            ITestResultRepository testResultRepository = new AwvLipidTestRepository();
            var isNewResultFlow = theEventData.EventDate >= _settings.ResultFlowChangeDate;
            var awvLipidTestResult = (AwvLipidTestResult)testResultRepository.GetTestResults(customer.CustomerId, theEventData.Id, isNewResultFlow);

            var observation = new List<Observation>();
            if (awvLipidTestResult != null && (awvLipidTestResult.TestNotPerformed == null || awvLipidTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0) && (awvLipidTestResult.UnableScreenReason == null || awvLipidTestResult.UnableScreenReason.Count == 0))
            {


                if (awvLipidTestResult.TriGlycerides != null)
                {
                    var triGlyceride = string.Empty;
                    var refRang = string.Empty;
                    if (awvLipidTestResult.TriGlycerides.Reading != null)
                        triGlyceride = awvLipidTestResult.TriGlycerides.Reading;

                    if (awvLipidTestResult.TriGlycerides.Finding != null)
                        refRang = awvLipidTestResult.TriGlycerides.Finding.Label;
                    var trig = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.LipidProfile).SecondValue,
                        TemplateId = GetLipidObseravationTemplates(),
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.LipidTriglycerides).SecondValue,
                        Reference = " <referenceRange><observationRange><text>" + refRang + "</text></observationRange></referenceRange>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = triGlyceride, Unit = "" }
                    };
                    observation.Add(trig);
                }

                //LDL

                if (awvLipidTestResult.LDL != null)
                {
                    var ldlReading = string.Empty;
                    var refRang = string.Empty;

                    if (awvLipidTestResult.LDL.Reading != null)
                        ldlReading = Reading(awvLipidTestResult.LDL);

                    if (awvLipidTestResult.LDL.Finding != null)
                        refRang = awvLipidTestResult.LDL.Finding.Label;


                    var ldl = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.LipidProfile).SecondValue,
                        TemplateId = GetLipidObseravationTemplates(),
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.LipidLdlcholesterol).SecondValue,
                        Reference = " <referenceRange><observationRange><text>" + refRang + "</text></observationRange></referenceRange>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = ldlReading, Unit = "" }
                    };
                    observation.Add(ldl);
                }

                if (awvLipidTestResult.HDL != null)
                {
                    //hdl
                    var hdlReading = string.Empty;
                    var refRang = string.Empty;

                    if (awvLipidTestResult.HDL.Reading != null)
                        hdlReading = awvLipidTestResult.HDL.Reading;

                    if (awvLipidTestResult.HDL.Finding != null)
                        refRang = awvLipidTestResult.HDL.Finding.Label;

                    var hdl = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.LipidProfile).SecondValue,
                        TemplateId = GetLipidObseravationTemplates(),
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.LipidLdlcholesterol).SecondValue,
                        Reference = " <referenceRange><observationRange><text>" + refRang + "</text></observationRange></referenceRange>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = hdlReading, Unit = "" }
                    };
                    observation.Add(hdl);
                }


                //
                if (awvLipidTestResult.TotalCholestrol != null)
                {
                    var totalCholesterolReading = string.Empty;
                    var refRang = string.Empty;

                    if (awvLipidTestResult.TotalCholestrol.Reading != null)
                        totalCholesterolReading = awvLipidTestResult.TotalCholestrol.Reading;

                    if (awvLipidTestResult.TotalCholestrol.Finding != null)
                        refRang = awvLipidTestResult.TotalCholestrol.Finding.Label;


                    var totalChole = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.LipidProfile).SecondValue,
                        TemplateId = GetLipidObseravationTemplates(),
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.LipidHdlcholesterol).SecondValue,
                        Reference = " <referenceRange><observationRange><text>" + refRang + "</text></observationRange></referenceRange>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = totalCholesterolReading, Unit = "" }
                    };
                    observation.Add(totalChole);
                }

            }
            return observation;
        }

        private Entry CreateAwvAaaEntery(Customer customer, Event theEventData)
        {
            var templateValue = ClinicalDocumentHelper.ClinicalRoots.First(c => c.FirstValue == ClinicalRootType.AwvAaa).SecondValue;
            var code = ClinicalDocumentHelper.LoincCodes.First(cc => cc.FirstValue == LoincCode.AwvAaa).SecondValue;

            return new Entry
            {
                TypeCode = VitalSignEntery,
                Organizer = new Organizer
                {
                    ClassCode = OrganizerClassCode,
                    MoodCode = OrganizerMoodCode,
                    TemplateId = templateValue,
                    // Id = new ClinicalRoot(Guid.NewGuid().ToString()),
                    Code = code,
                    StatusCode = new StatusCode { Code = "completed" },
                    Component = SetComponents(AwvaaaObservations(customer, theEventData))
                }
            };
        }
        private List<Observation> AwvaaaObservations(Customer customer, Event theEventData)
        {
            ITestResultRepository testResultRepository = new AwvAaaTestRepository();
            var isNewResultFlow = theEventData.EventDate >= _settings.ResultFlowChangeDate;
            var testResult = (AwvAaaTestResult)testResultRepository.GetTestResults(customer.CustomerId, theEventData.Id, isNewResultFlow);

            var observation = new List<Observation>();
            if (testResult != null && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0) && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0))
            {
                if (testResult.AortaSize != null)
                {
                    var asize = testResult.AortaSize != null ? testResult.AortaSize.Reading != null ? testResult.AortaSize.Reading.ToString() : "" : "";
                    var aaaLargestSagittalMeasurement = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaLargestSagittalMeasurement).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaLargestSagittalMeasurement).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = asize, Unit = "cm" }
                    };
                    observation.Add(aaaLargestSagittalMeasurement);
                }

                if (testResult.AortaRangeSaggitalView != null)
                {
                    var aortaRangeSaggitalView = string.Join(",", testResult.AortaRangeSaggitalView != null ? testResult.AortaRangeSaggitalView.Select(s => s.Label).ToArray() : new[] { "" });
                    var aaaLargestSagittalLocation = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaLargestSagittalLocation).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaLargestSagittalLocation).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = aortaRangeSaggitalView, Unit = "" }
                    };
                    observation.Add(aaaLargestSagittalLocation);
                }

                if (testResult.TransverseView != null)
                {
                    var reading = testResult.TransverseView != null ? testResult.TransverseView.FirstValue != null ? testResult.TransverseView.FirstValue.Reading.ToString() : "" : "";
                    var transverseView = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaLargestTransverseMeasurement1).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaLargestTransverseMeasurement1).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(transverseView);
                }

                if (testResult.TransverseView != null)
                {
                    var reading = testResult.TransverseView != null ? testResult.TransverseView.SecondValue != null ? testResult.TransverseView.SecondValue.Reading.ToString() : "" : "";
                    var transverseView = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaLargestTransverseMeasurement2).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaLargestTransverseMeasurement2).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(transverseView);
                }

                if (testResult.AortaRangeTransverseView != null)
                {
                    var reading = string.Join(",", testResult.AortaRangeTransverseView != null ? testResult.AortaRangeTransverseView.Select(s => s.Label).ToArray() : new[] { "" });
                    var transverseView = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaLargestMeasurementTransverseLocation).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaLargestMeasurementTransverseLocation).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(transverseView);
                }

                if (testResult.PeakSystolicVelocity != null)
                {
                    var reading = testResult.PeakSystolicVelocity != null ? testResult.PeakSystolicVelocity.Reading != null ? testResult.PeakSystolicVelocity.Reading.ToString() : "" : "";
                    var transverseView = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaPeakSystolicVelocityMeasurement).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaPeakSystolicVelocityMeasurement).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(transverseView);
                }

                if (testResult.PeakSystolicVelocityStandardFindings != null)
                {
                    var reading = string.Join(",", testResult.PeakSystolicVelocityStandardFindings != null ? testResult.PeakSystolicVelocityStandardFindings.Select(s => s.Label).ToArray() : new[] { "" });
                    var peakSystolicVelocityStandardFindings = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaPeakSystolicVelocityLocation).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaPeakSystolicVelocityLocation).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(peakSystolicVelocityStandardFindings);
                }

                if (testResult.ResidualLumenStandardFindings != null)
                {
                    var reading = testResult.ResidualLumenStandardFindings != null ? testResult.ResidualLumenStandardFindings.SecondValue != null ? testResult.ResidualLumenStandardFindings.SecondValue.Reading.ToString() : "" : "";
                    var residualLumenStandardFindings = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaResidualLumenMeasurement2).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaResidualLumenMeasurement2).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(residualLumenStandardFindings);
                }

                if (testResult.ResidualLumenStandardFindings != null)
                {
                    var reading = testResult.ResidualLumenStandardFindings != null ? testResult.ResidualLumenStandardFindings.SecondValue != null ? testResult.ResidualLumenStandardFindings.SecondValue.Reading.ToString() : "" : "";
                    var residualLumenStandardFindings = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaResidualLumenMeasurement2).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaResidualLumenMeasurement2).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(residualLumenStandardFindings);
                }

                if (testResult.AorticDissection != null)
                {
                    var reading = (testResult.AorticDissection.Reading ? "Yes" : string.Empty);
                    var aorticDissection = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaAorticDissection).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaAorticDissection).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(aorticDissection);
                }

                if (testResult.Plaque != null)
                {
                    var reading = (testResult.Plaque.Reading ? "Yes" : string.Empty);
                    var plaque = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaPlaque).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaPlaque).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(plaque);
                }

                if (testResult.Thrombus != null)
                {
                    var reading = (testResult.Thrombus.Reading ? "Yes" : string.Empty);
                    var thrombus = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvAaa).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AaaThrombus).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AaaThrombus).SecondValue,
                        //Reference = " <reference value='#DiastolicBP_1'/>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(thrombus);
                }

            }
            return observation;
        }

        private Entry CreateMicoralbumineEntery(Customer customer, Event theEventData)
        {
            var templateValue = ClinicalDocumentHelper.ClinicalRoots.First(c => c.FirstValue == ClinicalRootType.Urinalysis).SecondValue;
            var code = ClinicalDocumentHelper.LoincCodes.First(cc => cc.FirstValue == LoincCode.Urinalysis).SecondValue;

            return new Entry
            {
                TypeCode = VitalSignEntery,
                Organizer = new Organizer
                {
                    ClassCode = OrganizerClassCode,
                    MoodCode = OrganizerMoodCode,
                    TemplateId = templateValue,
                    // Id = new ClinicalRoot(Guid.NewGuid().ToString()),
                    Code = code,
                    StatusCode = new StatusCode { Code = "completed" },
                    Component = SetComponents(UrinalysisObservations(customer, theEventData))
                }
            };
        }

        private List<Observation> UrinalysisObservations(Customer customer, Event theEventData)
        {
            ITestResultRepository testResultRepository = new UrineMicroalbuminTestRepository();
            var isNewResultFlow = theEventData.EventDate >= _settings.ResultFlowChangeDate;
            var testResult = (UrineMicroalbuminTestResult)testResultRepository.GetTestResults(customer.CustomerId, theEventData.Id, isNewResultFlow);

            var observation = new List<Observation>();
            if (testResult != null && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0) && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0))
            {
                if (testResult.MicroalbuminValue != null)
                {
                    var refRang = string.Empty;
                    var reading = testResult.MicroalbuminValue != null ? testResult.MicroalbuminValue.Reading != null ? testResult.MicroalbuminValue.Reading.ToString() : "" : "";
                    if (testResult.Finding != null)
                        refRang = testResult.Finding.Label;
                    var urinalysis = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.Urinalysis).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.Urinalysis).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.Urinalysis).SecondValue,
                        Reference = " <referenceRange><observationRange><text>" + refRang + "</text></observationRange></referenceRange>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "" }
                    };
                    observation.Add(urinalysis);
                }
            }
            return observation;
        }

        private Entry CreateAwvGlucoseEntery(Customer customer, Event theEventData)
        {
            var templateValue = ClinicalDocumentHelper.ClinicalRoots.First(c => c.FirstValue == ClinicalRootType.AwvGlucose).SecondValue;
            var code = ClinicalDocumentHelper.LoincCodes.First(cc => cc.FirstValue == LoincCode.AwvGlucose).SecondValue;

            return new Entry
            {
                TypeCode = VitalSignEntery,
                Organizer = new Organizer
                {
                    ClassCode = OrganizerClassCode,
                    MoodCode = OrganizerMoodCode,
                    TemplateId = templateValue,
                    // Id = new ClinicalRoot(Guid.NewGuid().ToString()),
                    Code = code,
                    StatusCode = new StatusCode { Code = "completed" },
                    Component = SetComponents(AwvGlucoseObservations(customer, theEventData))
                }
            };
        }

        private List<Observation> AwvGlucoseObservations(Customer customer, Event theEventData)
        {
            ITestResultRepository testResultRepository = new AwvGlucoseTestRepository();
            var isNewResultFlow = theEventData.EventDate >= _settings.ResultFlowChangeDate;
            var testResult = (AwvGlucoseTestResult)testResultRepository.GetTestResults(customer.CustomerId, theEventData.Id, isNewResultFlow);

            var observation = new List<Observation>();
            if (testResult != null && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0) && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0))
            {
                if (testResult.Glucose != null)
                {

                    var reading = testResult.Glucose != null ? testResult.Glucose.Reading != null ? testResult.Glucose.Reading.ToString() : "" : "";
                    var refRang = string.Empty;
                    if (testResult.Glucose.Finding != null)
                        refRang = testResult.Glucose.Finding.Label;

                    var urinalysis = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvGlucose).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvGlucose).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AwvGlucose).SecondValue,
                        Reference = " <referenceRange><observationRange><text>" + refRang + "</text></observationRange></referenceRange>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "mg/dl" }
                    };

                    observation.Add(urinalysis);
                }
            }
            return observation;
        }

        private List<Observation> AwvHba1cObservations(Customer customer, Event theEventData)
        {
            ITestResultRepository testResultRepository = new AwvGlucoseTestRepository();
            var isNewResultFlow = theEventData.EventDate >= _settings.ResultFlowChangeDate;

            var testResult = (AwvGlucoseTestResult)testResultRepository.GetTestResults(customer.CustomerId, theEventData.Id, isNewResultFlow);

            var observation = new List<Observation>();
            if (testResult != null && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0) && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0))
            {
                if (testResult.Glucose != null)
                {

                    var reading = testResult.Glucose != null ? testResult.Glucose.Reading != null ? testResult.Glucose.Reading.ToString() : "" : "";
                    var refRang = string.Empty;
                    if (testResult.Glucose.Finding != null)
                        refRang = testResult.Glucose.Finding.Label;

                    var urinalysis = new Observation
                    {
                        Id = ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvGlucose).SecondValue,
                        TemplateId = new[] { ClinicalDocumentHelper.ClinicalRoots.First(cr => cr.FirstValue == ClinicalRootType.AwvGlucose).SecondValue },
                        Code = ClinicalDocumentHelper.LoincCodes.First(x => x.FirstValue == LoincCode.AwvGlucose).SecondValue,
                        Reference = " <referenceRange><observationRange><text>" + refRang + "</text></observationRange></referenceRange>",
                        StatusCode = new StatusCode { Code = "completed" },
                        ObservationValue = new ObservationValue { Value = reading, Unit = "mg/dl" }
                    };

                    observation.Add(urinalysis);
                }
            }
            return observation;
        }
    }
}