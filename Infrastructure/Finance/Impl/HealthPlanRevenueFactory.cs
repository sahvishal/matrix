using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using System;
using System.Collections.Generic;
namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class HealthPlanRevenueFactory : IHealthPlanRevenueFactory
    {
        public HealthPlanRevenueEditModel Create(HealthPlanRevenue healthPlanRevenue, IEnumerable<HealthPlanRevenueItem> healthPlanRevenueItems)
        {
            var model = new HealthPlanRevenueEditModel();

            throw new System.NotImplementedException();
        }



        public HealthPlanRevenue MapHealthPlanRevenueInfo(HealthPlanRevenueEditModel model, long createdById)
        {
            var retValue = new HealthPlanRevenue();
            retValue.AccountId = model.HealthPlanId;
            retValue.DateFrom = model.DateFrom.Value;
            retValue.RevenueItemTypeId = model.RevenueItemTypeId;
            retValue.DataRecorderMetaData = new DataRecorderMetaData(createdById, DateTime.Now, null);

            return retValue;
        }


        public IEnumerable<HealthPlanRevenueItem> MapHealthPlanRevenueItemInfo(HealthPlanRevenueEditModel model,long healthPlanRevenueId)
        {
            var retValue = new List<HealthPlanRevenueItem>();
            if (model.RevenueItemTypeId == (long)HealthPlanRevenueType.PerCustomer)
            {
                var objHealthPlanRevenueItem = new HealthPlanRevenueItem();
                objHealthPlanRevenueItem.HealthPlanRevenueId = healthPlanRevenueId;
                objHealthPlanRevenueItem.Price = model.Customer.Price;
                retValue.Add(objHealthPlanRevenueItem);
            }
            else if (model.RevenueItemTypeId == (long)HealthPlanRevenueType.PerPackage)
            {
                foreach (var item in model.PackageList)
                {
                    retValue.Add(new HealthPlanRevenueItem()
                    {
                        HealthPlanRevenueId=healthPlanRevenueId,
                        PackageId= item.PackageId,
                        Price=item.Price
                    });
                }
            }
            else if (model.RevenueItemTypeId == (long)HealthPlanRevenueType.PerTest)
            {
                foreach (var item in model.TestList)
                {
                  retValue.Add(new HealthPlanRevenueItem()
                    {
                        HealthPlanRevenueId=healthPlanRevenueId,
                        TestId= item.TestId,
                        Price=item.Price
                    });   
                }
            }
            return retValue;
        }
    }
}
