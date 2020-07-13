using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class RapsUploadHelper : IRapsUploadHelper
    {

        public const string DateOfServiceStartDate = "SERVICE_DATE";
        public const string CmsHicn = "HICN";
        public const string DiagnosisCode = "ICD";
        public const string IcdVersion = "ICD_VERSION";
        public const string MemberDob = "MEMBERDOB";
        //public   string MemberId = "PlanMemberId";
        public const string FirstName = "FIRST_NAME";
        public const string LastName = "LAST_NAME";



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
                GetRowValue(row, DateOfServiceStartDate);
            }
            catch (Exception)
            {
                sb.Add(DateOfServiceStartDate);
            }
            try
            {
                GetRowValue(row, CmsHicn);
            }
            catch (Exception)
            {
                sb.Add(CmsHicn);
            }
            try
            {
                GetRowValue(row, DiagnosisCode);
            }
            catch (Exception)
            {
                sb.Add(DiagnosisCode);
            }


            try
            {
                GetRowValue(row, MemberDob);
            }
            catch (Exception)
            {
                sb.Add(MemberDob);
            }
            try
            {
                GetRowValue(row, IcdVersion);
            }
            catch (Exception)
            {
                sb.Add(IcdVersion);
            }

            try
            {
                GetRowValue(row, FirstName);
            }
            catch (Exception)
            {
                sb.Add(FirstName);
            }
            try
            {
                GetRowValue(row, LastName);
            }
            catch (Exception)
            {
                sb.Add(LastName);
            } 

            var missingHeaders = string.Empty;

            if (sb.Any())
                missingHeaders = string.Join(",", sb);

            return missingHeaders;

        }

        public RapsUploadLog GetUploadLog(DataRow row, long rapsUploadId)
        {
            var rapsUploadLog = new RapsUploadLog
            {
                CmsHicn = GetRowValue(row, CmsHicn),
                ServiceDate = CovertToDate(GetRowValue(row, DateOfServiceStartDate)),
                IcdCode = GetRowValue(row, DiagnosisCode),
                IcdVersion = CovertToInt(GetRowValue(row, IcdVersion)), 
                MemberDob = CovertToDate(GetRowValue(row, MemberDob)),
                IsSuccessFull = false,
                RapsUploadId = rapsUploadId,
                FirstName = GetRowValue(row, FirstName),
                SecondName = GetRowValue(row, LastName),
                // MemberId = GetRowValue(row, MemberId)
            };
            if (!string.IsNullOrEmpty(rapsUploadLog.FirstName) && !string.IsNullOrEmpty(rapsUploadLog.SecondName) && rapsUploadLog.ServiceDate.HasValue && rapsUploadLog.MemberDob.HasValue)
            { rapsUploadLog.IsSuccessFull = true;}
            else
            {
                var error = new StringBuilder();
                if (string.IsNullOrEmpty(rapsUploadLog.FirstName))
                    error.Append("First Name, ");
                if (string.IsNullOrEmpty(rapsUploadLog.SecondName))
                    error.Append("Last Name, ");
                if (rapsUploadLog.ServiceDate==null)
                    error.Append("Service Date, ");

                if (rapsUploadLog.MemberDob == null)
                    error.Append("DOB ");
                error.Append("is null or empty");
                rapsUploadLog.ErrorMessage = error.ToString();
            }

            //rapsUploadLog = CheckIfCmsHicnProvided(rapsUploadLog);

            return rapsUploadLog;
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
        private int CovertToInt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            try
            {
                return int.Parse(value);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        private RapsUploadLog CheckIfCmsHicnProvided(RapsUploadLog rapsUploadLog)
        {
            //var error = string.Empty;
            //if (!string.IsNullOrEmpty(rapsUploadLog.ErrorMessage))
            //    error = rapsUploadLog.ErrorMessage;

            //if (string.IsNullOrEmpty(rapsUploadLog.CmsHicn))
            //{
            //    rapsUploadLog.IsSuccessFull = false;
            //    rapsUploadLog.ErrorMessage = error + " CMSHICN  is mandatory field.";
            //}

            return rapsUploadLog;
        }

    }
}
