using System;
using System.Collections.Generic;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Medical.Interfaces
{
    public interface IPcpResultExportServiceHelper
    {
        void ResultExport(DateTime fromDate, DateTime toDate, long accountId, string destinationPath, string corporateTag, string[] customTags = null, bool excludeCustomtagCusomers = false,
             bool useBlankValue = false, string resultExportFileName = "", bool considerEventDate = false, string[] showHiddenColumns = null, DateTime? eventStartDate = null, DateTime? eventEndDate = null, string[] showHiddenAdditionalFields = null, DateTime? stopSendingPdftoHealthPlanDate = null);

        void WriteCsvHeader(string fileName, string[] showHiddenColumns = null, IEnumerable<OrderedPair<string, string>> additionalFields = null);
    }
}