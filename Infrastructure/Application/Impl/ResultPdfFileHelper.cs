using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class ResultPdfFileHelper : IResultPdfFileHelper
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ILogger _logger;
        public ResultPdfFileHelper(ILogManager logManager, ICustomerRepository customerRepository, IEventRepository eventRepository)
        {
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _logger = logManager.GetLogger("PdfLogCsvWriter");
        }

        public string GetFileName(List<CustomerInfo> resultPdfPostedCustomers, EventCustomerResult ecr, string fileName, long fileType, bool appendDateTime = true)
        {
            var fileSentCount = resultPdfPostedCustomers.Count(x => x.CustomerId == ecr.CustomerId && x.EventId == ecr.EventId && x.FileName.ToLower().Contains(fileName.ToLower()));

            if (appendDateTime)
            {
                if (fileSentCount > 0)
                {
                    fileName += string.Format("_{0}_{1}", fileSentCount, DateTime.Now.ToString("yyyyMMdd"));
                }
            }
            else
            {
                fileName += string.Format("_{0}", (fileSentCount + 1));
            }

            return fileName;
        }

        public CustomerInfo GetCustomerInfo(Event eventData, string fileName, long fileType, Customer customer, long eventCustomerId)
        {
            return new CustomerInfo
            {
                CustomerId = customer.CustomerId,
                EventId = eventData.Id,
                DateSent = DateTime.Now,
                EventDate = eventData.EventDate,
                FileName = fileName,
                FileType = fileType,
                MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? string.Empty : customer.InsuranceId,
                EventCustomerId = eventCustomerId
            };
        }

        public void CreateCsvForFileShared(IEnumerable<CustomerInfo> customersInfo, string folderPath, string fileName)
        {
            _logger.Info("Creating csv file..");

            DirectoryOperationsHelper.CreateDirectoryIfNotExist(folderPath);

            try
            {
                var years = customersInfo.Where(x => x.EventDate.HasValue).Select(x => x.EventDate.Value.Year).Distinct();

                foreach (var year in years)
                {
                    var tempfileName = fileName + "_" + year + ".csv";

                    var destinationFileName = Path.Combine(folderPath, tempfileName);
                    //if (year < DateTime.Today.Year && DirectoryOperationsHelper.IsFileExist(destinationFileName))
                    //{
                    //    continue;
                    //}

                    DirectoryOperationsHelper.DeleteFileIfExist(destinationFileName);

                    _logger.Info("Count Records " + customersInfo.Count());

                    _logger.Info("destination Path: " + destinationFileName);

                    WriteCsv(destinationFileName, customersInfo.Where(x => x.EventDate.HasValue && x.EventDate.Value.Year == year));
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some Error occurred while Creating Csv log:");
                _logger.Error("Message:" + ex.Message);
                _logger.Error("Stack trace:" + ex.StackTrace);
            }

            _logger.Info("Created csv file..");
        }

        private string WriteCsv(string csvFilePath, IEnumerable<CustomerInfo> modelData)
        {
            using (var streamWriter = new StreamWriter(csvFilePath, false))
            {
                var members = (typeof(CustomerInfo)).GetMembers();

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

                streamWriter.Write(string.Join(",", header.ToArray()) + Environment.NewLine);

                var sanitizer = new CSVSanitizer();
                foreach (var model in modelData)
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
                            if (propInfo.PropertyType == typeof(IEnumerable<string>))
                            {
                                values.Add(string.Empty);
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
                            values.Add(formatter.ToString(obj));
                        else
                            values.Add(sanitizer.EscapeString(obj.ToString()));
                    }
                    streamWriter.Write(string.Join(",", values.ToArray()) + Environment.NewLine);
                }
                streamWriter.Close();
            }

            return "CSV File Export was succesful!";
        }

        public ResultPdfPostedXml CorrectMissingRecords(ResultPdfPostedXml resultPdfPostedXml)
        {
            if (resultPdfPostedXml == null || resultPdfPostedXml.Customer.IsNullOrEmpty()) return resultPdfPostedXml;

            var isRecordMissing = resultPdfPostedXml.Customer.Any(x => !x.EventDate.HasValue || string.IsNullOrEmpty(x.MemberId));

            if (!isRecordMissing) return resultPdfPostedXml;

            var customersInfo = resultPdfPostedXml.Customer;

            foreach (var customerInfo in customersInfo)
            {
                try
                {
                    if (string.IsNullOrEmpty(customerInfo.MemberId))
                    {
                        var customer = _customerRepository.GetCustomer(customerInfo.CustomerId);
                        customerInfo.MemberId = customer.InsuranceId;
                    }

                    if (!customerInfo.EventDate.HasValue)
                    {
                        var eventData = _eventRepository.GetById(customerInfo.EventId);
                        customerInfo.EventDate = eventData.EventDate;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Info("Error while getting memberId for customer Id " + customerInfo.CustomerId);
                    _logger.Error("Message " + ex.Message);
                    _logger.Error("StackTrace " + ex.StackTrace);
                }
            }

            return new ResultPdfPostedXml { Customer = customersInfo };
        }
    }
}
