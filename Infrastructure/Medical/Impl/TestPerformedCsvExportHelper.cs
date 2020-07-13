using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class TestPerformedCsvExportHelper : ITestPerformedCsvExportHelper
    {
        private IBaseReportService _baseReportService;
        public TestPerformedCsvExportHelper(IBaseReportService baseReportService)
        {
            _baseReportService = baseReportService;
        }

        public string WriteCsvTestPerformed(string physicalPath, string fileName, IEnumerable<TestPerformedViewModel> modelData, long userId = 0, ILogger logger = null, bool downloadAsZIP = false)
        {
            var csvFilePath = physicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(TestPerformedViewModel)).GetMembers();

            var header = new List<string>();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<long, int>>))
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
                        if (propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                        {
                            if (model.AdditionalFields != null && model.AdditionalFields.Any())
                            {
                                string additionFiledString = model.AdditionalFields.Aggregate(string.Empty,
                                    (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");

                                values.Add(sanitizer.EscapeString(additionFiledString));
                            }
                            else
                                values.Add(string.Empty);
                            continue;
                        }
                        else if (propInfo.PropertyType == typeof(FeedbackMessageModel))
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
                    var obj = propInfo.GetValue(model, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }

                csvStringBuilder.Append(string.Join(",", values.ToArray()) + Environment.NewLine);

            }

            var request = new GenericReportRequest { CsvFilePath = csvFilePath, Model = csvStringBuilder.ToString() };
            var isGenerated = _baseReportService.GetResponse(request);
            if (!isGenerated) return "CSV File Export failed!";
            if (downloadAsZIP && userId > 0 && logger != null)
            {
                var mediaLocation = new MediaLocation() { PhysicalPath = physicalPath };
                return _baseReportService.DownloadZipFile(mediaLocation, fileName, userId, logger);
            }
            else
                return fileName;
        }
    }
}
