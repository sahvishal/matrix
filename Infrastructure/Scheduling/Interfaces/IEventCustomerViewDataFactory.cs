using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Scheduling.Interfaces
{
    public interface IEventCustomerViewDataFactory
    {
        void Create(EventCustomerViewData eventCustomerViewData,
                    CustomerOrderBasicInfoRow customerOrderBasicInfoRow);

    }
}