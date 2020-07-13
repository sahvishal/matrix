using System;
using System.Data;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IMedicationUploadHelper
    {
        string CheckForColumns(DataRow row);
        MedicationUploadLog GetUploadLog(DataRow row, long medicationUploadId);
        DateTime? CovertToDate(string value);
    }
}
