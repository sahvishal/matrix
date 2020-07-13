using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Factories.Events
{
    [DefaultImplementation]
    public class EventCustomerFilterPredicateFactory : IEventCustomerFilterPredicateFactory
    {
        public List<IPredicate> CreatePredicate(EventCustomerFilterMode eventCustomerFilterMode)
        {
            var predicates = new List<IPredicate>();
            switch (eventCustomerFilterMode)
            {
                case EventCustomerFilterMode.Actual:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.IsTestAttended == 1);
                        return predicates;
                    }
                case EventCustomerFilterMode.Cash:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.Cash != 0m);
                        return predicates;
                    }
                case EventCustomerFilterMode.Check:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.Check != 0m);
                        return predicates;
                    }
                case EventCustomerFilterMode.CreditCard:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.CreditCard != 0m);
                        return predicates;
                    }

                case EventCustomerFilterMode.ECheck:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.Echeck != 0m);
                        return predicates;
                    }
                case EventCustomerFilterMode.NoShow:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.Noshow == 1);
                        return predicates;
                    }
                case EventCustomerFilterMode.Paid:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.IsPaid == 1);
                        return predicates;
                    }
                case EventCustomerFilterMode.Registered:
                    {
                        return predicates;
                    }
                case EventCustomerFilterMode.UnPaid:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.IsPaid == 0);
                        return predicates;
                    }
                case EventCustomerFilterMode.LeftWithoutScreening:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.LeftWithoutScreeningReasonId > 0);
                        return predicates;
                    }
                case EventCustomerFilterMode.UnPaidNoShowExcluded:
                    {
                        predicates.Add(CustomerOrderBasicInfoFields.IsPaid == 0);
                        predicates.Add(CustomerOrderBasicInfoFields.Noshow == 0);
                        return predicates;
                    }
                default:
                    throw new NotSupportedException(string.Format("The FilterMode {0} is not yet supported.",
                                                                  eventCustomerFilterMode));
            }
        }

        public IEnumerable<CustomerOrderBasicInfoRow> GetFilteredData(EventCustomerFilterMode eventCustomerFilterMode, CustomerOrderBasicInfoTypedView customerOrderBasicInfoTypedView)
        {

            switch (eventCustomerFilterMode)
            {
                case EventCustomerFilterMode.Actual:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.IsTestAttended == 1);
                    }
                case EventCustomerFilterMode.Cash:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.Cash != 0m);
                    }
                case EventCustomerFilterMode.Check:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.Check != 0m);

                    }
                case EventCustomerFilterMode.CreditCard:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.CreditCard != 0m);
                    }

                case EventCustomerFilterMode.ECheck:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.Echeck != 0m);
                    }
                case EventCustomerFilterMode.NoShow:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.Noshow == false);
                    }
                case EventCustomerFilterMode.Paid:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.IsPaid == 1);
                    }
                case EventCustomerFilterMode.Registered:
                    {
                        return customerOrderBasicInfoTypedView;
                    }
                case EventCustomerFilterMode.UnPaid:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.IsPaid == 0);
                    }
                case EventCustomerFilterMode.UnPaidNoShowExcluded:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.IsPaid == 0 && q.Noshow == false);
                    }
                case EventCustomerFilterMode.LeftWithoutScreening:
                    {
                        return customerOrderBasicInfoTypedView.Where(q => q.LeftWithoutScreeningReasonId > 0);

                    }
                default:
                    throw new NotSupportedException(string.Format("The FilterMode {0} is not yet supported.",
                                                                  eventCustomerFilterMode));
            }
        }
    }
}