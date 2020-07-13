using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.Data.EntityClasses;
using System;
using System.Linq;
using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using System.IO;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Application.ViewModels;

using System.Reflection;
using System.ComponentModel;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Infrastructure.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class HouseCallHafResultExportFactory : IHouseCallHafResultExportFactory
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly ILogger _logger;
        private readonly long[] assistiveDevicesUsedQuestionIds = { 1178, 1179, 1180, 1181 };
        private readonly long[] assistanceServicesUsedQuestionIds = { 1183, 1184, 1185, 1186, 1187, 1188, 1189, 1190 };
        private readonly long[] receivedDateUnkownQuestionIds = { 1123, 1128, 1133, 1138, 1143, 1148, 1153 };
        private readonly long[] checkboxQuestionIds = { 1157, 1160, 1161, 1166, 1168, 1170 };
        private readonly long[] itemsNeededByFamilyMembersQuestionIds = { 1233, 1234, 1235, 1236, 1237, 1238, 1239, 1240, 1241, 1242 };
        private readonly long[] lackOfTransportationQuestionIds = { 1244, 1245, 1246 };

        public HouseCallHafResultExportFactory(ILogger logger)
        {
            _logger = logger;
            _eventRepository = new EventRepository();
            _hostRepository = new HostRepository();
        }

        public void Create(IEnumerable<EventCustomersEntity> eventCustomerEntities, IEnumerable<OrderedPair<long, long>> orgRoleUserIdUserIdPairs,
            IEnumerable<UserEntity> userEntities, IEnumerable<Address> addresses, IEnumerable<CustomerProfileEntity> customerProfileEntities, IEnumerable<EventsEntity> eventsEntities,
            IEnumerable<CustomerHealthInfoEntity> customerHealthInfoEntities, IEnumerable<OrderedPair<long, string>> careCoordinatorIdNamePair,
            IEnumerable<CustomerPrimaryCarePhysicianEntity> primaryCarePhysicianEntities, IEnumerable<Address> pcpAddresses, IEnumerable<EventAppointmentEntity> eventAppointmentEntities,
            string destinationDirectory)
        {
            long totalRecords = eventCustomerEntities.Count();
            long counter = 1;

            _logger.Info("Total Records : " + totalRecords);

            var fileName = destinationDirectory + string.Format(@"\HRA-QA_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd"));

            if (!DirectoryOperationsHelper.IsDirectoryExist(destinationDirectory))
            {
                DirectoryOperationsHelper.CreateDirectory(destinationDirectory);
            }

            WriteCsvHeader(fileName);

            foreach (var eventCustomerEntity in eventCustomerEntities)
            {
                try
                {
                    _logger.Info(string.Format("Creating Model for event {0} and customer {1}", eventCustomerEntity.EventId, eventCustomerEntity.CustomerId));

                    var userId = orgRoleUserIdUserIdPairs.Where(oru => oru.FirstValue == eventCustomerEntity.CustomerId).Select(oru => oru.SecondValue).Single();

                    var user = userEntities.Where(u => u.UserId == userId).Select(u => u).Single();

                    var address = addresses.Where(a => a.Id == user.HomeAddressId).Select(a => a).Single();

                    var customer = customerProfileEntities.Where(cp => cp.CustomerId == eventCustomerEntity.CustomerId).Select(cp => cp).Single();

                    var eventData = eventsEntities.Where(e => e.EventId == eventCustomerEntity.EventId).Select(e => e).Single();

                    var primaryCarePhysician = primaryCarePhysicianEntities.Where(pcp => pcp.CustomerId == eventCustomerEntity.CustomerId).Select(pcp => pcp).FirstOrDefault();

                    var eventAppointment = eventAppointmentEntities.Where(ea => ea.AppointmentId == eventCustomerEntity.AppointmentId).Select(ea => ea).Single();

                    var hafAnswers = customerHealthInfoEntities.Where(chi => chi.EventCustomerId == eventCustomerEntity.EventCustomerId).Select(chi => chi).ToArray();

                    var answers = new List<OrderedPair<long, string>>();

                    foreach (var question in HouseCallHafResultExportHelper.Questions)
                    {
                        var hafAnswer = hafAnswers.Where(ha => ha.CustomerHealthQuestionId == question.FirstValue).Select(ha => ha).FirstOrDefault();

                        if (hafAnswer != null && question.FirstValue != 1233 && question.FirstValue != 1244)
                        {
                            if (receivedDateUnkownQuestionIds.Contains(question.FirstValue) || checkboxQuestionIds.Contains(question.FirstValue))
                            {
                                if (!string.IsNullOrEmpty(hafAnswer.HealthQuestionAnswer))
                                {
                                    answers.Add(new OrderedPair<long, string>(question.FirstValue, "Yes"));
                                }
                                else
                                {
                                    answers.Add(new OrderedPair<long, string>(question.FirstValue, ""));
                                }
                            }
                            else if (hafAnswer.HealthQuestionAnswer == "RefusedDeclined")
                            {
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, "Refused/Declined"));
                            }
                            else if (hafAnswer.HealthQuestionAnswer == "Retired disabled")
                            {
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, "Retired/disabled"));
                            }
                            else if (hafAnswer.HealthQuestionAnswer == "Is it chronic pain")
                            {
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, "It is chronic pain"));
                            }
                            else if (hafAnswer.HealthQuestionAnswer == "Is it acute pain")
                            {
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, "It is acute pain"));
                            }
                            else
                            {
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, hafAnswer.HealthQuestionAnswer));
                            }
                        }
                        else
                        {
                            if (question.FirstValue == 1177)
                            {
                                var healthQuestionAnswers = hafAnswers.Where(ha => assistiveDevicesUsedQuestionIds.Contains(ha.CustomerHealthQuestionId)).OrderBy(ha => ha.CustomerHealthQuestionId).Select(ha => ha.HealthQuestionAnswer);
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, string.Join(",", healthQuestionAnswers)));
                            }
                            else if (question.FirstValue == 1248)
                            {
                                var healthQuestionAnswers = hafAnswers.Where(ha => assistanceServicesUsedQuestionIds.Contains(ha.CustomerHealthQuestionId)).OrderBy(ha => ha.CustomerHealthQuestionId).Select(ha => ha.HealthQuestionAnswer);
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, string.Join(",", healthQuestionAnswers)));
                            }
                            else if (question.FirstValue == 1233)
                            {
                                var healthQuestionAnswers = hafAnswers.Where(ha => itemsNeededByFamilyMembersQuestionIds.Contains(ha.CustomerHealthQuestionId)).OrderBy(ha => ha.CustomerHealthQuestionId).Select(ha => ha.HealthQuestionAnswer);
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, string.Join(",", healthQuestionAnswers)));
                            }
                            else if (question.FirstValue == 1244)
                            {
                                var healthQuestionAnswers = hafAnswers.Where(ha => lackOfTransportationQuestionIds.Contains(ha.CustomerHealthQuestionId)).OrderBy(ha => ha.CustomerHealthQuestionId).Select(ha => ha.HealthQuestionAnswer);
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, string.Join(",", healthQuestionAnswers)));
                            }
                            else
                            {
                                answers.Add(new OrderedPair<long, string>(question.FirstValue, ""));
                            }
                        }
                    }

                    var model = new HouseCallHafResultExportModel
                    {
                        CustomerId = customer.CustomerId,
                        MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "" : customer.InsuranceId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Dob = user.Dob,
                        Gender = customer.Gender,
                        Phone = user.PhoneHome,
                        Address1 = address.StreetAddressLine1,
                        City = address.City,
                        State = address.State,
                        Zip = address.ZipCode.Zip,

                        EventId = eventData.EventId,
                        HealthAssesmentAnswer = answers,
                        RegistrationDate = eventCustomerEntity.DateCreated,
                    };

                    if (model.EventId > 0)
                    {
                        var theEvent = _eventRepository.GetById(model.EventId);
                        if (theEvent.HostId > 0)
                        {
                            var host = _hostRepository.GetHostForEvent(theEvent.Id);
                            model.EventLocation = host.OrganizationName;
                            model.EventAddress = host.Address.ToShortAddressString();
                        }
                    }

                    if (primaryCarePhysician != null)
                    {
                        model.PCPName = new Name(primaryCarePhysician.FirstName, primaryCarePhysician.MiddleName, primaryCarePhysician.LastName).FullName;

                        var pcpAddress = pcpAddresses != null ? pcpAddresses.Where(x => x.Id == primaryCarePhysician.Pcpaddress).FirstOrDefault() : null;
                        if (pcpAddress != null)
                        {
                            model.PCPAddress = pcpAddress.StreetAddressLine1;
                            model.PCPCity = pcpAddress.City;
                            model.PCPState = pcpAddress.State;
                            model.PCPZip = pcpAddress.ZipCode.Zip;
                        }

                    }

                    if (eventAppointment != null)
                    {
                        model.AppointmentDate = eventAppointment.StartTime;
                        model.AppointmentTime = eventAppointment.StartTime;
                    }

                    WriteCsv(model, fileName);
                    _logger.Info(counter + " completed out of " + totalRecords);

                    counter++;
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("\n\nFor Event {0} and Customer {1} \n Error:{2}", eventCustomerEntity.EventId, eventCustomerEntity.CustomerId, ex.Message));
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
                var members = (typeof(HouseCallHafResultExportModel)).GetMembers();

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
                            header.AddRange(HouseCallHafResultExportHelper.Questions.Select(q => EscapeString(q.SecondValue)).ToArray());
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

                streamWriter.Write(string.Join(HouseCallHafResultExportHelper.Delimiter, header.ToArray()) + Environment.NewLine);
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

        private void WriteCsv(HouseCallHafResultExportModel model, string fileName)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(HouseCallHafResultExportModel)).GetMembers();
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
                            foreach (var question in HouseCallHafResultExportHelper.Questions)
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

                streamWriter.Write(string.Join(HouseCallHafResultExportHelper.Delimiter, values.ToArray()) + Environment.NewLine);


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
