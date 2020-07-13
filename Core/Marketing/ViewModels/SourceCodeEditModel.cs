using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class SourceCodeEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long Id { get; set; }

        [DisplayName("Coupon Type")]
        public long SourceCodeTypeId { get; set; }

        public int CouponValueType { get; set; }

        [DisplayName("Coupon Code")]
        public string CouponCode { get; set; }

        [DisplayName("Discount")]
        public decimal CouponValue { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string CouponDescription { get; set; }

        [DisplayName("Minimum Purchase Amount")]
        public decimal? MinimumPurchaseAmount { get; set; }

        [DisplayName("Start Date")]
        [Format("mm/dd/YYYY")]
        public DateTime ValidityStartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? ValidityEndDate { get; set; }

        [DisplayName("Maximum Usage Count")]
        public int MaximumNumberTimesUsed { get; set; }

        public int CustomerType { get; set; }

        public IEnumerable<int> SelectedSignUpModes { get; set; }

        public IEnumerable<OrderedPair<int, string>> AllSignUpModes { get; set; }

        public IEnumerable<OrderedPair<long, string>> AllPackages { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscountEditModel> PackageDiscounts { get; set; }

        public IEnumerable<OrderedPair<long, string>> AllTests { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscountEditModel> TestDiscounts { get; set; }
        
        public IEnumerable<OrderedPair<long, string>> AllProducts { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscountEditModel> ProductDiscounts { get; set; }

        public IEnumerable<OrderedPair<long, string>> AllShippingOptions { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscountEditModel> ShippingDiscounts { get; set; }

        public IEnumerable<SourceCodeEventEditModel> Events { get; set; }
    }
}
