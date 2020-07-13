using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class MapEventListModelFactory : IMapEventListModelFactory
    {
        public MapEventListModel Create(IEnumerable<Event> events, IEnumerable<EventBasicInfoViewModel> eventListInfo, IEnumerable<ZipCode> zipCodes, IEnumerable<CorporateAccount> corporateAccounts)
        {
            var model = new MapEventListModel();
            var collection = new List<MapEventViewModel>();

            events.ToList().ForEach(e =>
            {
                var info = eventListInfo.Single(x => x.Id == e.Id);
                var zipCode = zipCodes.Where(x => x.Zip == info.HostAddress.ZipCode).FirstOrDefault();               

                var mapEventModel = new MapEventViewModel
                {
                    Id = e.Id,
                    //Latitude = zipCode.Latitude.ToString(),
                    //Longitude = zipCode.Longitude.ToString(),
                    Host = info.HostName,
                    Address = info.HostAddress.ToString(),
                    SponsoredBy = info.Sponsor,
                    Pods = info.Pods != null ? string.Join(", ", info.Pods.Select(pod => pod.SecondValue)) : string.Empty,
                    EventType = e.EventType,
                    TotalAppointmentSlots=info.TotalAppointmentSlots,
                    BookedSlots=info.BookedSlots,
                    EventDate=e.EventDate.ToString("dd/MM/yyyy")
                };
                
                if (e.AccountId.HasValue)
                {
                    var corporateAccount = corporateAccounts.Single(x => x.Id == e.AccountId);
                    if (corporateAccount.IsHealthPlan)                    
                        mapEventModel.EventType = EventType.HealthPlan;
                    else
                        mapEventModel.EventType = EventType.Corporate;
                }
                else
                    mapEventModel.EventType = EventType.Retail;

                mapEventModel= GetLatLngByZipCode(collection, zipCode.Latitude.ToString(), zipCode.Longitude.ToString(), mapEventModel);

                collection.Add(mapEventModel);
            });

            model.Collection = collection;
            return model;
        }
     
        private MapEventViewModel GetLatLngByZipCode(List<MapEventViewModel> collection, string lat, string lng,MapEventViewModel model)
        {
            do
            {
                var latpower = CountDigitsAfterDecimal(Convert.ToDouble(lat));
                var lngpower = CountDigitsAfterDecimal(Convert.ToDouble(lng));
                lat = (Convert.ToDouble(lat) + 1 / Math.Pow(10, latpower - 1)).ToString();
                lng = (Convert.ToDouble(lng) + 1 / Math.Pow(10, lngpower - 1)).ToString();
            }
            while (collection.Any(x => (x.Latitude) == lat && x.Longitude == lng));
           
            model.Latitude = lat.ToString();
            model.Longitude = lng.ToString();
            
            return model;
        }

        private int CountDigitsAfterDecimal(double value)
        {
            bool start = false;
            int count = 0;
            foreach (var s in value.ToString())
            {
                if (s == '.')
                {
                    start = true;
                }
                else if (start)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
