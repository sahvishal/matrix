using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class CustomerWithDuplicateAcesIdFileGenerator : ICustomerWithDuplicateAcesIdFileGenerator
    {
        private readonly IMediaRepository _mediaRepository;

        public CustomerWithDuplicateAcesIdFileGenerator(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public void GenerateCsvFile(long corporateUploadId, IEnumerable<CustomerWithDuplicateAcesModel> customers)
        {
            var tempMediaLocation = _mediaRepository.GetCustomerWithSameAcesIdFileLocation();
            var filePath = Path.Combine(tempMediaLocation.PhysicalPath, corporateUploadId.ToString() + ".csv");
            CreateHeader(filePath);
            UpdateRecords(filePath, customers);
        }

        private void CreateHeader(string filePath)
        {
            if (!DirectoryOperationsHelper.IsFileExist(filePath))
            {
                var csvStringBuilder = new StringBuilder();
                var members = (typeof(CustomerWithDuplicateAcesModel)).GetMembers();

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

                csvStringBuilder.Append(string.Join(",", header.ToArray()) + Environment.NewLine);
                File.AppendAllText(filePath, csvStringBuilder.ToString());
            }
        }

        private void UpdateRecords(string filePath, IEnumerable<CustomerWithDuplicateAcesModel> customers)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(CustomerWithDuplicateAcesModel)).GetMembers();
            var sanitizer = new CSVSanitizer();

            foreach (var customer in customers)
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
                    else if (obj.GetType() == typeof(string[]))
                        values.Add(sanitizer.EscapeString(string.Join(",", ((string[])obj).ToArray())));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }
                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            File.AppendAllText(filePath, csvStringBuilder.ToString());
        }
    }
}
