using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class CorporateUploadHelper : ICorporateUploadHelper
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventSchedulingSlotService _slotService;
        private readonly IEventService _eventService;
        private readonly ICsvReader _csvReader;
        private readonly IAppointmentRepository _appointmentRepository;

        public CorporateUploadHelper(IMediaRepository mediaRepository, IStateRepository stateRepository, ICountryRepository countryRepository,
            IEventPackageRepository eventPackageRepository, IEventSchedulingSlotService slotService, IEventService eventService, ICsvReader csvReader, IAppointmentRepository appointmentRepository)
        {
            _mediaRepository = mediaRepository;
            _stateRepository = stateRepository;
            _countryRepository = countryRepository;
            _eventPackageRepository = eventPackageRepository;
            _slotService = slotService;
            _eventService = eventService;
            _csvReader = csvReader;
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<MassRegistrationEditModel> GetRegistraionModels(string fileName)
        {
            var physicalPath = _mediaRepository.GetTempMediaFileLocation().PhysicalPath;

            var fullPath = physicalPath + fileName;
            var customerTable = _csvReader.ReadWithTextQualifier(fullPath);

            var states = _stateRepository.GetAllStates();
            var countries = _countryRepository.GetAll();

            var registrationEditModels = new List<MassRegistrationEditModel>();

            if (customerTable.Rows.Count > 0)
            {
                var invalidRowRemarks = new List<string>();
                var selectedAppointmentIds = new List<long>();

                foreach (DataRow row in customerTable.Rows)
                {
                    try
                    {
                        var eventId = Convert.ToInt64(row["EventId"].ToString());
                        var registrationEditModel = GetRegistrationEditModel(row, states, countries, eventId, selectedAppointmentIds);
                        registrationEditModels.Add(registrationEditModel);
                    }
                    catch (Exception ex)
                    {
                        invalidRowRemarks.Add("System Error:" + ex.Message);
                        continue;
                    }
                }
            }
            return registrationEditModels;
        }

        public MassRegistrationEditModel GetRegistrationEditModel(DataRow row, IEnumerable<State> states, IEnumerable<Country> countries, long eventId, List<long> selectedAppointmentIds)
        {
            var registrationEditModel = new MassRegistrationEditModel();
            registrationEditModel.FirstName = GetRowValue(row, "FirstName");
            registrationEditModel.LastName = GetRowValue(row, "LastName");
            registrationEditModel.Email = GetRowValue(row, "Email");

            registrationEditModel.Address = new AddressEditModel();
            registrationEditModel.Address.StreetAddressLine1 = GetRowValue(row, "Address");
            registrationEditModel.Address.StreetAddressLine2 = GetRowValue(row, "Suite");
            registrationEditModel.Address.City = GetRowValue(row, "City");

            registrationEditModel.Address.StateId =
                states.Where(s => s.Name == GetRowValue(row, "State")).Select(s => s.Id).FirstOrDefault();

            registrationEditModel.Address.CountryId =
                countries.Where(c => c.Name == GetRowValue(row, "Country")).Select(c => c.Id).FirstOrDefault();

            registrationEditModel.Address.ZipCode = GetRowValue(row, "Zip");

            var packages = _eventPackageRepository.GetPackagesForEvent(eventId);
            var appointments = _slotService.GetSlots(eventId, AppointmentStatus.Free).ToList();

            appointments.RemoveAll(a => selectedAppointmentIds.Contains(a.Id));

            registrationEditModel.PackageId = packages.Where(p => p.Package.Name == GetRowValue(row, "Package")).Select(p => p.PackageId).FirstOrDefault();

            var appointmentString = GetRowValue(row, "AppointmentTime");
            registrationEditModel.AppointmentId = string.IsNullOrEmpty(appointmentString) ? 0 : appointments.Where(ap => ap.StartTime.ToShortTimeString() == Convert.ToDateTime((string)appointmentString).ToShortTimeString()).Select(ap => ap.Id).FirstOrDefault();

            if (registrationEditModel.AppointmentId > 0)
                selectedAppointmentIds.Add(registrationEditModel.AppointmentId);

            var dateString = GetRowValue(row, "DOB");
            DateTime date;
            if (DateTime.TryParse(dateString, out date))
                registrationEditModel.DateOfBirth = date;

            registrationEditModel.HomeNumber = PhoneNumber.Create(GetRowValue(row, "PhoneNumber"), PhoneNumberType.Home);
            try
            {
                registrationEditModel.EmployeeId = GetRowValue(row, "EmployeeId");
            }
            catch
            { }


            try
            {
                registrationEditModel.InsuranceId = GetRowValue(row, "MemberId");
            }
            catch
            { }

            try
            {
                registrationEditModel.InsuranceId = GetRowValue(row, "InsuranceId");
            }
            catch
            { }

            try
            {
                var ssn = GetRowValue(row, "SSN");
                if (!string.IsNullOrEmpty(ssn))
                {
                    var length = ssn.Length;
                    var appendString = "";
                    for (int i = 0; i < 9 - length; i++)
                    {
                        appendString += "X";
                    }
                    registrationEditModel.Ssn = appendString + ssn;
                }
            }
            catch
            { }

            registrationEditModel.SendNotification = true;
            registrationEditModel.AddFreeShipping = true;
            return registrationEditModel;
        }

        public void SetDropDownInfo(MassRegistrationListModel model)
        {
            var eventpackges = _eventPackageRepository.GetPackagesForEvent(model.EventId);
            if (eventpackges != null && eventpackges.Count() > 0)
                model.Packages = eventpackges.Select(ep => ep.Package).OrderByDescending(ep => ep.Price).ToArray();
            model.Appointments = _slotService.GetSlots(model.EventId, AppointmentStatus.Free);
            model.Countries = _countryRepository.GetAll();
            model.States = _stateRepository.GetAllStates();
            model.Races = Race.None.GetNameValuePairs();
            var pairs = Gender.Male.GetNameValuePairs();
            model.Genders = pairs.Where(p => p.FirstValue != (int)Gender.Unspecified).Select(p => p).ToList();
        }

        public void SetEventDetails(MassRegistrationListModel model)
        {
            var eventData = _eventService.GetById(model.EventId);
            model.EventName = eventData.Name;
            model.EventDate = eventData.EventDate;
            model.RegisteredCustomersCount = _appointmentRepository.GetAllAppointmentsForEvent(model.EventId).Count();
            model.EventAddress = new Address()
            {
                StreetAddressLine1 = eventData.StreetAddressLine1,
                StreetAddressLine2 = eventData.StreetAddressLine2,
                City = eventData.City,
                State = eventData.State,
                ZipCode = new ZipCode(eventData.Zip)
            };
        }

        public static string ValidateModel<T>(IValidator<T> validator, T objectToValidate)
        {
            var result = validator.Validate(objectToValidate);
            if (result.IsValid) return string.Empty;

            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "&nbsp;&nbsp;"));

            if (htmlString.Length > 0)
            {
                return htmlString;
            }
            return string.Empty;
        }

        public static string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        public string CheckAddtionalField(CorporateCustomerEditModel customerEditModel, IEnumerable<AccountAdditionalFieldsEditModel> accountAdditionalFieldEditModel)
        {
            string errorMessage = string.Empty;
            if (!accountAdditionalFieldEditModel.Any() && (!string.IsNullOrEmpty(customerEditModel.AdditionalField1) || !string.IsNullOrEmpty(customerEditModel.AdditionalField2)
                                                           || !string.IsNullOrEmpty(customerEditModel.AdditionalField3) || !string.IsNullOrEmpty(customerEditModel.AdditionalField4)))
            {
                return errorMessage = "'Additional Fields'";
            }
            else
            {
                var additionalFieldids = accountAdditionalFieldEditModel.Select(x => x.AdditionalFieldId).ToList();

                if (!string.IsNullOrEmpty(customerEditModel.AdditionalField1))
                {
                    if (!additionalFieldids.Contains((long)AdditionalFieldsEnum.AdditionalField1))
                        errorMessage = errorMessage + "'Field 1',";
                }
                if (!string.IsNullOrEmpty(customerEditModel.AdditionalField2))
                {
                    if (!additionalFieldids.Contains((long)AdditionalFieldsEnum.AdditionalField2))
                        errorMessage = errorMessage + "'Field 2',";
                }
                if (!string.IsNullOrEmpty(customerEditModel.AdditionalField3))
                {
                    if (!additionalFieldids.Contains((long)AdditionalFieldsEnum.AdditionalField3))
                        errorMessage = errorMessage + "'Field 3',";
                }
                if (!string.IsNullOrEmpty(customerEditModel.AdditionalField4))
                {
                    if (!additionalFieldids.Contains((long)AdditionalFieldsEnum.AdditionalField4))
                        errorMessage = errorMessage + "'Field 4',";
                }

            }
            return errorMessage.Trim(',');
        }

        public long FailedCustomerCount(string failedCustomerFilePath, MediaLocation mediaLocation)
        {

            var file = mediaLocation.PhysicalPath + failedCustomerFilePath;

            var customerTable = _csvReader.ReadWithTextQualifier(file);

            var query = customerTable.AsEnumerable();

            return query.Count();
        }

        public void CreateHeaderFileRecord(string filePath, DataTable dataTable)
        {
            try
            {
                var query = (from DataColumn q in dataTable.Columns select q.ColumnName).ToArray();

                var header = string.Join(",", query);

                using (var sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(header + ",Error Message");
                    sw.Close();
                }
            }
            catch (Exception) { }

        }

        public CorporateCustomerEditModel GetCorporateCustomerEditModel(DataRow row)
        {
            var editModel = new CorporateCustomerEditModel();
            editModel.MemberId = GetRowValue(row, CorporateUploadColumn.MemberID);
            editModel.FirstName = GetRowValue(row, CorporateUploadColumn.FirstName);
            editModel.MiddleName = GetRowValue(row, CorporateUploadColumn.MiddleName);
            editModel.LastName = GetRowValue(row, CorporateUploadColumn.LastName);
            editModel.Gender = GetRowValue(row, CorporateUploadColumn.Gender);

            var dateofBirth = CovertToDate(GetRowValue(row, CorporateUploadColumn.Dob));
            editModel.Dob = dateofBirth == null ? GetRowValue(row, CorporateUploadColumn.Dob) : dateofBirth.Value.ToString("MM/dd/yyyy");

            editModel.Email = GetRowValue(row, CorporateUploadColumn.Email);
            editModel.AlternateEmail = GetRowValue(row, CorporateUploadColumn.Email);
            editModel.PhoneCell = GetRowValue(row, CorporateUploadColumn.PhoneCell);
            editModel.PhoneHome = GetRowValue(row, CorporateUploadColumn.PhoneHome);
            editModel.Address1 = GetRowValue(row, CorporateUploadColumn.Address1);
            editModel.Address2 = GetRowValue(row, CorporateUploadColumn.Address2);
            editModel.City = GetRowValue(row, CorporateUploadColumn.City);
            editModel.State = GetRowValue(row, CorporateUploadColumn.State);
            editModel.Zip = GetRowValue(row, CorporateUploadColumn.Zip);
            editModel.Hicn = GetRowValue(row, CorporateUploadColumn.Hicn);
            editModel.PcpFirstName = GetRowValue(row, CorporateUploadColumn.PcpFirstName);
            editModel.PcpLastName = GetRowValue(row, CorporateUploadColumn.PcpLastName);
            editModel.PcpPhone = GetRowValue(row, CorporateUploadColumn.PcpPhone);
            editModel.PcpFax = GetRowValue(row, CorporateUploadColumn.PcpFax);
            editModel.PcpEmail = GetRowValue(row, CorporateUploadColumn.PcpEmail);
            editModel.PcpAddress1 = GetRowValue(row, CorporateUploadColumn.PcpAddress1);
            editModel.PcpAddress2 = GetRowValue(row, CorporateUploadColumn.PcpAddress2);
            editModel.PcpCity = GetRowValue(row, CorporateUploadColumn.PcpCity);
            editModel.PcpState = GetRowValue(row, CorporateUploadColumn.PcpState);
            editModel.PcpZip = GetRowValue(row, CorporateUploadColumn.PcpZip);
            editModel.PcpNpi = GetRowValue(row, CorporateUploadColumn.PcpNpi);

            editModel.PreApprovedTest = GetTests(row, CorporateUploadColumn.PreApprovedTest);

            editModel.IsEligible = GetRowValue(row, CorporateUploadColumn.IsEligible);
            editModel.TargetYear = GetRowValue(row, CorporateUploadColumn.TargetYear);
            editModel.Language = GetRowValue(row, CorporateUploadColumn.Language);
            editModel.Lab = GetRowValue(row, CorporateUploadColumn.Lab);
            editModel.Copay = GetRowValue(row, CorporateUploadColumn.Copay);
            editModel.MedicareAdvantagePlanName = GetRowValue(row, CorporateUploadColumn.MedicareAdvantagePlanName);
            editModel.Lpi = GetRowValue(row, CorporateUploadColumn.Lpi);
            editModel.Market = GetRowValue(row, CorporateUploadColumn.Market);
            editModel.Mrn = GetRowValue(row, CorporateUploadColumn.Mrn);
            editModel.GroupName = GetRowValue(row, CorporateUploadColumn.GroupName);

            editModel.IcdCodes = GetIcdCodesTests(row, CorporateUploadColumn.IcdCodes);

            editModel.PreApprovedPackage = GetRowValue(row, CorporateUploadColumn.PreApprovedPackage);
            editModel.PCPMailingAddress1 = GetRowValue(row, CorporateUploadColumn.PCPMailingAddress1);
            editModel.PCPMailingAddress2 = GetRowValue(row, CorporateUploadColumn.PCPMailingAddress2);
            editModel.PCPMailingCity = GetRowValue(row, CorporateUploadColumn.PCPMailingCity);
            editModel.PCPMailingState = GetRowValue(row, CorporateUploadColumn.PCPMailingState);
            editModel.PCPMailingZip = GetRowValue(row, CorporateUploadColumn.PCPMailingZip);

            editModel.CurrentMedication = GetCurrentMedication(row, CorporateUploadColumn.CurrentMedication);
            editModel.CurrentMedicationSource = GetCurrentMedication(row, CorporateUploadColumn.CurrentMedicationSource);

            editModel.AdditionalField1 = GetRowValue(row, CorporateUploadColumn.AdditionalField1);
            editModel.AdditionalField2 = GetRowValue(row, CorporateUploadColumn.AdditionalField2);
            editModel.AdditionalField3 = GetRowValue(row, CorporateUploadColumn.AdditionalField3);
            editModel.AdditionalField4 = GetRowValue(row, CorporateUploadColumn.AdditionalField4);
            editModel.Activity = GetRowValue(row, CorporateUploadColumn.Activity);
            editModel.PredictedZip = GetRowValue(row, CorporateUploadColumn.PredictedZip);
            editModel.Mbi = GetRowValue(row, CorporateUploadColumn.Mbi);
            editModel.BillingMemberId = GetRowValue(row, CorporateUploadColumn.BillingMemberId);
            editModel.BillingMemberPlan = GetRowValue(row, CorporateUploadColumn.BillingMemberPlan);

            editModel.BillingMemberPlanYear = ConvertToInt(GetRowValue(row, CorporateUploadColumn.BillingMemberPlanYear));

            editModel.WarmTransferAllowed = GetRowValue(row, CorporateUploadColumn.WarmTransferAllowed);
            editModel.WarmTransferYear = GetRowValue(row, CorporateUploadColumn.WarmTransferYear);
            editModel.AcesId = GetRowValue(row, CorporateUploadColumn.AcesId);
            //editModel.RequiredTest = GetTests(row, CorporateUploadColumn.RequiredTest);
            //editModel.ForYear = GetRowValue(row, CorporateUploadColumn.ForYear);
            editModel.EligibilityYear = GetRowValue(row, MemberUploadbyAcesUploadColumn.EligibilityYear);

            return editModel;
        }

        private IEnumerable<string> GetTests(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value || string.IsNullOrWhiteSpace(row[fieldName].ToString())) return null;

            return row[fieldName].ToString().Split(',').Select(x => x.Trim().ToLower()).ToList();
        }

        private IEnumerable<string> GetCurrentMedication(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value || string.IsNullOrWhiteSpace(row[fieldName].ToString())) return null;

            return row[fieldName].ToString().Split(',').Select(x => x.Trim().ToLower()).ToList();
        }

        private IEnumerable<string> GetIcdCodesTests(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value || string.IsNullOrWhiteSpace(row[fieldName].ToString())) return null;

            return row[fieldName].ToString().Split(',').Select(x => x.Trim().ToUpper()).ToList();
        }

        public void UpdateFailedRecords(string filePath, IEnumerable<CorporateCustomerEditModel> failedCustomers)
        {
            var sb = new StringBuilder();
            var members = (typeof(CorporateCustomerEditModel)).GetMembers();
            var sanitizer = new CSVSanitizer();

            foreach (var customer in failedCustomers)
            {
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
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
                    var obj = propInfo.GetValue(customer, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else if (obj.GetType() == typeof(List<string>))
                        values.Add(sanitizer.EscapeString(string.Join(",", ((List<string>)obj).ToArray())));
                    else if (obj.GetType() == typeof(IEnumerable<string>))
                        values.Add(sanitizer.EscapeString(string.Join(",", ((IEnumerable<string>)obj).ToArray())));
                    else if (obj.GetType() == typeof(String[]) || obj.GetType() == typeof(string[]))
                        values.Add(sanitizer.EscapeString(string.Join(",", ((string[])obj).ToArray())));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }
                sb.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            System.IO.File.AppendAllText(filePath, sb.ToString());
        }

        public string CheckIsFileContainsRecord(bool isParseSucceded, MediaLocation mediaLocation, string filePath)
        {
            if (!isParseSucceded) return string.Empty;

            try
            {
                var customerTable = _csvReader.ReadWithTextQualifier(mediaLocation.PhysicalPath + filePath);

                if (customerTable.Rows.Count > 0)
                    return mediaLocation.Url + filePath;

                DirectoryOperationsHelper.Delete(filePath);

            }
            catch (Exception)
            {
            }

            return string.Empty;
        }

        public void CreateHeaderAdjustOrderForEventCustoerRecord(string filePath)
        {
            try
            {
                var members = (typeof(EventCusomerAdjustOrderViewModel)).GetMembers();

                var header = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
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

                    header.Add(propertyName);
                }

                using (var sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(string.Join(",", header));
                    sw.Close();
                }
            }
            catch (Exception) { }

        }

        public void UpdateAdjustOrderRecords(string filePath, IEnumerable<EventCusomerAdjustOrderViewModel> model)
        {
            var sb = new StringBuilder();
            var members = (typeof(EventCusomerAdjustOrderViewModel)).GetMembers();
            var sanitizer = new CSVSanitizer();

            foreach (var customer in model)
            {
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
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
                    var obj = propInfo.GetValue(customer, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else if (obj.GetType() == typeof(List<string>))
                        values.Add(sanitizer.EscapeString(string.Join(",", ((List<string>)obj).ToArray())));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }
                sb.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            File.AppendAllText(filePath, sb.ToString());
        }

        public string CheckAllColumnExist(string[] columnList)
        {
            var obj = new CorporateUploadColumn();
            var checkList = obj.GetType()
              .GetFields(BindingFlags.Public | BindingFlags.Static)
              .Where(f => f.FieldType == typeof(string))
              .Select(x => ((string)x.GetValue(null)).ToLower()).ToArray();

            var list = checkList.Except(columnList);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

        public string CheckAllEligibilityColumnExist(string[] givenList)
        {
            var columns = "Eligibility Status,Patient ID,Eligibility Year";
            string[] checkList = columns.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            var list = checkList.Except(givenList);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

        private int? ConvertToInt(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            int result = 0;
            int.TryParse(value, out result);

            if (result > 0)
                return result;

            return null;
        }

        private DateTime? CovertToDate(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            DateTime date;

            if (DateTime.TryParseExact(value,
                "yyyyMMdd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out date))
            {
                return date;
            }
            if (DateTime.TryParse(value,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out date))
            {
                return date;
            }
            return null;

        }

        public CorporateCustomerEditModel GetMemberUploadbyAcesCustomerEditModel(DataRow row)
        {
            var editModel = new CorporateCustomerEditModel();
            editModel.MemberId = GetRowValue(row, MemberUploadbyAcesUploadColumn.MemberID);
            editModel.FirstName = GetRowValue(row, MemberUploadbyAcesUploadColumn.FirstName);
            editModel.MiddleName = GetRowValue(row, MemberUploadbyAcesUploadColumn.MiddleName);
            editModel.LastName = GetRowValue(row, MemberUploadbyAcesUploadColumn.LastName);
            editModel.Gender = GetRowValue(row, MemberUploadbyAcesUploadColumn.Gender);

            var dateofBirth = CovertToDate(GetRowValue(row, MemberUploadbyAcesUploadColumn.Dob));
            editModel.Dob = dateofBirth == null ? GetRowValue(row, MemberUploadbyAcesUploadColumn.Dob) : dateofBirth.Value.ToString("MM/dd/yyyy");

            editModel.Email = GetRowValue(row, MemberUploadbyAcesUploadColumn.Email);
            editModel.AlternateEmail = GetRowValue(row, MemberUploadbyAcesUploadColumn.AlternateEmail);
            editModel.PhoneCell = GetRowValue(row, MemberUploadbyAcesUploadColumn.PhoneCell);
            editModel.PhoneHome = GetRowValue(row, MemberUploadbyAcesUploadColumn.PhoneHome);
            editModel.Address1 = GetRowValue(row, MemberUploadbyAcesUploadColumn.Address1);
            editModel.Address2 = GetRowValue(row, MemberUploadbyAcesUploadColumn.Address2);
            editModel.City = GetRowValue(row, MemberUploadbyAcesUploadColumn.City);
            editModel.State = GetRowValue(row, MemberUploadbyAcesUploadColumn.State);
            editModel.Zip = GetRowValue(row, MemberUploadbyAcesUploadColumn.Zip);
            editModel.Hicn = GetRowValue(row, MemberUploadbyAcesUploadColumn.Hicn);
            editModel.PcpFirstName = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpFirstName);
            editModel.PcpLastName = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpLastName);
            editModel.PcpPhone = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpPhone);
            editModel.PcpFax = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpFax);
            editModel.PcpEmail = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpEmail);
            editModel.PcpAddress1 = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpAddress1);
            editModel.PcpAddress2 = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpAddress2);
            editModel.PcpCity = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpCity);
            editModel.PcpState = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpState);
            editModel.PcpZip = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpZip);
            editModel.PcpNpi = GetRowValue(row, MemberUploadbyAcesUploadColumn.PcpNpi);

            editModel.PreApprovedTest = GetTests(row, MemberUploadbyAcesUploadColumn.PreApprovedTest);

            editModel.IsEligible = GetRowValue(row, MemberUploadbyAcesUploadColumn.IsEligible);
            editModel.TargetYear = GetRowValue(row, MemberUploadbyAcesUploadColumn.TargetYear);
            editModel.Language = GetRowValue(row, MemberUploadbyAcesUploadColumn.Language);
            editModel.Lab = GetRowValue(row, MemberUploadbyAcesUploadColumn.Lab);
            editModel.Copay = GetRowValue(row, MemberUploadbyAcesUploadColumn.Copay);
            editModel.MedicareAdvantagePlanName = GetRowValue(row, MemberUploadbyAcesUploadColumn.MedicareAdvantagePlanName);
            editModel.Lpi = GetRowValue(row, MemberUploadbyAcesUploadColumn.Lpi);
            editModel.Market = GetRowValue(row, MemberUploadbyAcesUploadColumn.Market);
            editModel.Mrn = GetRowValue(row, MemberUploadbyAcesUploadColumn.Mrn);
            editModel.GroupName = GetRowValue(row, MemberUploadbyAcesUploadColumn.GroupName);

            editModel.IcdCodes = GetIcdCodesTests(row, MemberUploadbyAcesUploadColumn.IcdCodes);

            editModel.PreApprovedPackage = GetRowValue(row, MemberUploadbyAcesUploadColumn.PreApprovedPackage);
            editModel.PCPMailingAddress1 = GetRowValue(row, MemberUploadbyAcesUploadColumn.PCPMailingAddress1);
            editModel.PCPMailingAddress2 = GetRowValue(row, MemberUploadbyAcesUploadColumn.PCPMailingAddress2);
            editModel.PCPMailingCity = GetRowValue(row, MemberUploadbyAcesUploadColumn.PCPMailingCity);
            editModel.PCPMailingState = GetRowValue(row, MemberUploadbyAcesUploadColumn.PCPMailingState);
            editModel.PCPMailingZip = GetRowValue(row, MemberUploadbyAcesUploadColumn.PCPMailingZip);

            editModel.CurrentMedication = GetCurrentMedication(row, MemberUploadbyAcesUploadColumn.CurrentMedication);
            editModel.CurrentMedicationSource = GetCurrentMedication(row, MemberUploadbyAcesUploadColumn.CurrentMedicationSource);

            editModel.AdditionalField1 = GetRowValue(row, MemberUploadbyAcesUploadColumn.AdditionalField1);
            editModel.AdditionalField2 = GetRowValue(row, MemberUploadbyAcesUploadColumn.AdditionalField2);
            editModel.AdditionalField3 = GetRowValue(row, MemberUploadbyAcesUploadColumn.AdditionalField3);
            editModel.AdditionalField4 = GetRowValue(row, MemberUploadbyAcesUploadColumn.AdditionalField4);
            editModel.Activity = GetRowValue(row, MemberUploadbyAcesUploadColumn.Activity);
            editModel.PredictedZip = GetRowValue(row, MemberUploadbyAcesUploadColumn.PredictedZip);
            editModel.Mbi = GetRowValue(row, MemberUploadbyAcesUploadColumn.Mbi);

            //editModel.BillingMemberId = GetRowValue(row, MemberUploadbyAcesUploadColumn.BillingMemberId);
            //editModel.BillingMemberPlan = GetRowValue(row, MemberUploadbyAcesUploadColumn.BillingMemberPlan);
            //editModel.BillingMemberPlanYear = ConvertToInt(GetRowValue(row, MemberUploadbyAcesUploadColumn.BillingMemberPlanYear));
            //editModel.WarmTransferAllowed = GetRowValue(row, MemberUploadbyAcesUploadColumn.WarmTransferAllowed);
            //editModel.WarmTransferYear = GetRowValue(row, MemberUploadbyAcesUploadColumn.WarmTransferYear);
            editModel.AcesId = GetRowValue(row, MemberUploadbyAcesUploadColumn.AcesId);
            editModel.EligibilityYear = GetRowValue(row, MemberUploadbyAcesUploadColumn.EligibilityYear);
            editModel.DNCFlag = GetRowValue(row, MemberUploadbyAcesUploadColumn.DNO);
            editModel.Product = GetRowValue(row, MemberUploadbyAcesUploadColumn.ProductNames);

            editModel.ACESClientID = GetRowValue(row, MemberUploadbyAcesUploadColumn.ACESClientID);

            return editModel;
        }

        public string CheckAllMemberUploadbyAcesColumnExist(string[] columnList)
        {
            var obj = new MemberUploadbyAcesUploadColumn();
            var checkList = obj.GetType()
              .GetFields(BindingFlags.Public | BindingFlags.Static)
              .Where(f => f.FieldType == typeof(string))
              .Select(x => ((string)x.GetValue(null)).ToLower()).ToArray();

            var list = checkList.Except(columnList);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

        public void UpdateMemberUploadbyAcesFailedCustomerRecords(string filePath, IEnumerable<MemberUploadbyAcesFailedCustomerModel> failedCustomers)
        {
            var sb = new StringBuilder();
            var members = (typeof(MemberUploadbyAcesFailedCustomerModel)).GetMembers();
            var sanitizer = new CSVSanitizer();

            foreach (var customer in failedCustomers)
            {
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
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
                    var obj = propInfo.GetValue(customer, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else if (obj.GetType() == typeof(List<string>))
                        values.Add(sanitizer.EscapeString(string.Join(",", ((List<string>)obj).ToArray())));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }
                sb.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            File.AppendAllText(filePath, sb.ToString());
        }

        public string CheckAllCustomerEligibilityUploadColumnExist(string[] columnList)
        {
            var obj = new CustomerEligibilityUploadColumn();
            var checkList = obj.GetType()
              .GetFields(BindingFlags.Public | BindingFlags.Static)
              .Where(f => f.FieldType == typeof(string))
              .Select(x => ((string)x.GetValue(null)).ToLower()).ToArray();

            var list = checkList.Except(columnList);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

        public string CheckForMissingColumnInCustomerActivityTypeUpload(string[] columnList)
        {
            var obj = new CustomerActivityTypeUploadColumn();

            var checkList = obj.GetType()
             .GetFields(BindingFlags.Public | BindingFlags.Static)
             .Where(f => f.FieldType == typeof(string))
             .Select(x => ((string)x.GetValue(null)).ToLower()).ToArray();

            var list = checkList.Except(columnList);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

        public IEnumerable<long> RemoveFocFromPreApprovedTest(List<long> preApprovedTestIds)
        {
            var isFocTest = preApprovedTestIds.Contains((long)TestType.Foc);
            if (isFocTest)
            {
                preApprovedTestIds.Remove((long)TestType.Foc);
                preApprovedTestIds.Add((long)TestType.FocAttestation);
            }
            return preApprovedTestIds.Distinct();
        }

    }
}