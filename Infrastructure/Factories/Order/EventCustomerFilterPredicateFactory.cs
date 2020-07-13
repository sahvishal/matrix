using System;
using HealthYes.Data.HelperClasses;
using HealthYes.Web.Infrastructure.Interfaces;
using SD.LLBLGen.Pro.ORMSupportClasses;
using HealthYes.Web.Core.Enum;
namespace HealthYes.Web.Infrastructure.Factories.Order
{
    public class EventCustomerFilterPredicateFactory : IEventCustomerFilterPredicateFactory
    {
        public IPredicate CreatePredicate(EventCustomerFilterMode eventCustomerFilterMode)
        {
            switch (eventCustomerFilterMode)
            {
                case EventCustomerFilterMode.Actual:
                    return CustomerOrderBasicInfoFields.IsTestAttended == true;
                case EventCustomerFilterMode.Cash:
                    return CustomerOrderBasicInfoFields.Cash > 0;
                case EventCustomerFilterMode.Check:
                    return CustomerOrderBasicInfoFields.Check > 0;
                case EventCustomerFilterMode.CreditCard:
                    return CustomerOrderBasicInfoFields.CreditCard > 0;
                case EventCustomerFilterMode.ECheck:
                    return CustomerOrderBasicInfoFields.Echeck > 0;
                case EventCustomerFilterMode.NoShow:
                    return CustomerOrderBasicInfoFields.Noshow == true;
                case EventCustomerFilterMode.Paid:
                    return CustomerOrderBasicInfoFields.IsPaid == true;
                case EventCustomerFilterMode.Registered:
                    return CustomerOrderBasicInfoFields.Noshow == false;
                case EventCustomerFilterMode.UnPaid:
                    return CustomerOrderBasicInfoFields.IsPaid == false;
                default:
                    throw new NotSupportedException(string.Format("The FilterMode {0} is not yet supported.",
                                                                  eventCustomerFilterMode));
            }
        }
    }
}