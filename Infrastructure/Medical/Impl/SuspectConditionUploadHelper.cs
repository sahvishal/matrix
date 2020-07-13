using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SuspectConditionUploadHelper : ISuspectConditionUploadHelper
    {
        private readonly ICsvReader _csvReader;

        public SuspectConditionUploadHelper(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        public string CheckForColumns(string[] columnList)
        {
            var obj = new SuspectConditionUploadColumn();
            var checkList = obj.GetType()
              .GetFields(BindingFlags.Public | BindingFlags.Static)
              .Where(f => f.FieldType == typeof(string))
              .Select(x => (string)x.GetValue(null)).ToArray();

            var list = checkList.Except(columnList);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

        public SuspectConditionUploadLog GetUploadLog(DataRow row, long suspectConditionUploadId)
        {
            var captureReferenceDate = CovertToDate(GetRowValue(row, SuspectConditionUploadColumn.CaptureReferenceDate));
            var memberDob = CovertToDate(GetRowValue(row, SuspectConditionUploadColumn.DOB));

            var suspectDataUploadLog = new SuspectConditionUploadLog
            {
                GMPI = GetRowValue(row, SuspectConditionUploadColumn.GMPI).Trim(),
                MemberID = GetRowValue(row, SuspectConditionUploadColumn.MemberID).Trim(),
                SubscriberID = GetRowValue(row, SuspectConditionUploadColumn.SubscriberID).Trim(),
                MemberName = GetRowValue(row, SuspectConditionUploadColumn.MemberName).Trim(),
                DOB = memberDob == null ? GetRowValue(row, SuspectConditionUploadColumn.DOB) : memberDob.Value.ToString("MM/dd/yyyy"),
                ICDCode = GetRowValue(row, SuspectConditionUploadColumn.ICDCode).Trim(),
                ICDDesc = GetRowValue(row, SuspectConditionUploadColumn.ICDDesc).Trim(),
                ICDCodeVersion = GetRowValue(row, SuspectConditionUploadColumn.ICDCodeVersion).Trim(),
                HCC = GetRowValue(row, SuspectConditionUploadColumn.HCC).Trim(),
                HCCDesc = GetRowValue(row, SuspectConditionUploadColumn.HCCDesc).Trim(),
                CaptureAction = GetRowValue(row, SuspectConditionUploadColumn.CaptureAction).Trim(),
                CaptureLocation = GetRowValue(row, SuspectConditionUploadColumn.CaptureLocation).Trim(),
                CaptureReasonDescription = GetRowValue(row, SuspectConditionUploadColumn.CaptureReasonDescription).Trim(),
                CaptureReferenceDate = captureReferenceDate == null ? GetRowValue(row, SuspectConditionUploadColumn.CaptureReferenceDate) : captureReferenceDate.Value.ToString("MM/dd/yyyy"),
                SectionName = GetRowValue(row, SuspectConditionUploadColumn.SectionName).Trim(),
                IsSuccessFull = false,
                SuspectConditionUploadId = suspectConditionUploadId,
                ErrorMessage = null
            };

            if ((!string.IsNullOrEmpty(suspectDataUploadLog.GMPI) || !string.IsNullOrEmpty(suspectDataUploadLog.MemberID)) //&& !string.IsNullOrEmpty(suspectDataUploadLog.SubscriberID)
                && !string.IsNullOrEmpty(suspectDataUploadLog.MemberName) && memberDob != null && !string.IsNullOrEmpty(suspectDataUploadLog.ICDCode) && !string.IsNullOrEmpty(suspectDataUploadLog.ICDCodeVersion)
                && !string.IsNullOrEmpty(suspectDataUploadLog.HCC) && !string.IsNullOrEmpty(suspectDataUploadLog.CaptureAction) && !string.IsNullOrEmpty(suspectDataUploadLog.CaptureLocation)
                && captureReferenceDate != null && !string.IsNullOrEmpty(suspectDataUploadLog.SectionName))
            {
                suspectDataUploadLog.IsSuccessFull = true;
            }
            else
            {
                var error = new StringBuilder();
                if (string.IsNullOrEmpty(suspectDataUploadLog.GMPI) && string.IsNullOrEmpty(suspectDataUploadLog.MemberID))
                    error.Append(SuspectConditionUploadColumn.GMPI + " Or " + SuspectConditionUploadColumn.MemberID + ", ");

                //if (string.IsNullOrEmpty(suspectDataUploadLog.SubscriberID))
                    //error.Append(SuspectConditionUploadColumn.SubscriberID + ", ");

                if (string.IsNullOrEmpty(suspectDataUploadLog.MemberName))
                    error.Append(SuspectConditionUploadColumn.MemberName + ", ");

                if (memberDob == null)
                    error.Append(SuspectConditionUploadColumn.DOB + ", ");

                if (string.IsNullOrEmpty(suspectDataUploadLog.ICDCode))
                    error.Append(SuspectConditionUploadColumn.ICDCode + ", ");

                //if (string.IsNullOrEmpty(suspectDataUploadLog.ICDDesc))
                //    error.Append(SuspectConditionUploadColumn.ICDDesc + ", ");

                if (string.IsNullOrEmpty(suspectDataUploadLog.ICDCodeVersion))
                    error.Append(SuspectConditionUploadColumn.ICDCodeVersion + ", ");

                if (string.IsNullOrEmpty(suspectDataUploadLog.HCC))
                    error.Append(SuspectConditionUploadColumn.HCC + ", ");

                //if (string.IsNullOrEmpty(suspectDataUploadLog.HCCDesc))
                //    error.Append(SuspectConditionUploadColumn.HCCDesc + ", ");

                if (string.IsNullOrEmpty(suspectDataUploadLog.CaptureAction))
                    error.Append(SuspectConditionUploadColumn.CaptureAction + ", ");

                if (string.IsNullOrEmpty(suspectDataUploadLog.CaptureLocation))
                    error.Append(SuspectConditionUploadColumn.CaptureLocation + ", ");

                //if (string.IsNullOrEmpty(suspectDataUploadLog.CaptureReasonDescription))
                //    error.Append(SuspectConditionUploadColumn.CaptureReasonDescription + ", ");

                if (captureReferenceDate == null)
                    error.Append(SuspectConditionUploadColumn.CaptureReferenceDate + ", ");

                if (string.IsNullOrEmpty(suspectDataUploadLog.SectionName))
                    error.Append(SuspectConditionUploadColumn.SectionName + ", ");
                if (error.Length > 0)
                {
                    error.Length = error.Length - 2;
                    error.Append(" not provided or invalid");
                }
                suspectDataUploadLog.ErrorMessage = error.ToString();
            }
            return suspectDataUploadLog;
        }

        private static string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
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

        public void UpdateFailedRecords(string filePath, IEnumerable<SuspectConditionUploadLogViewModel> failedRecordsList)
        {
            var sb = new StringBuilder();
            var members = (typeof(SuspectConditionUploadLogViewModel)).GetMembers();
            var sanitizer = new CSVSanitizer();

            foreach (var customer in failedRecordsList)
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

            System.IO.File.AppendAllText(filePath, sb.ToString());
        }

        public long FailedCustomerCount(string failedRecordsFilePath, MediaLocation mediaLocation)
        {
            var file = mediaLocation.PhysicalPath + failedRecordsFilePath;

            var customerTable = _csvReader.ReadWithTextQualifier(file);

            var query = customerTable.AsEnumerable();

            return query.Count();
        }

        public string CheckIsFileContainsRecord(MediaLocation mediaLocation, string filePath)
        {
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
    }
}
