using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Application.Repositories;
using Falcon.App.Infrastructure.Mappers.Shipping;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Shipping
{
    public class ShippingOptionRepository
        : UniqueItemRepository<ShippingOption, ShippingOptionEntity>, IShippingOptionRepository
    {
        private readonly IToolTipRepository _tooltipRepository;

        public ShippingOptionRepository(IToolTipRepository tooltipRepository)
            : base(new ShippingOptionMapper())
        {
            _tooltipRepository = tooltipRepository;
        }
        public ShippingOptionRepository()
            : this(new ToolTipRepository())
        { }

        protected override EntityField2 EntityIdField
        {
            get { return ShippingOptionFields.ShippingOptionId; }
        }

        public List<ShippingOption> GetAllShippingOptions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var shippingOptions = (from so in linqMetaData.ShippingOption
                                       join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals pso.ShippingOptionId into sopso
                                       from sp in sopso.DefaultIfEmpty()
                                       where so.IsActive && (sp.IsForPcp == null || !sp.IsForPcp)
                                       select so);
                return Mapper.MapMultiple(shippingOptions).ToList();
            }

        }

        public List<ShippingOption> GetAllShippingOptionsForTracking()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var shippingOptions = (from so in linqMetaData.ShippingOption
                                       join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals pso.ShippingOptionId into sopso
                                       from sp in sopso.DefaultIfEmpty()
                                       select so);
                return Mapper.MapMultiple(shippingOptions).ToList();
            }

        }

        public List<ShippingOption> GetAllShippingOptionsForBuyingProcess()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var shippingOptions = (from so in linqMetaData.ShippingOption
                                       join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals pso.ShippingOptionId into sopso
                                       from sp in sopso.DefaultIfEmpty()
                                       where so.IsActive && (sp.IsShowVisible == null || sp.IsShowVisible)
                                       select so);
                return Mapper.MapMultiple(shippingOptions).ToList();
            }

        }

        public List<ShippingOption> GetAllShippingOptionForCorporate(long accountId)
        {
            using (var adapter =  PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var shippingOptions = (from so in linqMetaData.ShippingOption
                                       join cso in linqMetaData.CorporateShippingOption on so.ShippingOptionId equals
                                           cso.ShippingOptionId
                                       where cso.AccountId == accountId
                                       select so);
                if (shippingOptions == null || shippingOptions.Count() == 0)
                    return null;
                return Mapper.MapMultiple(shippingOptions).ToList();
            }
        }

        public List<ShippingOption> GetShippingOptionsByShippingDetailIds(IEnumerable<long> shippingDetailIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var shippingOptionEntities = (from sd in linqMetaData.ShippingDetail
                                              join so in linqMetaData.ShippingOption on sd.ShippingOptionId equals
                                                  so.ShippingOptionId
                                              join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals
                                                  pso.ShippingOptionId into sopso
                                              from sp in sopso.DefaultIfEmpty()
                                              where shippingDetailIds.Contains(sd.ShippingDetailId) && (sp.IsShowVisible == null || sp.IsShowVisible)
                                              select so);
                return Mapper.MapMultiple(shippingOptionEntities).ToList();
            }
        }

        public ShippingOption GetShippingOptionByProductId(long productId, bool isForPcp = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var shippingOptionEntity = (from so in linqMetaData.ShippingOption
                                            join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals pso.ShippingOptionId
                                            where pso.ProductId == productId
                                            && pso.IsForPcp == isForPcp
                                            select so).FirstOrDefault();
                if (shippingOptionEntity == null)
                    return null;
                return Mapper.Map(shippingOptionEntity);

            }
        }

        public ShippingOption GetOnlineShippingOption()
        {
            return new ShippingOption
                       {
                           Id = 0,
                           Name = "Free online via secure portal",
                           Price = 0.00m,
                           Description = _tooltipRepository.GetToolTipContentByTag(ToolTipType.OnlineShippingDescription),
                           Disclaimer = string.Empty
                       };
        }

        public List<ShippingOption> GetAllShippingOptionForHospitalPartner(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var shippingOptions = (from so in linqMetaData.ShippingOption
                                       join hpso in linqMetaData.HospitalPartnerShippingOption on so.ShippingOptionId equals
                                           hpso.ShippingOptionId
                                       where hpso.HospitalPartnerId == hospitalPartnerId
                                       select so);
                if (shippingOptions == null || shippingOptions.Count() == 0)
                    return null;
                return Mapper.MapMultiple(shippingOptions).ToList();
            }
        }

    }
}
