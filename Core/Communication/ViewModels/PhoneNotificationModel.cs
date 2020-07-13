using System;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class PhoneNotificationModel
    {

        public PhoneNotificationModel(PhoneCommunicationViewModelBase smsCommunication)
        {
            SmsCommunication = smsCommunication;
        }
        public PhoneCommunicationViewModelBase SmsCommunication { get; set; }
        public Name CustomerName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public AddressViewModel AddressOfVenue { get; set; }
        public string LocationName { get; set; }
    }
}
