using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.OutboundReport.ViewModels;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class PipeDelimitedReportHelper : IPipeDelimitedReportHelper
    {
        public string Delimiter { get; set; }
        public PipeDelimitedReportHelper()
        {
            Delimiter = "|";
        }

        public DataTable Read(string filePath, string seprator = "")
        {
            var dtCardiovision = new DataTable();
            if (seprator != "")
                Delimiter = seprator;
            using (var reader = new StreamReader(filePath))
            {
                string row = reader.ReadLine();
                foreach (string strColumn in row.Split(new[] { Delimiter }, StringSplitOptions.None))
                {
                    dtCardiovision.Columns.Add(strColumn.Trim());
                }

                while (reader.Peek() != -1)
                {
                    row = reader.ReadLine();
                    DataRow dr = dtCardiovision.NewRow();
                    int i = 0;
                    foreach (string strValue in row.Split(new[] { Delimiter }, StringSplitOptions.None))
                    {
                        if (i >= dtCardiovision.Columns.Count)
                            break;

                        dr[i] = strValue.Trim().Replace("\"", "");
                        i++;
                    }

                    for (int j = i; j < dtCardiovision.Columns.Count; j++)
                        dr[j] = "";

                    dtCardiovision.Rows.Add(dr);
                }
            }

            return dtCardiovision;
        }

        public void Write<T>(IEnumerable<T> modelData, string folderLocation, string filePath)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(T)).GetMembers();

            if (!File.Exists(folderLocation + "\\" + filePath))
            {
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

                csvStringBuilder.Append(string.Join("|", header.ToArray()) + Environment.NewLine);

            }

            foreach (var model in modelData)
            {
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo == null)
                        continue;

                    if (propInfo.PropertyType == typeof(FeedbackMessageModel))
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
                        values.Add(obj.ToString());

                }

                csvStringBuilder.Append(string.Join("|", values.ToArray()) + Environment.NewLine);

            }

            SaveToFile(csvStringBuilder.ToString(), filePath, folderLocation);
        }

        private void SaveToFile(string fileContent, string filePath, string folderLocation)
        {
            CheckIfDirectoryExist(folderLocation);
            filePath = folderLocation + "\\" + filePath;

            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.Write(fileContent);
                streamWriter.Close();
            }
        }

        private void CheckIfDirectoryExist(string folderLocation)
        {
            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }
        }

        public string GetReportName(string fileType)
        {
            switch (fileType)
            {
                case ReportType.ChaseOutbound:
                    return "GWC_HLF_CL_";

                case ReportType.CareCodingOutbound:
                    return "GWC_HLF_CL_GAPS_";

                case ReportType.ResponseVendorInbound:
                    return "HLF_GWC_RESPONSE_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.ConditionInbound:
                    return "HLF_GWC_CONDITION_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.LabsInbound:
                    return "HLF_GWC_LAB_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.InterviewInbound:
                    return "HLF_GWC_INTERVIEW_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.BarrierInbound:
                    return "HLF_GWC_BARRIER_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.QuestionInbound:
                    return "HLF_GWC_QUESTION_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.Exception:
                    return "HLF_GWC_CL_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_EXCEP";

                case ReportType.CrosswalkZip:
                    return "HLF_GWC_CW_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.CrosswalkInbound:
                    return "HLF_GWC_CROSSWALK_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.CrosswalkLabZip:
                    return "HLF_GWC_LAB_RESULTS_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.CrosswalkLabInbound:
                    return "HLF_GWC_LAB_CROSSWALK_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                case ReportType.PatientDetail:
                    return "PatientDetail";

                case ReportType.DiagnosisReport:
                    return "DiagnosisReport";

                default:
                    return "GWC_HLF_CL_";
            }
        }

        public DataTable ReadWithTextQualifier(string filePath)
        {
            var dataTable = new DataTable();
            using (var reader = new StreamReader(filePath))
            {
                string row = reader.ReadLine();
                foreach (string strColumn in row.Split(new[] { Delimiter }, StringSplitOptions.None))
                {
                    dataTable.Columns.Add(strColumn.Replace("\"", ""));
                }

                while (reader.Peek() != -1)
                {
                    row = reader.ReadLine();
                    DataRow dr = dataTable.NewRow();
                    int i = 0;

                    bool cont = false;
                    string cs = "";

                    string[] c = row.Split(new[] { Delimiter }, StringSplitOptions.None);

                    foreach (string y in c)
                    {
                        if (i >= dataTable.Columns.Count)
                            break;

                        string x = y;

                        if (cont)
                        {
                            // End of field
                            if (x.EndsWith("\""))
                            {
                                cs += "," + x.Substring(0, x.Length - 1);
                                dr[i] = cs;
                                i++;
                                cs = "";
                                cont = false;
                                continue;

                            }
                            else
                            {
                                // Field still not ended
                                cs += "," + x;
                                continue;
                            }
                        }

                        // Fully encapsulated with no comma within
                        if (x.StartsWith("\"") && x.EndsWith("\"") && x.Length >= 2)
                        {
                            if ((x.EndsWith("\"\"") && !x.EndsWith("\"\"\"")) && x != "\"\"")
                            {
                                cont = true;
                                cs = x;
                                continue;
                            }

                            dr[i] = x.Substring(1, x.Length - 2);
                            i++;
                            continue;
                        }

                        // Start of encapsulation but comma has split it into at least next field
                        if (x.StartsWith("\"") && (!x.EndsWith("\"") || x.Length == 1))
                        {
                            cont = true;
                            cs += x.Substring(1);
                            continue;
                        }

                        // Non encapsulated complete field
                        dr[i] = x;
                        i++;

                    }

                    for (int j = i; j < dataTable.Columns.Count; j++)
                        dr[j] = "";

                    dataTable.Rows.Add(dr);
                }
            }

            return dataTable;
        }

        public void WriteWithTextQualifier<T>(IEnumerable<T> modelData, string folderLocation, string filePath)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(T)).GetMembers();

            if (!File.Exists(folderLocation + "\\" + filePath))
            {
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

                    header.Add("\"" + propertyName.Trim() + "\"");
                }

                csvStringBuilder.Append(string.Join("|", header.ToArray()) + Environment.NewLine);

            }

            foreach (var model in modelData)
            {
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo == null)
                        continue;

                    if (propInfo.PropertyType == typeof(FeedbackMessageModel))
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
                        values.Add("\"" + formatter.ToString(obj) + "\"");
                    else
                        values.Add("\"" + obj.ToString() + "\"");

                }

                csvStringBuilder.Append(string.Join("|", values.ToArray()) + Environment.NewLine);

            }

            SaveToFile(csvStringBuilder.ToString(), filePath, folderLocation);
        }
    }
}
