using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventPackage : DomainObjectBase, IOrderable
    {
        public long EventId { get; set; }
        public long PackageId { get; set; }

        private Package _package;
        public Package Package
        {
            get
            {
                if (Tests != null)
                {
                    _package.Tests = Tests.Select(t => t.Test).ToList();
                }
                return _package;
            }
            set { _package = value; }
        }

        public IEnumerable<EventTest> Tests { get; set; }

        public decimal Price { get; set; }

        public string Description { get { return string.Format("Package for {0:C} ", Price); } }

        public OrderItemType OrderItemType
        {
            get { return OrderItemType.EventPackageItem; }
        }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public bool AvailableThroughOnline { get; set; }
        public bool AvailableThroughCallCenter { get; set; }
        public bool AvailableThroughTechnician { get; set; }
        public bool AvailableThroughAdmin { get; set; }

        public long? HealthAssessmentTemplateId { get; set; }

        public bool IsRecommended { get; set; }

        public long Gender { get; set; }


        public bool MostPopular { get; set; }

        public bool BestValue { get; set; }

        public long? PodRoomId { get; set; }

        public EventPackage()
        { }

        public EventPackage(long eventPackageId)
            : base(eventPackageId)
        { }
    }
}