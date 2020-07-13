using System;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation]
    public class SourceCodeService : ISourceCodeService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IUniqueItemRepository<Test> _testRepository;
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly ISourceCodeFactory _sourceCodeFactory;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly IEventRepository _eventRepository;

        public SourceCodeService(IPackageRepository packageRepository, IUniqueItemRepository<Test> testRepository, ISourceCodeRepository sourceCodeRepository, IShippingOptionRepository shippingOptionRepository,
            IElectronicProductRepository electronicProductRepository, ISourceCodeFactory sourceCodeFactory, IEventRepository eventRepository)
        {
            _packageRepository = packageRepository;
            _testRepository = testRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _sourceCodeFactory = sourceCodeFactory;
            _shippingOptionRepository = shippingOptionRepository;
            _electronicProductRepository = electronicProductRepository;
            _eventRepository = eventRepository;
        }

        public SourceCodeListModel Get(SourceCodeListModelFilter filter, int pageNumber, int pageSize, out long totalRecords)
        {
            var sourceCodes = _sourceCodeRepository.GetbyFilter(filter, pageNumber, pageSize, out totalRecords);
            if (sourceCodes == null || sourceCodes.Count() < 1) return null;

            var packageids = sourceCodes.Where(sc => sc.PackageDiscounts != null).SelectMany(sc => sc.PackageDiscounts.Select(pd => pd.Id)).ToArray();
            var packages = packageids.Count() > 0 ? _packageRepository.GetByIds(packageids) : null;

            var testIds = sourceCodes.Where(sc => sc.TestDiscounts != null).SelectMany(sc => sc.TestDiscounts.Select(pd => pd.Id)).ToArray();
            var tests = testIds.Count() > 0 ? _testRepository.GetByIds(testIds) : null;

            var shippingOptionIds = sourceCodes.Where(sc => sc.ShippingDiscounts != null).SelectMany(sc => sc.ShippingDiscounts.Select(sd => sd.Id)).ToArray();
            var shippingOptions = shippingOptionIds.Count() > 0 ? _shippingOptionRepository.GetByIds(shippingOptionIds) : null;

            var productIds = sourceCodes.Where(sc => sc.ProductDiscounts != null).SelectMany(sc => sc.ProductDiscounts.Select(pd => pd.Id)).ToArray();
            var products = productIds.Count() > 0 ? _electronicProductRepository.GetByIds(productIds) : null;

            return _sourceCodeFactory.Create(sourceCodes, packages, tests, shippingOptions, products);
        }

        public SourceCodeEditModel Get(long id = 0)
        {
            SourceCodeEditModel model;
            if(id > 0)
            {
                var sourceCode = _sourceCodeRepository.GetSourceCodeById(id);
                model = Mapper.Map<SourceCode, SourceCodeEditModel>(sourceCode);

                if (model.PackageDiscounts != null && model.PackageDiscounts.Count() > 0)
                {
                    var ids = model.PackageDiscounts.Select(pd => pd.Id).ToArray();
                    var packages = _packageRepository.GetByIds(ids);

                    foreach (var packageDiscount in model.PackageDiscounts)
                    {
                        packageDiscount.Name = packages.Where(p => p.Id == packageDiscount.Id).Single().Name;
                    }
                }

                if (model.TestDiscounts != null && model.TestDiscounts.Count() > 0)
                {
                    var ids = model.TestDiscounts.Select(td => td.Id).ToArray();
                    var tests = _testRepository.GetByIds(ids);

                    foreach (var testDiscount in model.TestDiscounts)
                    {
                        testDiscount.Name = tests.Where(t => t.Id == testDiscount.Id).Single().Name;
                    }
                }

                if (model.ProductDiscounts != null && model.ProductDiscounts.Count() > 0)
                {
                    var ids = model.ProductDiscounts.Select(td => td.Id).ToArray();
                    var products = _electronicProductRepository.GetByIds(ids);

                    foreach (var productDiscount in model.ProductDiscounts)
                    {
                        productDiscount.Name = products.Where(t => t.Id == productDiscount.Id).Single().Name;
                    }
                }

                if (model.ShippingDiscounts != null && model.ShippingDiscounts.Count() > 0)
                {
                    var ids = model.ShippingDiscounts.Select(td => td.Id).ToArray();
                    var shippingOptions = _shippingOptionRepository.GetByIds(ids);

                    foreach (var shippingDiscount in model.ShippingDiscounts)
                    {
                        shippingDiscount.Name = shippingOptions.Where(t => t.Id == shippingDiscount.Id).Single().Name;
                    }
                }

                if(sourceCode.EventIds!=null && sourceCode.EventIds.Count()>0)
                {
                    var events = _eventRepository.GetEventswithPodbyIds(sourceCode.EventIds.ToArray());
                    model.Events = events.Select(e => new SourceCodeEventEditModel
                                                          {
                                                              EventId = e.Id,
                                                              EventDate = e.EventDate,
                                                              EventName = e.Name
                                                          }).ToArray();
                }
            }
            else
            {
                model = new SourceCodeEditModel
                {
                    ValidityStartDate = DateTime.Now,
                    MinimumPurchaseAmount = 0,
                    CouponValueType = (int)DiscountValueType.Money
                };
            }

            return Get(model);
        }

        public SourceCodeEditModel Get(SourceCodeEditModel model)
        {
            model.AllSignUpModes = SignUpMode.CallCenter.GetNameValuePairs().Select(dt => new OrderedPair<int, string>(dt.FirstValue, dt.SecondValue));
            model.AllPackages = _packageRepository.GetAll().Select(m => new OrderedPair<long, string>(m.Id, m.Name)).OrderBy(m => m.SecondValue).ToArray();
            model.AllTests = ((ITestRepository)_testRepository).GetAll().Select(m => new OrderedPair<long, string>(m.Id, m.Name)).OrderBy(m => m.SecondValue).ToArray();

            var shippingOptions = _shippingOptionRepository.GetAllShippingOptions();
            model.AllShippingOptions = shippingOptions != null ? shippingOptions.Select(so => new OrderedPair<long, string>(so.Id, so.Name)).OrderBy(m => m.SecondValue).ToArray() : new OrderedPair<long, string>[0];
            
            var products = _electronicProductRepository.GetAllProducts();
            model.AllProducts = products != null ? products.Select(po => new OrderedPair<long, string>(po.Id, po.Name)).OrderBy(m => m.SecondValue).ToArray() : new OrderedPair<long, string>[0];

            return model;
        }

    }
}