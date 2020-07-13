using System;

namespace Falcon.App.Core.Marketing.Domain
{
    public class PrintOrderItemShippingParser
    {
        


        private Int16 _trackingNumber = -1;
        public Int16 TrackingNumber { get { return _trackingNumber; } set { _trackingNumber = value; } }
        
        private Int16 _service = -1;
        public Int16 Service { get { return _service; } set { _service = value; } }

        private Int16 _status = -1;
        public Int16 Status { get { return _status; } set { _status = value; } }

        private Int16 _scheduledDelivery = -1;
        public Int16 ScheduledDelivery { get { return _scheduledDelivery; } set { _scheduledDelivery = value; } }

        private Int16 _shipToName = -1;
        public Int16 ShipToName { get { return _shipToName; } set { _shipToName = value; } }

        private Int16 _shipToAttention = -1;
        public Int16 ShipToAttention { get { return _shipToAttention; } set { _shipToAttention = value; } }

        private Int16 _shipToAddressLine1 = -1;
        public Int16 ShipToAddressLine1 { get { return _shipToAddressLine1; } set { _shipToAddressLine1 = value; } }

        private Int16 _shipToAddressLine2 = -1;
        public Int16 ShipToAddressLine2 { get { return _shipToAddressLine2; } set { _shipToAddressLine2 = value; } }

        private Int16 _shipToCity = -1;
        public Int16 ShipToCity { get { return _shipToCity; } set { _shipToCity = value; } }

        private Int16 _shipToPostalCode = -1;
        public Int16 ShipToPostalCode { get { return _shipToPostalCode; } set { _shipToPostalCode = value; } }

        private Int16 _shipToStateProvince = -1;
        public Int16 ShipToStateProvince { get { return _shipToStateProvince; } set { _shipToStateProvince = value; } }

        private Int16 _packageReferenceNo1 = -1;
        public Int16 PackageReferenceNo1 { get { return _packageReferenceNo1; } set { _packageReferenceNo1 = value; } }


        private Int16 _packageReferenceNo2 = -1;
        public Int16 PackageReferenceNo2 { get { return _packageReferenceNo2; } set { _packageReferenceNo2 = value; } }

        private Int16 _packageReferenceNo3 = -1;
        public Int16 PackageReferenceNo3 { get { return _packageReferenceNo3; } set { _packageReferenceNo3 = value; } }


    }
}
