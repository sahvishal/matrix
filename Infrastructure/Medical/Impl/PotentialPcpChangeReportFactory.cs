using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PotentialPcpChangeReportFactory : IPotentialPcpChangeReportFactory
    {
        private const string EmptyString = "";

        public PotentialPcpChangeReportViewModel CreateModel(PrimaryCarePhysician oldPcpDetails, PrimaryCarePhysician newPcpDetails, Customer customerInfo)
        {
            var model = new PotentialPcpChangeReportViewModel
            {
                Market = string.IsNullOrEmpty(customerInfo.Market) ? EmptyString : customerInfo.Market,
                MemberId = string.IsNullOrEmpty(customerInfo.InsuranceId) ? EmptyString : customerInfo.InsuranceId,
                Gmpi = customerInfo.AdditionalField3,
                FirstName = customerInfo.Name.FirstName,
                LastName = customerInfo.Name.LastName
            };

            if (oldPcpDetails == null)
            {
                model.ExistingPcpFullName = EmptyString;
                model.ExistingPcpAddress1 = EmptyString;
                model.ExistingPcpAddress2 = EmptyString;
                model.ExistingPcpCity = EmptyString;
                model.ExistingPcpState = EmptyString;
                model.ExistingPcpZip = EmptyString;
            }
            else
            {
                model.ExistingPcpFullName = oldPcpDetails.Name == null ? EmptyString : oldPcpDetails.Name.FullName;

                if (oldPcpDetails.Address == null)
                {
                    model.ExistingPcpAddress1 = EmptyString;
                    model.ExistingPcpAddress2 = EmptyString;
                    model.ExistingPcpCity = EmptyString;
                    model.ExistingPcpState = EmptyString;
                    model.ExistingPcpZip = EmptyString;
                }
                else
                {
                    model.ExistingPcpAddress1 = oldPcpDetails.Address.StreetAddressLine1;
                    model.ExistingPcpAddress2 = oldPcpDetails.Address.StreetAddressLine2;
                    model.ExistingPcpCity = oldPcpDetails.Address.City;
                    model.ExistingPcpState = oldPcpDetails.Address.State;
                    model.ExistingPcpZip = oldPcpDetails.Address.ZipCode.ToString();
                }
            }

            if (newPcpDetails == null)
            {
                model.NewPcpFullName = EmptyString;
                model.NewPcpAddress1 = EmptyString;
                model.NewPcpAddress2 = EmptyString;
                model.NewPcpCity = EmptyString;
                model.NewPcpState = EmptyString;
                model.NewPcpZip = EmptyString;
            }
            else
            {
                model.NewPcpFullName = newPcpDetails.Name == null ? EmptyString : newPcpDetails.Name.FullName;

                if (newPcpDetails.Address == null)
                {
                    model.NewPcpAddress1 = EmptyString;
                    model.NewPcpAddress2 = EmptyString;
                    model.NewPcpCity = EmptyString;
                    model.NewPcpState = EmptyString;
                    model.NewPcpZip = EmptyString;
                }
                else
                {
                    model.NewPcpAddress1 = newPcpDetails.Address.StreetAddressLine1;
                    model.NewPcpAddress2 = newPcpDetails.Address.StreetAddressLine2;
                    model.NewPcpCity = newPcpDetails.Address.City;
                    model.NewPcpState = newPcpDetails.Address.State;
                    model.NewPcpZip = newPcpDetails.Address.ZipCode.ToString();
                }
            }

            model.HfComment = EmptyString;
            return model;
        }
    }
}
