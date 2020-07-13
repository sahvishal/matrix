using System.ComponentModel;

namespace Falcon.App.Core.Marketing.Enum
{
    public enum DiscountType
    {
        [Description("Applicable on the whole order")]
        PerOrder = 1,
        [Description("Applicable only on the package or test")]
        PerPackage = 2,
        [Description("Applicable on add-on products")]
        PerProduct = 3,
        [Description("Applicable only on the Shipping")]
        PerShipping = 4
    }
}