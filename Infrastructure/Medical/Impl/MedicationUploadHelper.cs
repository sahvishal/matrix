using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MedicationUploadHelper : IMedicationUploadHelper
    {
        public static string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        public string CheckForColumns(DataRow row)
        {
            var sb = new List<string>();

            try
            {
                GetRowValue(row, MedicationUploadColumn.DateOfService);
            }
            catch (Exception)
            {
                sb.Add(MedicationUploadColumn.DateOfService);
            }
            try
            {
                GetRowValue(row, MedicationUploadColumn.Hicn);
            }
            catch (Exception)
            {
                sb.Add(MedicationUploadColumn.Hicn);
            }

            try
            {
                GetRowValue(row, MedicationUploadColumn.MemberDob);
            }
            catch (Exception)
            {
                sb.Add(MedicationUploadColumn.MemberDob);
            }

            try
            {
                GetRowValue(row, MedicationUploadColumn.MemberId);
            }
            catch (Exception)
            {
                sb.Add(MedicationUploadColumn.MemberId);
            }

            try
            {
                GetRowValue(row, MedicationUploadColumn.NdcText);
            }
            catch (Exception)
            {
                sb.Add(MedicationUploadColumn.NdcText);
            }

            var missingHeaders = string.Empty;

            if (sb.Any())
                missingHeaders = string.Join(",", sb);

            return missingHeaders;
        }

        public MedicationUploadLog GetUploadLog(DataRow row, long medicationUploadId)
        {
            var serviceDate = CovertToDate(GetRowValue(row, MedicationUploadColumn.DateOfService));
            var memberDob = CovertToDate(GetRowValue(row, MedicationUploadColumn.MemberDob));

            var medicationUploadLog = new MedicationUploadLog
            {
                CmsHicn = GetRowValue(row, MedicationUploadColumn.Hicn).Trim(),
                ServiceDate = serviceDate == null ? GetRowValue(row, MedicationUploadColumn.DateOfService) : serviceDate.Value.ToString("MM/dd/yyyy"),
                MemberDob = memberDob == null ? GetRowValue(row, MedicationUploadColumn.MemberDob) : memberDob.Value.ToString("MM/dd/yyyy"),
                IsSuccessFull = false,
                MemberId = GetRowValue(row, MedicationUploadColumn.MemberId).Trim(),
                NdcProductCode = GetRowValue(row, MedicationUploadColumn.NdcText).Trim(),
                MedicationUploadId = medicationUploadId,
                ErrorMessage = null
            };

            if (serviceDate != null && !string.IsNullOrEmpty(medicationUploadLog.NdcProductCode)
                && !(string.IsNullOrEmpty(medicationUploadLog.MemberId) && string.IsNullOrEmpty(medicationUploadLog.CmsHicn))
                && memberDob != null)
            {
                medicationUploadLog.IsSuccessFull = true;
            }
            else
            {
                var error = new StringBuilder();
                if (serviceDate == null)
                    error.Append(MedicationUploadColumn.DateOfService + ", ");
                if (string.IsNullOrEmpty(medicationUploadLog.NdcProductCode))
                    error.Append(MedicationUploadColumn.NdcText + ", ");
                if (memberDob == null)
                    error.Append(MedicationUploadColumn.MemberDob + " ");
                error.Append("not provided or invalid");
                medicationUploadLog.ErrorMessage = error.ToString();
            }

            return medicationUploadLog;
        }

        public DateTime? CovertToDate(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            DateTime date;

            if (DateTime.TryParseExact(value, "MMddyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
            {
                return date;
            }

            if (DateTime.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
            {
                return date;
            }
            return null;
        }

    }
}
