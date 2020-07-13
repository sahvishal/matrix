using System;
using System.IO;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class AnthemResultPostedViewModel
    {
        public string BatchName { get; set; }
        public Customer Customer { get; set; }
        public Event Event { get; set; }
        public EventCustomerResult EventCustomerResult { get; set; }
        public CorporateAccount CorporateAccount { get; set; }
        public DateTime ExportToTime { get; set; }
        public long TotalFilesInBatch { get; set; }
        public long EventCustomerId { get; set; }
        public string SourceFilePath { get; set; }
        public string DestinationFilePath { get; set; }
        public int PagesInfile { get; set; }
        public string DestinationFileNameWithoutExt { get; set; }
        public string DestinationPdfFileName { get { return DestinationFileNameWithoutExt + ".pdf"; } }
        public string DestinationPathWithBatchName { get { return Path.Combine(DestinationFilePath, BatchName); } }
        public string JulianDateFormate { get; set; }
        public long Identification { private get; set; }
        public string UniqueIdetificationDocketNumber { get { return Identification.ToString("00000000"); } }
        public string DocketNumber { get { return JulianDateFormate + "HLFR" + Identification.ToString("000000"); } }
        public string EDocketNumber { get { return JulianDateFormate + "VHA" + Identification.ToString("000000"); } }
        public string Tag { get; set; }
        public string Npi { get; set; }
        public int TotalCustomersInBatch { get; set; }

    }
}