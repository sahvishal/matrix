using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using FluentValidation;

namespace Falcon.App.Core.Users.ViewModels
{
    public class PhysicianLicenseModel
    {
        [UIHint("Hidden")]
        public long LicenseId { get; set; }

        [DisplayName("License Number")]
        public string LicenseNumber { get; set; }

        [DisplayName("Expiry Date")]
        [Format("MM/dd/yyyy")]
        public DateTime Expirydate { get; set; }

        [UIHint("Hidden")]
        public DateTime DateCreated { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        public long StateId { get; set; }
    }

    [DefaultImplementation(Interface = typeof(IValidator<PhysicianLicenseModel>))]
    public class PhysicianLicenseModelValidator : AbstractValidator<PhysicianLicenseModel>
    {
        public PhysicianLicenseModelValidator()
        { }
    }
}
