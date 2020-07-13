using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class MergeCustomerUploadHelper : IMergeCustomerUploadHelper
    {
        public const string CustomerId = "Customer Id";
        public const string DuplicateCustomerId = "Duplicate Customers";

        public static string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private long ConvertToLong(string customerIdString)
        {
            long customerId;
            long.TryParse(customerIdString, out customerId);

            return customerId;

        }

        public string CheckForColumns(DataRow row)
        {
            var sb = new List<string>();

            try
            {
                GetRowValue(row, CustomerId);
            }
            catch (Exception)
            {
                sb.Add(CustomerId);
            }

            try
            {
                GetRowValue(row, DuplicateCustomerId);
            }
            catch (Exception)
            {
                sb.Add(DuplicateCustomerId);
            }

            var missingHeaders = string.Empty;

            if (sb.Any())
                missingHeaders = string.Join(",", sb);

            return missingHeaders;

        }

        public MergeCustomerUploadLog GetUploadLog(DataRow row, long uploadId)
        {
            var mergeCustomerUploadLog = new MergeCustomerUploadLog
            {
                CustomerId = ConvertToLong(GetRowValue(row, CustomerId)),
                DuplicateCustomerId = GetRowValue(row, DuplicateCustomerId),
                StatusId = (long)MergeCustomerUploadStatus.Uploaded,
                IsSuccessful = false,
                UploadId = uploadId
            };


            if (mergeCustomerUploadLog.CustomerId <= 0 )
            {
                mergeCustomerUploadLog.IsSuccessful = false;
                mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                mergeCustomerUploadLog.ErrorMessage = "Invalid CustomerId :" + GetRowValue(row, CustomerId);
            }

            if (mergeCustomerUploadLog.DuplicateCustomerId.IsNullOrEmpty())
            {
                mergeCustomerUploadLog.IsSuccessful = false;
                mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                mergeCustomerUploadLog.ErrorMessage = "Duplicate Customer(s) is empty";
            }

            return mergeCustomerUploadLog;
        }
    }
}
