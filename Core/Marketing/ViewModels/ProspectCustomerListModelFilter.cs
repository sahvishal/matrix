using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class ProspectCustomerListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int DateType { get; set; }

        public long Source { get; set; }

        public string Tag { get; set; }

        public int Miles { get; set; }

        public string Zipcode { get; set; }

        public string PhoneNumber { get; set; }

        public long StateId { get; set; }

        public string City { get; set; }

        public string CorporateTag { get; set; }

        public string[] CustomTags { get; set; }

        public long AgentOrganizationId { get; set; }

    }
}