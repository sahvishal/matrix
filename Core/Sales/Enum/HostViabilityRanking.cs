
using System.Collections.Generic;

namespace Falcon.App.Core.Sales.Enum
{
    public sealed class HostViabilityRanking : TypeSafeEnum
    {
        private readonly int _persistenceLayerId;
        public int PersistenceLayerId { get { return _persistenceLayerId; } }

        private HostViabilityRanking(int persistenceLayerId, string name)
            : base(name)
        {
            _persistenceLayerId = persistenceLayerId;
        }

        public static readonly HostViabilityRanking DoNotSchedule = new HostViabilityRanking(37, "Do Not Schedule");
        public static readonly HostViabilityRanking LastResort = new HostViabilityRanking(38, "Last Resort");
        public static readonly HostViabilityRanking Difficult = new HostViabilityRanking(39, "Difficult");
        public static readonly HostViabilityRanking Acceptable = new HostViabilityRanking(40, "Acceptable");
        public static readonly HostViabilityRanking Optimal = new HostViabilityRanking(41, "Optimal");

        public static List<HostViabilityRanking> HostRankings
        {
            get
            {
                var hostRankings = new List<HostViabilityRanking> { Optimal, Acceptable, Difficult, LastResort, DoNotSchedule };
                return hostRankings;
            }
        }
    }

}
