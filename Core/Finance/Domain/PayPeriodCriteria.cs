using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
   public class PayPeriodCriteria : DomainObjectBase
    {
       public long PayPeriodId { get; set; }
       public long MinCustomer { get; set; }
       public long? MaxCustomer { get; set; }
       public long TypeId { get; set; }
       public decimal Ammount { get; set; }
    }
}
