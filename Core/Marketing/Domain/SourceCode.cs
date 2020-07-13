using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Marketing.Domain
{
    public class SourceCode : DomainObjectBase
    {
        //if discount is directly associated with the source and not on per package basic
        public DiscountValueType DiscountValueType { get; set; }

        public DiscountType DiscountType { get; set; }

        public decimal CouponValue { get; set; }

        public string CouponCode { get; set; }

        public string CouponDescription { get; set; }
        
        public decimal? MinimumPurchaseAmount { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public DateTime? ValidityEndDate { get; set; }

        public int MaximumNumberTimesUsed { get; set; }

        public CustomerType CustomerType { get; set; }

        public IEnumerable<SignUpMode> SelectedSignUpModes { get; set; }

        public IEnumerable<SourceCodeItemWiseDiscount> TestDiscounts { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscount> ProductDiscounts { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscount> ShippingDiscounts { get; set; }
        public IEnumerable<SourceCodeItemWiseDiscount> PackageDiscounts { get; set; }

        public IEnumerable<long> EventIds { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public bool IsActive { get; set; }

        public SourceCode()
        {
            InitValues();
        }

        public SourceCode(long id)
            : base(id)
        {
            InitValues();
        }

        private void InitValues()
        {
            ValidityStartDate = DateTime.Now;
            CouponDescription = "";
        }


        //TODO need to check this, if package specific code then what will happen.
        public decimal CalculateDiscount(decimal undiscountedPrice)
        {
            return Calculate(undiscountedPrice,CouponValue,DiscountValueType);
        }

        private static decimal Calculate(decimal undiscountedPrice, decimal value, DiscountValueType discountValueType)
        {
            if (discountValueType == DiscountValueType.Percent)
            {
                return (undiscountedPrice * (value / 100));
            }
            return value;
        }

        public decimal CalculateDiscount(decimal undiscountedPrice, long packageId)
        {
            if (PackageDiscounts == null)
                return 0m;

            var packageDiscount = PackageDiscounts.SingleOrDefault(pd => pd.Id == packageId);

            if (packageDiscount == null)
                return 0m;

            return Calculate(undiscountedPrice, packageDiscount.DiscountAmount, packageDiscount.DiscountValueType);      
        }


    }
}