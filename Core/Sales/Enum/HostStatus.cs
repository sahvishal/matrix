using System.Collections.Generic;

namespace Falcon.App.Core.Sales.Enum
{
    public sealed class HostStatus : TypeSafeEnum
    {
        private readonly int _persistenceLayerId;
        public int PersistenceLayerId { get { return _persistenceLayerId; } }

        private HostStatus(int persistenceLayerId, string name)
            : base(name)
        {
            _persistenceLayerId = persistenceLayerId;
        }

        public static readonly HostStatus Unknown = new HostStatus(0, "Unknown");
        public static readonly HostStatus Hot = new HostStatus(1, "Hot");
        public static readonly HostStatus Cold = new HostStatus(2, "Cold");
        public static readonly HostStatus Warm = new HostStatus(3, "Warm");

        public static List<HostStatus> HostStatuses
        {
            get
            {
                var hostStatuses = new List<HostStatus> {Unknown, Hot, Cold, Warm};
                return hostStatuses;
            }
        }
    }
}


