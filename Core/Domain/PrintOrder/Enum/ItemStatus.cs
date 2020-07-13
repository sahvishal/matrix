namespace Falcon.App.Core.Domain.PrintOrder.Enum
{
    public enum ItemStatus
    {
        Placed = 18,        // Handling is done through Event Wizard is Draft HSC created it from Event wizard
        Assigned = 19,      // Franchisor assigned to Print Vendor
        OutforDelivery = 20, //From the CSV
        Confirmed = 21,     // From Email, Call Center, Unique URL
        Returned = 22,      // From the CSV
        Delivered = 26,     // From the CSV
        InTransit = 27,     // From the CSV
        Unknown = 28,       // Status which is in CSV but we are not handling it

    }

}



