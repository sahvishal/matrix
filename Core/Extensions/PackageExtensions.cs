using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Extensions
{
    public static class PackageExtensions
    {

        public static List<GiftCertificateOfferingsViewData> CreateGiftCertificateOfferingsViewData(this IEnumerable<Package> packages)
        {
            var giftCertificateOfferingsViewData = new List<GiftCertificateOfferingsViewData>();

            foreach (var package in packages)
            {
                var giftCertificateOfferingViewData = new GiftCertificateOfferingsViewData
                                                          {
                                                              Price = package.Price.ToString(),
                                                              PackageName = package.Name,
                                                              TestNames =
                                                                  string.Join(", ",
                                                                              package.Tests.Select(test => test.Name).
                                                                                  ToArray())
                                                          };

                giftCertificateOfferingsViewData.Add(giftCertificateOfferingViewData);                
            }

            return giftCertificateOfferingsViewData;
        }
        
    }
}
