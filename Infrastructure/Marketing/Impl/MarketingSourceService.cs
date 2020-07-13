using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using AutoMapper;

namespace Falcon.App.Infrastructure.Marketing.Impl
{
    [DefaultImplementation]
    public class MarketingSourceService : IMarketingSourceService
    {
        private readonly IMarketingSourceRepository _marketingSourceRepository;
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IZipCodeRepository _zipCodeRepository;

        public MarketingSourceService(IMarketingSourceRepository marketingSourceRepository, ITerritoryRepository territoryRepository, IZipCodeRepository zipCodeRepository)
        {
            _marketingSourceRepository = marketingSourceRepository;
            _territoryRepository = territoryRepository;
            _zipCodeRepository = zipCodeRepository;
        }

        public IEnumerable<string> FetchMarketingSourceByZip(string zipCode, bool showOnline = false)
        {
            var globalSources = _marketingSourceRepository.GetGlobalMarketingSources(showOnline) ?? new string[0];

            if (!String.IsNullOrWhiteSpace(zipCode))
            {
                long[] zipIds = _zipCodeRepository.GetZipCode(zipCode).Select(z => z.Id).ToArray();

                var territories = _territoryRepository.GetTerritoriesForZipIds(zipIds).Select(t => t.Id);

                if (territories.Count() > 0)
                {
                    var marketingSources =
                        _marketingSourceRepository.GetMarketingSourceByTerritory(territories.ToArray(), showOnline);

                    if (marketingSources != null && marketingSources.Count() > 0)
                    {
                        globalSources = marketingSources.Concat(globalSources);
                    }
                }
            }
            return globalSources;
        }


        public MarketingSourceEditModel Save(MarketingSourceEditModel model)
        {
            var marketingSource = Mapper.Map<MarketingSourceEditModel, MarketingSource>(model);
            if (marketingSource.Id == 0)
                marketingSource.DataRecorderMetaData = new DataRecorderMetaData() { DateCreated = DateTime.Now };
            else
            {
                var inDb = ((IUniqueItemRepository<MarketingSource>)_marketingSourceRepository).GetById(marketingSource.Id);
                marketingSource.DataRecorderMetaData = inDb.DataRecorderMetaData;
                marketingSource.DataRecorderMetaData.DateModified = DateTime.Now;
            }

            marketingSource = ((IUniqueItemRepository<MarketingSource>)_marketingSourceRepository).Save(marketingSource);
            _marketingSourceRepository.SaveMarketingSourceTerritories(marketingSource.Id, model.SelectedTerritories);

            model = Get(marketingSource.Id);
            return model;
        }

        public MarketingSourceEditModel Get(long id)
        {
            var marketingSource = ((IUniqueItemRepository<MarketingSource>)_marketingSourceRepository).GetById(id);
            var model = Mapper.Map<MarketingSource, MarketingSourceEditModel>(marketingSource);

            model.Territories = _territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.Advertiser);
            var marketingSourceTerritories = _marketingSourceRepository.GetMarketingSourceTerritories(new long[] { id });

            if (!marketingSourceTerritories.IsNullOrEmpty())
            {
                model.SelectedTerritories = marketingSourceTerritories.Select(t => t.SecondValue);
            }
            return model;
        }

        public MarketingSourceListModel GetPagedRecords(int pageNumber, int pageSize, MarketingSourceListModelFilter filter, out int totalRecords)
        {
            var marketingSources = _marketingSourceRepository.GetPagedRecords(pageNumber, pageSize, filter, out totalRecords);
            var models = Mapper.Map<IEnumerable<MarketingSource>, IEnumerable<MarketingSourceBasicModel>>(marketingSources);

            var marketingSourceTerritories = _marketingSourceRepository.GetMarketingSourceTerritories(marketingSources.Select(m => m.Id));
            if (!marketingSourceTerritories.IsNullOrEmpty())
            {
                var territories = _territoryRepository.GetTerritories(marketingSourceTerritories.Select(m => m.SecondValue).Distinct().ToList());
                foreach (var model in models)
                {
                    var modelTerritories = marketingSourceTerritories.Where(mst => mst.FirstValue == model.Id).Select(mst => mst.SecondValue).ToArray();
                    if (!modelTerritories.IsNullOrEmpty())
                        model.Territories = territories.Where(t => modelTerritories.Contains(t.Id)).Select(t => t.Name);
                }
            }

            return new MarketingSourceListModel() { MarketingSourceBasicModels = models };
        }

        public void Delete(long id)
        {
            _marketingSourceRepository.Deactivate(id);
            //_marketingSourceRepository.DeleteMarketingSourceTerritories(id);
            //((IUniqueItemRepository<MarketingSource>) _marketingSourceRepository).deac(new MarketingSource(id));
        }

    }
}
