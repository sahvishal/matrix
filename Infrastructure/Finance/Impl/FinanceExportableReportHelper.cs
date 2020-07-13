using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class FinanceExportableReportHelper : BaseExportableReportHelper, IFinanceExportableReportHelper
    {
        private readonly IFinanceReportingService _financeReportingService;
        private readonly IBaseReportService _baseReportService;

        public FinanceExportableReportHelper(IMediaRepository mediaRepository, IBaseReportService baseReportService, ILogManager logManager,
            IFinanceReportingService financeReportingService)
            : base(mediaRepository, baseReportService, logManager)
        {
            _financeReportingService = financeReportingService;
            _baseReportService = baseReportService;
        }

        public string GiftCerificateExport(GiftCertificateReportFilter filter, long userId)
        {
            var dataGen = new ExportableDataGenerator<GiftCertificateReportViewModel, GiftCertificateReportFilter>(_financeReportingService.GetGiftCertificateReport, Logger);

            var model = dataGen.GetData(filter);

            return WriteCsvGiftCertificate(GetExportableFileName("GiftCerificateExport"), model.Collection, userId);
        }



        private string WriteCsvGiftCertificate(string fileName, IEnumerable<GiftCertificateReportViewModel> modelData, long userId)
        {
            var csvFilePath = ExportableMediaLocation.PhysicalPath + fileName;

            var csvStringBuilder = new StringBuilder();
            var members = (typeof(GiftCertificateReportViewModel)).GetMembers();

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

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }
    }
}