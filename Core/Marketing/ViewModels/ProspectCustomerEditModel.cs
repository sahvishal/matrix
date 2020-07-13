using System;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class ProspectCustomerEditModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MarketingSource { get; set; }

        public int Gender { get; set; }

        public AddressEditModel Address { get; set; }

        public PhoneNumber CallBackPhoneNumber { get; set; }

        public Email Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public int Source { get; set; }
        public int Tag { get; set; }

        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public bool IsCallBackPhoneNumberRequired { get; set; }

    }
}