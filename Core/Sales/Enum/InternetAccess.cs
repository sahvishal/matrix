using System.Collections.Generic;

namespace Falcon.App.Core.Sales.Enum
{
    public sealed class InternetAccess : TypeSafeEnum
    {
        private readonly int _persistenceLayerId;
        public int PersistenceLayerId { get { return _persistenceLayerId; } }

        private InternetAccess(int persistenceLayerId, string name)
            : base(name)
        {
            _persistenceLayerId = persistenceLayerId;
        }

        public static readonly InternetAccess Available_GoodSpeed = new InternetAccess(42, "Available (Good Speed)");
        public static readonly InternetAccess Available_AvgSpeed = new InternetAccess(43, "Available (Average Speed)");
        public static readonly InternetAccess Available_Unreliable = new InternetAccess(44, "Available (Unreliable)");
        public static readonly InternetAccess NotAvailable = new InternetAccess(45, "Not Available");

        public static List<InternetAccess> InternetAccessTypes
        {
            get
            {
                var internetAccessTypes = new List<InternetAccess> { Available_GoodSpeed, Available_AvgSpeed, Available_Unreliable, NotAvailable };
                return internetAccessTypes;
            }
        }

    }
}
