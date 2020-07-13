using System;

namespace Falcon.Entity.Other
{
    public class ECampaignDetailToolTip
    {
        public long CampaignID { get; set; }
        public string CampaignName { get; set; }
        public decimal Commission { get; set; }
        public decimal ParentCommission { get; set; }
        public DateTime? CampaignStartDate { get; set; }
        public DateTime? CampaignEndDate { get; set; }
        public bool IsPercentageCommission { get; set; }
        public string AdvocateName { get; set; }
        public string ParentAdvocateName { get; set; }
        public string SourceCode { get; set; }
        public bool IsSalesRepCampaign { get; set; }
    }
}
