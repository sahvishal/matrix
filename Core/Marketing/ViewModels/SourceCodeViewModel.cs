using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.Enum;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class SourceCodeViewModel
    {
        public long Id { get; set; }
        public string CouponCode { get; set; }
        public decimal CouponValue { get; set; }
        public DiscountValueType DiscountValueType { get; set; }
        public DiscountType DiscountType { get; set; }
        public string CouponDescription { get; set; }
        
        [DisplayName("Start Date")]
        [Format("mm/dd/YYYY")]
        public DateTime ValidityStartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? ValidityEndDate { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<SourceCodeItemWiseDiscountViewModel> PackageDiscounts { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscountViewModel> TestDiscounts { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscountViewModel> ProductDiscounts { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscountViewModel> ShippingDiscounts { get; set; }
    }
}