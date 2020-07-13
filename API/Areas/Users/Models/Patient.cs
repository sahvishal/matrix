using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace API.Areas.Users.Models
{
    [NoValidationRequired]
    public class Patient
    {
        public long CustomerId { get; set; }

        public Name Name { get; set; }

        public string Email { get; set; }

        public DateTime? DateofBirth { get; set; }

        public Race Race { get; set; }

        public AddressEditModel Address { get; set; }

        public PhoneNumber PhoneHome { get; set; }
        public PhoneNumber PhoneCell { get; set; }
        public PhoneNumber PhoneOffice { get; set; }

        public Gender Gender { get; set; }
    }
}