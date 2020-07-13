using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Marketing.Factories
{
    [DefaultImplementation]
    public class SourceCodeFactory : ISourceCodeFactory
    {
        public SourceCodeListModel Create(IEnumerable<SourceCode> sourceCodes, IEnumerable<Package> packages, IEnumerable<Test> tests, IEnumerable<ShippingOption> shippingOptions, IEnumerable<Product> products)
        {
            var listModel = new SourceCodeListModel();
            var sourceCodeViewModelCollection = new List<SourceCodeViewModel>();

            foreach (var sourceCode in sourceCodes)
            {
                var model = Mapper.Map<SourceCode, SourceCodeViewModel>(sourceCode);

                if(sourceCode.PackageDiscounts != null)
                {
                    var packageDiscountViewModelCollection = sourceCode.PackageDiscounts.Select(packageDiscount => new SourceCodeItemWiseDiscountViewModel
                                                    {
                                                        DiscountAmount = packageDiscount.DiscountAmount, 
                                                        DiscountValueType = packageDiscount.DiscountValueType, 
                                                        Name = packages.Where(p => p.Id == packageDiscount.Id).Single().Name
                                                    }).ToArray();

                    model.PackageDiscounts = packageDiscountViewModelCollection;
                }

                if (sourceCode.TestDiscounts != null)
                {
                    var testDiscountViewModelCollection = sourceCode.TestDiscounts.Select(testDiscount => new SourceCodeItemWiseDiscountViewModel
                    {
                        DiscountAmount = testDiscount.DiscountAmount,
                        DiscountValueType = testDiscount.DiscountValueType,
                        Name = tests.Where(t => t.Id == testDiscount.Id).Single().Name
                    }).ToArray();

                    model.TestDiscounts = testDiscountViewModelCollection;
                }

                if (sourceCode.ShippingDiscounts != null)
                {
                    var shippingDiscountViewModelCollection = sourceCode.ShippingDiscounts.Select(shippingDiscount => new SourceCodeItemWiseDiscountViewModel
                    {
                        DiscountAmount = shippingDiscount.DiscountAmount,
                        DiscountValueType = shippingDiscount.DiscountValueType,
                        Name = shippingOptions.Where(t => t.Id == shippingDiscount.Id).Single().Name
                    }).ToArray();

                    model.ShippingDiscounts = shippingDiscountViewModelCollection;
                }

                if (sourceCode.ProductDiscounts != null)
                {
                    var productDiscountViewModelCollection = sourceCode.ProductDiscounts.Select(productDiscount => new SourceCodeItemWiseDiscountViewModel
                    {
                        DiscountAmount = productDiscount.DiscountAmount,
                        DiscountValueType = productDiscount.DiscountValueType,
                        Name = products.Where(t => t.Id == productDiscount.Id).Single().Name
                    }).ToArray();

                    model.ProductDiscounts = productDiscountViewModelCollection;
                }

                sourceCodeViewModelCollection.Add(model);
            }

            listModel.SourceCodes = sourceCodeViewModelCollection;
            return listModel;
        }
    }
}