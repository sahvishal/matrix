using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.Domain
{
    public class ProspectCustomer : DomainObjectBase
    {
        private long? _status;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public Address Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public PhoneNumber CallBackPhoneNumber { get; set; }

        public Email Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public ProspectCustomerSource Source { get; set; }
        public ProspectCustomerTag Tag { get; set; }

        public long? SourceCodeId { get; set; }
        public string MarketingSource { get; set; }

        public long? CustomerId { get; set; }

        public bool? IsConverted { get; set; }

        public DateTime? ConvertedOnDate { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool IsContacted { get; set; }

        public DateTime? ContactedDate { get; set; }

        public long? ContactedBy { get; set; }

        public DateTime? CallBackRequestedOn { get; set; }
        public DateTime? CallBackRequestedDate { get; set; }
        public bool IsQueuedForCallBack { get; set; }

        public long Status
        {
            get { return _status.HasValue ? _status.Value : (long)ProspectCustomerConversionStatus.NotConverted; }
            set { _status = value; }
        }

        public DateTime? TagUpdateDate { get; set; }

        public ProspectCustomer()
        { }

        public ProspectCustomer(long id)
            : base(id)
        { }
    }
}
