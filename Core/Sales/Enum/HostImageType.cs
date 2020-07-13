using System.Collections.Generic;

namespace Falcon.App.Core.Sales.Enum
{
    public sealed class HostImageType : TypeSafeEnum
    {
        private readonly int _persistenceLayerId;
        public int PersistenceLayerId { get { return _persistenceLayerId; } }

        private HostImageType(int persistenceLayerId, string name)
            : base(name)
        {
            _persistenceLayerId = persistenceLayerId;
        }

        public static readonly HostImageType HostInfrastructure = new HostImageType(50, "Host Infrastructure");
        public static readonly HostImageType MarketingGeneral = new HostImageType(49, "Marketing (General)");
        public static readonly HostImageType Marquee = new HostImageType(52, "Marketing (Marquee)");
        public static readonly HostImageType Logo = new HostImageType(53, "Marketing (Logo)");

        public static List<HostImageType> HostImageTypes
        {
            get
            {
                var hostImages = new List<HostImageType> { HostInfrastructure, MarketingGeneral, Marquee, Logo };
                return hostImages;
            }
        }
    }
}
