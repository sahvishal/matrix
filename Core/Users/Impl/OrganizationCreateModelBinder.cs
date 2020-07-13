using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users.Impl
{
    public class OrganizationCreateModelBinder
    {
        public Organization ToDomain(OrganizationEditModel model)
        {
            return new Organization(model.Id)
            {
                BillingAddressId = model.BillingAddress != null ? model.BillingAddress.Id : 0,
                BusinessAddressId = model.BusinessAddress != null ? model.BusinessAddress.Id : 0,
                Description = model.Description,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FaxNumber = model.FaxNumber,
                LogoImageId = model.LogoImage != null ? model.LogoImage.Id : 0,
                TeamImageId = model.TeamImage != null ? model.TeamImage.Id : 0,
                Name = model.Name,
                OrganizationType = model.OrganizationType
            };
        }

        public Organization ToDomain(Organization domain, OrganizationEditModel model)
        {
            domain.Id = model.Id;
            domain.BillingAddressId = model.BillingAddress != null ? model.BillingAddress.Id : 0;
            domain.BusinessAddressId = model.BusinessAddress != null ? model.BusinessAddress.Id : 0;
            domain.Description = model.Description;
            domain.Email = model.Email;
            domain.PhoneNumber = model.PhoneNumber;
            domain.FaxNumber = model.FaxNumber;
            domain.LogoImageId = model.LogoImage != null ? model.LogoImage.Id : 0;
            domain.TeamImageId = model.TeamImage != null ? model.TeamImage.Id : 0;
            domain.Name = model.Name;
            domain.OrganizationType = model.OrganizationType;
            return domain;
        }

        public OrganizationEditModel ToModel(Organization organization, AddressEditModel billingAddress, AddressEditModel businessAddress, File logoImage, File teamImage)
        {
            return new OrganizationEditModel()
            {
                BillingAddress = billingAddress ?? new AddressEditModel(),
                BusinessAddress = businessAddress ?? new AddressEditModel(),
                Description = organization.Description,
                Email = organization.Email,
                FaxNumber = organization.FaxNumber,
                Id = organization.Id,
                LogoImage = logoImage,
                Name = organization.Name,
                OrganizationType = organization.OrganizationType,
                PhoneNumber = organization.PhoneNumber,
                TeamImage = teamImage
            };
        }

        public OrganizationEditModel ToModel(OrganizationEditModel model, Organization organization, AddressEditModel billingAddress, AddressEditModel businessAddress, File logoImage, File teamImage)
        {
            model.BillingAddress = billingAddress;
            model.BusinessAddress = businessAddress;
            model.Description = organization.Description;
            model.Email = organization.Email;
            model.FaxNumber = organization.FaxNumber;
            model.Id = organization.Id;
            model.LogoImage = logoImage;
            model.Name = organization.Name;
            model.OrganizationType = organization.OrganizationType;
            model.PhoneNumber = organization.PhoneNumber;
            model.TeamImage = teamImage;
            return model;
        }

    }
}
