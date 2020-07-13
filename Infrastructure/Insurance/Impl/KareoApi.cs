using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Core.Insurance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Kareo;
using Newtonsoft.Json;

namespace Falcon.App.Infrastructure.Insurance.Impl
{
    public class KareoApi
    {
        //private const string CustomerKey = "w45cb83ie96m";
        private const string ClientVersion = "2.1";

        private const string CaseName = "HF Screening";

        private const string ProviderFirstName = "JUSTIN";
        private const string ProviderMiddleName = "HUNG";
        private const string ProviderLastName = "PHAM";
        private const string ProviderNpi = "1821040866";

        private const string PlaceOfServiceCode = "15";
        private const string PlaceOfServiceName = "Mobile Unit";

        public ModifyPatientResp CreatePatient(Customer customer, Eligibility eligibility, IEnumerable<InsuranceCompany> insuranceCompanies, PrimaryCarePhysician pcp, BillingAccount billingAccount)
        {
            try
            {
                var client = new KareoServicesClient();

                var requestHeader = new RequestHeader
                {
                    ClientVersion = ClientVersion,
                    CustomerKey = billingAccount.CustomerKey,
                    User = billingAccount.UserName,
                    Password = billingAccount.Password
                };

                // Create the patient to insert.
                var newPatient = new PatientCreate
                {
                    FirstName = customer.Name.FirstName,
                    MiddleName = customer.Name.MiddleName,
                    LastName = customer.Name.MiddleName,
                    DateofBirth = customer.DateOfBirth,
                    Gender = customer.Gender == Gender.Male ? GenderCode.Male : customer.Gender == Gender.Female ? GenderCode.Female : GenderCode.Unknown,
                    MedicalRecordNumber = customer.CustomerId.ToString(),
                    AddressLine1 = customer.Address.StreetAddressLine1,
                    AddressLine2 = customer.Address.StreetAddressLine2,
                    City = customer.Address.City,
                    State = customer.Address.StateCode,
                    ZipCode = customer.Address.ZipCode.Zip,
                    HomePhone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : string.Empty,
                    WorkPhone = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.FormatPhoneNumber : string.Empty,
                    MobilePhone = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : string.Empty,
                    EmailAddress = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    PatientExternalID = customer.CustomerId.ToString()
                };

                // Set the practice we want to add this patient to
                var practice = new PracticeIdentifierReq
                {
                    PracticeName = billingAccount.Name
                };

                // Create the case details for the patient
                var patientCase = new PatientCaseCreateReq
                {
                    CaseName = CaseName,
                    //patientCase.PayerScenario
                    Active = true,
                    SendPatientStatements = true
                };

                var eligibleResponse = JsonConvert.DeserializeObject<EligibleResponse>(eligibility.Response);
                InsuranceCompany insuranceCompany = null;
                if (eligibleResponse.PrimaryInsurance != null)
                {
                    insuranceCompany = insuranceCompanies.FirstOrDefault(ic => ic.Code == eligibleResponse.PrimaryInsurance.Id);
                }
                else if (eligibleResponse.Insurance != null)
                {
                    insuranceCompany = insuranceCompanies.FirstOrDefault(ic => ic.Code == eligibleResponse.Insurance.Id);
                }

                if (insuranceCompany == null)
                {
                    insuranceCompany = insuranceCompanies.First(ic => ic.Id == eligibility.InsuranceCompanyId);
                }

                // Create the insurance policies for the patient case
                var primaryPolicy = new InsurancePolicyCreateReq
                {
                    CompanyName = insuranceCompany.Name,
                    PlanName = eligibleResponse.Plan.PlanName,
                    PolicyNumber = eligibleResponse.Demographics.Subscriber.MemberId,
                    PolicyGroupNumber = eligibleResponse.Demographics.Subscriber.GroupId,
                    Copay = eligibility.CoPayment.ToString("0.00")
                };
                //primaryPolicy.PlanID = eligibleResponse.Plan.PlanNumber;

                patientCase.Policies = new InsurancePolicyCreateReq[] { primaryPolicy };


                newPatient.Practice = practice;
                newPatient.Cases = new PatientCaseCreateReq[] { patientCase };
                if (pcp != null)
                {
                    newPatient.PrimaryCarePhysician = new PhysicianIdentifierReq
                    {
                        FullName = pcp.Name.FullName
                    };
                }

                // Create the create patient request object
                var request = new CreatePatientReq
                {
                    RequestHeader = requestHeader,
                    Patient = newPatient
                };

                // Call the Create Patient method
                var response = client.CreatePatient(request);

                // Check the response for an error
                if (response.ErrorResponse.IsError)
                    throw new Exception(response.ErrorResponse.ErrorMessage);

                if (!response.SecurityResponse.SecurityResultSuccess)
                    throw new Exception(response.SecurityResponse.SecurityResult);

                client.Close();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CreateEncounterResp CreateEncounter(long patientId, Event eventData, IEnumerable<EventTest> eventTests, BillingAccount billingAccount)
        {
            try
            {
                var patientResp = GetPatient(patientId, billingAccount);

                var client = new KareoServicesClient();

                var requestHeader = new RequestHeader
                {
                    ClientVersion = ClientVersion,
                    CustomerKey = billingAccount.CustomerKey,
                    User = billingAccount.UserName,
                    Password = billingAccount.Password
                };

                // Create the encounter to insert.
                var newEncounter = new EncounterCreate
                {
                    ServiceStartDate = eventData.EventDate,
                    PostDate = eventData.EventDate.AddDays(1),
                    BatchNumber = eventData.Id.ToString()
                };

                // Set the practice we want to add this encounter to
                int practiceId;
                int.TryParse(patientResp.Patient.PracticeId, out practiceId);
                var practice = new PracticeIdentifierReq
                {
                    PracticeID = practiceId,
                    PracticeName = patientResp.Patient.PracticeName
                };

                // Create the patient for the encounter
                var patient = new PatientIdentifierReq
                {
                    PatientID = Convert.ToInt32(patientId)
                };

                // Create the patient case for the encounter
                int caseId;
                int.TryParse(patientResp.Patient.Cases.First().PatientCaseID, out caseId);
                var encounterCase = new PatientCaseIdentifierReq
                {
                    CaseID = caseId
                };

                var provider = new ProviderIdentifierDetailedReq
                {
                    FirstName = ProviderFirstName,
                    MiddleName = ProviderMiddleName,
                    LastName = ProviderLastName,
                    NPI = ProviderNpi
                };

                // Set the service location
                var location = new EncounterServiceLocation
                {
                    LocationName = billingAccount.Name
                };

                var placeOfService = new EncounterPlaceOfService
                {
                    PlaceOfServiceCode = PlaceOfServiceCode,
                    PlaceOfServiceName = PlaceOfServiceName
                };

                // Create the service lines for this encounter
                var serviceLines = new List<ServiceLineReq>();
                if (eventTests != null && eventTests.Any())
                {
                    foreach (var eventTest in eventTests)
                    {
                        serviceLines.Add(new ServiceLineReq
                        {
                            ServiceStartDate = eventData.EventDate,
                            ProcedureCode = eventTest.Test.CPTCode,
                            DiagnosisCode1 = eventTest.Test.DiagnosisCode,
                            Units = 1,
                            UnitCharge = Convert.ToDouble(eventTest.Price)
                        });
                    }
                }


                // Make sure you set the encounter's practice, service location, patient, case, and
                // provider (and any other objects you create relating to the encounter)
                newEncounter.Practice = practice;
                newEncounter.Patient = patient;
                newEncounter.Case = encounterCase;
                newEncounter.RenderingProvider = provider;
                newEncounter.SupervisingProvider = provider;
                newEncounter.ServiceLocation = location;
                newEncounter.PlaceOfService = placeOfService;
                newEncounter.ServiceLines = serviceLines.ToArray();

                newEncounter.EncounterStatus = EncounterStatusCode.Submitted;

                // Create the create encounter request object
                var request = new CreateEncounterReq
                {
                    RequestHeader = requestHeader,
                    Encounter = newEncounter
                };

                // Call the Create Encounter method
                var response = client.CreateEncounter(request);

                // Check the response for an error
                if (response.ErrorResponse.IsError)
                    throw new Exception(response.ErrorResponse.ErrorMessage);
                if (!response.SecurityResponse.SecurityResultSuccess)
                    throw new Exception(response.SecurityResponse.SecurityResult);

                client.Close();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GetPatientResp GetPatient(long customerId, BillingAccount billingAccount)
        {
            try
            {
                var client = new KareoServicesClient();

                var requestHeader = new RequestHeader
                {
                    ClientVersion = ClientVersion,
                    CustomerKey = billingAccount.CustomerKey,
                    User = billingAccount.UserName,
                    Password = billingAccount.Password
                };

                var getPatientReq = new GetPatientReq
                {
                    RequestHeader = requestHeader,
                    Filter = new SinglePatientFilter { ExternalID = customerId.ToString() }
                };

                var getPatientResp = client.GetPatient(getPatientReq);

                client.Close();
                return getPatientResp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GetChargesResp GetClaim(BillingAccount billingAccount, long eventId, DateTime eventDate)
        {
            var client = new KareoServicesClient();

            var requestHeader = new RequestHeader
            {
                ClientVersion = ClientVersion,
                CustomerKey = billingAccount.CustomerKey,
                User = billingAccount.UserName,
                Password = billingAccount.Password
            };

            var getChargesReq = new GetChargesReq
            {
                RequestHeader = requestHeader,
                Filter = new ChargeFilter()
                {
                    PracticeName = billingAccount.Name,
                    BatchNumber = eventId.ToString(),
                    FromServiceDate = eventDate.AddDays(-1).ToShortDateString(),
                    ToServiceDate = eventDate.AddDays(1).ToShortDateString()
                },
                Fields = new ChargeFieldsToReturn()
                {
                    ID = true,
                    EncounterID = true,
                    PatientID = true,
                    ProcedureCode = true,
                    ProcedureName = true,
                    Units = true,
                    TotalCharges = true,
                    AdjustedCharges = true,
                    Receipts = true,
                    PatientBalance = true,
                    InsuranceBalance = true,
                    TotalBalance = true,
                    Status = true,
                    PatientFirstBillDate = true,
                    PatientLastBillDate = true
                }
            };

            var getChargesResp = client.GetCharges(getChargesReq);

            if (getChargesResp.ErrorResponse.IsError)
                throw new Exception(getChargesResp.ErrorResponse.ErrorMessage);
            if (!getChargesResp.SecurityResponse.SecurityResultSuccess)
                throw new Exception(getChargesResp.SecurityResponse.SecurityResult);

            client.Close();
            return getChargesResp;
        }

        public ModifyPatientResp CreatePatientNew(Customer customer, PrimaryCarePhysician pcp, BillingAccount billingAccount)
        {
            try
            {
                var client = new KareoServicesClient();

                var requestHeader = new RequestHeader
                {
                    ClientVersion = ClientVersion,
                    CustomerKey = billingAccount.CustomerKey,
                    User = billingAccount.UserName,
                    Password = billingAccount.Password
                };

                // Create the patient to insert.
                var newPatient = new PatientCreate
                {
                    FirstName = customer.Name.FirstName,
                    MiddleName = customer.Name.MiddleName,
                    LastName = customer.Name.LastName,
                    DateofBirth = customer.DateOfBirth,
                    Gender = customer.Gender == Gender.Male ? GenderCode.Male : customer.Gender == Gender.Female ? GenderCode.Female : GenderCode.Unknown,
                    MedicalRecordNumber = customer.CustomerId.ToString(),
                    AddressLine1 = customer.Address.StreetAddressLine1,
                    AddressLine2 = customer.Address.StreetAddressLine2,
                    City = customer.Address.City,
                    State = customer.Address.StateCode,
                    ZipCode = customer.Address.ZipCode.Zip,
                    HomePhone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : string.Empty,
                    WorkPhone = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.FormatPhoneNumber : string.Empty,
                    MobilePhone = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : string.Empty,
                    EmailAddress = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    PatientExternalID = customer.CustomerId.ToString()
                };

                // Set the practice we want to add this patient to
                var practice = new PracticeIdentifierReq
                {
                    PracticeName = billingAccount.Name
                };
                newPatient.Practice = practice;

                // Create the case details for the patient
                var patientCase = new PatientCaseCreateReq
                {
                    CaseName = CaseName,
                    //patientCase.PayerScenario
                    Active = true,
                    SendPatientStatements = true
                };
                newPatient.Cases = new[] { patientCase };

                if (pcp != null)
                {
                    newPatient.PrimaryCarePhysician = new PhysicianIdentifierReq
                    {
                        FullName = pcp.Name.FullName
                    };
                }

                // Create the create patient request object
                var request = new CreatePatientReq
                {
                    RequestHeader = requestHeader,
                    Patient = newPatient
                };

                // Call the Create Patient method
                var response = client.CreatePatient(request);

                // Check the response for an error
                if (response.ErrorResponse.IsError)
                    throw new Exception(response.ErrorResponse.ErrorMessage);

                if (!response.SecurityResponse.SecurityResultSuccess)
                    throw new Exception(response.SecurityResponse.SecurityResult);

                client.Close();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GetPatientsResp GetPatients(string firstName, string lastName, DateTime dateOfBirth, BillingAccount billingAccount)
        {
            try
            {
                var client = new KareoServicesClient();

                var requestHeader = new RequestHeader
                {
                    ClientVersion = ClientVersion,
                    CustomerKey = billingAccount.CustomerKey,
                    User = billingAccount.UserName,
                    Password = billingAccount.Password
                };

                var getPatientsReq = new GetPatientsReq
                {
                    RequestHeader = requestHeader,
                    Filter = new PatientFilter
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        FromDateOfBirth = dateOfBirth.ToString("MM/dd/yyyy"),
                        ToDateOfBirth = dateOfBirth.AddDays(1).ToString("MM/dd/yyyy")
                    }
                };

                var getPatientsResp = client.GetPatients(getPatientsReq);

                client.Close();
                return getPatientsResp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ModifyPatientResp UpdatePatient(long patientId, Customer customer, PrimaryCarePhysician pcp, BillingAccount billingAccount)
        {
            try
            {
                var client = new KareoServicesClient();

                var requestHeader = new RequestHeader
                {
                    ClientVersion = ClientVersion,
                    CustomerKey = billingAccount.CustomerKey,
                    User = billingAccount.UserName,
                    Password = billingAccount.Password
                };

                // Create the patient to insert.
                var updatePatient = new PatientUpdate
                {
                    PatientID = Convert.ToInt32(patientId),
                    FirstName = customer.Name.FirstName,
                    MiddleName = customer.Name.MiddleName,
                    LastName = customer.Name.LastName,
                    DateofBirth = customer.DateOfBirth,
                    Gender = customer.Gender == Gender.Male ? GenderCode.Male : customer.Gender == Gender.Female ? GenderCode.Female : GenderCode.Unknown,
                    MedicalRecordNumber = customer.CustomerId.ToString(),
                    AddressLine1 = customer.Address.StreetAddressLine1,
                    AddressLine2 = customer.Address.StreetAddressLine2,
                    City = customer.Address.City,
                    State = customer.Address.StateCode,
                    ZipCode = customer.Address.ZipCode.Zip,
                    HomePhone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : string.Empty,
                    WorkPhone = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.FormatPhoneNumber : string.Empty,
                    MobilePhone = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : string.Empty,
                    EmailAddress = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    PatientExternalID = customer.CustomerId.ToString()
                };

                // Set the practice we want to add this patient to
                var practice = new PracticeIdentifierReq
                {
                    PracticeName = billingAccount.Name
                };
                updatePatient.Practice = practice;

                // Create the case details for the patient
                var patientCase = new PatientCaseUpdateReq
                {
                    CaseName = CaseName,
                    //patientCase.PayerScenario
                    Active = true,
                    SendPatientStatements = true
                };
                updatePatient.Cases = new[] { patientCase };

                if (pcp != null)
                {
                    updatePatient.PrimaryCarePhysician = new PhysicianIdentifierReq
                    {
                        FullName = pcp.Name.FullName
                    };
                }

                // Create the create patient request object
                var request = new UpdatePatientReq
                {
                    RequestHeader = requestHeader,
                    Patient = updatePatient
                };

                // Call the Create Patient method
                var response = client.UpdatePatient(request);

                // Check the response for an error
                if (response.ErrorResponse.IsError)
                    throw new Exception(response.ErrorResponse.ErrorMessage);

                if (!response.SecurityResponse.SecurityResultSuccess)
                    throw new Exception(response.SecurityResponse.SecurityResult);

                client.Close();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
